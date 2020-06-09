using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RSoft.Helpers.Validations
{

    /// <summary>
    /// Provides methods for credit cards validation
    /// </summary>
    public static class CreditCard
    {

        /// <summary>
        /// Credit card brand enum
        /// </summary>
        [Flags]
        public enum CreditCardBrand
        {

            AmericanExpress = 1,
            DinersClubCarteBlanche = 2,
            DinersClubInternational = 3,
            DinersClubUSACanada = 4,
            Discover = 5,
            InstaPayment = 6,
            JCB = 7,
            Laser = 8,
            Maestro = 9,
            MasterCard = 10,
            Visa = 11,
            VisaElectron = 12
        }

        /// <summary>
        /// Check if credit card is specific brand
        /// </summary>
        /// <param name="brand">Brand enum value</param>
        /// <param name="number">Credit card number (only numbers, without mask)</param>
        /// <returns></returns>
        public static bool IsBrand(CreditCardBrand brand, string number)
        {

            if (!Regex.IsMatch(number, "^[0-9]*$"))
                return false;

            // American Express 
            if ((number.StartsWith("34") || number.StartsWith("37")) && brand == CreditCardBrand.AmericanExpress)
                return true;

            // Diners Club - Carte Blanche
            if ("300|301|302|303|304|305".Contains(number.Substring(0, 3)) && brand == CreditCardBrand.DinersClubCarteBlanche)
                return true;

            // Diners Club - International
            if (number.StartsWith("36") && brand == CreditCardBrand.DinersClubInternational)
                return true;

            // Diners Club - USA & Canada
            if (number.StartsWith("54") && brand == CreditCardBrand.DinersClubUSACanada)
                return true;

            // Discover                    
            int startSixPosition = int.Parse(number.Substring(0, 6));
            if
            (
                brand == CreditCardBrand.Discover && 
                (
                    "16|65".Contains(number.Substring(0, 2)) ||
                    "644|645|646|647|648|649".Contains(number.Substring(0, 3)) ||
                    number.Substring(0, 4) == "6011" ||
                    (startSixPosition >= 622126 && startSixPosition <= 622925)
                )
            )
            {
                return true;
            }

            // InstaPayment
            if ("637|638|639".Contains(number.Substring(0, 3)) && brand == CreditCardBrand.InstaPayment)
                return true;


            // JCB
            int startFourPosition = int.Parse(number.Substring(0, 4));
            if ((startFourPosition >= 3528 && startFourPosition <= 3589) && brand == CreditCardBrand.JCB)
                return true;

            // Laser
            if ("6304|6706|6771|6709".Contains(number.Substring(0, 4)) && brand == CreditCardBrand.Laser)
                return true;

            // Maestro
            if ("5018|5020|5038|5893|6304|6759|6761|6762|6763".Contains(number.Substring(0, 4)) && brand == CreditCardBrand.Maestro)
                return true;

            // MasterCard                  
            if ("51|52|53|54|55".Contains(number.Substring(0, 2)) && brand == CreditCardBrand.MasterCard)
                return true;

            // Visa Electron
            if (("4026|4508|4844|4913|4917".Contains(number.Substring(0, 4)) || number.StartsWith("417500")) && brand == CreditCardBrand.VisaElectron)
                return true;

            // Visa
            if (number.StartsWith("4") && brand == CreditCardBrand.Visa)
                return true;

            return false;

        }


        /// <summary>
        /// Check if credit card number is valid
        /// </summary>
        /// <param name="number">Credit card number (only numbers, without mask)</param>
        /// <returns></returns>
        public static bool Check(string number)
        {

            if (!Regex.IsMatch(number, "^[0-9]*$"))
                return false;

            // validate length
            // --------------------------------

            // American Express 
            if (IsBrand(CreditCardBrand.AmericanExpress, number) && number.Length != 15)
                return false;

            // Diners Club - Carte Blanche
            if (IsBrand(CreditCardBrand.DinersClubCarteBlanche, number) && number.Length != 14)
                return false;

            // Diners Club - International
            if (IsBrand(CreditCardBrand.DinersClubInternational, number) && number.Length != 14)
                return false;

            // Diners Club - USA & Canada
            if (IsBrand(CreditCardBrand.DinersClubUSACanada, number) && number.Length != 16)
                return false;

            // Discover
            if (IsBrand(CreditCardBrand.Discover, number) && number.Length != 16)
                return false;

            // InstaPayment
            if (IsBrand(CreditCardBrand.InstaPayment, number) && number.Length != 16)
                return false;

            // JCB
            if (IsBrand(CreditCardBrand.JCB, number) && number.Length != 16)
                return false;

            // Laser
            if (IsBrand(CreditCardBrand.Laser, number) && (number.Length < 16 || number.Length > 19))
                return false;

            // Maestro
            if (IsBrand(CreditCardBrand.Maestro, number) && (number.Length < 16 || number.Length > 19))
                return false;

            // MasterCard
            if (IsBrand(CreditCardBrand.MasterCard, number) && (number.Length < 16 || number.Length > 19))
                return false;

            // VisaElectron
            if (IsBrand(CreditCardBrand.VisaElectron, number) && number.Length != 16)
                return false;

            // Visa
            if (IsBrand(CreditCardBrand.Visa, number) && (number.Length < 13 || number.Length > 16))
                return false;


            // validate DV
            // --------------------------------

            string numberCheck = number.Substring(0, number.Length - 1);
            int dv = int.Parse(number.Substring(number.Length - 1, 1));
            string numberInverted = new string(numberCheck.Reverse().ToArray());

            int sumDigits = 0;
            for (int i = 0; i < numberInverted.Length; i++)
            {
                int pos = i + 1;
                int dig = int.Parse(numberInverted.Substring(i, 1));
                int r1 = dig * (pos % 2 == 1 ? 2 : 1);
                r1 = (r1 > 9 ? r1 - 9 : r1);
                sumDigits += r1;

            }

            if (sumDigits == 0)
                return false;

            int dvCheck = 0;
            int m = sumDigits % 10;
            if (m > 0)
                dvCheck = 10 - m;

            return (dvCheck == dv);


        }

    }
}
