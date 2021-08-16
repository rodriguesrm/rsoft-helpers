using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RSoft.Helpers.Validations
{

    /// <summary>
    /// Provides methods for brasilian documents validation
    /// </summary>
    public class BrasilianDocument
    {

        /// <summary>
        /// Cpf document validation
        /// </summary>
        /// <param name="cpf">Cpf document number (only numbers, no mask)</param>
        public static bool CheckCpf(string cpf)
        {

            // Check length
            if (cpf.Length != 11)
                return false;

            // Check contain only numbers
            if (!Regex.IsMatch(cpf, "[0-9]{11}"))
                return false;

            int dv;

            // Static invalidation
            if (new List<string>() { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" }.Contains(cpf))
                return false;

            // DV1 calculating
            dv = 0;
            for (int pos = 0; pos < 9; pos++)
                dv += (int.Parse(cpf.Substring(pos, 1)) * (pos + 1));

            dv = (dv % 11);
            if (dv == 10) dv = 0;

            // DV1 Check
            if (dv.ToString() != cpf.Substring(9, 1))
                return false;

            // DV2 calculating
            dv = 0;
            for (int pos = 0; pos < 10; pos++)
                dv += (int.Parse(cpf.Substring(pos, 1)) * pos);

            dv = (dv % 11);
            if (dv == 10) dv = 0;

            // DV2 Check
            if (dv.ToString() != cpf.Substring(10, 1))
                return false;

            return true;

        }

        /// <summary>
        /// Cnpj validation document
        /// </summary>
        /// <param name="cnpj">cnpjdocument number (only numbers, no mask)</param>
        public static bool CheckCnpj(string cnpj)
        {

            // check length
            if (cnpj.Length != 14)
                return false;

            // Check contain only numbers
            if (!Regex.IsMatch(cnpj, "[0-9]{14}"))
                return false;

            // Static invalidation
            if (new List<string>() { "00000000000000", "11111111111111", "22222222222222", "33333333333333", "44444444444444", "55555555555555", "66666666666666", "77777777777777", "88888888888888", "99999999999999" }.Contains(cnpj))
                return false;

            int dv;
            string[] factor = { "543298765432", "6543298765432" };

            // DV1 calculating
            dv = 0;
            for (int i = 0; i < 12; i++)
                dv += (int.Parse(cnpj.Substring(i, 1)) * int.Parse(factor[0].Substring(i, 1)));

            dv = (dv % 11);
            if (dv < 2)
                dv = 0;
            else
                dv = (11 - dv);

            // DV1 check
            if (dv.ToString() != cnpj.Substring(12, 1))
                return false;

            // DV2 calculating
            dv = 0;
            for (int i = 0; i < 13; i++)
                dv += (int.Parse(cnpj.Substring(i, 1)) * int.Parse(factor[1].Substring(i, 1)));

            dv = (dv % 11);
            if (dv < 2)
                dv = 0;
            else
                dv = (11 - dv);

            // DV2 check
            if (dv.ToString() != cnpj.Substring(13, 1))
                return false;

            return true;

        }

        /// <summary>
        /// Cpf our Cnpj document validation
        /// </summary>
        /// <param name="document">Document number (only numbers, no mask)</param>
        public static bool CheckDocument(string document)
        {

            if (Regex.IsMatch(document, "[0-9]{14}") && document.Length.Equals(14))
                return CheckCnpj(document);

            if (Regex.IsMatch(document, "[0-9]{11}") && document.Length.Equals(11))
                return CheckCpf(document);

            return false;

        }

    }
}
