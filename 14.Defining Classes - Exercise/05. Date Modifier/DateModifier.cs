using System;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int DifferenceBetweenTwoDates(string startDateString, string endDateString)
        {
            DateTime startDate = DateTime.Parse(startDateString);
            DateTime endDate = DateTime.Parse(endDateString);

            TimeSpan timeSpan = endDate - startDate;

            return Math.Abs(timeSpan.Days);
        }
    }
}
