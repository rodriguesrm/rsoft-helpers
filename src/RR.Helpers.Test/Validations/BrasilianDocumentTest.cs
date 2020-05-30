using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using vbd = RR.Helpers.Validations.BrasilianDocument;

namespace RR.Helpers.Test.Validations
{

    /// <summary>
    /// Brasilian documents validation helper tests
    /// </summary>
    public class BrasilianDocumentTest
    {

        #region Static methods

        /// <summary>
        /// Fake cpf and valid result flag generator
        /// </summary>
        public static IEnumerable<object[]> CpfFaker()
        {

            IList<object[]> result = new List<object[]>
            {

                new object[] { "16665432092", true },
                new object[] { "33833630744", true },
                new object[] { "77360078610", true },
                new object[] { "01789967180", true },
                new object[] { "51717134211", true },
                new object[] { "21433620480", true },
                new object[] { "44911343249", true },
                new object[] { "40481589295", true },
                new object[] { "44568568587", true },
                new object[] { "81423717317", true },
                new object[] { "77399746176", true },
                new object[] { "36356623721", true },
                new object[] { "44234699101", true },
                new object[] { "96325819381", true },
                new object[] { "55047225607", true },
                new object[] { "04198662134", true },
                new object[] { "82555528121", true },
                new object[] { "18082867400", true },
                new object[] { "48093872400", true },
                new object[] { "79472108377", true },
                new object[] { "85660893910", true },
                new object[] { "16684593705", true },
                new object[] { "75245475448", true },
                new object[] { "95389244010", true },
                new object[] { "54905161274", true },
                new object[] { "14163559280", true },
                new object[] { "93135605930", true },
                new object[] { "02327489504", true },
                new object[] { "59773836819", true },
                new object[] { "44806854131", true },

                new object[] { "", false },
                new object[] { "00000000000", false },
                new object[] { "11111111111", false },
                new object[] { "22222222222", false },
                new object[] { "33333333333", false },
                new object[] { "44444444444", false },
                new object[] { "55555555555", false },
                new object[] { "66666666666", false },
                new object[] { "77777777777", false },
                new object[] { "88888888888", false },
                new object[] { "99999999999", false },
                new object[] { "12345678901", false },
                new object[] { "1234", false },
                new object[] { "1234567890123", false },
                new object[] { "017889AB718", false },
                new object[] { "44806854151", false },
                new object[] { "44806854137", false }

            };

            return result;

        }

        /// <summary>
        /// Fake cnpj and valid result flag generator
        /// </summary>
        public static IEnumerable<object[]> CnpjFaker()
        {

            IList<object[]> result = new List<object[]>
            {

                new object[] { "21580534000104", true },
                new object[] { "78606195000105", true },
                new object[] { "32597259000158", true },
                new object[] { "90960600000194", true },
                new object[] { "98377633000118", true },
                new object[] { "77676726000173", true },
                new object[] { "11444777000161", true },
                new object[] { "07654344000163", true },
                new object[] { "80536038000112", true },
                new object[] { "15862875000170", true },

                new object[] { "", false },
                new object[] { "00000000000000", false },
                new object[] { "11111111111111", false },
                new object[] { "22222222222222", false },
                new object[] { "33333333333333", false },
                new object[] { "44444444444444", false },
                new object[] { "55555555555555", false },
                new object[] { "66666666666666", false },
                new object[] { "77777777777777", false },
                new object[] { "88888888888888", false },
                new object[] { "99999999999999", false },
                new object[] { "12345678901234", false },
                new object[] { "1234", false },
                new object[] { "123456789012356", false },
                new object[] { "017889AB718458", false },
                new object[] { "28338470000118", false }

            };

            return result;

        }


        #endregion

        #region Tests

        /// <summary>
        /// Test fail validate Cpf
        /// </summary>
        /// <param name="cpf">Cpf number</param>
        /// <param name="isSucess">Indicates the expected result</param>
        [Theory]
        [MemberData(nameof(CpfFaker))]
        public void CpfValidationTest(string cpf, bool isSucess)
            => vbd.CheckCpf(cpf).Should().Be(isSucess);

        /// <summary>
        /// Test fail validate Cnpj
        /// </summary>
        /// <param name="cnpj">Cnpj number</param>
        /// <param name="isSucess">Indicates the expected result</param>
        [Theory]
        [MemberData(nameof(CnpjFaker))]
        public void CnpjValidationTest(string cnpj, bool isSucess)
            => vbd.CheckCnpj(cnpj).Should().Be(isSucess);

        /// <summary>
        /// Check brasilian document test
        /// </summary>
        /// <param name="doc">Document number</param>
        /// <param name="isSucess">Indicates the expected result</param>
        [Theory]
        [InlineData("16665432092", true)]
        [InlineData("21580534000104", true)]
        [InlineData("123456", false)]
        public void CheckBrasilianDocument(string doc, bool isSucess)
            => vbd.CheckDocument(doc).Should().Be(isSucess);

        #endregion

    }

}