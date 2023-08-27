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
    public class DetailedException: Exception, IDetailedException
    {
        public DetailedException(string message, long code, StackTrace stackTraceObject, StackFrame stackFrame, string argumentName, Exception innerException) : base(message, innerException)
        {
            this.Code = code;
            this.DateTime = DateTime.UtcNow;
            this.Origin = new ExceptionSource
            {
                Assembly = System.Reflection.Assembly.GetExecutingAssembly().FullName,
                Class = stackFrame.GetMethod().DeclaringType.FullName,
                Method = stackFrame.GetMethod().Name,
                Argument = argumentName
            };

            this.StackTraceObject = stackTraceObject;
            this.StackFrame = stackFrame;

        }

        // : this(message, code, stackTraceObject, stackFrame, innerException)
        public DetailedException(string message, long code, StackTrace stackTraceObject, StackFrame stackFrame, Exception innerException) : this(message, code, stackTraceObject, stackFrame, null, innerException)
        {           
        }


        public DetailedException(string message, long code, StackTrace stackTraceObject, StackFrame stackFrame, string argumentName) : this(message, code, stackTraceObject, stackFrame, argumentName, null)
        {
        }


        /// <summary>
        ///    The exception's code.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        public long Code { get; private set; }

        /// <summary>
        ///    The exception's UTC date/time.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        public DateTime DateTime { get; private set; }

        /// <summary>
        ///    The exception's source details.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        public ExceptionSource Origin { get; private set; }

        /// <summary>
        ///    The origin stack trace object.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        public StackTrace StackTraceObject { get; private set; }

        /// <summary>
        ///    Provides information about the origin Stack Frame, which represents a function call on the call stack for the current thread.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>18/08/2023 04:53 PM</DateTime>
        /// </Created>
        public StackFrame StackFrame { get; private set; }
    }
}
