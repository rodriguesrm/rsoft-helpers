using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSoft.Helpers.Tools
{

    /// <summary>
    /// Files and folders tools helper
    /// </summary>
    public static class FileAndFolder
    {

        /// <summary>
        /// Remove path from a full name file
        /// </summary>
        /// <param name="fullName">Full name faile (path/name)</param>
        /// <returns>Only file name</returns>
        public static string RemovePath(string fullName)
        {
            fullName = fullName.Replace("/", "\\");
            if (fullName.Contains('\\'))
                return fullName.Split('\\').Last();
            else
                return fullName;
        }

        /// <summary>
        /// Get network base address
        /// </summary>
        /// <param name="fullPath">Full path network</param>
        public static string NetworkPathBase(string fullPath)
        {

            fullPath = fullPath.Replace("/", "\\");

            IList<string> pathList = fullPath.Split('\\').ToList();

            string result = string.Empty;

            if (pathList.Count >= 4)
                if (fullPath.StartsWith(@"\\"))
                    result = "\\\\" + pathList[2] + "\\" + pathList[3];

            return result;

        }

    }

}
