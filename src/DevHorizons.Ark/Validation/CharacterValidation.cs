// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.cs" company="Dev. Horizons - http://www.devhorizons.com">
//   Copyright (c) 2012 All Right Reserved
// </copyright>
// <summary>
//     Defines all the needed characters members.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>24/08/2010  10:22 AM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Ark.Validation
{
    using TurboCode;

    /// <summary>
    ///     Defines all the needed characters members.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>21/11/2012 05:50 PM</DateTime>
    /// </Created>
    public static class CharacterValidation
    {
        /// <summary>
        /// Determines whether the specified source is in lower case.
        /// </summary>
        /// <param name="source">The source character.</param>
        /// <returns>
        ///   <c>True</c> if the specified source is in lower case; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 01:57 PM</DateTime>
        /// </Created>
        public static bool IsLower(this char source)
        {
            return source == source.ToLower();
        }

        /// <summary>
        /// Determines whether the specified source is in upper case.
        /// </summary>
        /// <param name="source">The source character.</param>
        /// <returns>
        ///   <c>True</c> if the specified source is in upper case; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 01:57 PM</DateTime>
        /// </Created>
        public static bool IsUpper(this char source)
        {
            return source == source.ToUpper();
        }
    }
}

