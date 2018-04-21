// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Linq.Expressions;
    using static FailedTestMessage;

    /// <summary>
    /// Provides assertion support for <see cref="Exception">exceptions</see>.
    /// </summary>
    public static class ExceptionAsserterExtensions
    {
        /// <summary>
        /// Asserts the specified verification on the provided exception.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="Exception">exception</see> to verify.</typeparam>
        /// <param name="assert">The <see cref="ExceptionAsserter{T}">asserted exception</see> to verify.</param>
        /// <param name="verification">The verification <see cref="Func{T1,TResult}">function</see>.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <remarks>This method can be used to verify post exception results and behaviors such as exception properties.</remarks>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='Verify`1']/example[1]" />
        public static ExceptionAsserter<TException> Verify<TException>( this ExceptionAsserter<TException> assert, Func<TException, bool> verification ) where TException : Exception =>
            assert.Verify( verification, default( string ) );

        /// <summary>
        /// Asserts the specified verification on the provided exception.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="Exception">exception</see> to verify.</typeparam>
        /// <param name="assert">The <see cref="ExceptionAsserter{T}">asserted exception</see> to verify.</param>
        /// <param name="verification">The verification <see cref="Func{T1,TResult}">function</see>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <remarks>This method can be used to verify post exception results and behaviors such as exception properties.</remarks>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='Verify`1']/example[2]" />
        public static ExceptionAsserter<TException> Verify<TException>( this ExceptionAsserter<TException> assert, Func<TException, bool> verification, string message, params object[] parameters ) where TException : Exception
        {
            Arg.NotNull( assert, nameof( assert ) );
            Contract.Ensures( Contract.Result<ExceptionAsserter<TException>>() != null );

            assert.AssertParameterIsNotNull( verification, nameof( verification ) );
            assert.IsTrue( verification( assert.Exception ), message, parameters );

            return assert;
        }

        /// <summary>
        /// Asserts the specified test method throws an exception of any type.
        /// </summary>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Action"/> representing the test method.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='Throws']/example[1]" />
        public static ExceptionAsserter<Exception> Throws( this Asserter assert, Action testMethod ) => assert.Throws( testMethod, ExceptionNotThrown );

        /// <summary>
        /// Asserts the specified test method throws an exception of any type.
        /// </summary>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Action"/> representing the test method.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='Throws']/example[2]" />
        public static ExceptionAsserter<Exception> Throws( this Asserter assert, Action testMethod, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );
            Contract.Ensures( Contract.Result<ExceptionAsserter<Exception>>() != null );

            assert.AssertParameterIsNotNull( testMethod, nameof( testMethod ) );

            try
            {
                testMethod();
            }
            catch ( Exception ex )
            {
                return new ExceptionAsserter<Exception>( ex );
            }

            assert.Fail( message, parameters );
            return default( ExceptionAsserter<Exception> );
        }

        /// <summary>
        /// Asserts the specified test method throws an exception of the specified type.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type"/> of <see cref="ArgumentException"/> that should be thrown.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Action"/> representing the test method.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='Throws`1']/example[1]" />
        public static ExceptionAsserter<TException> Throws<TException>( this Asserter assert, Action testMethod ) where TException : Exception =>
            assert.Throws<TException>( testMethod, ExceptionOfTNotThrown, typeof( TException ) );

        /// <summary>
        /// Asserts the specified test method throws an exception of the specified type.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type"/> of <see cref="ArgumentException"/> that should be thrown.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Action"/> representing the test method.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='Throws`1']/example[2]" />
        public static ExceptionAsserter<TException> Throws<TException>( this Asserter assert, Action testMethod, string message, params object[] parameters ) where TException : Exception
        {
            Arg.NotNull( assert, nameof( assert ) );
            Contract.Ensures( Contract.Result<ExceptionAsserter<TException>>() != null );

            assert.AssertParameterIsNotNull( testMethod, nameof( testMethod ) );

            var exceptionType = typeof( TException );

            try
            {
                testMethod();
            }
            catch ( TException ex )
            {
                assert.AreEqual( exceptionType, ex.GetType(), WrongException, exceptionType, ex.GetType() );
                return new ExceptionAsserter<TException>( ex );
            }
            catch ( Exception ex )
            {
                assert.AreEqual( exceptionType, ex.GetType(), WrongException, exceptionType, ex.GetType() );
            }

            assert.Fail( message, parameters );
            return null;
        }

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see>.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Action"/> representing the test method.</param>
        /// <param name="paramName">The name of the parameter expected to throw an exception.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsForArgument`1']/example[1]" />
        public static ExceptionAsserter<TException> ThrowsForArgument<TException>( this Asserter assert, Action testMethod, string paramName ) where TException : ArgumentException =>
            assert.ThrowsForArgument<TException>( testMethod, paramName, ExceptionOfTNotThrown, typeof( TException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see>.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Action"/> representing the test method.</param>
        /// <param name="paramName">The name of the parameter expected to throw an exception.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsForArgument`1']/example[2]" />
        public static ExceptionAsserter<TException> ThrowsForArgument<TException>( this Asserter assert, Action testMethod, string paramName, string message, params object[] parameters ) where TException : ArgumentException
        {
            Arg.NotNull( assert, nameof( assert ) );
            Contract.Ensures( Contract.Result<ExceptionAsserter<TException>>() != null );

            assert.AssertParameterIsNotNull( testMethod, nameof( testMethod ) );

            var assertion = assert.Throws<TException>( testMethod, message, parameters );
            var actualParam = assertion.Exception.ParamName;

            assert.AreEqual( paramName, actualParam, WrongParameterName, paramName, actualParam );

            return assertion;
        }

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentNullException">argument null exception</see> if the supplied parameter is empty.
        /// </summary>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsEmpty']/example[1]" />
        public static ExceptionAsserter<ArgumentNullException> ThrowsIfArgumentIsEmpty( this Asserter assert, Expression<Action<string>> testMethod ) =>
            assert.ThrowsIfArgumentIs<string, ArgumentNullException>( testMethod, string.Empty, ExceptionOfTNotThrown, typeof( ArgumentNullException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentNullException">argument null exception</see> if the supplied parameter is empty.
        /// </summary>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsEmpty']/example[2]" />
        public static ExceptionAsserter<ArgumentNullException> ThrowsIfArgumentIsEmpty( this Asserter assert, Expression<Action<string>> testMethod, string message, params object[] parameters ) =>
            assert.ThrowsIfArgumentIs<string, ArgumentNullException>( testMethod, string.Empty, message, parameters );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see> if the supplied parameter is empty.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsEmpty`1']/example[1]" />
        public static ExceptionAsserter<TException> ThrowsIfArgumentIsEmpty<TException>( this Asserter assert, Expression<Action<string>> testMethod ) where TException : ArgumentException =>
            assert.ThrowsIfArgumentIs<string, TException>( testMethod, string.Empty, ExceptionOfTNotThrown, typeof( TException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see> if the supplied parameter is empty.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsEmpty`1']/example[2]" />
        public static ExceptionAsserter<TException> ThrowsIfArgumentIsEmpty<TException>( this Asserter assert, Expression<Action<string>> testMethod, string message, params object[] parameters ) where TException : ArgumentException =>
            assert.ThrowsIfArgumentIs<string, TException>( testMethod, string.Empty, message, parameters );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentNullException">argument null exception</see> if the supplied parameter is whitespace.
        /// </summary>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsWhiteSpace']/example[1]" />
        public static ExceptionAsserter<ArgumentNullException> ThrowsIfArgumentIsWhiteSpace( this Asserter assert, Expression<Action<string>> testMethod ) =>
            assert.ThrowsIfArgumentIs<string, ArgumentNullException>( testMethod, " ", ExceptionOfTNotThrown, typeof( ArgumentNullException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentNullException">argument null exception</see> if the supplied parameter is whitespace.
        /// </summary>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsWhiteSpace']/example[2]" />
        public static ExceptionAsserter<ArgumentNullException> ThrowsIfArgumentIsWhiteSpace( this Asserter assert, Expression<Action<string>> testMethod, string message, params object[] parameters ) =>
            assert.ThrowsIfArgumentIs<string, ArgumentNullException>( testMethod, " ", message, parameters );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see> if the supplied parameter is whitespace.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsWhiteSpace`1']/example[1]" />
        public static ExceptionAsserter<TException> ThrowsIfArgumentIsWhiteSpace<TException>( this Asserter assert, Expression<Action<string>> testMethod ) where TException : ArgumentException =>
            assert.ThrowsIfArgumentIs<string, TException>( testMethod, " ", ExceptionOfTNotThrown, typeof( TException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see> if the supplied parameter is whitespace.
        /// </summary>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsWhiteSpace`1']/example[2]" />
        public static ExceptionAsserter<TException> ThrowsIfArgumentIsWhiteSpace<TException>( this Asserter assert, Expression<Action<string>> testMethod, string message, params object[] parameters ) where TException : ArgumentException =>
            assert.ThrowsIfArgumentIs<string, TException>( testMethod, " ", message, parameters );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentNullException">argument null exception</see> if the supplied parameter is null.
        /// </summary>
        /// <typeparam name="TArg">The <see cref="Type">type</see> of parameter to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsNull`1']/example[1]" />
        public static ExceptionAsserter<ArgumentNullException> ThrowsIfArgumentIsNull<TArg>( this Asserter assert, Expression<Action<TArg>> testMethod ) where TArg : class =>
            assert.ThrowsIfArgumentIs<TArg, ArgumentNullException>( testMethod, null, ExceptionOfTNotThrown, typeof( ArgumentNullException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentNullException">argument null exception</see> if the supplied parameter is null.
        /// </summary>
        /// <typeparam name="TArg">The <see cref="Type">type</see> of parameter to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsNull`1']/example[2]" />
        public static ExceptionAsserter<ArgumentNullException> ThrowsIfArgumentIsNull<TArg>( this Asserter assert, Expression<Action<TArg>> testMethod, string message, params object[] parameters ) where TArg : class =>
            assert.ThrowsIfArgumentIs<TArg, ArgumentNullException>( testMethod, null, message, parameters );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see> if the supplied parameter is null.
        /// </summary>
        /// <typeparam name="TArg">The <see cref="Type">type</see> of parameter to test.</typeparam>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsNull`2']/example[1]" />
        public static ExceptionAsserter<TException> ThrowsIfArgumentIsNull<TArg, TException>( this Asserter assert, Expression<Action<TArg>> testMethod )
            where TArg : class
            where TException : ArgumentException =>
            assert.ThrowsIfArgumentIs<TArg, TException>( testMethod, null, ExceptionOfTNotThrown, typeof( TException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see> if the supplied parameter is null.
        /// </summary>
        /// <typeparam name="TArg">The <see cref="Type">type</see> of parameter to test.</typeparam>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsNull`2']/example[2]" />
        public static ExceptionAsserter<TException> ThrowsIfArgumentIsNull<TArg, TException>( this Asserter assert, Expression<Action<TArg>> testMethod, string message, params object[] parameters )
            where TArg : class
            where TException : ArgumentException =>
            assert.ThrowsIfArgumentIs<TArg, TException>( testMethod, null, message, parameters );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentOutOfRangeException">argument out of range exception</see> if the supplied parameter is out of range.
        /// </summary>
        /// <typeparam name="TArg">The <see cref="Type">type</see> of parameter to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="value">The <typeparamref name="TArg">value</typeparamref> that should cause the exception to be thrown.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsOutOfRange`1']/example[1]" />
        public static ExceptionAsserter<ArgumentOutOfRangeException> ThrowsIfArgumentIsOutOfRange<TArg>( this Asserter assert, Expression<Action<TArg>> testMethod, TArg value ) =>
            assert.ThrowsIfArgumentIs<TArg, ArgumentOutOfRangeException>( testMethod, value, ExceptionOfTNotThrown, typeof( ArgumentOutOfRangeException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentOutOfRangeException">argument out of range exception</see> if the supplied parameter is out of range.
        /// </summary>
        /// <typeparam name="TArg">The <see cref="Type">type</see> of parameter to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="value">The <typeparamref name="TArg">value</typeparamref> that should cause the exception to be thrown.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsOutOfRange`1']/example[2]" />
        public static ExceptionAsserter<ArgumentOutOfRangeException> ThrowsIfArgumentIsOutOfRange<TArg>( this Asserter assert, Expression<Action<TArg>> testMethod, TArg value, string message, params object[] parameters ) =>
            assert.ThrowsIfArgumentIs<TArg, ArgumentOutOfRangeException>( testMethod, value, message, parameters );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see> if the supplied parameter is out of range.
        /// </summary>
        /// <typeparam name="TArg">The <see cref="Type">type</see> of parameter to test.</typeparam>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="value">The <typeparamref name="TArg">value</typeparamref> that should cause the exception to be thrown.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsOutOfRange`2']/example[1]" />
        public static ExceptionAsserter<TException> ThrowsIfArgumentIsOutOfRange<TArg, TException>( this Asserter assert, Expression<Action<TArg>> testMethod, TArg value ) where TException : ArgumentException =>
            assert.ThrowsIfArgumentIs<TArg, TException>( testMethod, value, ExceptionOfTNotThrown, typeof( TException ) );

        /// <summary>
        /// Asserts the specified test method throws an <see cref="ArgumentException">argument exception</see> if the supplied parameter is null.
        /// </summary>
        /// <typeparam name="TArg">The <see cref="Type">type</see> of parameter to test.</typeparam>
        /// <typeparam name="TException">The <see cref="Type">type</see> of <see cref="ArgumentException"/> to expect.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="testMethod">The <see cref="Expression{T}">expression</see> representing the <see cref="Action{T}">test method</see>.</param>
        /// <param name="value">The <typeparamref name="TArg">value</typeparamref> that should cause the exception to be thrown.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <returns>The <see cref="ExceptionAsserter{T}">asserted exception</see>.</returns>
        /// <include file="examples.xml" path="Types/Type[@name='ExceptionExtensions']/Member[@name='ThrowsIfArgumentIsOutOfRange`2']/example[2]" />
        public static ExceptionAsserter<TException> ThrowsIfArgumentIsOutOfRange<TArg, TException>( this Asserter assert, Expression<Action<TArg>> testMethod, TArg value, string message, params object[] parameters ) where TException : ArgumentException =>
            assert.ThrowsIfArgumentIs<TArg, TException>( testMethod, value, message, parameters );

        static ExceptionAsserter<TException> ThrowsIfArgumentIs<TArg, TException>( this Asserter assert, Expression<Action<TArg>> testMethod, TArg value, string message, params object[] parameters ) where TException : ArgumentException
        {
            Arg.NotNull( assert, nameof( assert ) );
            Arg.NotNull( assert, nameof( testMethod ) );
            Contract.Ensures( Contract.Result<ExceptionAsserter<TException>>() != null );

            assert.AssertParameterIsNotNull( testMethod, nameof( testMethod ) );

            var test = testMethod.Compile();
            var assertion = assert.Throws<TException>( () => test( value ), message, parameters );
            var expectedParam = testMethod.Parameters.First().Name;
            var actualParam = assertion.Exception.ParamName;

            assert.AreEqual( expectedParam, actualParam, WrongParameterName, expectedParam, actualParam );

            return assertion;
        }
    }
}