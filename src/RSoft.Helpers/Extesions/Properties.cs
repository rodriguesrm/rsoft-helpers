using System;
using System.Reflection;

namespace RSoft.Helpers.Extesions
{

    /// <summary>
    /// Provides properties method helpers
    /// </summary>
    public static class Properties
    {

        /// <summary>
        /// Get property value by reflection
        /// </summary>
        /// <param name="obj">Target object</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property value</returns>
        public static object GetPropValue(this object obj, string propertyName)
        {
            foreach (string part in propertyName.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        /// <summary>
        /// Get property value by reflection
        /// </summary>
        /// <typeparam name="TType">Object type</typeparam>
        /// <param name="obj">Target object</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property value</returns>
        /// <exception cref="InvalidCastException">The exception that is thrown for invalid casting or explicit conversion.</exception>
        public static TType GetPropValue<TType>(this object obj, string propertyName)
        {
            object result = obj.GetPropValue(propertyName);
            if (result == null) { return default; }

            // Throws the InvalidCastException exception if the types are incompatible
            return (TType)result;
        }

    }

}
