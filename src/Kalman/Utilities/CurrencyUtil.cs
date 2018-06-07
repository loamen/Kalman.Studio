using System;

namespace Kalman.Utilities
{
	/// <summary>
	/// 金额结构。
	/// </summary>
	/// <remarks>
	/// 正确填写票据和结算凭证的基本规定
	/// <br></br>
	/// 银行、单位和个人填写的各种票据和结算凭证是办理支付结算和现金收付的重要依据，
	/// 直接关系到支付结算的准确、及时和安全。票据和结算凭证是银行、单位和个人凭以记载账
	/// 务的会计凭证，是记载经济业务和明确经济责任的一种书面证明。因此，填写票据和结算凭
	/// 证，必须做到标准化、规范化，要要素齐全、数字正确、字迹清晰、不错漏、不潦草，防止
	/// 涂改。
	/// <br></br>
	/// 一、中文大写金额数字应用正楷或行书填写，如壹（壹）、贰（贰）、叁、肆（肆）、
	/// 伍（伍）、陆（陆）、柒、捌、玖、拾、佰、仟、万（万）、亿、元、角、分、零、整（
	/// 正）等字样。不得用一、二（两）、三、四、五、六、七、八、九、十、念、毛、另（或0）
	/// 填写，不得自造简化字。如果金额数字书写中使用繁体字，如貳、陸、億、萬、圓的，也
	/// 应受理。
	/// <br></br>
	/// 二、中文大写金额数字到“元”为止的，在“元”之后，应写“整”（或“正”）字，
	/// 在“角”之后可以不写“整”（或“正”）字。大写金额数字有“分”的，“分”后面不
	/// 写“整”（或“正”）字。
	/// <br></br>
	/// 三、中文大写金额数字前应标明“人民币”字样，大写金额数字应紧接“人民币”字
	/// 样填写，不得留有空白。大写金额数字前未印“人民币”字样的，应加填“人民币”三字。
	/// 在票据和结算凭证大写金额栏内不得预印固定的“仟、佰、拾、万、仟、伯、拾、元、角、
	/// 分”字样。
	/// <br></br>
	/// 四、阿拉伯小写金额数字中有“0”时，中文大写应按照汉语语言规律、金额数字构
	/// 成和防止涂改的要求进行书写。举例如下：
	/// <br></br>
	/// （一）阿拉伯数字中间有“O”时，中文大写金额要写“零”字。如￥1，409．50，
	/// 应写成人民币壹仟肆佰零玖元伍角。
	/// <br></br>
	/// （二）阿拉伯数字中间连续有几个“0”时，中文大写金额中间可以只写一个“零”
	/// 字。如￥6，007．14，应写成人民币陆仟零柒元壹角肆分。
	/// <br></br>
	/// （三）阿拉伯金额数字万位或元位是“0”，或者数字中间连续有几个“0”，万位、
	/// 元位也是“0’，但千位、角位不是“0”时，中文大写金额中可以只写一个零字，也可
	/// 以不写“零”字。如￥1，680．32，应写成人民币壹仟陆佰捌拾元零叁角贰分，或者写
	/// 成人民币壹仟陆佰捌拾元叁角贰分；又如￥107，000．53，应写成人民币壹拾万柒仟元
	/// 零伍角叁分，或者写成人民币壹拾万零柒仟元伍角叁分。
	/// <br></br>
	/// （四）阿拉伯金额数字角位是“0”，而分位不是“0”时，中文大写金额“元”后
	/// 面应写“零”字。如￥16，409.02，应写成人民币壹万陆仟肆佰零玖元零贰分；又如
	/// ￥325．04，应写成人民币叁佰贰拾伍元零肆分。
	/// <br></br>
	/// 五、阿拉伯小写金额数字前面，均应填写入民币符号“￥”（或草写：）。阿拉伯
	/// 小写金额数字要认真填写，不得连写分辨不清。
	/// <br></br>
	/// 六、票据的出票日期必须使用中文大写。为防止变造票据的出禀日期，在填写月、
	/// 日时，月为壹、贰和壹拾的，日为壹至玖和壹拾、贰拾和叁抬的，应在其前加“零”；
	/// 日为抬壹至拾玖的，应在其前加“壹”。如1月15日，应写成零壹月壹拾伍日。再如
	/// 10月20日，应写成零壹拾月零贰拾日。
	/// <br></br>
	/// 七、票据出票日期使用小写填写的，银行不予受理。大写日期未按要求规范填写的，
	/// 银行可予受理，但由此造成损失的，由出票入自行承担。
	/// <br></br>
	/// 本算法遵守以上正确填写票据和结算凭证的基本规定，但尽可能短，即：可以不写“零”的地方一律不写“零”
	/// <br></br>
	/// 考虑到有可能“人民币”字样已印在纸样上，本函数的返回结果中将不出现
	/// </remarks>
	public class CurrencyUtil
	{
		/// <summary>
		/// 用金额值构造金额结构。
		/// </summary>
		/// <param name="currency">货币金额值。</param>
        public CurrencyUtil(double currency)
		{
			_Value = currency;
		}

		private double _Value;

		/// <summary>
		/// 获取当前金额结构的金额值。
		/// </summary>
		public double Value
		{
			get
			{
				return _Value;
			}
		}

		/// <summary>
		/// 获取大写金额字符串。
		/// </summary>
		/// <returns>返回大写货币金额字符串。</returns>
		public override string ToString()
		{
			return _Value.ToString ("C");
		}

		private static char[] ChineseNumber = new char[] {'零', '壹', '贰', '叁', '肆', '伍', '陆', '柒', '捌', '玖'};
		private static char[] ChinesePower  = new char[] {'拾', '佰', '仟'};

		/// <summary>
		/// 获取中文大写金额。
		/// </summary>
		/// <returns>返回金额大写串。</returns>
		public string ToChineseCurrencyString()
		{
			double value = _Value;
			if (value < 0)
			{
				value = - value;
			}
			int[] x = new int[5];
			string[] s = new string[5];
			bool[] b = new bool[5];
			bool bl;
			double v = Math.Floor(value);
			x[4] = (int) Math.Round((value - v) * 100);
			int i = 3;
			double v1;
			while (v > 0 && i >= 0)
			{
				v1 = Math.Floor(v / 10000) * 10000;
				x[i] = (int) Math.Round(v - v1);
				i --;
				v = v1 / 10000;
			}
			// 先计算整数部分每节的串
			for (i = 0; i < 4; i++)
			{
				s[i] = "";
				if (x[i] > 0)
				{
					b[i] = false;
					int p = 1000;
					bool bk = false;			// 前位为零
					bl = false;					// 未记录过
					for (int j = 0; j < 4; j ++)
					{
						int n = x[i] / p;		// 当前位
						x[i] -= n * p;			// 剩余位
						p /= 10;				// 幂
						if (n == 0)				// 当前位为零
						{
							if (j == 0)
							{
								b[i] = true;	// 如果是最高位
							}
							else
							{
								if (bl)			// 如果未记录过
								{
									bk = true;
								}
							}
						}
						else
						{
							if (bk)
							{
								s[i] += "零";
							}
							bl = true;
							s[i] += ChineseNumber[n];
							if (j < 3)
							{
								s[i] += ChinesePower[2 - j];
							}
							bk = false;
						}
					}
				}
			}
			// 小数部分
			bl = false;
			if (x[4] % 10 > 0)
			{
				s[4] = ChineseNumber[x[4] % 10] + "分";
			}
			else
			{
				bl = true;
				s[4] = "";
			}
			x[4] /= 10;
			if (x[4] > 0)
			{
				s[4] = ChineseNumber[x[4] % 10] + "角" + s[4];
				b[4] = false;
			}
			else
			{
				b[4] = !bl;
			}
			// 合并整数串
			string sv = "";
			bl = false;
			for (i = 0; i < 4; i++)
			{
				if (s[i].Length > 0)
				{
					if (bl && b[i])
					{
						sv += "零";
					}
					sv += s[i];
					switch (i)
					{
						case 0:
						case 2:
							sv += "万";
							break;
						case 1:
							sv += "亿";
							break;
						case 3:
							sv += "元";
							break;
					}
					bl = true;
				}
				else
				{
					if (bl)
					{
						switch (i)
						{
							case 1:
								sv += "亿";
								break;
							case 3:
								sv += "元";
								break;
						}
					}
				}
			}
			// 合并小数串
			if (s[4].Length == 0)
			{
				if (!bl)
				{
					sv = "零元";
				}
				sv += "整";
			}
			else
			{
				if (b[4] && bl)
				{
					sv += "零";
				}
				sv += s[4];
			}
			return sv;
		}

		/// <summary>
		/// 获取指定金额值的中文大写金额。
		/// </summary>
		/// <param name="value">金额。</param>
		/// <returns>返回金额大写。</returns>
		public static string ToChineseCurrencyString(double value)
		{
			CurrencyUtil currency = new CurrencyUtil(value);
			return currency.ToChineseCurrencyString();
		}

        public static string ToChineseCurrencyString(string value)
        {
            return ToChineseCurrencyString((double.Parse(value)));
        }
	}
}
