using System;

namespace AntFood.Framework.Helpers 
{
    public static class DateTimeHelpers
    {
        public static DateTime GetTodayUtcTime()
        {
            return DateTime.Today.ToUniversalTime();
        }
    }
}
