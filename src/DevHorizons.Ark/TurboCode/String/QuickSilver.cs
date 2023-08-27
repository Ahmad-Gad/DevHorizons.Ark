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
namespace DevHorizons.Ark.TurboCode
{
    using System.Diagnostics;
    using System.Globalization;
    using Exceptions;
    using Validation;

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
        ///    Slices the specified source.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both start and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="start">
        ///    The start/first index/position in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="end">
        ///    The last index/position in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be less than the 'start' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A slice of string which has specific start index and specific end index within the string length.
        /// </returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///     <para>If the input source is an empty string and both start and end are equal to zero, then the return would be empty string, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        public static string Slice(this string source, int start, int end)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (start < 0)
            {
                var argumentName = nameof(start);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be lower than zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (end < 0)
            {
                var argumentName = nameof(end);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be lower than zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (start > end)
            {
                var argumentName = nameof(start);
                var conflictArgument = nameof(end);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The value of the '{argumentName}' argument cannot be greater than or equal the value of the argument '{conflictArgument}'.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }

            if (source.Length == 0)
            {
                var argumentName = nameof(source);
                var conflictArgument = JString.Null;

                if (start != 0)
                {
                    conflictArgument = nameof(start);
                }
                else if (end != 0)
                {
                    conflictArgument = nameof(end);
                }

                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The '{conflictArgument}' value cannot be greater than zero if the input digital value of the argument '{argumentName}' is an empty string.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument | ArgumentExceptionCode.EmptyString;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }

            if (start > source.Length - 1)
            {
                var argumentName = nameof(start);
                var conflictArgument = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The '{argumentName}' cannot be greater than the upper bound index of the string value of the argument '{conflictArgument}'.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }


            if (end > source.Length - 1)
            {
                var argumentName = nameof(end);
                var conflictArgument = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The '{argumentName}' cannot be greater than the upper bound index of the string value of the argument '{conflictArgument}'.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }

            return source.SliceInternal(start, end);
        }

        /// <summary>
        ///     Gets part of a string from the left position of a specific string based on the mentioned length.
        /// </summary>
        /// <param name="source">
        ///    The source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, the length value must be only equal to '1' to return empty string as the output value.</para>
        /// </param>
        /// <param name="length">
        ///    The length (count) of characters to capture.
        ///    <para>Cannot be greater than the length of the source or '<see cref="ArgumentException"/>' exception will be thrown.</para>
        ///    <para>Cannot less than or equal to zero.</para>
        /// </param>
        /// <returns>The left part of string based on the mentioned length.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///     <para>If the input source is an empty string and the length value is '1', then the return would be empty string, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  05:17 PM</DateTime>
        /// </Created>
        public static string Left(this string source, int length)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (length <= 0)
            {
                var argumentName = nameof(length);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be equal or lower than zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (source.Length == 0 && length != 1)
            {
                var argumentName = nameof(source);
                var conflictArgument = nameof(length);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The integer '{conflictArgument}' value can be only equal to '1' if the input digital value of the argument '{argumentName}' is an empty string.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument | ArgumentExceptionCode.EmptyString;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }

            if (length > source.Length)
            {
                var argumentName = nameof(length);
                var conflictArgument = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The '{argumentName}' cannot be greater than the length of the string value of the argument '{conflictArgument}'.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }

            return source.Substring(0, length);
        }

        /// <summary>
        ///     Gets part of a string from the right position of a specific string based on the mentioned length.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="length">
        ///    The length (count) of characters to capture.
        ///    <para>Cannot be greater than the length of the source or '<see cref="ArgumentException"/>' exception will be thrown.</para>
        /// </param>
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        /// </remarks>
        /// <returns>
        ///    The right part of string based on the mentioned length.
        ///    <para>Will return 'null' if the input source is null.</para>
        ///    <para>Will return 'empty string' if the input source is an empty string.</para>
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  05:17 PM</DateTime>
        /// </Created>
        public static string Right(this string source, int length)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (length <= 0)
            {
                var argumentName = nameof(length);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be equal or lower than zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (source.Length == 0 && length != 1)
            {
                var argumentName = nameof(source);
                var conflictArgument = nameof(length);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The integer '{conflictArgument}' value can be only equal to '1' if the input digital value of the argument '{argumentName}' is an empty string.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument | ArgumentExceptionCode.EmptyString;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }

            if (length > source.Length)
            {
                var argumentName = nameof(length);
                var conflictArgument = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The '{argumentName}' cannot be greater than the length of the string value of the argument '{conflictArgument}'.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }

            return source.Substring(source.Length - length);
        }

        /// <summary>
        ///    To the initial caps format.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="culture">
        ///     Optional: The locale culture which will be used in the string comparison only if the 'matchCase' is assigned to 'false'.
        ///     <para>The Default Value: <see cref="CultureInfo.InvariantCulture"/>.</para>
        /// </param>
        /// <returns>
        ///    String with initial caps characters.
        /// </returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the is empty string.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 02:04 PM</DateTime>
        /// </Created>
        public static string ToInitialCaps(this string source, CultureInfo culture = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                var argumentName = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be empty string";
                var exceptionCode = ArgumentExceptionCode.EmptyString;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (culture == null)
            {
                culture = CultureInfo.InvariantCulture;
            }

            source = source.ToLower(culture);
            var newString = source[0].ToUpper(culture).ToString();

            if (source.Length == 1)
            {
                return newString;
            }

            for (int i = 1; i < source.Length; i++)
            {
                var ascii = source[i - 1];

                if (!((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122) || (ascii >= 48 && ascii <= 57) || ascii == Character.SingleQuote))
                {
                    newString += source[i].ToUpper(culture);
                }
                else
                {
                    newString += source[i];
                }
            }

            return newString;
        }

        /// <summary>
        ///     To a string's characters cases reverted (from upper to lower and from lower to upper).
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="culture">
        ///     Optional: The locale culture which will be used in the string comparison only if the 'matchCase' is assigned to 'false'.
        ///     <para>The Default Value: <see cref="CultureInfo.InvariantCulture"/>.</para>
        /// </param>
        /// <returns>
        ///    The string's characters cases reverted (from upper to lower and from lower to upper).
        ///    <para>Will return 'null' if the input source is null.</para>
        ///    <para>Will return 'empty string' if the input source is an empty string.</para>
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 02:07 PM</DateTime>
        /// </Created>
        public static string ToRevertedCase(this string source, CultureInfo culture = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                var argumentName = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be empty string";
                var exceptionCode = ArgumentExceptionCode.EmptyString;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            var newString = string.Empty;

            foreach (char chr in source)
            {
                var newChar = chr.IsUpper() ? chr.ToLower(culture) : chr.ToUpper(culture);
                newString += newChar;
            }

            return newString;
        }

        #region Internal Functions
        internal static string SliceInternal(this string source, int start, int end)
        {
            return source.Substring(start, end - start + 1);
        }
        #endregion Internal Functions
    }
}