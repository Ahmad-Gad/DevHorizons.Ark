// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JCompare.cs" company="Dev. Horizons - http://www.devhorizons.com">
//   Copyright (c) 2012 All Right Reserved
// </copyright>
// <summary>
//     Defines all the needed extension methods required to compare between objects/values/items.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>24/08/2010  10:22 AM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Ark
{
    /// <summary>
    ///     Defines all the needed extension methods required to compare between objects/values/items.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>24/08/2022  10:11 PM</DateTime>
    /// </Created>
    public static class JCompare
    {
        /// <summary>
        ///    Compare two collections.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="source">The source collection to compare.</param>
        /// <param name="value">The second collection to compare to.</param>
        /// <returns><c>true</c> if all the items within the two collection are exactly matching; otherwise else, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>24/08/2022 10:21 PM</DateTime>
        /// </Created>
        public static bool CompareTo<T>(this IEnumerable<T> source, IEnumerable<T> value)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (source.Count() != value.Count())
            {
                return false;
            }

            var sourceCollection = source.ToList();
            var valueCollection = value.ToList();
            for (var i = 0; i < sourceCollection.Count; i++)
            {
                if (!sourceCollection[i].Equals(valueCollection[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
