// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ExceptionAsserterTest
    {
        [TestMethod]
        public void ConstructorShouldNotAllowNullException()
        {
            // arrange
            var exception = default( Exception );

            try
            {
                // act
                new ExceptionAsserter<Exception>( exception );
            }
            catch ( ArgumentNullException ex )
            {
                // assert
                Assert.AreEqual( nameof( exception ), ex.ParamName );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ConstructorShouldSetExpectedException()
        {
            // arrange
            var exception = new Exception();

            // act
            var target = new ExceptionAsserter<Exception>( exception );

            // assert
            Assert.AreEqual( exception, target.Exception );
        }
    }
}