﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharSingleDelimiter.cs" company="Dev. Horizons - http://www.devhorizons.com">
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
        ///    Splits the specified source string by a specific separator/delimiter into collection of strings assuming that the first character/index is the first character from the left.
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
        ///     Will return 'null' if the 'delimiter' does not exist in the specified input source.
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        /// </remarks>
        /// <returns>Collection of split strings by a specific separator or 'null' if the 'delimiter' does not exist in the specified input source.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  11:41 AM</DateTime>
        /// </Created>
        public static List<string> SplitLeft(this string source, char delimiter, bool matchCase = true, CultureInfo culture = null)
        {
            return source.SplitLeft(delimiter, 0, matchCase, culture);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator/delimiter into collection of strings assuming that the first character/index is the first character from the left.
        /// </summary>
        /// <param name="source">
        ///    The source string to be split.
        ///    <para>Cannot be null or empty string.</para>
        /// </param>
        /// <param name="delimiter">
        ///    The separator.
        ///    <para>Cannot be null</para>
        /// </param>
        /// <param name="start">
        ///    The start index in the specified 'source' string, where the split operation should start.
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
        ///     Will return 'null' if the 'delimiter' does not exist in the specified input source.
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        /// </remarks>
        /// <returns>Collection of split strings by a specific separator or 'null' if the 'delimiter' does not exist in the specified input source.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        public static List<string> SplitLeft(this string source, char delimiter, int start, bool matchCase = true, CultureInfo culture = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return SplitLeft(source, delimiter, start, source.Length - 1, matchCase, culture);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator/delimiter into collection of strings assuming that the first character/index is the first character from the left.
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
        ///    The start index in the specified 'source' string, where the split operation should start.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        /// </param>
        /// <param name="end">
        ///    The last index in the specified 'source' string, where the split operation should stop.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot less than the 'start' value.</para>
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
        ///     Will return 'null' if the 'delimiter' does not exist in the specified input source.
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        /// </remarks>
        /// <returns>Collection of split strings by a specific separator or 'null' if the 'delimiter' does not exist in the specified input source.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  11:41 AM</DateTime>
        /// </Created>
        public static List<string> SplitLeft(this string source, char delimiter, int start, int end, bool matchCase = true, CultureInfo culture = null)
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

            source = source.Substring(start, end - start + 1);
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
                if (txt[i] == del)
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
                            array.Add(source.Substring(0, i));
                        }
                    }
                    else
                    {
                        array.Add(source.Substring(start, i - start));

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
                array.Add(source.Substring(start));
            }

            return array;
        }
    }
}
