using System;
using System.Text.Json;

namespace RSoft.Helpers.Extensions
{

    /// <summary>
    /// Json extensions
    /// </summary>
    public static class JsonExtension
    {

        /// <summary>
        /// Parses the text representing a single JSON value into an instance of the type specified by a generic type parameter.
        /// </summary>
        /// <param name="json">Json text expression to work</param>
        /// <param name="options">Options to control the behavior during parsing.</param>
        /// <returns>A TValue representation of the JSON value.</returns>
        /// <exception cref="System.ArgumentNullException">json is null.</exception>
        /// <exception cref="System.Text.Json.JsonException">The JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
        /// <exception cref="System.NotSupportedException">There is no compatible System.Text.Json.Serialization.JsonConverter for TValue or its serializable members.</exception>
        public static TValue JsonDeserialize<TValue>(this string json, JsonSerializerOptions options = null)
        {
            TValue result = default;
            options ??= new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            if (!string.IsNullOrWhiteSpace(json))
                result = JsonSerializer.Deserialize<TValue>(json, options);
            return result;
        }


        /// <summary>
        /// Converts the value of a type specified by a generic type parameter into a JSON string.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="options">Options to control serialization behavior.</param>
        /// <returns>A JSON string representation of the value.</returns>
        /// <exception cref="System.NotSupportedException">There is no compatible System.Text.Json.Serialization.JsonConverter for TValue or its serializable members.</exception>
        public static string JsonSerialize<TValue>(this TValue value, JsonSerializerOptions options = null)
        {
            if (value == null)
                return null;
            return  JsonSerializer.Serialize(value, options);
        }

    }

}
