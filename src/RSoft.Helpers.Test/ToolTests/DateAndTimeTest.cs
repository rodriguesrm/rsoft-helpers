using Xunit;
using System;
using System.Collections.Generic;
using dt = RSoft.Helpers.Tools.DateAndTime;
using RSoft.Helpers.Models;

namespace RSoft.Helpers.Test.ToolTests
{

    /// <summary>
    /// Date and time tool helpers test
    /// </summary>
    public class DateAndTimeTest
    {

        #region Static methods

        /// <summary>
        /// Date generator for last kaey in month test
        /// </summary>
        public static IEnumerable<object[]> DateGenerator()
        {

            IList<object[]> result = new List<object[]>
            {


                new object[] { new DateTime(2019, 1, 1),  31, true },
                new object[] { new DateTime(2019, 2, 1),  28, true },
                new object[] { new DateTime(2019, 2, 1),  29, false },
                new object[] { new DateTime(2020, 2, 1),  29, true },
                new object[] { new DateTime(2019, 3, 1),  31, true },
                new object[] { new DateTime(2019, 4, 1),  30, true },
                new object[] { new DateTime(2019, 5, 1),  31, true },
                new object[] { new DateTime(2019, 6, 1),  30, true },
                new object[] { new DateTime(2019, 7, 1),  31, true },
                new object[] { new DateTime(2019, 8, 1),  31, true },
                new object[] { new DateTime(2019, 9, 1),  30, true },
                new object[] { new DateTime(2019, 10, 1), 31, true },
                new object[] { new DateTime(2019, 11, 1), 30, true },
                new object[] { new DateTime(2019, 12, 1), 31, true }

            };

            return result;

        }

        /// <summary>
        /// Date generator for age calculator test
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> DateForAgeGenerator()
        {

            IList<object[]> result = new List<object[]>()
            {
                new  object[] { new DateTime(1976, 11, 13), new DateTime(2019, 5, 7), 42, 6, 24 },
                new  object[] { new DateTime(2010, 9, 15), new DateTime(2019, 9, 10), 8, 11, 25 },
                new  object[] { new DateTime(2000, 9, 10), new DateTime(2019, 9, 15), 19, 0, 5 },
                new  object[] { new DateTime(2018, 5, 30), new DateTime(2020, 5, 20), 1, 11, 20 },
                new  object[] { new DateTime(2018, 5, 30), new DateTime(2020, 6, 20), 2, 0, 20 },
                new  object[] { new DateTime(2018, 5, 20), new DateTime(2020, 5, 21), 2, 0, 1 },
                new  object[] { new DateTime(2018, 5, 20), new DateTime(2019, 5, 19), 0, 11, 29 }
            };

            return result;

        }

        #endregion

        #region Tests

        /// <summary>
        /// This static method test
        /// </summary>
        [Fact]
        public void StaticMethodsTest()
        {
            Assert.NotNull(DateForAgeGenerator());
            Assert.NotNull(DateGenerator());
        }

        /// <summary>
        /// Last day in month test
        /// </summary>
        [Theory]
        [MemberData(nameof(DateGenerator))]
        public void LastDayInMonthTest(DateTime date, int checkDay, bool checkResult)
            => Assert.Equal(checkResult, dt.LastDayInMonth(date).Equals(checkDay));

        /// <summary>
        /// Age test in specific date
        /// </summary>
        [Theory]
        [MemberData(nameof(DateForAgeGenerator))]
        public void AgeTest(DateTime bornDate, DateTime finalDate, int years, int months, int days)
        {

            AgeResult age = dt.Age(bornDate, finalDate);

            Assert.Equal(years, age.Years);
            Assert.Equal(months, age.Months);
            Assert.Equal(days, age.Days);

        }

        /// <summary>
        /// Age test to today
        /// </summary>
        [Fact]
        public void AgeTestNow()
        {

            DateTime bornDate = new DateTime(1976, 11, 13);
            AgeResult check = dt.Age(bornDate, DateTime.Now.Date);
            AgeResult age = dt.Age(bornDate);

            Assert.Equal(check.Years, age.Years);
            Assert.Equal(check.Months, age.Months);
            Assert.Equal(check.Days, age.Days);

        }

        #endregion

    }

}
