using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.ComponentModel;

namespace Kalman.Net
{
    public class MXLookUp
    {        
        [DllImport("dnsapi", EntryPoint="DnsQuery_W", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
        private static extern int DnsQuery([MarshalAs(UnmanagedType.VBByRefStr)]ref string pszName, QueryTypes wType, QueryOptions options, int aipServers, ref IntPtr ppQueryResults, int pReserved);

        [DllImport("dnsapi", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern void DnsRecordListFree(IntPtr pRecordList, int FreeType);

        /// <summary>
        /// 获取MX记录，如：mx0.qq.com,mx1.qq.com
        /// </summary>
        /// <param name="mailAddress">邮件地址或域名，如xxx@qq.com,qq.com</param>
        /// <returns>返回MX记录数组</returns>
        public static string[] GetMXRecords(string mailAddress)
        {					 
            IntPtr ResultsPointer = IntPtr.Zero;
			IntPtr MXPointer = IntPtr.Zero;
            MXStruct RecordStruct;		
            ArrayList QueryResults = new ArrayList();
            int QueryCode;
            string MXRecord;
            string Domain;

            Domain = mailAddress.Substring(mailAddress.IndexOf('@') + 1);

            try			
            {					
				QueryCode = MXLookUp.DnsQuery(ref Domain, QueryTypes.DNS_TYPE_MX, QueryOptions.DNS_QUERY_BYPASS_CACHE, 0, ref ResultsPointer, 0);
						
                if (QueryCode != 0)
				{
					if(QueryCode==9003)
					{
						QueryResults.Add("MX Record Not Found");
					}
					else
					{
						throw new Win32Exception(QueryCode);
					}
				}

				for (MXPointer = ResultsPointer; !MXPointer.Equals(IntPtr.Zero); MXPointer = RecordStruct.pNext)
				{
					RecordStruct = (MXStruct) Marshal.PtrToStructure(MXPointer, typeof(MXStruct));

					if (RecordStruct.wType == 15)
					{
						MXRecord = Marshal.PtrToStringAuto(RecordStruct.pNameExchange);
						QueryResults.Add(MXRecord);
					}
				}
			}
			finally
			{
				MXLookUp.DnsRecordListFree(ResultsPointer, 0);
			}
				
            return (string[]) QueryResults.ToArray(typeof(string));
		}

		private enum QueryOptions
        {         
            DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE = 1,
            DNS_QUERY_BYPASS_CACHE = 8,
            DNS_QUERY_DONT_RESET_TTL_VALUES = 0x100000,
            DNS_QUERY_NO_HOSTS_FILE = 0x40,
            DNS_QUERY_NO_LOCAL_NAME = 0x20,
            DNS_QUERY_NO_NETBT = 0x80,
            DNS_QUERY_NO_RECURSION = 4,
            DNS_QUERY_NO_WIRE_QUERY = 0x10,
            DNS_QUERY_RESERVED = -16777216,
            DNS_QUERY_RETURN_MESSAGE = 0x200,
            DNS_QUERY_STANDARD = 0,
            DNS_QUERY_TREAT_AS_FQDN = 0x1000,
            DNS_QUERY_USE_TCP_ONLY = 2,
            DNS_QUERY_WIRE_ONLY = 0x100
        }

        private enum QueryTypes
        {
           DNS_TYPE_MX = 15
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MXStruct
        {
            public IntPtr pNext;
            public string pName;
            public short wType;
            public short wDataLength;
            public int flags;
            public int dwTtl;
            public int dwReserved;
            public IntPtr pNameExchange;
            public short wPreference;
            public short Pad;
        }
    }
}

