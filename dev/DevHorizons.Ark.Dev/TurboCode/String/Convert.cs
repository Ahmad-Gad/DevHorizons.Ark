// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Convert.cs" company="Dev. Horizons - http://www.devhorizons.com">
//   Copyright (c) 2012 All Right Reserved
// </copyright>
// <summary>
//     Defines all the needed string's manipulation operations methods.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>24/08/2010  10:22 AM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Ark.Dev.TurboCode
{
    /// <summary>
    ///     Defines all the needed string's manipulation operations methods.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>30/06/2012  06:17 PM</DateTime>
    /// </Created>
    public static partial class JString
    {
        /// <summary>
        ///    Converts to String from a string or to empty string if the object is null.
        /// </summary>
        /// <param name="source">The source object to be converted.</param>
        /// <returns>Valid safe-type String</returns>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///      <DateTime>24/08/2010  2:16 PM</DateTime>
        /// </Created>
        public static string ToStringOrEmptyString(this object source)
        {
            return ToSafeString(source, string.Empty);
        }

        /// <summary>
        /// Converts to String from a valid object.
        /// </summary>
        /// <param name="source">The source object to be converted.</param>
        /// <param name="defaultValue">The default return (failover) value in case if the conversion operation failed.</param>
        /// <returns>Valid safe-type String</returns>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///      <DateTime>24/08/2010  2:16 PM</DateTime>
        /// </Created>
        public static string ToSafeString(this object source, string defaultValue)
        {
            return source is null ? defaultValue : source.ToString();
        }

        public unsafe static Span<char> ToSpan(this string source)
        {
            if (source is null)
            {
                return null;
            }

            unsafe
            {
                fixed (char* ptr = source)
                {
                    return new Span<char>(ptr, source.Length);
                }
            }
        }
    }
}
