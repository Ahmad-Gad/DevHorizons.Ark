﻿// --------------------------------------------------------------------------------------------------------------------
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
namespace DevHorizons.Ark.TurboCode
{
    using System.Diagnostics;
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

        #region Split to Collection of string Between Two Delimiters (Left Delimiter & Right Delimiter) As String
        /// <summary>
        ///     Split a single string into an array of string using two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        /// </param>
        /// <returns>Array of string from a single string using two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static List<string> SplitBiLeft(this string source, string leftDelimiter, string rightDelimiter, bool matchCase = true)
        {
            return source.SplitBiLeft(leftDelimiter, rightDelimiter, 0, matchCase);
        }


        /// <summary>
        ///     Split a single string into an array of string using two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        /// </param>
        /// <returns>Array of string from a single string using two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static List<string> SplitBiLeft(this string source, string leftDelimiter, string rightDelimiter, int start, bool matchCase = true)
        {
            return source.SplitBiLeft(leftDelimiter, rightDelimiter, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Split a single string into an array of string using two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        /// </param>
        /// <returns>Array of string from a single string using two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static List<string> SplitBiLeft(this string source, string leftDelimiter, string rightDelimiter, int start, int end, bool matchCase = true)
        {
            if (start < 0 || end <= 0 || start >= end || end > source.Length - 1)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length;

            var leftDel = leftDelimiter;
            var rightDel = rightDelimiter;
            var txt = source;

            if (matchCase == false)
            {
                leftDel = leftDelimiter.ToLower();
                rightDel = rightDelimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var array = new List<string>();
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = 0; i < len; i++)
            {
                if (leftDelimiter.Length + i <= txt.Length)
                {
                    var txtCutLeft = txt.Substring(i, leftDelimiter.Length);

                    if (txtCutLeft == leftDel)
                    {
                        start = i + leftDelimiter.Length;
                        i = start - 1;
                    }
                }

                if (start != -1)
                {
                    if (rightDelimiter.Length + i > txt.Length)
                    {
                        continue;
                    }

                    var txtCutRigh = txt.Substring(i, rightDelimiter.Length);

                    if (txtCutRigh == rightDel)
                    {
                        if (i == start)
                        {
                            array.Add(string.Empty);
                        }
                        else
                        {
                            end = i - 1;

                            array.Add(source.Slice(start, end));
                        }

                        start = -1;
                        i += rightDel.Length - 1;
                    }
                }
            }

            return array;
        }
        #endregion Split to Collection of string Between Two Delimiters (Left Delimiter & Right Delimiter) As String

        #region Split to Collection of string Between Two Delimiters (Left Delimiter & Right Delimiter) As Character

        /// <summary>
        ///     Split a string into an array using two character delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        /// </param>
        /// <returns>Array of string from a single string using two character delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static List<string> SplitLeft(this string source, char leftDelimiter, char rightDelimiter, bool matchCase = true)
        {
            return source.SplitLeft(leftDelimiter, rightDelimiter, 0, matchCase);
        }

        /// <summary>
        ///     Split a string into an array using two character delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        /// </param>
        /// <returns>Array of string from a single string using two character delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static List<string> SplitLeft(this string source, char leftDelimiter, char rightDelimiter, int start, bool matchCase = true)
        {
            return source.SplitLeft(leftDelimiter, rightDelimiter, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Split a string into an array using two character delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <param name="matchCase">
        ///    The matching case of comparing whether it's sensitive or insensitive.
        ///    <para><c>true</c>: case sensitive.</para>
        ///    <para><c>false</c>: case insensitive.</para>
        ///    <para> Default Value: <c>true</c>.</para>
        /// </param>
        /// <returns>Array of string from a single string using two character delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static List<string> SplitLeft(this string source, char leftDelimiter, char rightDelimiter, int start, int end, bool matchCase = true)
        {
            if (start < 0 || end <= 0 || start >= end || start >= source.Length || end >= source.Length)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length;

            var leftDel = leftDelimiter;
            var rightDel = rightDelimiter;
            var txt = source;

            if (matchCase == false)
            {
                leftDel = leftDelimiter.ToLower();
                rightDel = rightDelimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var array = new List<string>();
            start = -1;
            //// ---------------------------------------------------------
            for (var i = 0; i < len; i++)
            {

                if (start == -1)
                {
                    var txtCutLeft = txt[i];

                    if (txtCutLeft == leftDel)
                    {
                        start = i + 1;
                    }
                } 
                else
                {
                    var txtCutRigh = txt[i];

                    if (txtCutRigh == rightDel)
                    {
                        end = i - 1;
                        array.Add(source.Slice(start, end));
                        start = -1;
                    }
                }
            }

            return array;
        }
        #endregion Split to Collection of string Between Two Delimiters (Left Delimiter & Right Delimiter) As Character


        #region Left Side Split Between Two Delimiters
        #region Split Left a String Between Two Delimiters (Left Delimiter & Right Delimiter) As String
        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitLeft5(this string source, string leftDelimiter, string rightDelimiter, int index)
        {
            return SplitLeft5(source, leftDelimiter, rightDelimiter, index, true);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitLeft5(this string source, string leftDelimiter, string rightDelimiter, int index, bool matchCase)
        {
            return SplitLeft5(source, leftDelimiter, rightDelimiter, index, 0, source.Length - 1, matchCase);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitLeft5(this string source, string leftDelimiter, string rightDelimiter, int index, int start)
        {
            return SplitLeft5(source, leftDelimiter, rightDelimiter, index, start, source.Length - 1);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitLeft5(this string source, string leftDelimiter, string rightDelimiter, int index, int start, bool matchCase)
        {
            return SplitLeft5(source, leftDelimiter, rightDelimiter, index, start, source.Length - 1, matchCase);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitLeft5(this string source, string leftDelimiter, string rightDelimiter, int index, int start, int end)
        {
            return SplitLeft5(source, leftDelimiter, rightDelimiter, index, start, end, true);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitLeft5(this string source, string leftDelimiter, string rightDelimiter, int index, int start, int end, bool matchCase)
        {
            if (index < 0 || start < 0 || end <= 0 || index >= source.Length || start >= end || end > source.Length - 1)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length;

            var leftDel = leftDelimiter;
            var rightDel = rightDelimiter;
            var txt = source;

            if (matchCase == false)
            {
                leftDel = leftDelimiter.ToLower();
                rightDel = rightDelimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var counter = -1;
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = 0; i < len; i++)
            {
                if (leftDelimiter.Length + i <= txt.Length)
                {
                    var txtCutLeft = txt.Substring(i, leftDelimiter.Length);

                    if (txtCutLeft == leftDel)
                    {
                        start = i + leftDelimiter.Length;
                        i = start - 1;
                    }
                }

                if (start != -1)
                {
                    if (rightDelimiter.Length + i > txt.Length)
                    {
                        continue;
                    }

                    var txtCutRigh = txt.Substring(i, rightDelimiter.Length);

                    if (txtCutRigh == rightDel)
                    {
                        counter++;

                        if (counter == index)
                        {
                            if (i == start)
                            {
                                return string.Empty;
                            }

                            end = i - 1;
                            break;
                        }

                        start = -1;
                        i += rightDel.Length - 1;
                    }
                }
            }

            return source.Slice(start, end);
        }
        #endregion Split Left a String Between Two Delimiters (Left Delimiter & Right Delimiter) As String

        #region Split Left a String Between Two Delimiters (Left Delimiter & Right Delimiter) As Character
        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiLeft(this string source, char leftDelimiter, char rightDelimiter, int index)
        {
            return SplitBiLeft(source, leftDelimiter, rightDelimiter, index, true);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiLeft(this string source, char leftDelimiter, char rightDelimiter, int index, bool matchCase)
        {
            return SplitBiLeft(source, leftDelimiter, rightDelimiter, index, 0, source.Length - 1, matchCase);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiLeft(this string source, char leftDelimiter, char rightDelimiter, int index, int start)
        {
            return SplitBiLeft(source, leftDelimiter, rightDelimiter, index, start, source.Length - 1);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiLeft(this string source, char leftDelimiter, char rightDelimiter, int index, int start, bool matchCase)
        {
            return SplitBiLeft(source, leftDelimiter, rightDelimiter, index, start, source.Length - 1, matchCase);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiLeft(this string source, char leftDelimiter, char rightDelimiter, int index, int start, int end)
        {
            return SplitBiLeft(source, leftDelimiter, rightDelimiter, index, start, end, true);
        }

        /// <summary>
        /// Split starting from the left a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the left a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiLeft(this string source, char leftDelimiter, char rightDelimiter, int index, int start, int end, bool matchCase)
        {
            if (index < 0 || start < 0 || end <= 0 || index >= source.Length || start >= end || end > source.Length - 1)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length - 1;

            var leftDel = leftDelimiter;
            var rightDel = rightDelimiter;
            var txt = source;

            if (matchCase == false)
            {
                leftDel = leftDelimiter.ToLower();
                rightDel = rightDelimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var counter = -1;
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = 0; i < len; i++)
            {
                var txtCutLeft = txt[i];

                if (txtCutLeft == leftDel)
                {
                    start = i + 1;
                }

                if (start != -1)
                {
                    var txtCutRigh = txt[i];

                    if (txtCutRigh == rightDel)
                    {
                        counter++;

                        if (counter == index)
                        {
                            if (i == start)
                            {
                                return string.Empty;
                            }

                            end = i - 1;
                            break;
                        }

                        start = -1;
                    }
                }
            }

            return source.Slice(start, end);
        }
        #endregion Split Left a String Between Two Delimiters (Left Delimiter & Right Delimiter) As Character
        #endregion Left Side Split Between Two Delimiters
 

        #region Right Side Split
        #region Right Side Split With Single Delimiter
        #region Split Right With Delimiter As String
        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string).
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <returns>The split item based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, string delimiter, int index)
        {
            return SplitRight2(source, delimiter, index, 0, source.Length - 1, true);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string).
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The split item based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, string delimiter, int index, bool matchCase)
        {
            return SplitRight2(source, delimiter, index, 0, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string).
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <returns>The split item based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, string delimiter, int index, int start)
        {
            return SplitRight2(source, delimiter, index, start, source.Length - 1, true);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string).
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The split item based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, string delimiter, int index, int start, bool matchCase)
        {
            return SplitRight2(source, delimiter, index, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string).
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="end">The end index in the string, where the split operation should stop.</param>
        /// <returns>The split item based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, string delimiter, int index, int start, int end)
        {
            return SplitRight2(source, delimiter, index, start, end, true);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string).
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="end">The end index in the string, where the split operation should stop.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The split item based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, string delimiter, int index, int start, int end, bool matchCase)
        {
            if (index < 0 || start < 0 || end <= 0 || index >= source.Length || start >= end || end > source.Length - 1)
            {
                return null;
            }
            //// ---------------------------------------------------------
            source = source.Slice(start, end);
            var len = source.Length - delimiter.Length + 1;

            var del = delimiter;
            var txt = source;

            if (matchCase == false)
            {
                del = delimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var counter = -1;
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = len - 1; i >= 0; i--)
            {
                var txtCut = txt.Substring(i, delimiter.Length);
                if (txtCut == del)
                {
                    counter++;

                    if (index == 0 && counter == 0)
                    {
                        start = i + delimiter.Length;
                        end = source.Length;
                        break;
                    }
                    else if (counter == index - 1)
                    {
                        end = i;
                    }
                    else if (counter == index)
                    {
                        start = i + delimiter.Length;
                        break;
                    }

                    i -= delimiter.Length - 1;
                }
            }

            if (counter == -1 || index > counter + 1)
            {
                return null;
            }
            else if (index == counter + 1)
            {
                start = 0;
            }
            //// ---------------------------------------------------------

            return source.Substring(start, end - start);
        }
        #endregion Split Right With Delimiter As String

        #region Split Right With Delimiter As Character
        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string) based on a specific separator character.
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator character.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <returns>The split item based on the specified index and specific separator character.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, char delimiter, int index)
        {
            return SplitRight2(source, delimiter, index, 0, source.Length - 1, true);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string) based on a specific separator character.
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator character.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The split item based on the specified index and specific separator character.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, char delimiter, int index, bool matchCase)
        {
            return SplitRight2(source, delimiter, index, 0, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string) based on a specific separator character.
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator character.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <returns>The split item based on the specified index and specific separator character.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, char delimiter, int index, int start)
        {
            return SplitRight2(source, delimiter, index, start, source.Length - 1, true);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string) based on a specific separator character.
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator character.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The split item based on the specified index and specific separator character.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, char delimiter, int index, int start, bool matchCase)
        {
            return SplitRight2(source, delimiter, index, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string) based on a specific separator character.
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator character.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="end">The end index in the string, where the split operation should stop.</param>
        /// <returns>The split item based on the specified index and specific separator character.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, char delimiter, int index, int start, int end)
        {
            return SplitRight2(source, delimiter, index, start, end, true);
        }

        /// <summary>
        ///     Splits the specified source string by a specific separator; starting from the right side (end of the string) to the left side (beginning of the string) based on a specific separator character.
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator character.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="end">The end index in the string, where the split operation should stop.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The split item based on the specified index and specific separator character.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitRight2(this string source, char delimiter, int index, int start, int end, bool matchCase)
        {
            if (index < 0 || start < 0 || end <= 0 || index >= source.Length || start >= end || end > source.Length - 1)
            {
                return null;
            }
            //// ---------------------------------------------------------
            source = source.Slice(start, end);
            var len = source.Length;

            var del = delimiter;
            var txt = source;

            if (matchCase == false)
            {
                del = delimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var counter = -1;
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = len - 1; i >= 0; i--)
            {
                if (txt[i] == del)
                {
                    counter++;

                    if (index == 0 && counter == 0)
                    {
                        start = i + 1;
                        end = source.Length;
                        break;
                    }
                    else if (counter == index - 1)
                    {
                        end = i;
                    }
                    else if (counter == index)
                    {
                        start = i + 1;
                        break;
                    }
                }
            }

            if (counter == -1 || index > counter + 1)
            {
                return null;
            }
            else if (index == counter + 1)
            {
                start = 0;
            }
            //// ---------------------------------------------------------

            return source.Substring(start, end - start);
        }
        #endregion Split Right With Delimiter As Character
        #endregion Right Side Split With Single Delimiter

        #region Right Side Split Between Two Delimiters
        #region Split Right a String Between Two Delimiters (Left Delimiter & Right Delimiter) As String
        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, string leftDelimiter, string rightDelimiter, int index)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, true);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, string leftDelimiter, string rightDelimiter, int index, bool matchCase)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, 0, source.Length - 1, matchCase);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, string leftDelimiter, string rightDelimiter, int index, int start)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, start, source.Length - 1);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, string leftDelimiter, string rightDelimiter, int index, int start, bool matchCase)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, start, source.Length - 1, matchCase);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, string leftDelimiter, string rightDelimiter, int index, int start, int end)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, start, end, true);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, string leftDelimiter, string rightDelimiter, int index, int start, int end, bool matchCase)
        {
            if (index < 0 || start < 0 || end <= 0 || index >= source.Length || start >= end || end > source.Length - 1)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length - rightDelimiter.Length + 1;

            var leftDel = leftDelimiter;
            var rightDel = rightDelimiter;
            var txt = source;

            if (matchCase == false)
            {
                leftDel = leftDelimiter.ToLower();
                rightDel = rightDelimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var counter = -1;
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = len - 1; i >= 0; i--)
            {
                var txtCutRight = txt.Substring(i, rightDelimiter.Length);

                if (txtCutRight == rightDel)
                {
                    end = i - 1;
                    i = end;
                }

                if (end != -1)
                {
                    if (leftDelimiter.Length + i > txt.Length)
                    {
                        continue;
                    }

                    var txtCutLeft = txt.Substring(i, leftDelimiter.Length);

                    if (txtCutLeft == leftDel)
                    {
                        counter++;

                        if (counter == index)
                        {
                            if (i + leftDelimiter.Length - 1 == end)
                            {
                                return string.Empty;
                            }

                            start = i + leftDelimiter.Length;
                            break;
                        }

                        end = -1;
                        i -= rightDel.Length - 1;
                    }
                }
            }

            return source.Slice(start, end);
        }
        #endregion Split Right a String Between Two Delimiters (Left Delimiter & Right Delimiter) As String

        #region Split Right a String Between Two Delimiters (Left Delimiter & Right Delimiter) As Character
        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, char leftDelimiter, char rightDelimiter, int index)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, true);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, char leftDelimiter, char rightDelimiter, int index, bool matchCase)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, 0, source.Length - 1, matchCase);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, char leftDelimiter, char rightDelimiter, int index, int start)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, start, source.Length - 1);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, char leftDelimiter, char rightDelimiter, int index, int start, bool matchCase)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, start, source.Length - 1, matchCase);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, char leftDelimiter, char rightDelimiter, int index, int start, int end)
        {
            return SplitBiRight2(source, leftDelimiter, rightDelimiter, index, start, end, true);
        }

        /// <summary>
        /// Split starting from the right a string between two string delimiters.
        /// </summary>
        /// <param name="source">The source string to split.</param>
        /// <param name="leftDelimiter">The left delimiter.</param>
        /// <param name="rightDelimiter">The right delimiter.</param>
        /// <param name="index">The index of the split string.</param>
        /// <param name="start">The start position in the source string.</param>
        /// <param name="end">The end position in the source string.</param>
        /// <param name="matchCase">If set to <c>true</c>, split using the sensitive case search, otherwise, ignore the case.</param>
        /// <returns>A split string starting from the right a string between two string delimiters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>07/11/2012 02:39 PM</DateTime>
        /// </Created>
        public static string SplitBiRight2(this string source, char leftDelimiter, char rightDelimiter, int index, int start, int end, bool matchCase)
        {
            if (index < 0 || start < 0 || end <= 0 || index >= source.Length || start >= end || end > source.Length - 1)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length;

            var leftDel = leftDelimiter;
            var rightDel = rightDelimiter;
            var txt = source;

            if (matchCase == false)
            {
                leftDel = leftDelimiter.ToLower();
                rightDel = rightDelimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var counter = -1;
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = len - 1; i >= 0; i--)
            {
                var txtCutRight = txt[i];

                if (txtCutRight == rightDel)
                {
                    end = i - 1;
                }

                if (end != -1)
                {
                    var txtCutLeft = txt[i];

                    if (txtCutLeft == leftDel)
                    {
                        counter++;

                        if (counter == index)
                        {
                            start = i + 1;
                            break;
                        }

                        end = -1;
                    }
                }
            }

            return source.Slice(start, end);
        }
        #endregion Split Right a String Between Two Delimiters (Left Delimiter & Right Delimiter) As Character
        #endregion Right Side Split Between Two Delimiters
        #endregion Right Side Split

        #region SplitCut Right Side
        #region SplitCut Right Side With String Separator
        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, string delimiter, int index)
        {
            return SplitCutRight(source, delimiter, index, Direction.Left, true);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, string delimiter, int index, bool matchCase)
        {
            return SplitCutRight(source, delimiter, index, Direction.Left, matchCase);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, string delimiter, int index, Direction splitDirection)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, true);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, string delimiter, int index, Direction splitDirection, bool matchCase)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, 0, matchCase);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, string delimiter, int index, Direction splitDirection, int start)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, start, source.Length - 1);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, string delimiter, int index, Direction splitDirection, int start, bool matchCase)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="end">The end index in the string, where the split operation should stop.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, string delimiter, int index, Direction splitDirection, int start, int end)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, start, end, true);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="end">The end index in the string, where the split operation should stop.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, string delimiter, int index, Direction splitDirection, int start, int end, bool matchCase)
        {
            if (index < 0 || start < 0 || end <= 0 || index >= source.Length || start >= end || end > source.Length - 1)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length - delimiter.Length + 1;

            var del = delimiter;
            var txt = source;

            if (matchCase == false)
            {
                del = delimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var counter = -1;
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = len - 1; i >= 0; i--)
            {
                var txtCut = txt.Substring(i, delimiter.Length);
                if (txtCut == del)
                {
                    counter++;

                    if (counter == index - 1)
                    {
                        end = i - 1;
                    }
                    else if (counter == index)
                    {
                        start = i + delimiter.Length;
                        break;
                    }

                    i -= delimiter.Length + 1;
                }
            }

            if (counter == -1 || index > counter + 1)
            {
                return null;
            }

            if (counter != -1)
            {
                if (splitDirection == Direction.Left)
                {
                    if (start == -1 && end == -1)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        start = start == -1 ? 0 : start;
                        end = end == -1 ? end = source.Length - 1 : end;
                    }
                }
                else
                {
                    if (start == -1 && end == -1)
                    {
                        return source;
                    }
                }
            }

            if (splitDirection == Direction.Left)
            {
                start = 0;
            }
            else
            {
                end = source.Length - 1;
                if (end < start)
                {
                    return string.Empty;
                }
            }

            return source.Slice(start, end);
        }
        #endregion SplitCut Right Side With String Separator

        #region SplitCut Right Side With Character Separator
        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, char delimiter, int index)
        {
            return SplitCutRight(source, delimiter, index, Direction.Left, true);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, char delimiter, int index, bool matchCase)
        {
            return SplitCutRight(source, delimiter, index, Direction.Left, matchCase);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, char delimiter, int index, Direction splitDirection)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, true);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, char delimiter, int index, Direction splitDirection, bool matchCase)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, 0, matchCase);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, char delimiter, int index, Direction splitDirection, int start)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, start, source.Length - 1);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, char delimiter, int index, Direction splitDirection, int start, bool matchCase)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="end">The end index in the string, where the split operation should stop.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, char delimiter, int index, Direction splitDirection, int start, int end)
        {
            return SplitCutRight(source, delimiter, index, splitDirection, start, end, true);
        }

        /// <summary>
        ///     <para>Capturing part of a string after or before a specific separator based on the specified index.</para>
        ///     <para>The index direction should count from the right side (the end of the string).</para>
        /// </summary>
        /// <param name="source">The source string to be split.</param>
        /// <param name="delimiter">The separator.</param>
        /// <param name="index">The specified index for the split item.</param>
        /// <param name="splitDirection">
        ///     <para>The splitting direction:</para>
        ///     <para>[Left]: Capturing the text from the start index to the split index.</para>
        ///     <para>[Right]: Capturing the text from the split index to the end index.</para>
        /// </param>
        /// <param name="start">The start index in the string, where the split operation should start.</param>
        /// <param name="end">The end index in the string, where the split operation should stop.</param>
        /// <param name="matchCase">The matching case of comparing whether it's sensitive or insensitive.</param>
        /// <returns>The captured part of a string after or before a specific separator based on the specified index.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>01/07/2012  02:16 PM</DateTime>
        /// </Created>
        public static string SplitCutRight(this string source, char delimiter, int index, Direction splitDirection, int start, int end, bool matchCase)
        {
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

            if (index < 0)
            {
                var argumentName = nameof(index);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be lower than zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
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

            if (end <= 0)
            {
                var argumentName = nameof(end);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{argumentName}' cannot be lower than or equal zero.";
                var exceptionCode = ArgumentExceptionCode.OutRange;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (index >= source.Length)
            {
                var argumentName = nameof(index);
                var conflictArgument = nameof(source);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The '{argumentName}' cannot be greater than or equal to the length of the input string value of the argument '{conflictArgument}'.";
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


            if (start >= end)
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


            source = source.Slice(start, end);

            var len = source.Length;

            var del = delimiter;
            var txt = source;

            if (matchCase == false)
            {
                del = delimiter.ToLower();
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            var counter = -1;
            start = -1;
            end = -1;
            //// ---------------------------------------------------------
            for (var i = len - 1; i >= 0; i--)
            {
                var txtCut = txt[i];
                if (txtCut == del)
                {
                    counter++;

                    if (counter == index - 1)
                    {
                        end = i - 1;
                    }
                    else if (counter == index)
                    {
                        start = i + 1;
                        break;
                    }
                }
            }

            if (counter == -1 || index > counter + 1)
            {
                return null;
            }

            if (counter != -1)
            {
                if (splitDirection == Direction.Left)
                {
                    if (start == -1 && end == -1)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        start = start == -1 ? 0 : start;
                        end = end == -1 ? source.Length - 1 : end;
                    }
                }
                else
                {
                    if (start == -1 && end == -1)
                    {
                        return source;
                    }
                }
            }

            if (splitDirection == Direction.Left)
            {
                start = 0;
            }
            else
            {
                end = source.Length - 1;
                if (end < start)
                {
                    return string.Empty;
                }
            }

            return source.Slice(start, end);
        }
        #endregion SplitCut Right Side With Character Separator
        #endregion SplitCut Right Side





        #region Replace
        #region Single Replace
        #region Replace Strings
        /// <summary>
        ///     Replaces the specified old string value found any place in the specified source string with the new specified new string value.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="oldValue">The old string value to be replaced.</param>
        /// <param name="newValue">The replacement new string value.</param>
        /// <returns>The modified string with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, string oldValue, string newValue)
        {
            return source.Replace(oldValue, newValue, true);
        }

        /// <summary>
        ///     Replaces the specified old string value found any place in the specified source string with the new specified new string value.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="oldValue">The old string value to be replaced.</param>
        /// <param name="newValue">The replacement new string value.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, string oldValue, string newValue, bool matchCase)
        {
            return source.Replace(oldValue, newValue, 0, matchCase);
        }

        /// <summary>
        ///     Replaces the specified old string value found any place in the specified source string with the new specified new string value.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="oldValue">The old string value to be replaced.</param>
        /// <param name="newValue">The replacement new string value.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, string oldValue, string newValue, int start, bool matchCase)
        {
            return source.Replace(oldValue, newValue, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Replaces the specified old string value found any place in the specified source string with the new specified new string value.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="oldValue">The old string value to be replaced.</param>
        /// <param name="newValue">The replacement new string value.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <returns>The modified string with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, string oldValue, string newValue, int start)
        {
            return source.Replace(oldValue, newValue, start, source.Length - 1);
        }

        /// <summary>
        ///     Replaces the specified old string value found any place in the specified source string with the new specified new string value.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="oldValue">The old string value to be replaced.</param>
        /// <param name="newValue">The replacement new string value.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="end">The end index in the string, where the replace operation should stop.</param>
        /// <returns>The modified string with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, string oldValue, string newValue, int start, int end)
        {
            return source.Replace(oldValue, newValue, start, end, true);
        }

        /// <summary>
        ///     Replaces the specified old string value found any place in the specified source string with the new specified new string value.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="oldValue">The old string value to be replaced.</param>
        /// <param name="newValue">The replacement new string value.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="end">The end index in the string, where the replace operation should stop.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, string oldValue, string newValue, int start, int end, bool matchCase)
        {
            if (start < 0 || end <= 0 || start >= end || end > source.Length - 1)
            {
                return null;
            }

            var startPart = source.Slice(0, start - 1).ToStringOrEmptyString();
            var endPart = source.Slice(end + 1, source.Length - 1).ToStringOrEmptyString();
            var sourceSlice = source.Slice(start, end);

            var len = sourceSlice.Length;
            var searchString = oldValue;
            var txt = sourceSlice;
            var newString = string.Empty;

            if (matchCase == false)
            {
                txt = sourceSlice.ToLower();
                searchString = oldValue.ToLower();
            }

            //// ---------------------------------------------------------
            for (var i = 0; i < len; i++)
            {
                if (i + searchString.Length > len)
                {
                    newString += sourceSlice.Substring(i);
                    break;
                }

                var txtCut = txt.Substring(i, searchString.Length);
                if (txtCut == searchString)
                {
                    newString += newValue;
                    i += searchString.Length - 1;
                }
                else
                {
                    newString += sourceSlice[i];
                }
            }

            return startPart + newString + endPart;
        }
        #endregion Replace Strings

        #region Replace Characters
        /// <summary>
        ///     Replaces the specified old character value found any place in the specified source character with the new specified new character value.
        /// </summary>
        /// <param name="source">The character source to be modified.</param>
        /// <param name="oldValue">The old character value to be replaced.</param>
        /// <param name="newValue">The replacement new character value.</param>
        /// <returns>The modified character with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, char oldValue, char newValue)
        {
            return source.Replace(oldValue, newValue, true);
        }

        /// <summary>
        ///     Replaces the specified old character value found any place in the specified source character with the new specified new character value.
        /// </summary>
        /// <param name="source">The character source to be modified.</param>
        /// <param name="oldValue">The old character value to be replaced.</param>
        /// <param name="newValue">The replacement new character value.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified character with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, char oldValue, char newValue, bool matchCase)
        {
            return source.Replace(oldValue, newValue, 0, matchCase);
        }

        /// <summary>
        ///     Replaces the specified old character value found any place in the specified source character with the new specified new character value.
        /// </summary>
        /// <param name="source">The character source to be modified.</param>
        /// <param name="oldValue">The old character value to be replaced.</param>
        /// <param name="newValue">The replacement new character value.</param>
        /// <param name="start">The start index in the character, where the replace operation should start.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified character with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, char oldValue, char newValue, int start, bool matchCase)
        {
            return source.Replace(oldValue, newValue, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Replaces the specified old character value found any place in the specified source character with the new specified new character value.
        /// </summary>
        /// <param name="source">The character source to be modified.</param>
        /// <param name="oldValue">The old character value to be replaced.</param>
        /// <param name="newValue">The replacement new character value.</param>
        /// <param name="start">The start index in the character, where the replace operation should start.</param>
        /// <returns>The modified character with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, char oldValue, char newValue, int start)
        {
            return source.Replace(oldValue, newValue, start, source.Length - 1);
        }

        /// <summary>
        ///     Replaces the specified old character value found any place in the specified source character with the new specified new character value.
        /// </summary>
        /// <param name="source">The character source to be modified.</param>
        /// <param name="oldValue">The old character value to be replaced.</param>
        /// <param name="newValue">The replacement new character value.</param>
        /// <param name="start">The start index in the character, where the replace operation should start.</param>
        /// <param name="end">The end index in the character, where the replace operation should stop.</param>
        /// <returns>The modified character with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, char oldValue, char newValue, int start, int end)
        {
            return source.Replace(oldValue, newValue, start, end, true);
        }

        /// <summary>
        ///     Replaces the specified old character value found any place in the specified source character with the new specified new character value.
        /// </summary>
        /// <param name="source">The character source to be modified.</param>
        /// <param name="oldValue">The old character value to be replaced.</param>
        /// <param name="newValue">The replacement new character value.</param>
        /// <param name="start">The start index in the character, where the replace operation should start.</param>
        /// <param name="end">The end index in the character, where the replace operation should stop.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified character with the new values after the replace process.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, char oldValue, char newValue, int start, int end, bool matchCase)
        {
            if (start < 0 || end <= 0 || start >= end || end > source.Length - 1)
            {
                return source;
            }

            var sourceSlice = source.Slice(start, end);
            var startPart = source.Slice(0, start - 1).ToStringOrEmptyString();
            var endPart = source.Slice(end + 1, source.Length - 1).ToStringOrEmptyString();

            var len = sourceSlice.Length;
            var searchcharacter = oldValue;
            var txt = sourceSlice;
            var returnString = string.Empty;

            if (matchCase == false)
            {
                txt = sourceSlice.ToLower();
                searchcharacter = oldValue.ToLower();
            }

            //// ---------------------------------------------------------
            for (var i = 0; i < len; i++)
            {
                var txtCut = txt[i];
                if (txtCut == searchcharacter)
                {
                    returnString += newValue;
                }
                else
                {
                    returnString += sourceSlice[i];
                }
            }

            return startPart + returnString + endPart;
        }

        #endregion Replace Characters
        #endregion Single Replace

        #region Multiple Replace Using Dictionary
        #region Replace Strings
        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of strings.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of strings to used for the multi replace.</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of strings.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<string, string> dictionary)
        {
            return Replace(source, dictionary, true);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of strings.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of strings to used for the multi replace.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of strings.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<string, string> dictionary, bool matchCase)
        {
            return Replace(source, dictionary, 0, matchCase);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of strings.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of strings to used for the multi replace.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of strings.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<string, string> dictionary, int start)
        {
            return Replace(source, dictionary, start, true);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of strings.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of strings to used for the multi replace.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="end">The end index in the string, where the replace operation should stop.</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of strings.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<string, string> dictionary, int start, int end)
        {
            return Replace(source, dictionary, start, end, true);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of strings.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of strings to used for the multi replace.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of strings.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<string, string> dictionary, int start, bool matchCase)
        {
            return Replace(source, dictionary, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of strings.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of strings to used for the multi replace.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="end">The end index in the string, where the replace operation should stop.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of strings.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<string, string> dictionary, int start, int end, bool matchCase)
        {
            if (start < 0 || end <= 0 || start >= end || end > source.Length - 1)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length;
            var txt = source;
            var newString = string.Empty;

            if (matchCase == false)
            {
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            for (var i = 0; i < len; i++)
            {
                var found = false;

                foreach (var item in dictionary)
                {
                    var key = matchCase ? item.Key : item.Key.ToLower();
                    var value = item.Value;
                    if (key.Length + i <= txt.Length)
                    {
                        var txtCut = txt.Substring(i, key.Length);
                        if (txtCut == key)
                        {
                            found = true;
                            newString += value;
                            i += key.Length - 1;
                            break;
                        }
                    }
                }

                if (found == false)
                {
                    newString += source[i];
                }
            }

            return newString;
        }
        #endregion Replace Strings

        #region Replace Characters
        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of characters.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of characters to used for the multi replace.</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of characters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<char, char> dictionary)
        {
            return Replace(source, dictionary, true);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of characters.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of characters to used for the multi replace.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of characters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<char, char> dictionary, bool matchCase)
        {
            return Replace(source, dictionary, 0, matchCase);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of characters.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of characters to used for the multi replace.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of characters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<char, char> dictionary, int start)
        {
            return Replace(source, dictionary, start, true);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of characters.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of characters to used for the multi replace.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="end">The end index in the string, where the replace operation should stop.</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of characters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<char, char> dictionary, int start, int end)
        {
            return Replace(source, dictionary, start, end, true);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of characters.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of characters to used for the multi replace.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of characters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<char, char> dictionary, int start, bool matchCase)
        {
            return Replace(source, dictionary, start, source.Length - 1, matchCase);
        }

        /// <summary>
        ///     Replaces multiple strings with multiple values based on the specified dictionary of characters.
        /// </summary>
        /// <param name="source">The source string to be modified.</param>
        /// <param name="dictionary">The dictionary of characters to used for the multi replace.</param>
        /// <param name="start">The start index in the string, where the replace operation should start.</param>
        /// <param name="end">The end index in the string, where the replace operation should stop.</param>
        /// <param name="matchCase">If set to <c>true</c> comparing in sensitive case (Same as Binary Search), otherwise else; comparing in insensitive case same as (Same as Text Search).</param>
        /// <returns>The modified string that had a replacing operations with multiple strings with multiple values based on the specified dictionary of characters.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 04:25 PM</DateTime>
        /// </Created>
        public static string Replace(this string source, Dictionary<char, char> dictionary, int start, int end, bool matchCase)
        {
            if (start < 0 || end <= 0 || start >= end || end > source.Length - 1)
            {
                return null;
            }

            source = source.Slice(start, end);

            var len = source.Length;
            var txt = source;
            var newString = string.Empty;

            if (matchCase == false)
            {
                txt = source.ToLower();
            }

            //// ---------------------------------------------------------
            for (var i = 0; i < len; i++)
            {
                var found = false;

                foreach (var item in dictionary)
                {
                    var key = matchCase ? item.Key : item.Key.ToLower();
                    var value = item.Value;

                    var txtCut = txt[i];
                    if (txtCut == key)
                    {
                        found = true;
                        newString += value;
                        break;
                    }
                }

                if (found == false)
                {
                    newString += source[i];
                }
            }

            return newString;
        }
        #endregion Replace Characters
        #endregion Multiple Replace Using Dictionary
        #endregion Replace

   

        #region Trim
        /*
        private static string TrimStart(this string source, string trimString)
        {
            // ToDO
            return null;
        }

        private static string TrimEnd(this string source, string trimString)
        {
            // ToDO
            return null;
        }

        private static string TrimStart(this string source, string trimString, int count)
        {
            // ToDO
            return null;
        }

        private static string TrimEnd(this string source, string trimString, int count)
        {
            // ToDO
            return null;
        }

        private static string TrimStart(this string source, string trimString, bool matchCase)
        {
            // ToDO
            return null;
        }

        private static string TrimEnd(this string source, string trimString, bool matchCase)
        {
            // ToDO
            return null;
        }

        private static string TrimStart(this string source, string trimString, bool matchCase, int count)
        {
            // ToDO
            return null;
        }

        private static string TrimEnd(this string source, string trimString, bool matchCase, int count)
        {
            // ToDO
            return null;
        }
        */
        #endregion Trim

        //#region Metadata
        ///// <summary>
        /////     Gets the first single name of a specific object.
        ///// </summary>
        ///// <param name="source">The source.</param>
        ///// <returns>The first single name of a specific object.</returns>
        ///// <Created>
        /////     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        /////     <DateTime>23/08/2013 02:07 PM</DateTime>
        ///// </Created>
        //public static string GetObjectName(this object source)
        //{
        //    var type = source.GetType();
        //    var name = type.Name;
        //    return source.GetType().ToString().SplitRight('.', 0);
        //}

        ///// <summary>
        /////     Gets the first single name of a specific Generic Type.
        ///// </summary>
        ///// <typeparam name="T">A specific Generic Type.</typeparam>
        ///// <param name="source">The source.</param>
        ///// <returns>The first single name of a specific Generic Type.</returns>
        ///// <Created>
        /////     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        /////     <DateTime>23/08/2013 02:07 PM</DateTime>
        ///// </Created>
        //public static string GetGenericTypeName<T>(this IEnumerable<T> source)
        //{
        //    return typeof(T).ToString().SplitRight('.', 0);
        //}
        //#endregion Metadata
    }
}
