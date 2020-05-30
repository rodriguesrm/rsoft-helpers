using RR.Helpers.Models;
using System;

namespace RR.Helpers.Tools
{

    /// <summary>
    /// Date and time tool helpers
    /// </summary>
    public static class DateAndTime
    {

        /// <summary>
        /// Returns the last day in the specified month of a date
        /// </summary>
        /// <param name="data">Date to analyze</param>
        public static int LastDayInMonth(DateTime date)
            => DateTime.DaysInMonth(date.Year, date.Month);

        /// <summary>
        /// Calculate age based on date
        /// </summary>
        /// <param name="bornDate">Born date</param>
        public static AgeResult Age(DateTime bornDate)
            => Age(bornDate, DateTime.Now.Date);

        /// <summary>
        /// Calculate age based on date
        /// </summary>
        /// <param name="bornDate">Born date</param>
        /// <param name="date">Final date to calculate</param>
        public static AgeResult Age(DateTime bornDate, DateTime date)
        {

            date = date.Date;

            TimeSpan diff;

            // ---------------------------------------------------------------
            // Years
            // ---------------------------------------------------------------
            int years = 0;
            diff = date.Subtract(bornDate.Date);
            if (diff.Days > 365)
            {

                years = (date.Year - bornDate.Year);

                if (bornDate.Month > date.Month)
                    years--;
                else
                    if (bornDate.Month == date.Month)
                        if (bornDate.Day > date.Day)
                            years--;

            }

            // ---------------------------------------------------------------
            // Months
            // ---------------------------------------------------------------
            int months = date.Month - bornDate.Month;
            if (months <= 0)
            {
                if (months == 0)
                {
                    if (date.Day < bornDate.Day)
                        months = 11;
                }
                else
                {
                    months = (12 + months);
                }
            }
            else
            {
                if (date.Day < bornDate.Day)
                    months--;
            }

            // ---------------------------------------------------------------
            // Days
            // ---------------------------------------------------------------
            int days = date.Day - bornDate.Day;
            if (days < 0)
            {
                days = (30 + days);
            }

            AgeResult resultAge = new AgeResult(years, months, days);

            return resultAge;

        }

    }
}
