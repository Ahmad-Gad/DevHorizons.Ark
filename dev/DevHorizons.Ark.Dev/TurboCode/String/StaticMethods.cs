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
        ///     Get a string of concatenated white spaces with based on a specific redundant count.
        /// </summary>
        /// <param name="redundantCount">The redundant count for the specified string concatenation.</param>
        /// <returns>Concatenated white spaces string based on a specific redundant count.</returns>
        /// <remarks>If the <c>redundantCount</c> value is lower than 1, it will return <c>null</c>.</remarks>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2022 02:38 PM</DateTime>
        /// </Created>
        public static string Space(int redundantCount)
        {
            return Repeat(Character.WhiteSpace, redundantCount);
        }

        /// <summary>
        ///     Get a string of concatenated white spaces with based on a specific redundant count.
        /// </summary>
        /// <param name="redundantCount">The redundant count for the specified string concatenation.</param>
        /// <returns>Concatenated white spaces string based on a specific redundant count.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>24/08/2022 07:10 PM</DateTime>
        /// </Created>
        public static string Tab(int redundantCount)
        {
            return Repeat(Character.HorizontalTab, redundantCount);
        }
    }
}
