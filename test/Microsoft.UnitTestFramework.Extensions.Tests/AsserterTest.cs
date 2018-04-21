// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using static StringExtensions;

    [TestClass]
    public class AsserterTest
    {
        [TestMethod]
        public void AssertParameterIsNotNullShouldAssertNullReferenceType()
        {
            // arrange
            var assert = new Asserter();
            var parameter = default( string );

            try
            {
                // act
                assert.AssertParameterIsNotNull( parameter, nameof( parameter ) );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( parameter ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AssertParameterIsNotNullShouldNotAssertValueType()
        {
            // arrange
            var assert = new Asserter();

            // act, assert
            assert.AssertParameterIsNotNull( 1, "test" );
        }

        [TestMethod]
        public void AssertParameterIsNotNullShouldAssertNullArray()
        {
            // arrange
            var assert = new Asserter();
            var parameter = default( string[] );

            try
            {
                // act
                assert.AssertParameterIsNotNull( parameter, nameof( parameter ) );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( parameter ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AssertParameterIsNotNullShouldAssertNullArrayElement()
        {
            // arrange
            var assert = new Asserter();
            var parameter = default( string );

            try
            {
                // act
                assert.AssertParameterIsNotNull( new[] { "one", default( string ), "three" }, nameof( parameter ) );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( parameter ) + "[]" ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AssertParameterIsNotNullShouldNotAssertArrayElementValueType()
        {
            // arrange
            var assert = new Asserter();

            // act, assert
            assert.AssertParameterIsNotNull( new[] { 1, 2, 3 }, "test" );
        }

        [TestMethod]
        public void AssertParameterIsNotNullShouldAssertNullEnumerable()
        {
            // arrange
            var assert = new Asserter();
            var parameter = default( IEnumerable<string> );

            try
            {
                // act
                assert.AssertParameterIsNotNull( parameter, nameof( parameter ) );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( parameter ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AssertParameterIsNotNullShouldAssertNullEnumerableItem()
        {
            // arrange
            var assert = new Asserter();
            var parameter = default( string );

            try
            {
                // act
                assert.AssertParameterIsNotNull( new[] { "one", parameter, "three" }.AsEnumerable(), nameof( parameter ) );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( parameter ) + "[]" ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AssertParameterIsNotNullShouldNotAssertEnumerableItemValueType()
        {
            // arrange
            var assert = new Asserter();

            // act, assert
            assert.AssertParameterIsNotNull( new[] { 1, 2, 3 }.AsEnumerable(), "test" );
        }
    }
}