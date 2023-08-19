// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Direction.cs" company="Dev. Horizons - http://www.devhorizons.com">
//   Copyright (c) 2010 All Right Reserved
// </copyright>
// <summary>
//   Defines all possible directions for the engine to start processing a string by either manipulation or searching.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>24/08/2010  10:22 AM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------

namespace DevHorizons.Ark
{
    /// <summary>
    ///     The start position of a specific string manipulation/search.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///    <DateTime>30/06/2012  04:23 PM</DateTime>
    /// </Created>
    public enum Direction
    {
        /// <summary>
        ///     The left position.
        /// </summary>
        Left = -1,

        /// <summary>
        ///     The right position.
        /// </summary>
        Right = 1
    }

}
