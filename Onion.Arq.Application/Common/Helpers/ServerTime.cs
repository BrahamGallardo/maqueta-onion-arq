namespace Onion.Arq.Application.Common.Helpers
{
    public class ServerTime
    {
        public ServerTime() { }
        public static DateTime GetServerTimeCAT() => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Alaskan Standard Time")); //CAT
        public static DateTime GetServerTimePST() => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")); //PST
        public static DateTime GetServerTimeMST()
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
        public static DateTime GetServerTimeCST()
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
        public static DateTime GetServerTimeEST()
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        public static DateTime GetServerTimeAST()
        {
            return GetServerTimeCST().IsDaylightSavingTime() ? GetServerTimeCST().AddHours(-1) : GetServerTimeCST().AddHours(-2); //AST
        }
        public static DateTime GetServerTimeARZ()
        {
            return GetServerTimeCST().IsDaylightSavingTime() ? GetServerTimeCST().AddHours(2) : GetServerTimeCST().AddHours(1); //ARZ
        }
        public static DateTime GetServerTimeHST()
        {
            return GetServerTimeCST().IsDaylightSavingTime() ? GetServerTimeCST().AddHours(5) : GetServerTimeCST().AddHours(4); //HST
        }

    }
}
