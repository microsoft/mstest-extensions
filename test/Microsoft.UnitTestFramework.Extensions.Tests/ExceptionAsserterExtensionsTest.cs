// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using static StringExtensions;

    [TestClass]
    public class ExceptionAsserterExtensionsTest
    {
        [TestMethod]
        public void VerifyShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( ExceptionAsserter<Exception> );

            try
            {
                // act
                assert.Verify( exception => true );
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( assert ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void VerifyShouldNotAllowNullExtensionObjectWithMessage()
        {
            // arrange
            var assert = default( ExceptionAsserter<Exception> );

            try
            {
                // act
                assert.Verify( exception => true, "test" );
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( assert ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void VerifyShouldNotAllowNullVerificationFunction()
        {
            // arrange
            var assert = new ExceptionAsserter<Exception>( new Exception() );
            var verification = default( Func<Exception, bool> );

            try
            {
                // act
                assert.Verify( verification );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( verification ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void VerifyShouldNotAllowNullVerificationFunctionWithMessage()
        {
            // arrange
            var assert = new ExceptionAsserter<Exception>( new Exception() );
            var verification = default( Func<Exception, bool> );

            try
            {
                // act
                assert.Verify( verification, string.Empty );
            }
            catch ( AssertFailedException ex )
            {
                // asseert
                Assert.AreEqual( GetExpectedMessage( nameof( verification ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void VerifyShouldNotReturnNull()
        {
            // arrange
            var assert = new ExceptionAsserter<Exception>( new Exception() );

            // act
            var actual = assert.Verify( e => true );

            // assert
            Assert.IsNotNull( actual );
        }

        [TestMethod]
        public void VerifyShouldNotReturnNullWithMessage()
        {
            // arrange
            var assert = new ExceptionAsserter<Exception>( new Exception() );

            // act
            var actual = assert.Verify( e => true );

            // assert
            Assert.IsNotNull( actual );
        }

        [TestMethod]
        public void VerifyShouldAssertFailedVerification()
        {
            // arrange
            var assert = new ExceptionAsserter<Exception>( new Exception() );

            try
            {
                // act
                assert.Verify( e => false );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void VerifyShouldAssertFailedVerificationWithMessage()
        {
            // arrange
            var assert = new ExceptionAsserter<Exception>( new Exception() );

            try
            {
                // act
                assert.Verify( exception => false, "A '{0}' message.", "test" );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( "Assert.IsTrue failed. A 'test' message.", ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );

            try
            {
                // act
                assert.Throws( () => { } );
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( assert ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsShouldNotAllowNullExtensionObjectWithMessage()
        {
            // arrange
            var assert = default( Asserter );

            try
            {
                // act
                assert.Throws( () => { }, string.Empty );
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( assert ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsShouldNotAllowNullTestMethod()
        {
            // arrange
            var assert = new Asserter();
            var testMethod = default( Action );

            try
            {
                // act
                assert.Throws( testMethod );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( testMethod ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsShouldNotAllowNullTestMethodWithMessage()
        {
            // arrange
            var assert = new Asserter();
            var testMethod = default( Action );

            try
            {
                // act
                assert.Throws( testMethod, string.Empty );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( testMethod ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsShouldFailWhenAnExceptionIsNotThrown()
        {
            // arrange
            var assert = new Asserter();

            try
            {
                // act
                assert.Throws( () => { } );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( "Assert.Fail failed. An exception was expected, but not thrown.", ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsShouldFailWhenAnExceptionIsNotThrownWithMessage()
        {
            // arrange
            var assert = new Asserter();

            try
            {
                // act
                assert.Throws( () => { }, "A '{0}' message.", "test" );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( "Assert.Fail failed. A 'test' message.", ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsShouldReturnExpectedException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new Exception();

            // act
            var actual = assert.Throws( () => throw expected );

            // assert
            Assert.IsNotNull( actual );
            Assert.AreEqual( expected, actual.Exception );
        }

        [TestMethod]
        public void ThrowsOfTShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );

            try
            {
                // act
                assert.Throws<Exception>( () => { } );
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( assert ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsOfTShouldNotAllowNullExtensionObjectWithMessage()
        {
            // arrange
            var assert = default( Asserter );

            try
            {
                // act
                assert.Throws<Exception>( () => { }, string.Empty );
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( assert ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsOfTShouldNotAllowNullTestMethod()
        {
            // arrange
            var assert = new Asserter();
            var testMethod = default( Action );

            try
            {
                // act
                assert.Throws<Exception>( testMethod );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( testMethod ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsOfTShouldNotAllowNullTestMethodWithMessage()
        {
            // arrange
            var assert = new Asserter();
            var testMethod = default( Action );

            try
            {
                // act
                assert.Throws<Exception>( testMethod, string.Empty );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( testMethod ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsOfTShouldFailWhenAnExceptionIsNotThrown()
        {
            // arrange
            var assert = new Asserter();

            try
            {
                // act
                assert.Throws<Exception>( () => { } );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( $"Assert.Fail failed. An exception of type {typeof( Exception )} was expected, but not thrown.", ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsOfTShouldFailWhenAnExceptionIsNotThrownWithMessage()
        {
            // arrange
            var assert = new Asserter();

            try
            {
                // act
                assert.Throws<Exception>( () => { }, "A '{0}' message.", "test" );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( "Assert.Fail failed. A 'test' message.", ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsOfTShouldReturnExpectedException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new Exception();

            // act
            var actual = assert.Throws<Exception>( () => throw expected );

            // assert
            Assert.IsNotNull( actual );
            Assert.AreEqual( expected, actual.Exception );
        }

        [TestMethod]
        public void ThrowsOfTShouldFailWhenInstanceOfExceptionIsNotExpectedType()
        {
            // arrange
            var assert = new Asserter();

            try
            {
                // act
                assert.Throws<ArgumentException>( () => throw new ArgumentNullException() );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                var format = "Assert.AreEqual failed. Expected:<{0}>. Actual:<{1}>. The expected exception was {0}, but an exception of type {1} was thrown.";
                var expected = string.Format( format, typeof( ArgumentException ), typeof( ArgumentNullException ) );
                Assert.AreEqual( expected, ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsOfTShouldFailWhenExceptionIsNotExpectedType()
        {
            // arrange
            var assert = new Asserter();

            try
            {
                // act
                assert.Throws<ArgumentException>( () => throw new InvalidOperationException() );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                var format = "Assert.AreEqual failed. Expected:<{0}>. Actual:<{1}>. The expected exception was {0}, but an exception of type {1} was thrown.";
                var expected = string.Format( format, typeof( ArgumentException ), typeof( InvalidOperationException ) );
                Assert.AreEqual( expected, ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ThrowsIfArgumentIsEmptyShouldAssertException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new ArgumentNullException( "arg" );

            // act
            var result = assert.ThrowsIfArgumentIsEmpty( arg => Throw( arg, expected ) );

            // assert
            result.Verify( actual => actual == expected );
        }

        [TestMethod]
        public void ThrowsOfTIfArgumentIsEmptyShouldAssertException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new ArgumentException( "test", "arg" );

            // act
            var result = assert.ThrowsIfArgumentIsEmpty<ArgumentException>( arg => Throw( arg, expected ) );

            // assert
            result.Verify( actual => actual == expected );
        }

        [TestMethod]
        public void ThrowsIfArgumentIsWhiteSpaceShouldAssertException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new ArgumentNullException( "arg" );

            // act
            var result = assert.ThrowsIfArgumentIsWhiteSpace( arg => Throw( arg, expected ) );

            // assert
            result.Verify( actual => actual == expected );
        }

        [TestMethod]
        public void ThrowsOfTIfArgumentIsWhiteSpaceShouldAssertException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new ArgumentException( "test", "arg" );

            // act
            var result = assert.ThrowsIfArgumentIsWhiteSpace<ArgumentException>( arg => Throw( arg, expected ) );

            // assert
            result.Verify( actual => actual == expected );
        }

        [TestMethod]
        public void ThrowsIfArgumentIsNullShouldAssertException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new ArgumentNullException( "arg" );

            // act
            var result = assert.ThrowsIfArgumentIsNull( ( string arg ) => Throw( arg, expected ) );

            // assert
            result.Verify( actual => actual == expected );
        }

        [TestMethod]
        public void ThrowsOfTIfArgumentIsNullShouldAssertException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new ArgumentException( "test", "arg" );

            // act
            var result = assert.ThrowsIfArgumentIsNull<string, ArgumentException>( arg => Throw( arg, expected ) );

            // assert
            result.Verify( actual => actual == expected );
        }

        [TestMethod]
        public void ThrowsIfArgumentIsOutOfRangeShouldAssertException()
        {
            // arrange
            var assert = new Asserter();
            var expectedValue = 1;
            var expected = new ArgumentOutOfRangeException( "arg", expectedValue, default( string ) );

            // act
            var result = assert.ThrowsIfArgumentIsOutOfRange( arg => Throw( arg, expected ), 1 );

            // assert
            result.Verify( actual => actual == expected ).Verify( e => Equals( e.ActualValue, expectedValue ) );
        }

        [TestMethod]
        public void ThrowsOfTIfArgumentIsOutOfRangeShouldAssertException()
        {
            // arrange
            var assert = new Asserter();
            var expected = new ArgumentException( "test", "arg" );

            // act
            var result = assert.ThrowsIfArgumentIsOutOfRange<int, ArgumentException>( arg => Throw( arg, expected ), 1 );

            // assert
            result.Verify( actual => actual == expected );
        }

        static void Throw<TArg, TException>( TArg arg, TException ex ) where TException : Exception => throw ex;
    }
}