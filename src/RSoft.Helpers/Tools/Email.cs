using System.Linq;

namespace RSoft.Helpers.Tools
{

    /// <summary>
    /// Provides methods to assist with actions on email information
    /// </summary>
    public static class Email
    {

        /// <summary>
        /// Extract login from email (before @)
        /// </summary>
        public static string Login(string email)
            => email.Split('@').ToList().FirstOrDefault();

        /// <summary>
        /// Extract domain from email (after @)
        /// </summary>
        public static string Domain(string email)
            => email.Split('@').ToList().LastOrDefault();

    }

}
