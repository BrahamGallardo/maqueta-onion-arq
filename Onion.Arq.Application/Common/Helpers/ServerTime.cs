using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Arq.Application.Common.Helpers
{
    public class ServerTime
    {
        public ServerTime() { }
        public static DateTime GetServerTimeCAT() => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Alaskan Standard Time")); //CAT
        public static DateTime GetServerTimePST() => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")); //PST
        public static DateTime GetServerTimeMST()
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
        public static DateTime GetServerTimeCst()
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
        public static DateTime GetServerTimeEST()
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        public static DateTime GetServerTimeAST()
        {
            return GetServerTimeCst().IsDaylightSavingTime() ? GetServerTimeCst().AddHours(-1) : GetServerTimeCst().AddHours(-2); //AST
        }
        public static DateTime GetServerTimeARZ()
        {
            return GetServerTimeCst().IsDaylightSavingTime() ? GetServerTimeCst().AddHours(2) : GetServerTimeCst().AddHours(1); //ARZ
        }
        public static DateTime GetServerTimeHST()
        {
            return GetServerTimeCst().IsDaylightSavingTime() ? GetServerTimeCst().AddHours(5) : GetServerTimeCst().AddHours(4); //HST
        }

    }
}
