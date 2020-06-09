using Xunit;
using System.Collections.Generic;
using RSoft.Helpers.Validations;
using System.Xml.Schema;

namespace RSoft.Helpers.Test.Validations
{
    
    /// <summary>
    /// Credit card validation helpers test
    /// </summary>
    public class CreditCardTest
    {

        #region Static methods

        /// <summary>
        /// Fake cpf and valid result flag generator
        /// </summary>
        public static IEnumerable<object[]> CreditCardMaker()
        {

            IList<object[]> result = new List<object[]>
            {

                new object[] { "RSOFT", false },
                
                new object[] { "34000000", false },
                new object[] { "37000000", false },

                new object[] { "30000000", false },
                new object[] { "30100000", false },
                new object[] { "30200000", false },
                new object[] { "30300000", false },
                new object[] { "30400000", false },
                new object[] { "30500000", false },

                new object[] { "36000000", false },

                new object[] { "54000000", false },

                new object[] { "16000000", false },
                new object[] { "65000000", false },

                new object[] { "64400000", false },
                new object[] { "64500000", false },
                new object[] { "64600000", false },
                new object[] { "64700000", false },
                new object[] { "64800000", false },
                new object[] { "64900000", false },
                new object[] { "60110000", false },

                new object[] { "62212500", false },
                new object[] { "62292600", false },

                new object[] { "63700000", false },
                new object[] { "63800000", false },
                new object[] { "63900000", false },

                new object[] { "35280000", false },
                new object[] { "35890000", false },

                new object[] { "63040000", false },
                new object[] { "67060000", false },
                new object[] { "67710000", false },
                new object[] { "67090000", false },
                                                 
                new object[] { "50180000", false },
                new object[] { "50200000", false },
                new object[] { "50380000", false },
                new object[] { "58930000", false },
                new object[] { "63040000", false },
                new object[] { "67590000", false },
                new object[] { "67610000", false },
                new object[] { "67620000", false },
                new object[] { "67630000", false },

                new object[] { "51000000", false },
                new object[] { "52000000", false },
                new object[] { "53000000", false },
                new object[] { "54000000", false },
                new object[] { "55000000", false },

                new object[] { "40260000", false },
                new object[] { "45080000", false },
                new object[] { "48440000", false },
                new object[] { "49130000", false },
                new object[] { "49170000", false },

                new object[] { "40000000", false },

                new object[] { "5018000000000000000000", false },
                new object[] { "6304000000000000000000", false },

                new object[] { "00000000", false },

                new object[] { "5540178600731682", false },
                new object[] { "4916146408317417", false },
                new object[] { "347875977777653", false },
                new object[] { "30277999506428", false },
                new object[] { "6011367352717548", false },
                new object[] { "214989013442642", false },
                new object[] { "3543261305762830", false },
                new object[] { "869961172416434", false },
                new object[] { "6062821961640473", false },
                new object[] { "5094415645867027", false },
                new object[] { "4556737586899854", false },

                new object[] { "5540178600731681", true },
                new object[] { "4916146408317416", true },
                new object[] { "347875977777652", true },
                new object[] { "30277999506429", true },
                new object[] { "6011367352717547", true },
                new object[] { "214989013442641", true },
                new object[] { "3543261305762839", true },
                new object[] { "869961172416433", true },
                new object[] { "6062821961640472", true },
                new object[] { "5094415645867025", true },
                new object[] { "4556737586899855", true }
            };

            return result;

        }

        #endregion

        #region Tests

        /// <summary>
        /// Check credit card number
        /// </summary>
        /// <param name="number">Credit card number</param>
        /// <param name="valid">Indicates the expected result</param>
        [Theory]
        [MemberData(nameof(CreditCardMaker))]
        public void CheckBrasilianDocument(string number, bool valid)
            => Assert.Equal(valid, CreditCard.Check(number));

        /// <summary>
        /// Return false when credit card number is string on check brand
        /// </summary>
        [Fact]
        public void IsBrandFalseIfString()
            => Assert.False(CreditCard.IsBrand(CreditCard.CreditCardBrand.AmericanExpress, "ABC"));

        #endregion

    }
}
