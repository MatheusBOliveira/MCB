using System;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class DateTimeExtensionMethods
    {
        public static bool IsBetween(this DateTime dt, DateTime startDate, DateTime endDate)
        {
            return dt >= startDate && dt <= endDate;
        }
    }
}


