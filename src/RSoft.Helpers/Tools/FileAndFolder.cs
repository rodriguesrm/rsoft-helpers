using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        /// <summary>
        /// Save a file on disk
        /// </summary>
        /// <param name="fullName">Fullname file</param>
        /// <param name="file">Byte-array of file</param>
        /// <param name="cancellationToken">Cancellation token object</param>
        public static async Task SaveFileAsync(string fullName, byte[] file, CancellationToken cancellationToken = default)
            => await SaveFileAsync(fullName, file, true, cancellationToken);

        /// <summary>
        /// Gravar um arquivo no disco
        /// </summary>
        /// <param name="fullName">Fullname file</param>
        /// <param name="file">Byte-array of file</param>
        /// <param name="overwrite">Indicates whether the file should be overwritten if exists</param>
        /// <param name="cancellationToken">Cancellation token object</param>
        public static async Task SaveFileAsync(string fullName, byte[] file, bool overwrite, CancellationToken cancellationToken = default)
        {

            if (File.Exists(fullName) && !overwrite)
                throw new InvalidOperationException($"{fullName} file already exists");

            await File.WriteAllBytesAsync(fullName, file, cancellationToken);

        }

    }

}
