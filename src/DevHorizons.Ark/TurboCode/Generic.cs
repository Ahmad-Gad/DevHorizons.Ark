namespace DevHorizons.Ark.TurboCode
{
    public static class Generic
    {
        /// <summary>
        ///    Determines the generic type behind a collection. E.g. "<![CDATA[List<string>]]>" or "<![CDATA[string[]]]>" will return "string".
        /// </summary>
        /// <param name="collecton">The specified collection type.</param>
        /// <returns>
        ///    The generic type behind a collection.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static Type GetGenericType(this System.Collections.ICollection collecton)
        {
            return collecton.GetType().GenericTypeArguments[0];
        }
    }
}
