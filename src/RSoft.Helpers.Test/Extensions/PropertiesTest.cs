using RSoft.Helpers.Extesions;
using RSoft.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace RSoft.Helpers.Test.Extensions
{

    /// <summary>
    /// Reflection helpers test
    /// </summary>
    public class PropertiesTest
    {

        private AgeResult _age = new AgeResult(1976, 11, 13);

        /// <summary>
        /// Get property sucessuful test
        /// </summary>
        [Fact]
        public void GetPropValueTest()
        {
            object years = Properties.GetPropValue(_age, "Years");
            Assert.NotNull(years);
        }

        /// <summary>
        /// Get property applying specific type sucessful test
        /// </summary>
        [Fact]
        public void GetPropValueSpecificTypeTest()
        {
            int years = Properties.GetPropValue<int>(_age, "Years");
            Assert.Equal(_age.Years, years);
        }

        /// <summary>
        /// Get property applying specific type throw exception test
        /// </summary>
        [Fact]
        public void GetPropValueSpecificTypeThrowExceptionTest()
        {
            void action() => Properties.GetPropValue<short>(_age, "Years");
            InvalidCastException ex = Assert.Throws<InvalidCastException>(action);
            Assert.IsType<InvalidCastException>(ex);
        }

        [Fact]
        public void GetPropValueReturNull()
        {
            object checkObj;

            checkObj = Properties.GetPropValue(null, "PropertyNotExist");
            Assert.Null(checkObj);

            checkObj = Properties.GetPropValue(_age, string.Empty);
            Assert.Null(checkObj);

            int checkInt = Properties.GetPropValue<int>(_age, "PropertyNotExist");
            Assert.Equal(0, checkInt);
        }

    }

}
