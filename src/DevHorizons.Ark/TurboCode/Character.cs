﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.cs" company="Dev. Horizons - http://www.devhorizons.com">
//   Copyright (c) 2012 All Right Reserved
// </copyright>
// <summary>
//     Defines all the needed characters members.
// </summary>
// <Created>
//     <Author>Ahmad Adel Gad(ahmad.adel@devhorizons.com)</Author>
//     <DateTime>24/08/2010  10:22 AM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Ark
{
    /// <summary>
    ///     Defines all the needed characters members.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
    ///     <DateTime>21/11/2012 05:50 PM</DateTime>
    /// </Created>
    public static class Character
    {
        #region Public Properties
        /// <summary>
        ///     Gets the Null Char (<![CDATA[0]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Null
        {
            get
            {
                return '\0';

            }
        }

        /// <summary>
        ///     Gets the white space value <![CDATA[( )]]>.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char WhiteSpace
        {
            get
            {
                return Convert.ToChar(32);
            }
        }

        /// <summary>
        ///    Gets the Carriage Return (<![CDATA["\n"]]>).
        ///    <para>ASCII Code: 10</para>
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 01:02 PM</DateTime>
        /// </Created>
        public static char Cr
        {
            get
            {
                return Convert.ToChar(10);
            }
        }

        /// <summary>
        ///    Gets the Line Feed (<![CDATA[\r]]>).
        ///    <para>ASCII Code: 13</para>
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 01:02 PM</DateTime>
        /// </Created>
        public static char Lf
        {
            get
            {
                return Convert.ToChar(13);
            }
        }

        /// <summary>
        ///     Gets the Horizontal Tab spaces value <![CDATA[(      )]]>.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char HorizontalTab
        {
            get
            {
                return Convert.ToChar(9);
            }
        }

        /// <summary>
        ///     Gets the Single Quote (<![CDATA[']]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char SingleQuote
        {
            get
            {
                return Convert.ToChar(39);
            }
        }

        /// <summary>
        ///     Gets the Double Quotes (<![CDATA["]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char DoubleQuotes
        {
            get
            {
                return Convert.ToChar(34);
            }
        }

        /// <summary>
        ///     Gets the Opening Brace (Left Brace) (<![CDATA[{]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char OpeningBrace
        {
            get
            {
                return Convert.ToChar(123);
            }
        }

        /// <summary>
        ///     Gets the Closing Brace (Right Brace) (<![CDATA[}]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char ClosingBrace
        {
            get
            {
                return Convert.ToChar(125);
            }
        }

        /// <summary>
        ///     Gets the Slash (<![CDATA[/]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Slash
        {
            get
            {
                return Convert.ToChar(47);
            }
        }

        /// <summary>
        ///     Gets the Back Slash (<![CDATA[\]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char BackSlash
        {
            get
            {
                return Convert.ToChar(92);
            }
        }

        /// <summary>
        ///     Gets the Colon (<![CDATA[:]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Colon
        {
            get
            {
                return Convert.ToChar(58);
            }
        }

        /// <summary>
        ///     Gets the Colon (<![CDATA[;]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char SemiColon
        {
            get
            {
                return Convert.ToChar(59);
            }
        }

        /// <summary>
        ///     Gets the Vertical Bar (<![CDATA[|]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char VerticalBar
        {
            get
            {
                return Convert.ToChar(124);
            }
        }

        /// <summary>
        ///     Gets the Equals (<![CDATA[=]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static new char Equals
        {
            get
            {
                return Convert.ToChar(61);
            }
        }

        /// <summary>
        ///     Gets the Exclamation Mark (<![CDATA[!]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char ExclamationMark
        {
            get
            {
                return Convert.ToChar(33);
            }
        }

        /// <summary>
        ///     Gets the HashSign (<![CDATA[#]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char HashSign
        {
            get
            {
                return Convert.ToChar(35);
            }
        }

        /// <summary>
        ///     Gets the Equivalency Sign (<![CDATA[~]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char EquivalencySign
        {
            get
            {
                return Convert.ToChar(126);
            }
        }

        /// <summary>
        ///     Gets the Dollar Sign (<![CDATA[$]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char DollarSign
        {
            get
            {
                return Convert.ToChar(36);
            }
        }

        /// <summary>
        ///     Gets the Percent Sign (<![CDATA[%]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char PercentSign
        {
            get
            {
                return Convert.ToChar(37);
            }
        }

        /// <summary>
        ///     Gets the Ampersand (<![CDATA[&]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Ampersand
        {
            get
            {
                return Convert.ToChar(38);
            }
        }

        /// <summary>
        ///     Gets the Asterisk (<![CDATA[*]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Asterisk
        {
            get
            {
                return Convert.ToChar(42);
            }
        }

        /// <summary>
        ///     Gets the Plus (<![CDATA[+]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Plus
        {
            get
            {
                return Convert.ToChar(43);
            }
        }

        /// <summary>
        ///     Gets the Comma (<![CDATA[,]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Comma
        {
            get
            {
                return Convert.ToChar(44);
            }
        }

        /// <summary>
        ///     Gets the Hyphen (<![CDATA[-]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Hyphen
        {
            get
            {
                return Convert.ToChar(45);
            }
        }

        /// <summary>
        ///     Gets the Period (<![CDATA[.]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Period
        {
            get
            {
                return Convert.ToChar(46);
            }
        }

        /// <summary>
        ///     Gets the Question Mark (<![CDATA[?]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char QuestionMark
        {
            get
            {
                return Convert.ToChar(63);
            }
        }

        /// <summary>
        ///     Gets the At Sign (<![CDATA[@]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char AtSign
        {
            get
            {
                return Convert.ToChar(64);
            }
        }

        /// <summary>
        ///     Gets the Circumflex/Caret (<![CDATA[^]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char Circumflex
        {
            get
            {
                return Convert.ToChar(94);
            }
        }

        /// <summary>
        ///     Gets the Under-Score (<![CDATA[_]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char UnderScore
        {
            get
            {
                return Convert.ToChar(95);
            }
        }

        /// <summary>
        ///     Gets the Grave Accent (<![CDATA[`]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char GraveAccent
        {
            get
            {
                return Convert.ToChar(96);
            }
        }

        /// <summary>
        ///     Gets the Opening Square Bracket (<![CDATA[[]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char OpeningSquareBracket
        {
            get
            {
                return Convert.ToChar(91);
            }
        }

        /// <summary>
        ///     Gets the Closing Square Bracket (<![CDATA[]]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char ClosingSquareBracket
        {
            get
            {
                return Convert.ToChar(93);
            }
        }

        /// <summary>
        ///     Gets the Opening Bracket (<![CDATA[(]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char OpeningBracket
        {
            get
            {
                return Convert.ToChar(40);
            }
        }

        /// <summary>
        ///     Gets the Closing Bracket (<![CDATA[)]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char ClosingBracket
        {
            get
            {
                return Convert.ToChar(41);
            }
        }

        /// <summary>
        ///     Gets the Less Than (<![CDATA[<]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char LessThan
        {
            get
            {
                return Convert.ToChar(60);
            }
        }

        /// <summary>
        ///     Gets the Greater Than (<![CDATA[>]]>).
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>12/11/2012 02:34 PM</DateTime>
        /// </Created>
        public static char GreaterThan
        {
            get
            {
                return Convert.ToChar(62);
            }
        }

        /// <summary>
        ///     Gets the Euro sign/symbol (<![CDATA[€]]>).
        ///     <para>ASCII Code: 8364</para>
        ///     <para>HEX Code: 20AC</para>
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>24/08/2022 08:25 PM</DateTime>
        /// </Created>
        public static char EuroSign
        {
            get
            {
                return Convert.ToChar('\u20AC');
            }
        }
        #endregion Public Properties

        #region Public Methods
        #region Validation

        /// <summary>
        /// Determines whether the specified source is in lower case.
        /// </summary>
        /// <param name="source">The source character.</param>
        /// <returns>
        ///   <c>True</c> if the specified source is in lower case; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
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
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>13/11/2012 01:57 PM</DateTime>
        /// </Created>
        public static bool IsUpper(this char source)
        {
            return source == source.ToUpper();
        }
        #endregion Validation

        #region Convert
        /// <summary>
        ///      Converts to "char" from a valid "object".
        /// </summary>
        /// <param name="source">The source object to be converted.</param>
        /// <returns>Valid "char" value</returns>
        /// <Created>
        ///     <Author>Ahmad Adel Gad(ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>30/06/2012  05:55 PM</DateTime>
        /// </Created>
        public static char ToChar(this object source)
        {
            return Convert.ToChar(source.ToString());
        }

        /// <summary>
        ///      Converts to "char" from a valid "object".
        /// </summary>
        /// <param name="source">The source object to be converted.</param>
        /// <param name="defaultValue">The default return (replacement) value in case if the conversion operation failed.</param>
        /// <returns>Valid "char" value</returns>
        /// <Created>
        ///     <Author>Ahmad Adel Gad(ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>30/06/2012  05:55 PM</DateTime>
        /// </Created>
        public static char ToChar(this object source, char defaultValue)
        {
            try
            {
                return Convert.ToChar(source.ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///      Gets ASCII code as "Integer" from a valid "char" data type.
        /// </summary>
        /// <param name="source">The source character to be converted.</param>
        /// <returns>Valid ASCII code ("Integer")</returns>
        /// <Created>
        ///     <Author>Ahmad Adel Gad(ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>30/06/2012  05:55 PM</DateTime>
        /// </Created>
        public static int GetAsciiCode(this char source)
        {
            return Convert.ToInt32(source);
        }
        /// <summary>
        ///     Converts a character to the upper case.
        /// </summary>
        /// <param name="source">The source character.</param>
        /// <returns>Character with upper case.</returns>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>20/10/2012 01:32 PM</DateTime>
        /// </Created>
        public static char ToUpper(this char source)
        {
            return Convert.ToChar(source.ToString().ToUpperInvariant());
        }

        /// <summary>
        ///     Converts a character to the lower case.
        /// </summary>
        /// <param name="source">The source character.</param>
        /// <returns>Character with lowered case.</returns>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>20/10/2012 01:32 PM</DateTime>
        /// </Created>
        public static char ToLower(this char source)
        {
            return Convert.ToChar(source.ToString().ToLowerInvariant());
        }
        #endregion Convert
        #endregion Public Methods

    }
}

