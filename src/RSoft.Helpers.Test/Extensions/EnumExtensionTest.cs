using RSoft.Helpers.Attribute;
using RSoft.Helpers.Extensions;
using System.ComponentModel;
using Xunit;

namespace RSoft.Helpers.Test.Extensions
{

    /// <summary>
    /// Reflection enum extension tests
    /// </summary>
    public class EnumExtensionTest
    {

        private enum TestEnum
        {
            [Description("Option One")]
            [RoleName("R1")]
            Option1,
            [Description("Option Two")]
            [RoleName("R2")]
            Option2,
            [Description("Option Three")]
            [RoleName("R3")]
            Option3
        }

        /// <summary>
        /// Get enum description
        /// </summary>
        [Fact]
        public void GetEnumDescription()
        {
            TestEnum opt = TestEnum.Option1;
            string check = opt.GetDescription();
            Assert.Equal("Option One", check);
        }

        /// <summary>
        /// Get role name from attribute in enum
        /// </summary>
        [Fact]
        public void GetRoleNameAttribute()
        {
            TestEnum opt = TestEnum.Option2;
            string check = opt.GetRole();
            Assert.Equal("R2", check);
        }

    }

}
