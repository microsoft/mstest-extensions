// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;

    /// <summary>
    /// Represents an asserter for exceptions.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type">type</see> asserted <see cref="Exception">exception</see>.</typeparam>
    public class ExceptionAsserter<T> : Asserter where T : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionAsserter{T}"/> class.
        /// </summary>
        /// <param name="exception">The <typeparamref name="T">exception</typeparamref> to assert.</param>
        public ExceptionAsserter( T exception )
        {
            Arg.NotNull( exception, nameof( exception ) );
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception that was asserted.
        /// </summary>
        /// <value>An <typeparamref name="T">exception</typeparamref> object.</value>
        public T Exception { get; }
    }
}