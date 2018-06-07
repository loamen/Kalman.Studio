using System;
using System.Collections.Generic;

namespace Kalman.Utilities
{
	/// <summary>
	/// 农历日期结构。
	/// </summary>
	/// <remarks>
	/// 本结构采用词典法实现：有效区间：1901年1月1日至2100年12月31日。
	/// </remarks>
	public struct LunarDateUtil
    {
        #region 嵌套类型

        /// <summary>
        /// 处理跨年的翻转日
        /// </summary>
        sealed class IndependentReversingDays
        {
            private List<int> _Days;

            private IndependentReversingDays()
            {
                _Days = new List<int>();
            }

            public void Add(int day)
            {
                int index = _Days.BinarySearch(day);
                index = ~index;
                _Days.Insert(index, day);
            }

            public int[] GetDays(int first, int last)
            {
                int index0 = _Days.BinarySearch(first);
                if (index0 < 0)
                {
                    index0 = ~index0;
                }
                int index1 = _Days.BinarySearch(last);
                if (index1 < 0)
                {
                    index1 = ~index1;
                }
                else
                {
                    index1++;
                }
                index1 -= index0;
                if (index1 > 0)
                {
                    int[] days = new int[index1];
                    _Days.CopyTo(index0, days, 0, index1);
                    _Days.RemoveRange(index0, index1);
                    return days;
                }
                return new int[0];
            }

            private static IndependentReversingDays _Current = new IndependentReversingDays();

            public static IndependentReversingDays Current
            {
                get
                {
                    return _Current;
                }
            }
        }

        /// <summary>
        /// 日期数组
        /// </summary>
        /// <remarks>
        /// 日期数组保存多个日期，通过优化的算法
        /// 快速计算日期所在的序号，以及每个序号对应的日期
        /// </remarks>
        abstract class DayArray
        {
            protected int _First, _Last;
            private int _Index;
            private byte[] _Days;

            protected DayArray(int year)
            {
                _Last = year * 365 + year / 4 - year / 100 + year / 400;
                _First = year - 1;
                _First = _First * 365 + _First / 4 - _First / 100 + _First / 400;
                _Last -= _First;
                int[] days = CreateDays(year);
                _Index = Array.BinarySearch<int>(days, 256);
                if (_Index < 0)
                {
                    _Index = ~_Index;
                }
                _Days = new byte[days.Length];
                for (int i = 0; i < days.Length; i++)
                {
                    if (days[i] < 256)
                    {
                        _Days[i] = (byte)days[i];
                    }
                    else
                    {
                        _Days[i] = (byte)(days[i] - 256);
                    }
                }
            }

            protected abstract int[] CreateDays(int year);

            public int IndexOf(DateTime day)
            {
                int days = GetDays(day) - _First;
                if (days >= 0 & days < _Last)
                {
                    int low = 0;
                    int high = _Days.Length - 1;
                    while (low <= high)
                    {
                        int index = (low + high) >> 1;
                        int v = _Days[index];
                        if (index >= _Index)
                        {
                            v += 256;
                        }
                        if (v == days)
                        {
                            return index;
                        }
                        if (v < days)
                        {
                            low = index + 1;
                        }
                        else
                        {
                            high = index - 1;
                        }
                    }
                    return ~low;
                }
                throw new ArgumentOutOfRangeException("day");
            }

            public int Length
            {
                get
                {
                    return _Days.Length;
                }
            }

            public DateTime this[int index]
            {
                get
                {
                    if (index >= 0 && index < Length)
                    {
                        int days = _Days[index];
                        if (index >= _Index)
                        {
                            days += 256;
                        }
                        return GetDateTime(_First + days);
                    }
                    throw new ArgumentOutOfRangeException("index");
                }
            }

            protected static DateTime GetDateTime(int days)
            {
                long ticks = days;
                ticks *= TicksPerDay;
                return new DateTime(ticks);
            }

            protected static int GetDays(DateTime date)
            {
                return GetDays(date.Date.Ticks);
            }

            protected static int GetDays(long ticks)
            {
                return (int)(ticks / TicksPerDay);
            }

            const long TicksPerDay = 0xc92a69c000L;
        }

        /// <summary>
        /// 节气日期数组
        /// </summary>
        sealed class SolarTeamDayArray : DayArray
        {
            public SolarTeamDayArray(int year) : base(year)
            {
            }

            protected override int[] CreateDays(int year)
            {
                int[] days = new int[24];
                long ticks0 = FirstSolarTeamDayTicks + TicksPerYear * (year - 1900);
                for (int i = 0; i < 24; i++)
                {
                    days[i] = GetDays(ticks0 + SolarTeamMinutes[i] * TicksPerMinute) - _First;
                }
                return days;
            }

            const long TicksPerYear = 0x11f0231a116b8L;
            const long TicksPerMinute = 0x23c34600L;
            static readonly long FirstSolarTeamDayTicks = (new DateTime(1900, 1, 6, 2, 5, 0)).Ticks;
            static readonly int[] SolarTeamMinutes = new int[] {
                0,      21208,  42467,  63836,  85337,  107014, 128867, 150921,
                173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033,
                353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
        }

        /// <summary>
        /// 工作日数组
        /// </summary>
        sealed class WorkingDayArray : DayArray
        {
            public WorkingDayArray(int year) : base(year)
            {
            }

            private void AddDays(List<int> days, ref int first, int length)
            {
                int len = length;
                if (len + first > _Last)
                {
                    len = _Last - first;
                }
                for (int i = 0; i < len; i++)
                {
                    days.Add(i + first);
                }
                first += len + 1;
            }

            #region 假日逻辑

            private DateTime GetSpringFestivalDay(int year)
            {
                return GetLunarDay(year, 1, 1);
            }

            private DateTime GetChingMingFestivalDay(int year)
            {
                return GetSolarTeamDay(year, 6);
            }

            private DateTime GetDragonBoadDay(int year)
            {
                return GetLunarDay(year, 5, 5);
            }

            private DateTime GetMidAutumnFestevalDay(int year)
            {
                return GetLunarDay(year, 8, 15);
            }

            private void ReverseDay(List<int> days, int day)
            {
                if (day < 0 || day >= _Last)
                {
                    IndependentReversingDays.Current.Add(_First + day);
                }
                else
                {
                    int index = days.BinarySearch(day);
                    if (index >= 0)
                    {
                        days.RemoveAt(index);
                    }
                    else
                    {
                        days.Insert(~index, day);
                    }
                }
            }

            private void ReverseDay(List<int> days, DateTime day)
            {
                ReverseDay(days, GetDays(day) - _First);
            }

            private void ReverseDays(List<int> days, DateTime day, params int[] deltas)
            {
                int days0 = GetDays(day) - _First;
                ReverseDay(days, days0);
                if (deltas == null)
                {
                    return;
                }
                if (deltas.Length == 0)
                {
                    return;
                }
                foreach (int delta in deltas)
                {
                    ReverseDay(days, days0 + delta);
                }
            }

            private void AddSequentialHoliday(List<int> days, DateTime day)
            {
                switch (day.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        // 周日，移到周一
                        ReverseDay(days, day.AddDays(1));
                        break;
                    case DayOfWeek.Tuesday:
                        // 周二，向前靠
                        ReverseDays(days, day, -1, -2);
                        break;
                    case DayOfWeek.Wednesday:
                        // 周三，向后靠
                        ReverseDays(days, day, 1, 2, 3, 4);
                        break;
                    case DayOfWeek.Thursday:
                        // 周四，向后靠
                        ReverseDays(days, day, 1, 3);
                        break;
                    case DayOfWeek.Saturday:
                        // 周六，移动周一
                        ReverseDay(days, day.AddDays(2));
                        break;
                    default:
                        // 周一、周五，直接翻转
                        ReverseDay(days, day);
                        break;
                }
            }

            private void AddGoldenweek(List<int> days, DateTime firstDay, bool springFestival)
            {
                switch (firstDay.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        // 周日，移到周一
                        ReverseDays(days, firstDay.AddDays(-1), 2, 3, 4, 5, 6, 8);
                        break;
                    case DayOfWeek.Monday:
                        // 周一，直接翻转
                        ReverseDays(days, firstDay.AddDays(-2), 1, 2, 3, 4, 5, 6);
                        break;
                    case DayOfWeek.Tuesday:
                        // 周二，向前靠
                        if (springFestival)
                        {
                            ReverseDays(days, firstDay.AddDays(-3), 1, 3, 4, 5, 6, 9);
                        }
                        else
                        {
                            ReverseDays(days, firstDay.AddDays(-3), 1, 2, 3, 4, 5, 6);
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        // 周三，向后靠
                        if (springFestival)
                        {
                            ReverseDays(days, firstDay.AddDays(-4), 1, 4, 5, 6, 9, 10);
                        }
                        else
                        {
                            ReverseDays(days, firstDay.AddDays(-4), 1, 2, 3, 4, 5, 6);
                        }
                        break;
                    case DayOfWeek.Thursday:
                        // 周四，向后靠
                        ReverseDays(days, firstDay, 1, 4, 5, 6, 9, 10);
                        break;
                    case DayOfWeek.Friday:
                        // 周五，直接翻转
                        ReverseDays(days, firstDay, 3, 4, 5, 6, 8, 9);
                        break;
                    case DayOfWeek.Saturday:
                        // 周六，移动周一
                        ReverseDays(days, firstDay.AddDays(2), 1, 2, 3, 4);
                        break;
                }
            }

            #endregion

            private DateTime GetSolarTeamDay(int year, int index)
            {
                DayArray days = GetSolarTeamDays(year);
                return days[index];
            }

            private DateTime GetLunarDay(int year, int month, int day)
            {
                LunarDateUtil ldate = new LunarDateUtil(year, month, day, false);
                return ldate.Date;
            }

            protected override int[] CreateDays(int year)
            {
                List<int> days = new List<int>();
                int x = (_First + 1) % 7;
                int i = 0;
                while (i < _Last)
                {
                    if (x == 0)
                    {
                        i++;
                        AddDays(days, ref i, 5);
                    }
                    else if (x == 6)
                    {
                        i += 2;
                        x = 0;
                    }
                    else
                    {
                        AddDays(days, ref i, 6 - x);
                        x = 0;
                    }
                }
                #region 加入国家规定的调休
                AddSequentialHoliday(days, new DateTime(year, 1, 1));                   // 元旦连休
                AddGoldenweek(days, new DateTime(year, 10, 1), false);	                // 十一黄金周
                if (year < 2008)
                {
                    AddGoldenweek(days, GetSpringFestivalDay(year), true);		        // 春节黄金周
                    AddGoldenweek(days, new DateTime(year, 5, 1), false);	            // 五一黄金周
                }
                else
                {
                    AddGoldenweek(days, GetSpringFestivalDay(year).AddDays(-1), true);	// 春节黄金周
                    AddSequentialHoliday(days, new DateTime(year, 5, 1));               // 五一连休
                    AddSequentialHoliday(days, GetChingMingFestivalDay(year));          // 清明节连休
                    AddSequentialHoliday(days, GetDragonBoadDay(year));                 // 端午节连休
                    AddSequentialHoliday(days, GetMidAutumnFestevalDay(year));          // 中秋节连休
                }
                #endregion
                #region 加入周边年份的翻转日期
                foreach (int d in IndependentReversingDays.Current.GetDays(_First, _First + _Last - 1))
                {
                    ReverseDay(days, d - _First);
                }
                #endregion
                return days.ToArray();
            }
        }

        #endregion

        /// <summary>
        /// 按公历日期构造。
        /// </summary>
        /// <param name="date">公历日期。</param>
        public LunarDateUtil(DateTime date)
		{
			_Date = date.Date;
			_Year = 0;
			_Month = 0;
			_Day = 0;
			_IsLeap = false;
			DateChanged();
		}

		/// <summary>
		/// 按农历日期构造。
		/// </summary>
		/// <param name="year">农历年。</param>
		/// <param name="month">农历月。</param>
		/// <param name="day">农历日。</param>
		/// <param name="isLeap">是否农历闰月。</param>
		public LunarDateUtil(int year, int month, int day, bool isLeap)
		{
            _Date = DateTime.MinValue;
			_Year = year;
			_Month = month;
			_Day = day;
			_IsLeap = isLeap;
			LunarChanged();
		}

		private DateTime _Date;
		private int _Year, _Month, _Day;
		private bool _IsLeap;

		/// <summary>
		/// 公历日期变化，计算农历日期。
		/// </summary>
		private void DateChanged()
		{
			DateTime d0 = new DateTime(1900, 1, 31);
			if (_Date < d0 || _Date.Year > 2100)
			{
                throw new ArgumentOutOfRangeException("date");
			}
			TimeSpan ts = _Date - d0;
			int days = ts.Days + 1;
			int year = 1900;
			int t;
			while (days > (t = DaysOfLunarYear(year)))
			{
				days -= t;
				year ++;
			}
			int leap = LeapMonth(year);
			int month = 0;
			bool isLeap = false;
			bool nextLeap = false;
			do
			{
				if (!nextLeap)
				{
					month ++;
					nextLeap = month == leap;
					isLeap = false;
					t = DaysOfMonth(year, month);
				}
				else
				{
					isLeap = true;
					nextLeap = false;
					// 正好是闰月
					t = DaysOfLeapMonth(year);
				}
				if (days > t)
				{
					days -= t;
				}
				else
				{
					break;
				}
			} while (true);
			_Year = year;
			_Month = month;
			_Day = days;
			_IsLeap = isLeap;
		}

		/// <summary>
		/// 农历日期变化，计算公历日期。
		/// </summary>
		private void LunarChanged()
		{
			if (LunarIsValid())
			{
				int x = _Day - 1;
				// 农历年头到农历1900年1月1日间的天数
				for (int year = _Year - 1; year >= 1900; year --)
				{
					x += DaysOfLunarYear(year);
				}
				int month = 1;
				int leapMonth = LeapMonth(_Year);
				bool nextLeap = false;
				while (month < _Month)
				{
					if (month == leapMonth)
					{
						if (nextLeap)
						{
							nextLeap = false;
							x += DaysOfLeapMonth(_Year);
							month ++;
						}
						else
						{
							nextLeap = true;
							x += DaysOfMonth(_Year, month);
						}
					}
					else
					{
						x += DaysOfMonth(_Year, month);
						month ++;
					}
				}
				if (_IsLeap && leapMonth == _Month)
				{
					x += DaysOfMonth(_Year, _Month);
				}
				_Date = (new DateTime(1900, 1, 31)).AddDays(x);
			}
			else
			{
				_Date = DateTime.MinValue;
			}
		}

		/// <summary>
		/// 获取公历日期。
		/// </summary>
		public DateTime Date
		{
			get
			{
				return _Date;
			}
			set
			{
                if (_Date != value.Date)
                {
                    _Date = value;
                    DateChanged();
                }
			}
		}

		/// <summary>
		/// 获取农历年。
		/// </summary>
		public int Year
		{
			get
			{
				return _Year;
			}
		}

		/// <summary>
		/// 获取农历月。
		/// </summary>
		public int Month
		{
			get
			{
				return _Month;
			}
		}

		/// <summary>
		/// 获取农历日。
		/// </summary>
		public int Day
		{
			get
			{
				return _Day;
			}
		}

		/// <summary>
		/// 获取农历年名。
		/// </summary>
		public string YearName
		{
			get
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// 获取农历月名。
		/// </summary>
		public string MonthName
		{
			get
			{
				if (_Month > 0 && _Month <= 12)
				{
					return (_IsLeap ? "闰" : string.Empty) + ChMonths[_Month - 1] + "月";
				}
				return string.Empty;
			}
		}

		/// <summary>
		/// 获取农历日名。
		/// </summary>
		public string DayName
		{
			get
			{
				if (_Day == 20 || _Day == 30)
				{
					return ChDays[_Day / 10 - 1] + "十";
				}
				int day = _Day - 1;
				if (day >= 0 && day < 10)
				{
					return "初" + ChDays[day];
				}
				if (day >= 10 && day < 19)
				{
					return "十" + ChDays[day - 10];
				}
				if (day >= 20 && day < 30)
				{
					return "廿" + ChDays[day - 20];
				}
				return string.Empty;
			}
		}

		/// <summary>
		/// 获取节气名。
		/// </summary>
		/// <remarks>
		/// 如果当日无节气，则返回空串。
		/// </remarks>
		public string SolarName
		{
			get
			{
                DayArray dayArray = GetSolarTeamDays(this._Date.Year);
                int index = dayArray.IndexOf(this._Date);
				if (index >= 0)
				{
					return SolarTeamNames[index];
				}
				return string.Empty;
			}
		}

		/// <summary>
		/// 获取是否为公休日。
		/// </summary>
		/// <remarks>
		/// 公休日包括:每周六,每周日,元旦公休,春节黄金周,五一黄金周,国庆黄金周。<b></b>
		/// 计算黄金周时自动按最均匀补休算法处理,仅供参考。
		/// </remarks>
		public bool IsHoliday
		{
			get
			{
                DayArray dayArray = GetWorkingDays(this._Date.Year);
                return dayArray.IndexOf(_Date) < 0;
			}
		}

        /// <summary>
        /// 获取到指定日期的工作日天数。
        /// </summary>
        /// <param name="day">指定目标日期。</param>
        /// <returns>
        /// 返回从当前日期开始到指定目标日期间的工作日天数。
        /// 如果指定的目标日期则返回负数。</returns>
        public int GetWorkingDays(DateTime day)
        {
            return GetWorkingDays(_Date, day.Date);
        }

        /// <summary>
        /// 获取指定工作日后的日期。
        /// </summary>
        /// <param name="days">工作日数。</param>
        /// <returns>
        /// 获取指定工作日后的日期。
        /// 如果工作日数为负数，则返回指定工作日之前的日期。
        /// </returns>
        public DateTime GetWorkingDateAfter(int days)
        {
            return GetWorkingDayAfter(_Date, days);
        }

        /// <summary>
        /// 获取指定工作日前的日期。
        /// </summary>
        /// <param name="days">工作日数。</param>
        /// <returns>
        /// 获取指定工作日前的日期。
        /// 如果工作日数为负数，则返回指定工作日之后的日期。
        /// </returns>
        public DateTime GetWorkingDateBefore(int days)
        {
            return GetWorkingDayBefore(_Date, days);
        }

        /// <summary>
        /// 获取指定年月节气日期表。
        /// </summary>
        /// <param name="year">年。</param>
        /// <param name="month">月。</param>
        /// <returns>返回日期数集合。</returns>
        public static int[] GetSolarTeamDays(int year, int month)
        {
            DayArray dayArray = GetSolarTeamDays(year);
            DateTime d1 = dayArray[(month - 1) * 2];
            DateTime d2 = dayArray[(month - 1) * 2];
            return new int[] { d1.Day, d2.Day };
        }

		#region 内部算法
		
		static readonly Int32[] LunarInfos = new int[] {
            0x4bd8,0x4ae0,0xa570,0x54d5,0xd260,0xd950,0x5554,0x56af,0x9ad0,0x55d2,
            0x4ae0,0xa5b6,0xa4d0,0xd250,0xd295,0xb54f,0xd6a0,0xada2,0x95b0,0x4977,
            0x497f,0xa4b0,0xb4b5,0x6a50,0x6d40,0xab54,0x2b6f,0x9570,0x52f2,0x4970,
            0x6566,0xd4a0,0xea50,0x6a95,0x5adf,0x2b60,0x86e3,0x92ef,0xc8d7,0xc95f,
            0xd4a0,0xd8a6,0xb55f,0x56a0,0xa5b4,0x25df,0x92d0,0xd2b2,0xa950,0xb557,
            0x6ca0,0xb550,0x5355,0x4daf,0xa5b0,0x4573,0x52bf,0xa9a8,0xe950,0x6aa0,
            0xaea6,0xab50,0x4b60,0xaae4,0xa570,0x5260,0xf263,0xd950,0x5b57,0x56a0,
            0x96d0,0x4dd5,0x4ad0,0xa4d0,0xd4d4,0xd250,0xd558,0xb540,0xb6a0,0x95a6,
            0x95bf,0x49b0,0xa974,0xa4b0,0xb27a,0x6a50,0x6d40,0xaf46,0xab60,0x9570,
            0x4af5,0x4970,0x64b0,0x74a3,0xea50,0x6b58,0x5ac0,0xab60,0x96d5,0x92e0, //1999
            0xc960,0xd954,0xd4a0,0xda50,0x7552,0x56a0,0xabb7,0x25d0,0x92d0,0xcab5,
            0xa950,0xb4a0,0xbaa4,0xad50,0x55d9,0x4ba0,0xa5b0,0x5176,0x52bf,0xa930,
            0x7954,0x6aa0,0xad50,0x5b52,0x4b60,0xa6e6,0xa4e0,0xd260,0xea65,0xd530,
            0x5aa0,0x76a3,0x96d0,0x4afb,0x4ad0,0xa4d0,0xd0b6,0xd25f,0xd520,0xdd45,
            0xb5a0,0x56d0,0x55b2,0x49b0,0xa577,0xa4b0,0xaa50,0xb255,0x6d2f,0xada0,
            0x4b63,0x937f,0x49f8,0x4970,0x64b0,0x68a6,0xea5f,0x6b20,0xa6c4,0xaaef,
            0x92e0,0xd2e3,0xc960,0xd557,0xd4a0,0xda50,0x5d55,0x56a0,0xa6d0,0x55d4,
            0x52d0,0xa9b8,0xa950,0xb4a0,0xb6a6,0xad50,0x55a0,0xaba4,0xa5b0,0x52b0,
            0xb273,0x6930,0x7337,0x6aa0,0xad50,0x4b55,0x4b6f,0xa570,0x54e4,0xd260,
            0xe968,0xd520,0xdaa0,0x6aa6,0x56df,0x4ae0,0xa9d4,0xa4d0,0xd150,0xf252,
            0xd520};

        static readonly string[] SolarTeamNames = new string[] {
            "小寒","大寒","立春","雨水","惊蛰","春分","清明","谷雨",
            "立夏","小满","芒种","夏至","小暑","大暑","立秋","处暑",
            "白露","秋分","寒露","霜降","立冬","小雪","大雪","冬至"};
        static readonly string[] ChMonths = new string[] {
            "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "冬", "腊" };
        static readonly string[] ChDays = new string[] {
            "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };


        static readonly object _SolarTeamDayArraysLocker = new object();
        static readonly object _WorkingDayArraysLocker = new object();
        static readonly Dictionary<int, DayArray> _SolarTeamDayArrays = new Dictionary<int, DayArray>();
        static readonly Dictionary<int, DayArray> _WorkingDayArrays = new Dictionary<int, DayArray>();

        private static DayArray GetSolarTeamDays(int year)
		{
            lock (_SolarTeamDayArraysLocker)
			{
                if (_SolarTeamDayArrays.ContainsKey(year))
                {
                    return _SolarTeamDayArrays[year];
                }
                DayArray dayArray = new SolarTeamDayArray(year);
                _SolarTeamDayArrays.Add(year, dayArray);
                return dayArray;
            }
		}

        private static DayArray GetWorkingDays(int year)
        {
            lock (_WorkingDayArraysLocker)
            {
                if (_WorkingDayArrays.ContainsKey(year))
                {
                    return _WorkingDayArrays[year];
                }
                DayArray dayArray = new WorkingDayArray(year);
                _WorkingDayArrays.Add(year, dayArray);
                return dayArray;
            }
        }

		private bool LunarIsValid()
		{
			if (_Year > 2099 || _Year < 1901 || _Month > 12 || _Month < 1 || _Day > 30 || _Day < 1)
			{
				return false;
			}
			if (_IsLeap)
			{
				if (LeapMonth(_Year) == _Month)
				{
					return _Day <= DaysOfLeapMonth(_Year);
				}
				else
				{
					return false;
				}
			}
			return _Day <= DaysOfMonth(_Year, _Month);
		}

		private static int DaysOfLunarYear(int year)
		{
			int x = 348;
			int i = 0x8000;
			while (i > 8)
			{
				if ((LunarInfos[year - 1900] & i) > 0)
				{
					x ++;
				}
				i = i >> 1;
			}
			return x + DaysOfLeapMonth(year);
		}

		private static int DaysOfLeapMonth(int year)
		{
			if (LeapMonth(year) > 0)
			{
				if ((LunarInfos[year - 1899] & 0xf) == 0xf)
				{
					return 30;
				}
				else
				{
					return 29;
				}
			}
			return 0;
		}

		private static int LeapMonth(int year)
		{
			int x = LunarInfos[year - 1900] & 0xf;
			return x == 0xf ? 0: x;
		}

		private static int DaysOfMonth(int year, int month)
		{
			int x = LunarInfos[year - 1900];
			int i = 0x8000;
			if (month > 1)
			{
				i = 0x8000 >> (month - 1);
			}
			if ((x & i) > 0)
			{
				return 30;
			}
			return 29;
		}

        private static int GetNextYearWorkingDays(int radix, int year, DateTime day)
        {
            DayArray dayArray = GetWorkingDays(year);
            if (day.Year > year)
            {
                return GetNextYearWorkingDays(dayArray.Length + radix, year + 1, day);
            }
            int index = dayArray.IndexOf(day);
            if (index < 0)
            {
                index = ~index;
                return radix + index;
            }
            return radix + index + 1;
        }

        private static int GetWorkingDays(DateTime day1, DateTime day2)
        {
            if (day1 == day2)
            {
                return 0;
            }
            // 算以前的工作日数
            if (day2 < day1)
            {
                return - GetWorkingDays(day2, day1);
            }
            DayArray dayArray = GetWorkingDays(day1.Year);
            int index0 = dayArray.IndexOf(day1);
            if (index0 < 0)
            {
                index0 = ~index0;
            }
            // 跨年
            if (day2.Year > day1.Year)
            {
                return GetNextYearWorkingDays(dayArray.Length - index0 - 1, day1.Year + 1, day2);
            }
            // 当年
            int index1 = dayArray.IndexOf(day2);
            if (index1 < 0)
            {
                index1 = ~index1;
                index1--;
            }
            return index1 - index0;
        }

        private static DateTime GetWorkingDayAfter(DateTime day, int days)
        {
            if (days < 0)
            {
                return GetWorkingDayBefore(day, - days);
            }
            DayArray dayArray = GetWorkingDays(day.Year);
            int index = dayArray.IndexOf(day);
            if (index < 0)
            {
                index = ~index;
            }
            int remains = dayArray.Length - index;
            if (days >= remains)
            {
                // 合理假设：每年元月1日总是非工作日
                return GetWorkingDayAfter(new DateTime(day.Year + 1, 1, 1), days - remains);
            }
            return dayArray[index + days];
        }

        private static DateTime GetLastYearWorkingDay(int year, int days)
        {
            DayArray dayArray = GetWorkingDays(year);
            if (dayArray.Length - days > 0)
            {
                return dayArray[dayArray.Length - days - 1];
            }
            return GetLastYearWorkingDay(year - 1, days - dayArray.Length);
        }

        private static DateTime GetWorkingDayBefore(DateTime day, int days)
        {
            if (days < 0)
            {
                return GetWorkingDayAfter(day, - days);
            }
            DayArray dayArray = GetWorkingDays(day.Year);
            int index = dayArray.IndexOf(day);
            if (index > 0)
            {
                if (index - days >= 0)
                {
                    return dayArray[index - days];
                }
                return GetLastYearWorkingDay(day.Year - 1, days - index - 1);//xiaoguohua:return GetLastYearWorkingDay(day.Year - 1, days - index)
            }
            index = ~index;
            if (index == 0)
            {
                return GetLastYearWorkingDay(day.Year - 1, days);
            }
            index --;
            if (index - days >= 0)
            {
                return dayArray[index - days];
            }
            return GetLastYearWorkingDay(day.Year - 1, days - index-1);
        }

		#endregion
	}
}
