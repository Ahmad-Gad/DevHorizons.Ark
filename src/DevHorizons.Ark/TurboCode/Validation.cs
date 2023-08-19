namespace DevHorizons.Ark.TurboCode
{
    using System.Reflection;

    public static class Validation
    {
        /// <summary>
        ///   Determines whether the specified type is a simple single value based type including <see cref="string"/>, <see cref="Guid"/> and enum declared types.
        /// </summary>
        /// <param name="type">The type to be verified.</param>
        /// <remarks>If null, will throuw exception.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if the specified value is a simple value type which should be stored only on the stack partion of the memory.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsSimpleType(this Type type)
        {
            if (type == typeof(string) || type == typeof(Guid) || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(DateOnly))
            {
                return true;
            }

            return type.IsValueType && (type.IsEnum || type.IsPrimitive);
        }

        /// <summary>
        ///   Determines whether the specified value is a simple single value based type including <see cref="string"/>, <see cref="Guid"/> and enum declared types.
        /// </summary>
        /// <param name="value">The object to be verified.</param>
        /// <remarks>If null, will throuw exception.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        ///   <c>true</c> if the specified value is a simple value type which should be stored only on the stack partion of the memory.
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
        ///    Determines whether the specified type is a composite valid to be serialized into <c>Json or Xml</c> string.
        /// </summary>
        /// <param name="type">
        ///    The type to be validated of being serialized into <c>Json or Xml</c> string.
        ///    <para>Accepted inputs: Classes, User Defined Strcutures, Arrays and Generic Collections.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// <returns>
        ///   <c>true</c> if collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsGenericCollection(this Type type)
        {
            return type.GetInterfaces().Length != 0 && type.GetInterface((typeof(ICollection<>)).FullName) != null;
        }

        /// <summary>
        ///    Determines whether the specified value is a generic collection.
        /// </summary>
        /// <param name="value">
        ///    The value to be validated of being a generic collection.
        /// </param>
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
        ///    Determines whether the specified value is a collection.
        /// </summary>
        /// <param name="value">
        ///    The value to be validated of being a collection.
        /// </param>
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

            var type = value.GetType();
            return type.IsCollection();
        }

        /// <summary>
        ///    Determines whether the specified type is a collection (collection, generic collection or array).
        /// </summary>
        /// <param name="type">
        ///    The type to be validated of being a collection or generic collection.
        /// </param>
        /// <returns>
        ///   <c>true</c> if collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCollectionOrGenericCollection(this Type type)
        {
            return type.IsCollection() || type.IsGenericCollection();
        }

        /// <summary>
        ///    Determines whether the specified object is a collection (collection, generic collection or array).
        /// </summary>
        /// <param name="value">
        ///    The object to be validated of being a collection.
        /// </param>
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

            var valueType = value.GetType();
            return valueType.IsCollectionOrGenericCollection();
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

        // --------------------------------------------------------------------------------------------------

        /// <summary>
        ///    Determines whether the specified property type is a concrete class which can be instantiated.
        /// </summary>
        /// <remarks>This could be single class or collection.</remarks>
        /// <param name="prop">The propery to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified propery is a concrete class which can be instantiated (either single class or collection); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClass(this MemberInfo prop)
        {
            if (prop == null)
            {
                return false;
            }

            var type = prop.MemberType.GetType();

            if (type.IsGenericType)
            {
                return type.GenericTypeArguments[0].IsSingleConcreteClass();
            }
            else if (type.HasElementType)
            {
                return type.GetElementType().IsSingleConcreteClass();
            }

            return type.IsClass && !type.IsAbstract && type != typeof(string);
        }

        /// <summary>
        ///    Determines whether the specified type is a concrete class which can be instantiated.
        /// </summary>
        /// <remarks>This could be single class or collection.</remarks>
        /// <param name="type">The type to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is a concrete class which can be instantiated (either single class or collection); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClass(this Type type)
        {
            if (type.IsGenericType)
            {
                return type.GenericTypeArguments[0].IsSingleConcreteClass();
            }
            else if (type.HasElementType)
            {
                return type.GetElementType().IsSingleConcreteClass();
            }

            return type.IsClass && !type.IsAbstract && type != typeof(string);
        }

        /// <summary>
        ///    Determines whether the specified object is concrete class which can be instantiated.
        /// </summary>
        /// <remarks>This could be single class or collection.</remarks>
        /// <param name="obj">The object to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is a concrete class which can be instantiated (either single class or collection); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClass(this object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var type = obj.GetType();
            return type.IsConcreteClass();
        }


        /// <summary>
        ///    Determines whether the specified collection is a collection of concrete class which can be instantiated.
        /// </summary>
        /// <param name="obj">The object to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is a collection of concrete class which can be instantiated; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClassCollection(this object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not System.Collections.ICollection)
            {
                return false;
            }

            var type = obj.GetType();
            if (type.IsGenericCollection())
            {
                return obj.GetType().GenericTypeArguments[0].IsSingleConcreteClass();
            }
            else
            {
                return obj.GetType().GetElementType().IsSingleConcreteClass();
            }
        }


        /// <summary>
        ///    Determines whether the specified type is a collection of concrete class which can be instantiated.
        /// </summary>
        /// <param name="type">The type to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is a collection of concrete class which can be instantiated; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClassCollection(this Type type)
        {
            return type.IsGenericCollection() && type.GenericTypeArguments[0].IsSingleConcreteClass();
        }

    }
}
