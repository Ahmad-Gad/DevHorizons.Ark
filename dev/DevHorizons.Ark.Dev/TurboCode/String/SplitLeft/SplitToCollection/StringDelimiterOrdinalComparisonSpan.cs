﻿// --------------------------------------------------------------------------------------------------------------------
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
    // using System.Collections.Immutable;
    using System.Diagnostics;
    using Exceptions;


    /// <summary>
    ///     Defines all the needed string's manipulation operations methods.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>30/06/2012  06:17 PM</DateTime>
    /// </Created>
    public static class StringDelimiterOrdinalComparisonSpan
    {
        /// <summary>
        ///     Splits the specified source string by a specific separator/delimiter into collection of strings assuming that the first character/index is the first character from the left.
        /// </summary>
        /// <param name="source">
        ///    The source string to be split.
        ///    <para>Cannot be null or empty string.</para>
        /// </param>
        /// <param name="delimiter">
        ///    The separator.
        ///    <para>Cannot be null or empty string.</para>
        ///    <para>The length cannot be greater than the length of the 'source' string.</para>
        /// </param>
        /// <param name="ignoreCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case insensitive.</para>
        ///    <para><c>false</c>: case sensitive.</para>
        ///    <para>Using the 'Ordinal/Binnary' comparison type by default which can be altered through the 'comparisonType' argument in other overloads.</para>
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
        public static ReadOnlySpan<string> SplitLeftOrdinalComparisonSpan(this string source, ReadOnlySpan<char> delimiter, bool ignoreCase)
        {
            return source.SplitLeftOrdinalComparisonSpan(delimiter, GetComparisonType(ignoreCase));
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
        ///    <para>Cannot be null or empty string.</para>
        ///    <para>The length cannot be greater than the length of the 'source' string.</para>
        /// </param>
        /// <param name="comparisonType">
        ///    Specifies the culture, case, and comparison rules to be used.
        ///    <para>The Default Value: <see cref="StringComparison.Ordinal"/>.</para>
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
        public static ReadOnlySpan<string> SplitLeftOrdinalComparisonSpan(this string source, ReadOnlySpan<char> delimiter, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.SplitLeftOrdinalComparisonSpan(delimiter, 0, source.Length - 1, comparisonType);
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
        ///    <para>Cannot be null or empty string.</para>
        ///    <para>The length cannot be greater than the length of the 'source' string.</para>
        /// </param>
        /// <param name="start">
        ///    The markIndex index in the specified 'source' string, where the split operation should markIndex.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        /// </param>
        /// <param name="ignoreCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case insensitive.</para>
        ///    <para><c>false</c>: case sensitive.</para>
        ///    <para>Using the 'Ordinal/Binnary' comparison type by default which can be altered through the 'comparisonType' argument in other overloads.</para>
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
        public static ReadOnlySpan<string> SplitLeftOrdinalComparisonSpan(this string source, ReadOnlySpan<char> delimiter, int start, bool ignoreCase)
        {
            return source.SplitLeftOrdinalComparisonSpan(delimiter, start, GetComparisonType(ignoreCase));
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
        ///    <para>Cannot be null or empty string.</para>
        ///    <para>The length cannot be greater than the length of the 'source' string.</para>
        /// </param>
        /// <param name="start">
        ///    The markIndex index in the specified 'source' string, where the split operation should markIndex.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        /// </param>
        /// <param name="comparisonType">
        ///    Specifies the culture, case, and comparison rules to be used.
        ///    <para>The Default Value: <see cref="StringComparison.Ordinal"/>.</para>
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
        public static ReadOnlySpan<string> SplitLeftOrdinalComparisonSpan(this string source, ReadOnlySpan<char> delimiter, int start, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.SplitLeftOrdinalComparisonSpan(delimiter, start, source.Length - 1, comparisonType);
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
        ///    <para>Cannot be null or empty string.</para>
        ///    <para>The length cannot be greater than the length of the 'source' string.</para>
        /// </param>
        /// <param name="start">
        ///    The markIndex index in the specified 'source' string, where the split operation should markIndex.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be equal or greater than the 'end' value.</para>
        /// </param>
        /// <param name="end">
        ///    The last index in the specified 'source' string, where the split operation should stop.
        ///    <para>Cannot be less than zero, unless the delimiter is just one character.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source', unless the delimiter is just one character.</para>
        ///    <para>Cannot be equal or less than the 'markIndex' value, unless the delimiter is just one character, then it would be acceptable to be equal to the 'markIndex' value.</para>
        /// </param>
        /// <param name="ignoreCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case insensitive.</para>
        ///    <para><c>false</c>: case sensitive.</para>
        ///    <para>Using the 'Ordinal/Binnary' comparison type by default which can be altered through the 'comparisonType' argument in other overloads.</para>
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
        public static ReadOnlySpan<string> SplitLeftOrdinalComparisonSpan(this string source, ReadOnlySpan<char> delimiter, int start, int end, bool ignoreCase)
        {
            return source.SplitLeftOrdinalComparisonSpan(delimiter, start, end, GetComparisonType(ignoreCase));
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
        ///    <para>Cannot be null or empty string.</para>
        ///    <para>The length cannot be greater than the length of the 'source' string.</para>
        /// </param>
        /// <param name="start">
        ///    The markIndex index in the specified 'source' string, where the split operation should markIndex.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be equal or greater than the 'end' value.</para>
        /// </param>
        /// <param name="end">
        ///    The last index in the specified 'source' string, where the split operation should stop.
        ///    <para>Cannot be less than zero, unless the delimiter is just one character.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source', unless the delimiter is just one character.</para>
        ///    <para>Cannot be equal or less than the 'markIndex' value, unless the delimiter is just one character, then it would be acceptable to be equal to the 'markIndex' value.</para>
        /// </param>
        /// <param name="comparisonType">
        ///    Specifies the culture, case, and comparison rules to be used.
        ///    <para>The Default Value: <see cref="StringComparison.Ordinal"/>.</para>
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
        public static ReadOnlySpan<string> SplitLeftOrdinalComparisonSpan(this string source, ReadOnlySpan<char> delimiter, int start, int end, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (delimiter == null)
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

            if (delimiter.Length == 0)
            {
                var argumentName = nameof(delimiter);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be empty string";
                var exceptionCode = ArgumentExceptionCode.EmptyString;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (delimiter.Length > source.Length)
            {
                var argumentName = nameof(delimiter);
                var conflictArgument = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The length of the '{argumentName}' argument cannot be greater than the length of the argument '{conflictArgument}'.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
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

            if (end <= 0 && delimiter.Length != 1)
            {
                var argumentName = nameof(end);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be lower than or equal zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (end > source.Length - 1 && delimiter.Length != 1)
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

            if (start > end || start >= end && delimiter.Length != 1)
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

            return SplitLeftOrdinalComparisonInternalSpan(source, delimiter, start, end, comparisonType);
        }

        #region Private Methods
        /// <summary>
        ///     Get the associated comparison type based on the case sensitivity decision.
        /// </summary>
        /// <param name="ignoreCase">If 'true', case insensitive, otherwise, case sensitive.</param>
        /// <returns>The associated comparison type based on the case sensitivity decision.</returns>
        private static StringComparison GetComparisonType(bool ignoreCase)
        {
            return ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
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
        ///    <para>Cannot be null or empty string.</para>
        ///    <para>The length cannot be greater than the length of the 'source' string.</para>
        /// </param>
        /// <param name="comparisonType">
        ///    Specifies the culture, case, and comparison rules to be used.
        ///    <para>The Default Value: <see cref="StringComparison.Ordinal"/>.</para>
        /// </param>
        /// <returns>Collection of split strings by a specific separator or 'null' if the 'delimiter' does not exist in the specified input source.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  11:41 AM</DateTime>
        /// </Created>
        private static ReadOnlySpan<string> SplitLeftOrdinalComparisonInternalSpanList(this ReadOnlySpan<char> source, ReadOnlySpan<char> delimiter, int start, int end, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (delimiter.Length == source.Length)
            {
                if (delimiter.Equals(source, comparisonType))
                {
                    return new string[] { string.Empty, string.Empty };
                }

                return new string[] { source.ToString() };
            }

            var array = new List<string>();
            var len = end - delimiter.Length + 1;

            //// ---------------------------------------------------------
            var markIndex = -1;
            var counter = 0;
            //// ---------------------------------------------------------
            for (var i = start; i <= len; i++)
            {
                var txtCut = source.Slice(i, delimiter.Length);
                if (txtCut.Equals(delimiter, comparisonType))
                {
                    counter++;

                    if (markIndex == -1)
                    {
                        if (i == 0)
                        {
                            array.Add(string.Empty);
                        }
                        else
                        {
                            array.Add(new string(source.SliceLeftSpanInternal(start, i - 1)));
                        }
                    }
                    else
                    {
                        array.Add(new string(source.Slice(markIndex, i - markIndex)));

                        if (i == len)
                        {
                            array.Add(string.Empty);
                        }
                    }

                    markIndex = i + delimiter.Length;
                    i += delimiter.Length - 1;
                }
            }

            if (array.Count == 0)
            {
                return new string[] { source.ToString() }; ;
            }

            if (counter == array.Count)
            {
                array.Add(new string(source.SliceLeftSpanInternal(markIndex, end)));
            }

            return array.ToArray();
        }

        private static ReadOnlySpan<string> SplitLeftOrdinalComparisonInternalSpan(this ReadOnlySpan<char> source, ReadOnlySpan<char> delimiter, int start, int end, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (delimiter.Length == source.Length)
            {
                if (delimiter.Equals(source, comparisonType))
                {
                    return new string[] { string.Empty, string.Empty };
                }

                return new string[] { source.ToString() };
            }

            Span<string> spanBank = new string[(source.Length / delimiter.Length) + 2];

            var len = end - delimiter.Length + 1;

            //// ---------------------------------------------------------
            var markIndex = -1;
            var counter = 0;
            var bankIndex = -1;
            //// ---------------------------------------------------------
            for (var i = start; i <= len; i++)
            {
                var txtCut = source.Slice(i, delimiter.Length);
                if (txtCut.Equals(delimiter, comparisonType))
                {
                    counter++;

                    if (markIndex == -1)
                    {
                        if (i == 0)
                        {
                            spanBank[++bankIndex] = string.Empty;
                        }
                        else
                        {
                            spanBank[++bankIndex] = new string(source.SliceLeftSpanInternal(start, i - 1));
                        }
                    }
                    else
                    {
                        spanBank[++bankIndex] = new string(source.Slice(markIndex, i - markIndex));

                        if (i == len)
                        {
                            spanBank[++bankIndex] = string.Empty;
                        }
                    }

                    markIndex = i + delimiter.Length;
                    // bankIndex++;
                    i += delimiter.Length - 1;
                }
            }

            if (bankIndex == -1)
            {
                return new string[] { source.ToString() };
            }

            if (counter == bankIndex + 1)
            {
                spanBank[++bankIndex] = new string(source.SliceLeftSpanInternal(markIndex, end));
            }

            return spanBank.Slice(0, bankIndex + 1);
        }

        /*
        private unsafe static ReadOnlySpan<string> SplitLeftUnsafeInternal(this ReadOnlySpan<char> source, ReadOnlySpan<char> delimiter, int start, int end, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (delimiter.Length == source.Length)
            {
                if (delimiter.Equals(source, comparisonType))
                {
                    return new string[] { string.Empty, string.Empty };
                }

                return new string[] { source.ToString() };
            }

            Span<string> spanBank = new string[(source.Length / delimiter.Length) + 2];
            Span<char> delSpan = stackalloc char[delimiter.Length];
            var len = end - delimiter.Length + 1;
            Span<char> txtCut = stackalloc char[len];
            //// ---------------------------------------------------------
            var markIndex = -1;
            var counter = -1;
            var bankIndex = -1;
            var txtCutCounter = -1;
            int delCounter = -1;
            //// ---------------------------------------------------------
            fixed (char* pt = source)
            {
                for (var i = start; i <= len; i++)
                {
                    if (delCounter < delimiter.Length - 1)
                    {
                        delSpan[++delCounter] = pt[i];
                        continue;
                    }
                    else
                    {
                        txtCut[++txtCutCounter] = pt[i];
                    }

                    
                    // var txtCut = source.Slice(i, delimiter.Length);
                    //if (delSpan.Equals(delimiter, comparisonType))
                    if (delimiter.Equals(delSpan, comparisonType))
                    {
                        delCounter = -1;
                        counter++;

                        if (markIndex == -1 && counter == 0)
                        {
                            spanBank[++bankIndex] = string.Empty;
                        }
                        else
                        {
                            spanBank[++bankIndex] = new string(txtCut.SliceLeftSpanInternal(0, txtCutCounter));

                            if (i == len)
                            {
                                spanBank[++bankIndex] = string.Empty;
                            }

                            txtCutCounter = -1;
                        }

                        markIndex = i;
                        // bankIndex++;
                    }

                    delSpan.Slice(1).CopyTo(delSpan);
                    delSpan[delSpan.Length - 1] = pt[i];
                }
            }

            if (bankIndex == -1)
            {
                return new string[] { source.ToString() };
            }

            if (counter == bankIndex + 1)
            {
                spanBank[++bankIndex] = new string(source.SliceLeftSpanInternal(markIndex, end));
            }

            return spanBank.Slice(0, bankIndex + 1);
        }
        */

        #endregion Private Methods
    }
}
