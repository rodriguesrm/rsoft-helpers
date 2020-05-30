using FluentAssertions;
using System;
using System.Globalization;
using Xunit;
using hlp = RR.Helpers.Tools;

namespace RR.Helpers.Test.ToolTests
{

    /// <summary>
    /// Cast helper tests
    /// </summary>
    public class CastTest
    {
       
        /// <summary>
        /// Try convert fail test
        /// </summary>
        [Fact]
        public void TryCastFailTest()
        {

            hlp.Cast.TryCast("A", out int _).Should().BeFalse();

            hlp.Cast.TryCast("A", out double _).Should().BeFalse();

            hlp.Cast.TryCast("A", out DateTime _).Should().BeFalse();
            hlp.Cast.TryCast("19761113", out DateTime _).Should().BeFalse();
            hlp.Cast.TryCast("13111976", out DateTime _).Should().BeFalse();
            hlp.Cast.TryCast("13/11/1976", out DateTime _).Should().BeFalse();
            hlp.Cast.TryCast("13-11-1976", out DateTime _).Should().BeFalse();

        }

        /// <summary>
        /// Try convert sucessful test
        /// </summary>
        [Fact]
        public void TryCastSucessfulTest()
        {

            

            hlp.Cast.TryCast("1", out int outInt).Should().BeTrue();
            outInt.Equals(1).Should().BeTrue();

            hlp.Cast.TryCast("2.5", out double outDouble).Should().BeTrue();
            outDouble.Equals(2.5D).Should().BeTrue();

            DateTime check = new DateTime(1976, 11, 13);
            hlp.Cast.TryCast("11/13/1976", out DateTime outDate1).Should().BeTrue();
            outDate1.Equals(check).Should().BeTrue();

            hlp.Cast.TryCast("1976-11-13", out DateTime outDate3).Should().BeTrue();
            outDate3.Equals(check).Should().BeTrue();

            hlp.Cast.TryCast("11-13-1976", out DateTime outDate4).Should().BeTrue();
            outDate4.Equals(check).Should().BeTrue();

            hlp.Cast.TryCast("13/11/1976", out DateTime outDate2, CultureInfo.CreateSpecificCulture("pt-BR")).Should().BeTrue();
            outDate2.Equals(check).Should().BeTrue();

        }

    }

}