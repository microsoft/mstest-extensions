// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq.Expressions;
    using static StringExtensions;

    [TestClass]
    public class INotifyPropertyChangedExtensionsTest
    {
        [TestMethod]
        public void PropertyChangedShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var subject = new Person();

            try
            {
                // act
                assert.PropertyChanged( subject, p => p.FirstName, string.Empty );
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
        public void PropertyChangedShouldAssertNullObject()
        {
            // arrange
            var assert = new Asserter();
            var subject = default( Person );

            try
            {
                // act
                assert.PropertyChanged( subject, p => p.FirstName, string.Empty );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( subject ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void PropertyChangedShouldAssertNullPropertyExpression()
        {
            // arrange
            var assert = new Asserter();
            var subject = new Person();
            var testProperty = default( Expression<Func<Person, string>> );

            try
            {
                // act
                assert.PropertyChanged( subject, testProperty, string.Empty );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( testProperty ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void PropertyChangedShouldAssertNullOtherPropertyExpressions()
        {
            // arrange
            var assert = new Asserter();
            var subject = new Person();
            var otherProperties = default( Expression<Func<Person, object>>[] );

            try
            {
                // act
                assert.PropertyChanged( subject, p => p.FirstName, string.Empty, otherProperties );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( otherProperties ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void PropertyNotChangedShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var subject = new Person();

            try
            {
                // act
                assert.PropertyNotChanged( subject, p => p.FirstName, string.Empty );
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
        public void PropertyNotChangedShouldAssertNullObject()
        {
            // arrange
            var assert = new Asserter();
            var subject = default( Person );

            try
            {
                // act
                assert.PropertyNotChanged( subject, p => p.FirstName, string.Empty );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( subject ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void PropertyNotChangedShouldAssertNullPropertyExpression()
        {
            // arrange
            var assert = new Asserter();
            var subject = new Person();
            var testProperty = default( Expression<Func<Person, string>> );

            try
            {
                // act
                assert.PropertyNotChanged( subject, testProperty, string.Empty );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( testProperty ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ShouldPassWhenOnlyOnePropertyChangeIsExpected()
        {
            // arrange
            var assert = new Asserter();
            var subject = new Person();
            var expected = 123;

            // act, assert
            assert.PropertyChanged( subject, p => p.Id, expected );
        }

        [TestMethod]
        public void ShouldFailWhenOnePropertyPropertyChangeIsExpectedButMultiplePropertiesChange()
        {
            // arrange
            var assert = new Asserter();
            var subject = new Person();
            var expected = "Bob";

            try
            {
                // act (setting the FirstName property also raises FullName property change, but is not expected)
                assert.PropertyChanged( subject, p => p.FirstName, expected );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ShouldPassWhenAllExpectedPropertiesChange()
        {
            // arrange
            var assert = new Asserter();
            var subject = new Person();
            var expected = "Bob";

            // act, asssert (expect setting FirstName also raises event for FullName)
            assert.PropertyChanged( subject, p => p.FirstName, expected, p => p.FullName );
        }

        [TestMethod]
        public void ShouldFailWhenSomeOfTheExpectedPropertiesDoNotChange()
        {
            // assert
            var assert = new Asserter();
            var subject = new Person();
            var expected = "Bob";

            try
            {
                // act (expect FirstName and FullName, but not LastName)
                assert.PropertyChanged( subject, p => p.FirstName, expected, p => p.FullName, p => p.LastName );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ShouldPassWhenPropertyExpectedNotToChangeRemainsUnchanged()
        {
            // arrange
            var assert = new Asserter();
            var expected = "Bob";
            var subject = new Person() { FirstName = expected };

            // act, assert
            assert.PropertyNotChanged( subject, p => p.FirstName, expected );
        }

        [TestMethod]
        public void ShouldFailWhenPropertyExpectedNotToChangeHasChanged()
        {
            // arrange
            var assert = new Asserter();
            var subject = new Person() { FirstName = "Bob" };

            try
            {
                // act
                assert.PropertyNotChanged( subject, p => p.FirstName, "John" );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }
    }
}