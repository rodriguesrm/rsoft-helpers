using System;
using System.Globalization;
using Xunit;
using hlp = RSoft.Helpers.Tools;

namespace RSoft.Helpers.Test.ToolTests
{

    /// <summary>
    /// Cast helper tests
    /// </summary>
    public class CastTest
    {

        #region Static Methods

        //TODO: Implement generator to tests

        #endregion

        #region Tests

        /// <summary>
        /// Try convert fail test
        /// </summary>
        [Fact]
        public void TryCastFailTest()
        {

            Assert.False(hlp.Cast.TryCast("A", out int _));
            Assert.False(hlp.Cast.TryCast("A", out double _));
            Assert.False(hlp.Cast.TryCast("A", out DateTime _));
            Assert.False(hlp.Cast.TryCast("19761113", out DateTime _));
            Assert.False(hlp.Cast.TryCast("13111976", out DateTime _));
            Assert.False(hlp.Cast.TryCast("13/11/1976", out DateTime _));
            Assert.False(hlp.Cast.TryCast("13-11-1976", out DateTime _));

        }

        /// <summary>
        /// Try convert sucessful test
        /// </summary>
        [Fact]
        public void TryCastSucessfulTest()
        {



            Assert.True(hlp.Cast.TryCast("1", out int outInt));
            Assert.True(outInt.Equals(1));

            Assert.True(hlp.Cast.TryCast("2.5", out double outDouble));
            Assert.True(outDouble.Equals(2.5D));

            DateTime check = new DateTime(1976, 11, 13);
            Assert.True(hlp.Cast.TryCast("11/13/1976", out DateTime outDate1));
            Assert.True(outDate1.Equals(check));

            Assert.True(hlp.Cast.TryCast("1976-11-13", out DateTime outDate3));
            Assert.True(outDate3.Equals(check));

            Assert.True(hlp.Cast.TryCast("11-13-1976", out DateTime outDate4));
            Assert.True(outDate4.Equals(check));

            Assert.True(hlp.Cast.TryCast("13/11/1976", out DateTime outDate2, CultureInfo.CreateSpecificCulture("pt-BR")));
            Assert.True(outDate2.Equals(check));

        }

        #endregion

    }

}