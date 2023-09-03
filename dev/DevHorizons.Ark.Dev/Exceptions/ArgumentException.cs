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


    /// <summary>
    ///    Defines all required detailed properties for Dev. Horizons' inner exceptions.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>18/08/2023 04:53 PM</DateTime>
    /// </Created>
    public class ArgumentException : DetailedException
    {
        public ArgumentException(string argumentName, ArgumentExceptionCode exceptionCode, string message, long code, StackTrace stackTraceObject, StackFrame stackFrame, string conflictArguement, Exception innerException = null) : base(message, code, stackTraceObject, stackFrame, argumentName, innerException)
        {
            this.ExceptionCode = exceptionCode;
            this.ConflictArguement = conflictArguement;
        }


        public ArgumentException(string argumentName, ArgumentExceptionCode exceptionCode, string message, long code, StackTrace stackTraceObject, StackFrame stackFrame, Exception innerException = null) : this(argumentName, exceptionCode, message, code, stackTraceObject, stackFrame, null, innerException)
        {
        }

        public ArgumentExceptionCode ExceptionCode { get; private set; }

        public string? ConflictArguement { get; private set; }
    }
}
