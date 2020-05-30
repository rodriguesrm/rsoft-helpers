using RR.Helpers.Tools;
using Xunit;

namespace RR.Helpers.Test.ToolTests
{

    /// <summary>
    /// Number and string tool helpers test
    /// </summary>
    public class NumberAndStringTest
    {

        #region Test

        /// <summary>
        /// Return only number for expression
        /// </summary>
        /// <param name="expression">Expression to clear</param>
        /// <param name="check">Expression result expected</param>
        [Theory]
        [InlineData("Nevaska4231", "4231")]
        [InlineData("ReverseFlash", "")]
        [InlineData("789456123", "789456123")]
        public void RemoveTextTest(string expression, string check)
        {
            string result = NumberAndString.RemoveText(expression);
            Assert.Equal(check, result);
        }

        /// <summary>
        /// Return expression withou 
        /// </summary>
        /// <param name="expression">Expression to clear</param>
        /// <param name="check">Expression result expected</param>
        [Theory]
        [InlineData("Caitlin 123 Snow", " ", "Caitlin  Snow")]
        [InlineData("12Caitlin@Snow34", "@", "Caitlin@Snow")]
        public void RemoveNumberTest(string expression, string exceptChars, string check)
        {
            string result = NumberAndString.RemoveNumbers(expression, exceptChars);
            Assert.Equal(check, result);
        }

        /// <summary>
        /// Return expression withou 
        /// </summary>
        /// <param name="expression">Expression to clear</param>
        /// <param name="check">Expression result expected</param>
        [Theory]
        [InlineData("Caitlin 123 Snow", "Caitlin  Snow")]
        [InlineData("12Caitlin@Snow34", "CaitlinSnow")]
        public void RemoveNumberKeepSapceTest(string expression, string check)
        {
            string result = NumberAndString.RemoveNumbers(expression, true);
            Assert.Equal(check, result);
        }

        /// <summary>
        /// Return expression withou 
        /// </summary>
        /// <param name="expression">Expression to clear</param>
        /// <param name="check">Expression result expected</param>
        [Theory]
        [InlineData("Caitlin 123 Snow", "CaitlinSnow")]
        [InlineData("12Caitlin@Snow34", "CaitlinSnow")]
        public void RemoveNumberNoKeepCharsTest(string expression, string check)
        {
            string result = NumberAndString.RemoveNumbers(expression);
            Assert.Equal(check, result);
        }

        #endregion

    }

}
