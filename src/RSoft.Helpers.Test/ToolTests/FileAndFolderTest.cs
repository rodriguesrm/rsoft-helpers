using Xunit;
using RSoft.Helpers.Tools;

namespace RSoft.Helpers.Test.ToolTests
{

    /// <summary>
    /// File and folder tool helpers test
    /// </summary>
    public class FileAndFolderTest
    {

        #region Test

        /// <summary>
        /// Return name file only test
        /// </summary>
        /// <param name="fullFileName">Folder and file name (full path)</param>
        [Theory]
        [InlineData(@"c:\windows\system32\drivers\etc\hots\file.ext")]
        [InlineData(@"\\server\sharedfolder\subfolder\destination\file.ext")]
        [InlineData("/home/user/destination/file.ext")]
        [InlineData("//server/sharedfolder/subfolder/destination/file.ext")]
        [InlineData("file.ext")]
        public void ReturnFileNameTest(string fullFileName)
            => Assert.Equal("file.ext", FileAndFolder.RemovePath(fullFileName));

        /// <summary>
        /// Return base network path test
        /// </summary>
        /// <param name="fullFileName">Folder and file name (full path)</param>
        [Theory]
        [InlineData(@"\\server\sharedfolder\subfolder\destination\file.ext")]
        [InlineData("//server/sharedfolder/subfolder/destination/file.ext")]
        public void ReturnNetworkPathBaseTest(string fullFileName)
        {
            string result = FileAndFolder.NetworkPathBase(fullFileName);
            Assert.Equal(@"\\server\sharedfolder", result);
        }

        /// <summary>
        /// Return no base network path test
        /// </summary>
        /// <param name="fullFileName">Folder and file name (full path)</param>
        [Theory]
        [InlineData(@"c:\windows\system32\drivers\etc\hots\file.ext")]
        [InlineData("/home/user/destination/file.ext")]
        public void ReturnNetworkPathEmptyTest(string fullFileName)
        {
            string result = FileAndFolder.NetworkPathBase(fullFileName);
            Assert.True(string.IsNullOrWhiteSpace(result));
        }

        #endregion

    }

}
