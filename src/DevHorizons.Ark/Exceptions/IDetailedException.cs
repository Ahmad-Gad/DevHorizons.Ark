// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDetailedException.cs" company="Dev. Horizons - http://www.devhorizons.com">
//   Copyright (c) 2023 All Right Reserved
// </copyright>
// <summary>
//     Defines all required detailed properties for Dev. Horizons' inner exceptions.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>18/08/2023 04:53 PM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.Ark.Exceptions
{
    using System.Diagnostics;
    using System.Runtime.Serialization;

    /// <summary>
    ///    Defines all required detailed properties for Dev. Horizons' inner exceptions.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>18/08/2023 04:53 PM</DateTime>
    /// </Created>
    public interface IDetailedException: ISerializable
    {
        /// <summary>
        ///    The exception's code.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        long Code { get; }

        /// <summary>
        ///    The exception's date/time.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        DateTime DateTime { get; }

        /// <summary>
        ///    The exception's source details.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        ExceptionSource Origin { get; }

        /// <summary>
        ///    The origin stack trace object.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        StackTrace StackTraceObject { get; }

        /// <summary>
        ///    Provides information about the origin Stack Frame, which represents a function call on the call stack for the current thread.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        StackFrame StackFrame { get; }
    }
}
