// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;

    /// <summary>
    /// Represents the properties and methods that are needed to perform a unit test.
    /// </summary>
    /// <example>This example demonstrates how to create a unit test where test assertions can be extended.
    /// <code lang="C#"><![CDATA[
    /// namespace MyTests
    /// {
    ///     using Microsoft.VisualStudio.TestTools.UnitTesting;
    ///     using System;
    ///     using System.Collections.Generic;
    ///     using System.Linq;
    ///
    ///     [TestClass]
    ///     public class MyTestClass : UnitTest
    ///     {
    ///         [TestMethod]
    ///         public void ExampleTest
    ///         {
    ///             // Assert is an instance property of the UnitTest class which can be extended with extension methods
    ///             Assert.Inconclusive();
    ///         }
    ///     }
    /// }
    /// ]]></code></example>
    public class UnitTest
    {
        Asserter assert;
        CollectionAsserter collectionAssert = new CollectionAsserter();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTest"/> class.
        /// </summary>
        public UnitTest()
            : this( new Asserter() )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTest"/> class.
        /// </summary>
        /// <param name="assert">The <see cref="Asserter">asserter</see> used for testing.</param>
        public UnitTest( Asserter assert )
        {
            Arg.NotNull( assert, nameof( assert ) );
            this.assert = assert;
        }

        /// <summary>
        /// Gets or sets the <see cref="Asserter"/> object that provides support for unit testing.
        /// </summary>
        /// <value>The <see cref="Asserter">asserter</see> object that is associated with the unit test.</value>
        public Asserter Assert
        {
            get => assert;
            set => assert = value ?? throw new ArgumentNullException( nameof( value ) );
        }

        /// <summary>
        /// Gets or sets the <see cref="CollectionAsserter"/> object that provides support for unit testing.
        /// </summary>
        /// <value>The <see cref="CollectionAsserter">collection asserter</see> object that is associated with the unit test.</value>
        public CollectionAsserter CollectionAssert
        {
            get => collectionAssert;
            set => collectionAssert = value ?? throw new ArgumentNullException( nameof( value ) );
        }
    }
}