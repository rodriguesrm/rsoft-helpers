using System;
using System.Globalization;

namespace RR.Helpers.Tools
{

    /// <summary>
    /// Provides methods for generic conversions
    /// </summary>
    public static class Cast
    {

        /// <summary>
        /// Try to convert an object to a specified style with an invariant culture provider. A return value indicates whether the conversion was successful.
        /// </summary>
        /// <typeparam name="T">Type for cast</typeparam>
        /// <param name="obj">Object to convert</param>
        /// <param name="result">Conversion result, if successful</param>
        /// <returns>A Boolean value of the result</returns>
        /// <exception cref="System.InvalidCastException">The exception that is thrown for invalid casting or explicit conversion.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument is invalid, or when a composite format string is not well formed.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        public static bool TryCast<T>(object obj, out T result)
            => TryCast<T>(obj, out result, CultureInfo.InvariantCulture);

        /// <summary>
        /// Try to convert an object to a specified style with an invariant culture provider. A return value indicates whether the conversion was successful.
        /// </summary>
        /// <typeparam name="T">Type for cast</typeparam>
        /// <param name="obj">Objeto para conversão</param>
        /// <param name="obj">Object to convert</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <returns>A Boolean value of the result</returns>
        /// <exception cref="System.InvalidCastException">The exception that is thrown for invalid casting or explicit conversion.</exception>
        /// <exception cref="System.FormatException">The exception that is thrown when the format of an argument is invalid, or when a composite format string is not well formed.</exception>
        /// <exception cref="System.OverflowException">The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.</exception>
        /// <exception cref="System.ArgumentNullException">The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.</exception>
        public static bool TryCast<T>(object obj, out T result, IFormatProvider provider)
        {
            try
            {
                result = (T)Convert.ChangeType(obj, typeof(T), provider);
                return true;
            }
            catch
            {

                result = default;
                return false;
            }
        }

    }

}
