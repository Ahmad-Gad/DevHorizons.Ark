// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PublicProperties.cs" company="Dev. Horizons - http://www.devhorizons.com">
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
        /// Gets the Carriage Return.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 01:02 PM</DateTime>
        /// </Created>
        public static string CrLf
        {
            get
            {
                /// var crlfChars = new char[2] { Character.Lf, Character.Cr };
                /// var crlfString = new string(crlfChars);
                var crlfString = string.Empty + Character.Lf + Character.Cr;
                return crlfString;
            }
        }

        /// <summary>
        ///     Gets the Horizontal Tab spaces value.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static string HorizontalTab
        {
            get
            {
                return new string(Character.HorizontalTab, 1);
            }
        }

        /// <summary>
        ///     Gets the white space string value.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>24/08/2022 08:12 PM</DateTime>
        /// </Created>
        public static string WhiteSpace
        {
            get
            {
                return new string(Character.WhiteSpace, 1);
            }
        }
    }
}
