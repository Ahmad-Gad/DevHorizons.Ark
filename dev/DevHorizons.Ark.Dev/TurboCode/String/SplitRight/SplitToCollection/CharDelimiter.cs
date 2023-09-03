// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringSingleDelimiter.cs" company="Dev. Horizons - http://www.devhorizons.com">
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
    using System.Diagnostics;
    using System.Globalization;
    using Exceptions;

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
        ///     Splits the specified source string from the right to left by a specific separator/delimiter into collection of strings assuming that the first character/index is the first character from the right.
        /// </summary>
        /// <param name="source">
        ///    The source string to be split.
        ///    <para>Cannot be null or empty string.</para>
        /// </param>
        /// <param name="delimiter">
        ///    The separator.
        ///    <para>Cannot be null.</para>
        /// </param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        ///    <para>Using the 'Invariant Culture' by default in the comparison which can be altered through the 'culture' argument.</para>
        /// </param>
        /// <param name="culture">
        ///     Optional: The locale culture which will be used in the string comparison only if the 'matchCase' is assigned to 'false'.
        ///     <para>The Default Value: <see cref="CultureInfo.InvariantCulture"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     The zero-based index is the first charcter from the right side of the string.
        ///     <para>Will return 'null' if the 'delimiter' does not exist in the specified input source.</para>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///     <para>The Arabic text already starts from right to left. So, if your intention is to deal with Arabic letters from right to left, then use the "<see cref="SplitLeft(string, char, bool, CultureInfo)"/>" extension method.</para>
        /// </remarks>
        /// <returns>Collection of split strings by a specific separator (from right to left) or 'null' if the 'delimiter' does not exist in the specified input source.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  11:41 AM</DateTime>
        /// </Created>
        public static List<string> SplitRight(this string source, char delimiter, bool matchCase = true, CultureInfo culture = null)
        {
            return source.SplitRight(delimiter, 0, matchCase, culture);
        }

        /// <summary>
        ///     Splits the specified source string from the right to left by a specific separator/delimiter into collection of strings assuming that the first character/index is the first character from the right.
        /// </summary>
        /// <param name="source">
        ///    The source string to be split.
        ///    <para>Cannot be null or empty string.</para>
        /// </param>
        /// <param name="delimiter">
        ///    The separator.
        ///    <para>Cannot be null.</para>
        /// </param>
        /// <param name="start">
        ///    The start index in the specified 'source' string from the right side, where the split operation should start.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        /// </param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        ///    <para>Using the 'Invariant Culture' by default in the comparison which can be altered through the 'culture' argument.</para>
        /// </param>
        /// <param name="culture">
        ///     Optional: The locale culture which will be used in the string comparison only if the 'matchCase' is assigned to 'false'.
        ///     <para>The Default Value: <see cref="CultureInfo.InvariantCulture"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     The zero-based index is the first charcter from the right side of the string.
        ///     <para>Will return 'null' if the 'delimiter' does not exist in the specified input source.</para>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///     <para>The Arabic text already starts from right to left. So, if your intention is to deal with Arabic letters from right to left, then use the "<see cref="SplitLeft(string, char, int, bool, CultureInfo)"/>" extension method.</para>
        /// </remarks>
        /// <returns>Collection of split strings by a specific separator (from right to left) or 'null' if the 'delimiter' does not exist in the specified input source.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  11:41 AM</DateTime>
        /// </Created>
        public static List<string> SplitRight(this string source, char delimiter, int start, bool matchCase = true, CultureInfo culture = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.SplitRight(delimiter, start, source.Length - 1, matchCase, culture);
        }

        /// <summary>
        ///     Splits the specified source string from the right to left by a specific separator/delimiter into collection of strings assuming that the first character/index is the first character from the right.
        /// </summary>
        /// <param name="source">
        ///    The source string to be split.
        ///    <para>Cannot be null or empty string.</para>
        /// </param>
        /// <param name="delimiter">
        ///    The separator.
        ///    <para>Cannot be null.</para>
        /// </param>
        /// <param name="start">
        ///    The start index in the specified 'source' string from the right side, where the split operation should start.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be equal or greater than the 'end' value.</para>
        /// </param>
        /// <param name="end">
        ///    The last index in the specified 'source' string from the right side, where the split operation should stop.
        ///    <para>Cannot be less than zero, unless the delimiter is just one character.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source', unless the delimiter is just one character.</para>
        ///    <para>Cannot be equal or less than the 'start' value, unless the delimiter is just one character, then it would be acceptable to be equal to the 'start' value.</para>
        /// </param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        ///    <para>Using the 'Invariant Culture' by default in the comparison which can be altered through the 'culture' argument.</para>
        /// </param>
        /// <param name="culture">
        ///     Optional: The locale culture which will be used in the string comparison only if the 'matchCase' is assigned to 'false'.
        ///     <para>The Default Value: <see cref="CultureInfo.InvariantCulture"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     The zero-based index is the first charcter from the right side of the string.
        ///     <para>Will return 'null' if the 'delimiter' does not exist in the specified input source.</para>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///     <para>The Arabic text already starts from right to left. So, if your intention is to deal with Arabic letters from right to left, then use the "<see cref="SplitLeft(string, char, int, int, bool, CultureInfo)"/>" extension method.</para>
        /// </remarks>
        /// <returns>Collection of split strings by a specific separator (from right to left) or 'null' if the 'delimiter' does not exist in the specified input source.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  11:41 AM</DateTime>
        /// </Created>
        public static List<string> SplitRight(this string source, char delimiter, int start, int end, bool matchCase = true, CultureInfo culture = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (delimiter == Character.Null)
            {
                throw new ArgumentNullException(nameof(delimiter));
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

            source = source.SliceRightInternal(start, end);

            var del = delimiter;
            var txt = source;

            if (matchCase == false)
            {
                if (culture == null)
                {
                    culture = CultureInfo.InvariantCulture;
                }

                del = delimiter.ToUpper(culture);
                txt = source.ToUpper(culture);
            }

            if (txt.Length == 1)
            {
                if (txt[0] == del)
                {
                    return new List<string> { string.Empty, string.Empty };
                }

                return null;
            }

            var array = new List<string>();
            //// ---------------------------------------------------------
            start = -1;
            var counter = 0;
            //// ---------------------------------------------------------
            for (var i = 0; i < txt.Length; i++)
            {
                if (txt[txt.Length - 1 - i] == del)
                {
                    counter++;

                    if (start == -1)
                    {
                        if (i == 0)
                        {
                            array.Add(string.Empty);
                        }
                        else
                        {
                            array.Add(source.CutRightInternal(0, i));
                        }
                    }
                    else
                    {
                        array.Add(source.CutRightInternal(start, i - start));

                        if (i + 1 == txt.Length)
                        {
                            array.Add(string.Empty);
                        }

                    }

                    start = i + 1;
                }
            }

            if (array.Count == 0)
            {
                return null;
            }

            if (counter == array.Count)
            {
                array.Add(source.CutRightInternal(start));
            }

            return array;
        }
    }
}
