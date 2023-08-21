
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Generic.cs" company="Dev. Horizons - http://www.devhorizons.com">
//   Copyright (c) 2012 All Right Reserved
// </copyright>
// <summary>
//     Defines all the needed extension methods required for the generic types.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>24/08/2010  10:22 AM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Ark.TurboCode
{
    /// <summary>
    ///    Defines all the needed extension methods required for the generic types.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>24/08/2022  10:11 PM</DateTime>
    /// </Created>

    public static class Generic
    {
        /// <summary>
        ///    Determines the generic type behind a collection. E.g. "<![CDATA[List<string>]]>" or "<![CDATA[string[]]]>" will return "string".
        /// </summary>
        /// <param name="collecton">The specified collection type.</param>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <returns>
        ///    The generic type behind a collection.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static Type GetGenericType<T>(this ICollection<T> collecton)
        {
            return collecton.GetType().GenericTypeArguments[0];
        }
    }
}
