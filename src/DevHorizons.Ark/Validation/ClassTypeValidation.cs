// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validation.cs" company="Dev. Horizons - http://www.devhorizons.com">
//   Copyright (c) 2023 All Right Reserved
// </copyright>
// <summary>
//     Defines all the needed extension methods required to validate the types or the values against certain types.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>18/08/2023 04:53 PM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------

namespace DevHorizons.Ark.Validation
{
    /// <summary>
    ///     Defines all the needed extension methods required to validate the types or the values against certain types.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>24/08/2022  10:11 PM</DateTime>
    /// </Created>
    public static class ClassTypeValidation
    {
        /// <summary>
        ///   Determines whether the specified type is a simple single value based type including <see cref="string"/>, <see cref="Guid"/> and enum declared types.
        /// </summary>
        /// <param name="type">The type to be verified.</param>
        /// <remarks>
        ///    User defined 'struct' types are excluded; which means, if the input value is a 'struct' type, the return value will be 'false'.
        /// </remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if the specified value is a simple value type which should be stored only on the stack partion of the memory; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsSimpleType(this Type type)
        {
            if (type == typeof(string) || type == typeof(Guid) || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(DateOnly) || type.IsEnum)
            {
                return true;
            }

            return type.IsValueType && type.IsPrimitive;
        }

        /// <summary>
        ///   Determines whether the specified value is a simple single value based type including <see cref="string"/>, <see cref="Guid"/> and enum declared types.
        /// </summary>
        /// <param name="value">The object to be verified.</param>
        /// <remarks>
        ///    Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.
        ///    <para>User defined 'struct' types are excluded; which means, if the input value is a 'struct' type, the return value will be 'false'.</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if the specified value is a simple value type which should be stored only on the stack partion of the memory; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsSimpleType(this object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var type = value.GetType();
            return type.IsSimpleType();
        }

        /// <summary>
        ///   Determines whether the specified type is a 'struct' type.
        /// </summary>
        /// <param name="type">The type to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is a struct; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsStruct(this Type type)
        {
            if (type == typeof(string) || type == typeof(Guid) || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(DateOnly) || type.IsEnum)
            {
                return false;
            }

            return type.IsValueType && !type.IsPrimitive;
        }

        /// <summary>
        ///   Determines whether the specified value is a 'struct' type.
        /// </summary>
        /// <param name="value">The value to be verified.</param>
        /// <remarks>Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if the specified value is a struct.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsStruct(this object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var type = value.GetType();

            return type.IsStruct();
        }

        /// <summary>
        ///    Determines whether the specified type is a composite valid to be serialized into <c>Json or Xml</c> string.
        /// </summary>
        /// <param name="type">
        ///    The type to be validated of being serialized into <c>Json or Xml</c> string.
        ///    <para>Accepted inputs: Classes, User Defined Strcutures, Arrays, Collections and Generic Collections.</para>
        /// </param>
        /// <returns>
        ///   <c>true</c> if [is structured type] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCompositeType(this Type type)
        {
            return !type.IsSimpleType();
        }

        /// <summary>
        ///    Determines whether the specified object is a composite valid to be serialized into <c>Json or Xml</c> string.
        /// </summary>
        /// <param name="value">
        ///    The object to be validated of being serialized into <c>Json or Xml</c> string.
        ///    <para>Accepted inputs: Classes, User Defined Strcutures, Arrays and Generic Collections.</para>
        /// </param>
        /// <remarks>Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if [is structured type] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCompositeType(this object value)
        {
            return !value.IsSimpleType();
        }

        /// <summary>
        ///    Determines whether the specified type is a generic collection.
        /// </summary>
        /// <param name="type">
        ///    The type to be validated of being a generic collection.
        /// </param>
        /// <remarks>The condition will be fulfilled if the type is implementing the '<see cref="ICollection{T}"/>' interface.</remarks>
        /// <returns>
        ///   <c>true</c> if collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsGenericCollection(this Type type)
        {
            if (!type.IsClass || type == typeof(string))
            {
                return false;
            }

            return type.GetInterfaces().Length != 0 && type.GetInterface(typeof(ICollection<>).FullName) != null;
        }

        /// <summary>
        ///    Determines whether the specified value is a generic collection.
        /// </summary>
        /// <param name="value">
        ///    The value to be validated of being a generic collection.
        /// </param>
        /// <remarks>
        ///    Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.
        ///    <para>The condition will be fulfilled if the input value's type is implementing the '<see cref="ICollection{T}"/>' interface.</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsGenericCollection(this object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var type = value.GetType();
            return type.IsGenericCollection();
        }

        /// <summary>
        ///    Determines whether the specified type is a collection.
        /// </summary>
        /// <param name="type">
        ///    The type to be validated of being a collection.
        /// </param>
        /// <remarks>The condition will be fulfilled if the type is implementing the '<see cref="System.Collections.ICollection"/>' interface.</remarks>
        /// <returns>
        ///   <c>true</c> if collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCollection(this Type type)
        {
            if (!type.IsClass || type == typeof(string))
            {
                return false;
            }

            return type.GetInterfaces().Length != 0 && type.GetInterface(typeof(System.Collections.ICollection).FullName) != null;
        }

        /// <summary>
        ///    Determines whether the specified value is a collection.
        /// </summary>
        /// <param name="value">
        ///    The value to be validated of being a collection.
        /// </param>
        /// <remarks>
        ///    Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.
        ///    <para>The condition will be fulfilled if the input value's type is implementing the '<see cref="System.Collections.ICollection"/>' interface.</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCollection(this object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value is System.Collections.ICollection;
        }

        /// <summary>
        ///    Determines whether the specified type is a collection (collection, generic collection or array).
        /// </summary>
        /// <param name="type">
        ///    The type to be validated of being a collection or generic collection.
        /// </param>
        /// <remarks>
        ///    The condition will be fulfilled if the input value's type is implementing either of the following two interfaces:
        ///    <para><see cref="System.Collections.ICollection"/></para>
        ///    <para><see cref="ICollection{T}"/></para>
        /// </remarks>
        /// <returns>
        ///   <c>true</c> if array, collection or generic collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCollectionOrGenericCollection(this Type type)
        {
            if (!type.IsClass || type == typeof(string))
            {
                return false;
            }

            var interfaces = type.GetInterfaces();
            if (interfaces.Length == 0)
            {
                return false;
            }

            var icolType = typeof(System.Collections.ICollection);
            var igcolType = typeof(ICollection<>);

            foreach (var iface in interfaces)
            {
                if (iface == icolType)
                {
                    return true;
                }

                if (iface.IsGenericType && iface.GetGenericTypeDefinition() == igcolType)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///    Determines whether the specified object is a collection (collection, generic collection or array).
        /// </summary>
        /// <param name="value">
        ///    The object to be validated of being a collection.
        /// </param>
        /// <remarks>
        ///    Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.
        ///    The condition will be fulfilled if the input value's type is implementing either of the following two interfaces:
        ///    <para><see cref="System.Collections.ICollection"/></para>
        ///    <para><see cref="ICollection{T}"/></para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCollectionOrGenericCollection(this object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value is System.Collections.ICollection)
            {
                return true;
            }

            var valueType = value.GetType();
            return valueType.IsGenericCollection();
        }

        /// <summary>
        ///    Determines whether the specified type is a type a single concrete class which can be instantiated.
        /// </summary>
        /// <param name="type">The type to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is an instance of a single class (if collection, it will return false); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsSingleConcreteClass(this Type type)
        {
            return type.IsClass && !type.IsCollectionOrGenericCollection() && !type.IsAbstract && type != typeof(string);
        }


        /// <summary>
        ///    Determines whether the specified object is instantiated from a single concrete class.
        /// </summary>
        /// <param name="value">
        ///    The object to be verified.
        /// </param>
        /// <remarks>Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if the specified object is an instance of a single class; otherwise, <c>false</c> (if collection, it will return false).
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsSingleConcreteClass(this object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var type = value.GetType();
            return type.IsSingleConcreteClass();
        }

        /// <summary>
        ///    Determines whether the specified collection is a collection of concrete class which can be instantiated.
        /// </summary>
        /// <param name="value">The object to be verified.</param>
        /// <remarks>Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if the specified object is a collection of concrete class which can be instantiated; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCollectionOfConcreteClass(this System.Collections.ICollection value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var type = value.GetType();
            if (type.HasElementType)
            {
                return type.GetElementType().IsSingleConcreteClass();
            }
            else if (type.GenericTypeArguments.Length == 1)
            {
                return type.GenericTypeArguments[0].IsSingleConcreteClass();
            }

            return false;
        }

        /// <summary>
        ///    Determines whether the specified collection is a collection of concrete class which can be instantiated.
        /// </summary>
        /// <param name="value">The object to be verified.</param>
        /// <remarks>Will throw '<see cref="ArgumentNullException"/>' exception if the input value is null.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if the specified object is a collection of concrete class which can be instantiated; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCollectionOfConcreteClass<T>(this ISet<T> value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.GetType().GenericTypeArguments[0].IsSingleConcreteClass();
        }
    }
}
