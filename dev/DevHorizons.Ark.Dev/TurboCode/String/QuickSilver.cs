﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
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
        ///    Retrieves a sub-string from this instance based on the specified startIndex position from the right until the end of the string (the left).
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="startIndex">
        ///    The startIndex/first index/position from the right in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A sub-string from this instance based on the specified startIndex position from the right and the specified length.
        /// </returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///    The zero-based index is the first charcter from the right side of the string.
        ///    <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///    <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///    <para>If the input source is an empty string and both startIndex and end are equal to zero, then the return would be empty string, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        ///    <para>The Arabic text already starts from right to left. So, if your intention is to deal with Arabic letters from right to left, then use the out-of-the-box "Substring" extension method.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        public static string CutRight(this string source, int startIndex)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (startIndex < 0)
            {
                var argumentName = nameof(startIndex);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be lower than zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (startIndex > source.Length - 1 && startIndex != 0)
            {
                var argumentName = nameof(startIndex);
                var conflictArgument = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The '{argumentName}' cannot be greater than the upper bound index of the string value of the argument '{conflictArgument}'.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }


            return source.CutRightInternal(startIndex);
        }

        /// <summary>
        ///    Retrieves a sub-string from this instance based on the specified startIndex position from the right and the specified length.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="startIndex">
        ///    The startIndex/first index/position from the right in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="length">
        ///    The length of the string to cut.
        ///    <para>Cannot be less than 0.</para>
        ///    <para>Cannot be greater than the length the string value of the argument 'source'.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        ///    <para>Will return empty strin if assigned to zero.</para>
        /// </param>
        /// <returns>
        ///    A sub-string from this instance based on the specified startIndex position from the right and the specified length.
        /// </returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///    The zero-based index is the first charcter from the right side of the string.
        ///    <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///    <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///    <para>If the input source is an empty string and both startIndex and end are equal to zero, then the return would be empty string, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        ///    <para>The Arabic text already starts from right to left. So, if your intention is to deal with Arabic letters from right to left, then use the out-of-the-box "Substring" extension method.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        public static string CutRight(this string source, int startIndex, int length)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (startIndex < 0)
            {
                var argumentName = nameof(startIndex);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be lower than zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (length < 0)
            {
                var argumentName = nameof(length);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be lower than zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (startIndex > source.Length - 1 && startIndex != 0)
            {
                var argumentName = nameof(startIndex);
                var conflictArgument = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The '{argumentName}' cannot be greater than the upper bound index of the string value of the argument '{conflictArgument}'.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }

            if (startIndex + length > source.Length)
            {
                var argumentName = nameof(startIndex);
                var conflictArgument = nameof(length);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The value of the '{argumentName}' plus the value of the argument '{conflictArgument}' cannot be greater than the length of the input source.";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame, conflictArgument);
            }


            return source.CutRightInternal(startIndex, length);
        }

        /// <summary>
        ///    Slices the specified source from left to right where the base zero index is the first character in from the left side of the string.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="start">
        ///    The startIndex/first index/position from the left in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="end">
        ///    The last index/position from the left in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be less than the 'startIndex' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A slice of string (from the left to the right) which has specific startIndex index and specific end index within the string length.
        /// </returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///     <para>If the input source is an empty string and both startIndex and end are equal to zero, then the return would be empty string, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        public static string SliceLeft(this string source, int start, int end)
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

            return source.SliceLeftInternal(start, end);
        }

        /// <summary>
        ///    Slices the specified source from right to left where the base zero index is the first character in from the right side of the string.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="start">
        ///    The startIndex/first index/position from the right in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="end">
        ///    The last index/position from the right in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be less than the 'startIndex' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A slice of string (from the right to the left) which has specific startIndex index and specific end index within the string length.
        /// </returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <remarks>
        ///     <para>The zero-based index is the first charcter from the right side of the string.</para>
        ///     <para>Will throw '<see cref="ArgumentNullException"/>' if the input/source is null.</para>
        ///     <para>Will throw '<see cref="ArgumentException"/>' if the specified arguments are out of range or specified with unexpected/invalid values.</para>
        ///     <para>If the input source is an empty string and both startIndex and end are equal to zero, then the return would be empty string, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        ///     <para>The Arabic text already starts from right to left. So, if your intention is to deal with Arabic letters from right to left, then use the "<see cref="SliceLeft(string, int, int)"/>" extension method.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        public static string SliceRight(this string source, int start, int end)
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

            return source.SliceRightInternal(start, end);
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
        ///    <para>The Arabic text already starts from right to left. So, if your intention is to deal with Arabic letters from right to left, then use the "<see cref="Left(string, int)"/>" extension method.</para>
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

            if (source.Length == 1)
            {
                return source.ToUpper(culture);
            }

            source = source.ToLower(culture);
            var strBuilder = new StringBuilder(source[0].ToUpper(culture).ToString(), source.Length);


            for (int i = 1; i < source.Length; i++)
            {
                var ascii = source[i - 1];

                if (!((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122) || (ascii >= 48 && ascii <= 57) || ascii == Character.SingleQuote))
                {
                    strBuilder.Append(source[i].ToUpper(culture));
                }
                else
                {
                    strBuilder.Append(source[i]);
                }
            }

            return strBuilder.ToString(); ;
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

            if (culture == null)
            {
                culture = CultureInfo.InvariantCulture;
            }

            if (source.Length == 1)
            {
                return source.IsUpper(culture) ? source.ToLower(culture) : source.ToUpper(culture);
            }

            var strBuilder = new StringBuilder(source.Length);

            foreach (char chr in source)
            {
                strBuilder.Append(chr.IsUpper() ? chr.ToLower(culture) : chr.ToUpper(culture));
            }

            return strBuilder.ToString();
        }

        #region Internal Functions
        /// <summary>
        ///    Slices the specified source from left to right where the base zero index is the first character in from the left side of the string.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="start">
        ///    The startIndex/first index/position from the left in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="end">
        ///    The last index/position from the left in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be less than the 'startIndex' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A slice of string (from the left to the right) which has specific startIndex index and specific end index within the string length.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        internal static string SliceLeftInternal(this string source, int start, int end)
        {
            return source.Substring(start, end - start + 1);
        }

        /// <summary>
        ///    Slices the specified source from left to right where the base zero index is the first character in from the left side of the string.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="start">
        ///    The startIndex/first index/position from the left in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="end">
        ///    The last index/position from the left in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be less than the 'startIndex' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A slice of string (from the left to the right) which has specific startIndex index and specific end index within the string length.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        internal static ReadOnlySpan<char> SliceLeftInternalToSpan(this string source, int start, int end)
        {
            return source.AsSpan().Slice(start, end - start + 1);
        }

        /// <summary>
        ///    Slices the specified source from left to right where the base zero index is the first character in from the left side of the string.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="start">
        ///    The startIndex/first index/position from the left in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="end">
        ///    The last index/position from the left in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be less than the 'startIndex' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A slice of string (from the left to the right) which has specific startIndex index and specific end index within the string length.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        internal static ReadOnlySpan<char> SliceLeftSpanInternal(this ReadOnlySpan<char> source, int start, int end)
        {
            return source.Slice(start, end - start + 1);
        }

        internal static ReadOnlySpan<char> SliceLeftSpanInternal(this Span<char> source, int start, int end)
        {
            return source.Slice(start, end - start + 1);
        }

        internal static ReadOnlyMemory<char> SliceLeftMemoryInternal(this ReadOnlyMemory<char> source, int start, int end)
        {
            return source.Slice(start, end - start + 1);
        }

        /// <summary>
        ///    Slices the specified source from right to left where the base zero index is the first character in from the right side of the string.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="start">
        ///    The startIndex/first index/position from the right in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="end">
        ///    The last index/position from the right in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be less than the 'startIndex' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A slice of string (from the right to the left) which has specific startIndex index and specific end index within the string length.
        /// </returns>
        /// <remarks>
        ///     The zero-based index is the first charcter from the right side of the string.
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        internal static string SliceRightInternal(this string source, int start, int end)
        {
            var upperBound = source.Length - 1;
            return source.SliceLeftInternal(upperBound - end, upperBound - start);
        }

        /// <summary>
        ///    Retrieves a sub-string from this instance based on the specified startIndex position from the right until the end of the string (the left).
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="startIndex">
        ///    The startIndex/first index/position from the right in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <returns>
        ///    A sub-string from this instance based on the specified startIndex position from the right and the specified length.
        /// </returns>
        /// <remarks>
        ///    The zero-based index is the first charcter from the right side of the string.
        ///    <para>The Arabic text already starts from right to left. So, if your intention is to deal with Arabic letters from right to left, then use the out-of-the-box "Substring" extension method.</para>
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        public static string CutRightInternal(this string source, int startIndex)
        {
            return source.Substring(0, source.Length - startIndex);
        }

        /// <summary>
        ///    Retrieves a sub-string from this instance based on the specified startIndex position from the right and the specified length.
        /// </summary>
        /// <param name="source">
        ///     The input source string.
        ///     <para>Cannot be null.</para>
        ///     <para>Can be empty string however, both startIndex and end must be zero, otherwise, the '<see cref="ArgumentException"/>' will be thrown.</para>
        /// </param>
        /// <param name="startIndex">
        ///    The startIndex/first index/position from the right in the specified 'source' string to slice.
        ///    <para>Cannot be less than zero.</para>
        ///    <para>Cannot be greater than the upper bound index of the string value of the argument 'source'.</para>
        ///    <para>Cannot be greater than the 'end' value.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        /// </param>
        /// <param name="length">
        ///    The length of the string to cut.
        ///    <para>Cannot be less than 0.</para>
        ///    <para>Cannot be greater than the length the string value of the argument 'source'.</para>
        ///    <para>If the input source is an empty string, then the only value is accepted is zero.</para>
        ///    <para>Will return empty strin if assigned to zero.</para>
        /// </param>
        /// <returns>
        ///    A sub-string from this instance based on the specified startIndex position from the right and the specified length.
        /// </returns>
        /// <remarks>
        ///    The zero-based index is the first charcter from the right side of the string.
        /// </remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>15/07/2012  01:17 AM</DateTime>
        /// </Created>
        internal static string CutRightInternal(this string source, int startIndex, int length)
        {
            return source.Substring(source.Length - startIndex - length, length);
        }
        #endregion Internal Functions
    }
}