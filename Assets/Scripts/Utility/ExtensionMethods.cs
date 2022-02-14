using System;

namespace BurningSky.Utility
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method to return an enum value of type T for the given string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Extension method to return an enum value of type T for the given int.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this Enum value)
        {
            var name = value.ToString();
            return name.ToEnum<T>();
        }
    }
}
