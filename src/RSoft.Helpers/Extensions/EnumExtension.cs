using RSoft.Helpers.Attribute;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace RSoft.Helpers.Extensions
{

    /// <summary>
    /// Enum tools extensions
    /// </summary>
    public static class EnumExtension
    {

        /// <summary>
        /// Get the enum description attribute
        /// </summary>
        /// <param name="genericEnum">Enum to work</param>
        /// <exception cref="ArgumentNullException">When name is null</exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded</exception>
        /// <exception cref="ArgumentNullException">When attributeType is null</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context</exception>
        /// <exception cref="ArgumentNullException">When source is null</exception>
        public static string GetDescription<T>(this T genericEnum) where T : struct
        {
            Type genericEnumType = genericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(genericEnum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attribs != null && attribs.Count() > 0)
                {
                    return ((DescriptionAttribute)attribs.ElementAt(0)).Description;
                }
            }
            return genericEnum.ToString();
        }

        /// <summary>
        /// Get the enum role name attribute
        /// </summary>
        /// <param name="genericEnum">Enum to work</param>
        /// <exception cref="ArgumentNullException">When name is null</exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded</exception>
        /// <exception cref="ArgumentNullException">When attributeType is null</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context</exception>
        /// <exception cref="ArgumentNullException">When source is null</exception>
        public static string GetRole<T>(this T genericEnum) where T : struct
        {
            Type genericEnumType = genericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(genericEnum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(RoleNameAttribute), false);
                if (attribs != null && attribs.Count() > 0)
                {
                    return ((RoleNameAttribute)attribs.ElementAt(0)).Name;
                }
            }
            return null;
        }

    }

}
