
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
namespace DevHorizons.Ark.Dev.TurboCode
{
    using System.Diagnostics;
    using Exceptions;

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
        /// <param name="index">
        ///    Optional: The index of the generic element.
        ///    <para>It will be handy for the <see cref="IDictionary{TKey, TValue}"/> types.</para>
        ///    <para>Default Value: 0</para>
        /// </param>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <remarks>
        ///    Will throw '<see cref="ArgumentExceptionCode"/>' if the index is lower than zero.
        ///    <para>It will return 'null' if the index is out of range.</para>
        /// </remarks>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>
        ///    The generic type behind a collection.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static Type GetGenericType<T>(this ICollection<T> collecton, int index = 0)
        {
            if (index < 0)
            {
                var argumentName = nameof(index);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{index}' cannot be less than zero";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.InvalidValue;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            var type = collecton.GetType();
            if (type.IsArray && type.HasElementType)
            {
                return index > 0 ? null : type.GetElementType();
            }

            var genericElements = type.GenericTypeArguments;
            return index < genericElements.Length ? genericElements[index] : null;
        }

        /// <summary>
        ///    Determines the generic type behind of the element behind the specified generic object.
        /// </summary>
        /// <param name="obj">The specified object.</param>
        /// <param name="index">
        ///    Optional: The index of the generic element.
        ///    <para>It will be handy for the types which has more than one generic element/definition. E.g. <see cref="ILookup{TKey, TElement}"/>.</para>
        ///    <para>Default Value: 0</para>
        /// </param>
        /// <remarks>
        ///    Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.
        ///    Will throw '<see cref="ArgumentExceptionCode"/>' if the index is lower than zero.
        ///    <para>It will return 'null' if the specified object is not a generic type or the index is out of range.</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>
        ///    The generic type behind a collection.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static Type GetGenericType(this object obj, int index = 0)
        {
            if (index < 0)
            {
                var argumentName = nameof(index);
                var stackFrame = new StackFrame();
                var stackStrace = new StackTrace();
                var message = $"The input digital value of the argument '{index}' cannot be less than zero";
                var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.InvalidValue;
                var code = (long)exceptionCode;

                throw new ArgumentException(argumentName, exceptionCode, message, code, stackStrace, stackFrame);
            }

            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var type = obj.GetType();
            if (type.IsArray && type.HasElementType)
            {
                return index > 0 ? null : type.GetElementType();
            }

            return type.IsGenericType && index < type.GenericTypeArguments.Length ? type.GenericTypeArguments[index] : null;
        }
    }
}
