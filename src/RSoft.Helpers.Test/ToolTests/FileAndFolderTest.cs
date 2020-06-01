using Xunit;
using RSoft.Helpers.Tools;
using System;
using System.Threading.Tasks;
using System.IO;

namespace RSoft.Helpers.Test.ToolTests
{

    /// <summary>
    /// File and folder tool helpers test
    /// </summary>
    public class FileAndFolderTest
    {

        #region Local objects/variables

        private const string _testFileName = "filetest.txt";
        private const string _fileBase64Content = "TG9yZW0gSXBzdW0gaXMgc2ltcGx5IGR1bW15IHRleHQgb2YgdGhlIHByaW50aW5nIGFuZCB0eXBlc2V0dGluZyBpbmR1c3RyeS4gTG9yZW0gSXBzdW0gaGFzIGJlZW4gdGhlIGluZHVzdHJ5J3Mgc3RhbmRhcmQgZHVtbXkgdGV4dCBldmVyIHNpbmNlIHRoZSAxNTAwcywgd2hlbiBhbiB1bmtub3duIHByaW50ZXIgdG9vayBhIGdhbGxleSBvZiB0eXBlIGFuZCBzY3JhbWJsZWQgaXQgdG8gbWFrZSBhIHR5cGUgc3BlY2ltZW4gYm9vay4gSXQgaGFzIHN1cnZpdmVkIG5vdCBvbmx5IGZpdmUgY2VudHVyaWVzLCBidXQgYWxzbyB0aGUgbGVhcCBpbnRvIGVsZWN0cm9uaWMgdHlwZXNldHRpbmcsIHJlbWFpbmluZyBlc3NlbnRpYWxseSB1bmNoYW5nZWQuIEl0IHdhcyBwb3B1bGFyaXNlZCBpbiB0aGUgMTk2MHMgd2l0aCB0aGUgcmVsZWFzZSBvZiBMZXRyYXNldCBzaGVldHMgY29udGFpbmluZyBMb3JlbSBJcHN1bSBwYXNzYWdlcywgYW5kIG1vcmUgcmVjZW50bHkgd2l0aCBkZXNrdG9wIHB1Ymxpc2hpbmcgc29mdHdhcmUgbGlrZSBBbGR1cyBQYWdlTWFrZXIgaW5jbHVkaW5nIHZlcnNpb25zIG9mIExvcmVtIElwc3VtLg==";

        #endregion

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

        /// <summary>
        /// Save array-byte on file
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void SaveFileOnDisk()
        {
            byte[] fileBytes = Convert.FromBase64String(_fileBase64Content);
            FileAndFolder.SaveFileAsync(_testFileName, fileBytes, default).Wait();
            Assert.True(File.Exists(_testFileName));
        }

        /// <summary>
        /// Save array-byte on file overwritting
        /// </summary>
        [Fact]
        public void OverwriteSaveFileOnDisk()
        {
            byte[] fileBytes = Convert.FromBase64String(_fileBase64Content);
            if (File.Exists(_testFileName)) File.Delete(_testFileName);
            FileAndFolder.SaveFileAsync(_testFileName, new byte[] { }, default).Wait();
            FileAndFolder.SaveFileAsync(_testFileName, fileBytes, true, default).Wait();
            Assert.True(File.Exists(_testFileName));
            File.Delete(_testFileName);
        }

        /// <summary>
        /// Save array-byte on file overwritting
        /// </summary>
        [Fact]
        public async Task SaveFileOnDiskThrowsException()
        {
            byte[] fileBytes = Convert.FromBase64String(_fileBase64Content);
            await FileAndFolder.SaveFileAsync(_testFileName, new byte[] { }, default);
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(async () => await FileAndFolder.SaveFileAsync(_testFileName, fileBytes, false, default));
            Assert.IsType<InvalidOperationException>(ex);
            if (File.Exists(_testFileName)) File.Delete(_testFileName);
        }

        #endregion

    }

}
