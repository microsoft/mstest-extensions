// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class UnitTestTest
    {
        [TestMethod]
        public void ConstructorShouldNotAllowNullAsserter()
        {
            // arrange
            var assert = default( Asserter );

            try
            {
                // act
                new UnitTest( assert );
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
        public void ConstructorShouldSetExpectedProperties()
        {
            // arrange
            var expected = new Asserter();

            // act
            var target = new UnitTest( expected );

            // assert
            Assert.AreEqual( expected, target.Assert );
        }

        [TestMethod]
        public void AssertPropertyShouldNotBeNullByDefault()
        {
            // arrange
            var target = new UnitTest();

            // act
            var result = target.Assert;

            // assert
            Assert.IsNotNull( result );
        }

        [TestMethod]
        public void CollectionAssertPropertyShouldNotBeNullByDefault()
        {
            // arrange
            var target = new UnitTest();

            // act
            var result = target.CollectionAssert;

            // assert
            Assert.IsNotNull( result );
        }

        [TestMethod]
        public void AssertPropertyShouldSetExpectedValue()
        {
            // arrange
            var expected = new Asserter();
            var target = new UnitTest();

            // act
            target.Assert = expected;

            // assert
            Assert.AreEqual( expected, target.Assert );
        }

        [TestMethod]
        public void AssertPropertyShouldNotAllowNullValues()
        {
            // arrange
            var target = new UnitTest();
            var value = default( Asserter );

            try
            {
                // act
                target.Assert = value;
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( value ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void CollectionAssertPropertyShouldSetExpectedValue()
        {
            // arrange
            var expected = new CollectionAsserter();
            var target = new UnitTest();

            // act
            target.CollectionAssert = expected;

            // assert
            Assert.AreEqual( expected, target.CollectionAssert );
        }

        [TestMethod]
        public void CollectionAssertPropertyShouldNotAllowNullValues()
        {
            // arrange
            var target = new UnitTest();
            var value = default( CollectionAsserter );

            try
            {
                // act
                target.CollectionAssert = value;
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( value ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }
    }
}