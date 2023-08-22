// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringValidation.cs" company="Dev. Horizons - http://www.devhorizons.com">
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
namespace DevHorizons.Ark.Validation
{
    using System.Diagnostics;
    using System.Globalization;

    using Exceptions;
    using TurboCode;
    using Validation;

    /// <summary>
    ///     Defines all the needed string's manipulation operations methods.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>30/06/2012  06:17 PM</DateTime>
    /// </Created>
    public static class StringValidation
    {

        /// <summary>
        ///    Determines whether the specified source is in lower case.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>
        ///   <c>True</c> if the specified source is in lower case; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 01:57 PM</DateTime>
        /// </Created>
        public static bool IsLower(this string source)
        {
            return source == source.ToLowerInvariant();
        }

        /// <summary>
        ///    Determines whether the specified source is in upper case.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>
        ///   <c>True</c> if the specified source is in upper case; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 01:57 PM</DateTime>
        /// </Created>
        public static bool IsUpper(this string source)
        {
            return source == source.ToUpperInvariant();
        }
      
    }
}
