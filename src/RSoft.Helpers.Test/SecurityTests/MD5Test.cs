using System;
using mt = RSoft.Helpers.Security.MD5;
using Xunit;
using System.Linq;

namespace RSoft.Helpers.Test.SecurityTests
{


    /// <summary>
    /// RSoft.Helpers.Security method tests
    /// </summary>
    public class MD5Test
    {

        [Fact]
        public void HashMD5TestNoOutput()
        {

            byte[] byteCheck = new byte[] { 159, 40, 18, 20, 204, 202, 53, 123, 235, 30, 241, 180, 107, 11, 64, 18 };

            byte[] byteResult = mt.HashMD5("a2b2c3");

            Assert.True(byteCheck.SequenceEqual(byteResult));

        }

        [Fact]
        public void HashMD5TestWithOutput()
        {

            string stringCheck = "9F281214CCCA357BEB1EF1B46B0B4012";
            byte[] byteCheck = new byte[] { 159, 40, 18, 20, 204, 202, 53, 123, 235, 30, 241, 180, 107, 11, 64, 18 };

            byte[] byteResult = mt.HashMD5("a2b2c3", out string result);

            Assert.Equal(stringCheck, result);
            Assert.True(byteCheck.SequenceEqual(byteResult));

        }

        [Fact]
        public void ByteArrayToString()
        {

            string stringCheck = "9f281214ccca357beb1ef1b46b0b4012";
            byte[] byteArray = new byte[] { 159, 40, 18, 20, 204, 202, 53, 123, 235, 30, 241, 180, 107, 11, 64, 18 };

            string result = mt.ByteArrayToString(byteArray);
            Assert.Equal(stringCheck, result);

        }

        [Fact]
        public void StringToByteArray()
        {

            string hex = "9F281214CCCA357BEB1EF1B46B0B4012";
            byte[] byteCheck = new byte[] { 159, 40, 18, 20, 204, 202, 53, 123, 235, 30, 241, 180, 107, 11, 64, 18 };

            byte[] result = mt.StringToByteArray(hex);
            Assert.True(result.SequenceEqual(byteCheck));

        }

    }

}
