// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JString.cs" company="Dev. Horizons - http://www.devhorizons.com">
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
    using System.Text;


    /// <summary>
    ///     Defines all the needed string's manipulation operations methods.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>30/06/2012  06:17 PM</DateTime>
    /// </Created>
    public static partial class JString
    {
        #region String Source
        /// <summary>
        ///     Get a string of concatenated string with a specific source source and specific redundant count.
        /// </summary>
        /// <param name="source">The source string to be repeated in a concatenation with a specific redundant count. Cannot be null or empty string.</param>
        /// <param name="count">The redundant count for the specified string concatenation.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns>
        ///     Concatenated string with a specific source source and specific redundant count.
        /// </returns>
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>It will return empty string if the source is empty string, .</para>
        ///     <para>It will return the same value of the input source without any change if the 'count' is less than or equal zero.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:38 PM</DateTime>
        /// </Created>
        public static string Repeat(this string source, int count)
        {
            return source.Repeat(count, null);
        }

        /// <summary>
        ///     Get a string of concatenated string with a specific source source and specific redundant count.
        /// </summary>
        /// <param name="source">The source string to be repeated in a concatenation with a specific redundant count. Cannot be null or empty string.</param>
        /// <param name="count">The redundant count for the specified string concatenation.</param>
        /// <param name="delimiter">The delimiter string used as a separator between the keywords concatenation.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns>
        ///     Concatenated string with a specific source source and specific redundant count.
        /// </returns>
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>It will return empty string if the source is empty string, .</para>
        ///     <para>It will return the same value of the input source without any change if the 'count' is less than or equal zero.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:38 PM</DateTime>
        /// </Created>
        public static string Repeat(this string source, int count, string delimiter)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                return source;
            }

            if (count <= 1)
            {
                return source;
            }

            if (string.IsNullOrEmpty(delimiter))
            {
                return source.RepeatInternal(count);
            }

            var strBuilder = new StringBuilder(source, count * 2 - 1);
           
            for (int i = 1; i < count; i++)
            {
                strBuilder.Append(delimiter);
                strBuilder.Append(source);
            }

            return strBuilder.ToString();
        }

        /// <summary>
        ///     Get a string of concatenated string with a specific source source and specific redundant count.
        /// </summary>
        /// <param name="source">The source string to be repeated in a concatenation with a specific redundant count. Cannot be null or empty string.</param>
        /// <param name="count">The redundant count for the specified string concatenation.</param>
        /// <param name="delimiter">The delimiter string used as a separator between the keywords concatenation.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns>
        ///     Concatenated string with a specific source source and specific redundant count.
        /// </returns>
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>It will return empty string if the source is empty string, .</para>
        ///     <para>It will return the same value of the input source without any change if the 'count' is less than or equal zero.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:38 PM</DateTime>
        /// </Created>
        public static string Repeat(this string source, int count, char delimiter)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                return source;
            }

            if (count <= 1)
            {
                return source;
            }

            if (delimiter == Character.Null)
            {
                return source.RepeatInternal(count);
            }

            var strBuilder = new StringBuilder(source, count * 2 - 1);

            for (int i = 1; i < count; i++)
            {
                strBuilder.Append(delimiter);
                strBuilder.Append(source);
            }

            return strBuilder.ToString();
        }
        #endregion String Source

        #region Char Source
        /// <summary>
        ///     Get a string of concatenated string with a specific source character and specific redundant count.
        /// </summary>
        /// <param name="source">The source char to be repeated in a concatenation with a specific redundant count.</param>
        /// <param name="count">The redundant count for the specified string concatenation.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns>
        ///    Concatenated string with a specific source character and specific redundant count.
        /// </returns>
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>It will return empty string if the source is empty string, .</para>
        ///     <para>It will return the same value of the input source without any change if the 'count' is less than or equal zero.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:38 PM</DateTime>
        /// </Created>
        public static string Repeat(this char source, int count)
        {
            return source.Repeat(count, string.Empty);
        }

        /// <summary>
        ///     Get a string of concatenated string with a specific source character and specific redundant count.
        /// </summary>
        /// <param name="source">The source char to be repeated in a concatenation with a specific redundant count.</param>
        /// <param name="count">The redundant count for the specified string concatenation.</param>
        /// <param name="delimiter">The delimiter string used as a separator between the keywords concatenation.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns>
        ///    Concatenated string with a specific source character and specific redundant count.
        /// </returns>
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>It will return empty string if the source is empty string, .</para>
        ///     <para>It will return the same value of the input source without any change if the 'count' is less than or equal zero.</para>
        /// </remarks>
        /// <remarks>If the <c>count</c> value is lower than 1, it will return <c>null</c>.</remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:38 PM</DateTime>
        /// </Created>
        public static string Repeat(this char source, int count, string delimiter)
        {
            if (source == Character.Null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (count <= 1)
            {
                unsafe
                {
                    return new string(&source);
                }
            }

            if (string.IsNullOrEmpty(delimiter))
            {
                return source.RepeatInternal(count);
            }

            var strBuilder = new StringBuilder(count * 2 - 1);
            strBuilder.Append(source);

            for (int i = 1; i < count; i++)
            {
                strBuilder.Append(delimiter);
                strBuilder.Append(source);
            }

            return strBuilder.ToString();
        }

        /// <summary>
        ///     Get a string of concatenated string with a specific source source and specific redundant count.
        /// </summary>
        /// <param name="source">The source char to be repeated in a concatenation with a specific redundant count. Cannot be null or empty string.</param>
        /// <param name="count">The redundant count for the specified string concatenation.</param>
        /// <param name="delimiter">The delimiter string used as a separator between the keywords concatenation.</param>
        /// <exception cref="ArgumentNullException" />
        /// <returns>
        ///     Concatenated string with a specific source source and specific redundant count.
        /// </returns>
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>It will return empty string if the source is empty string, .</para>
        ///     <para>It will return the same value of the input source without any change if the 'count' is less than or equal zero.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:38 PM</DateTime>
        /// </Created>
        public static string Repeat(this char source, int count, char delimiter)
        {
            if (source == Character.Null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (count <= 1)
            {
                unsafe
                {
                    return new string(&source);
                }
            }

            if (delimiter == Character.Null)
            {
                return source.RepeatInternal(count);
            }

            var strBuilder = new StringBuilder(count * 2 - 1);
            strBuilder.Append(source);

            for (int i = 1; i < count; i++)
            {
                strBuilder.Append(delimiter);
                strBuilder.Append(source);
            }

            return strBuilder.ToString();
        }
        #endregion Char Source

        #region Private Methods
        /// <summary>
        ///     Get a string of concatenated string with a specific source character and specific redundant count.
        /// </summary>
        /// <param name="source">The source string to be repeated in a concatenation with a specific redundant count.</param>
        /// <param name="count">The redundant count for the specified string concatenation.</param>
        /// <returns>Concatenated string with a specific source character and specific redundant count.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:38 PM</DateTime>
        /// </Created>
        private static string RepeatInternal(this string source, int count)
        {
            var strBuilder = new StringBuilder(source, count);

            for (int i = 1; i < count; i++)
            {
                strBuilder.Append(source);
            }

            return strBuilder.ToString();
        }

        /// <summary>
        ///     Get a string of concatenated string with a specific source character and specific redundant count.
        /// </summary>
        /// <param name="source">The source string to be repeated in a concatenation with a specific redundant count.</param>
        /// <param name="count">The redundant count for the specified string concatenation.</param>
        /// <returns>Concatenated string with a specific source character and specific redundant count.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:38 PM</DateTime>
        /// </Created>
        private static string RepeatInternal(this char source, int count)
        {
            var strBuilder = new StringBuilder(count);
            strBuilder.Append(source);

            for (int i = 1; i < count; i++)
            {
                strBuilder.Append(source);
            }

            return strBuilder.ToString();
        }
        #endregion Private Methods
    }
}
