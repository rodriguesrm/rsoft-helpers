using Xunit;
using ht = RR.Helpers.Tools.Email;

namespace RR.Helpers.Test.ToolTests
{

    /// <summary>
    /// Email helpers tests
    /// </summary>
    public class EmailTest
    {

        /// <summary>
        /// login extract test
        /// </summary>
        /// <param name="emailAddress">E-mail address</param>
        /// <param name="check">check for test</param>
        [Theory]
        [InlineData("john.diggle", "john.diggle")]
        [InlineData("john.diggle@arrowverse", "john.diggle")]
        [InlineData("john.diggle@arrowverse.tv", "john.diggle")]
        public void ExtractLoginTest(string emailAddress, string check)
            => Assert.Equal(check, ht.Login(emailAddress));

        /// <summary>
        /// Teste de extração de dominio do e-mail
        /// </summary>
        /// <param name="emailAddress">E-mail address</param>
        /// <param name="check">check for test</param>
        [Theory]
        [InlineData("john.diggle", "john.diggle")]
        [InlineData("john.diggle@arrowverse", "arrowverse")]
        [InlineData("john.diggle@arrowverse.tv", "arrowverse.tv")]
        public void ExtractDomainTest(string emailAddress, string check)
            => Assert.Equal(check, ht.Domain(emailAddress));

    }

}
