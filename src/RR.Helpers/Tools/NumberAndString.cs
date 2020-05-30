using System.Text;

namespace RR.Helpers.Tools
{

    /// <summary>
    /// Number and String tool helper
    /// </summary>
    public static class NumberAndString
    {

        /// <summary>
        /// Remove chars the provided expression by leaving only the numbers
        /// </summary>
        /// <param name="expression">Expression to be cleaned</param>
        public static string RemoveText(string expression)
        {

            StringBuilder ret = new StringBuilder();

            for (int pos = 0; pos < expression.Length; pos++)
            {
                string character = expression.Substring(pos, 1);
                if ("0123456789".IndexOf(character) >= 0)
                    ret.Append(character);
            }

            return ret.ToString();

        }

        /// <summary>
        /// Remover numers from provided expression by leaving only letters
        /// </summary>
        /// <param name="expression">Expression to be cleaned</param>
        public static string RemoveNumbers(string expression)
        {
            return RemoveNumbers(expression, false);
        }

        /// <summary>
        /// Remover numers from provided expression by leaving only letters
        /// </summary>
        /// <param name="expression">Expression to be cleaned</param>
        /// <param name="keepSpace">Indicates whether space will be maintained</param>
        public static string RemoveNumbers(string expression, bool keepSpace)
        {
            return RemoveNumbers(expression, (keepSpace ? " " : string.Empty));
        }

        /// <summary>
        /// Remover numers from provided expression by leaving only letters
        /// </summary>
        /// <param name="expression">Expression to be cleaned</param>
        /// <param name="keepChars">List of characters to be maintained</param>
        public static string RemoveNumbers(string expression, string keepChars)
        {

            StringBuilder result = new StringBuilder();

            string valids = $"ABCDEFGHIJKLMNOPQRSTUVWXYZ{keepChars}";
            for (int pos = 0; pos < expression.Length; pos++)
            {
                string character = expression.Substring(pos, 1);
                if (valids.IndexOf(character.ToUpper()) >= 0)
                    result.Append(character);
            }

            return result.ToString();

        }

    }

}
