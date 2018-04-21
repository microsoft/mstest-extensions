// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static StringExtensions;

    [TestClass]
    public class IEnumerableExtensionsTest
    {
        [TestMethod]
        public void AllItemsAreNotNullShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var sequence = new object[0];

            try
            {
                // act
                assert.AllItemsAreNotNull( sequence );
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
        public void AllItemsAreNotNullShouldNotAllowNullSequence()
        {
            // arrange
            var assert = new Asserter();
            var sequence = default( IEnumerable<object> );

            try
            {
                // act
                assert.AllItemsAreNotNull( sequence );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( sequence ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AllItemsAreNotNullShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };

            // act, assert
            assert.AllItemsAreNotNull( sequence );
        }

        [TestMethod]
        public void AllItemsAreNotNullShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new List<object>()
            {
                new object(),
                default(object),
                new object(),
            };

            try
            {
                // act
                assert.AllItemsAreNotNull( sequence );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AllItemsAreUniqueShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var sequence = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AllItemsAreUnique( sequence, comparer );
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
        public void AllItemsAreUniqueShouldNotAllowNullSequence()
        {
            // arrange
            var assert = new Asserter();
            var sequence = default( IEnumerable<object> );
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AllItemsAreUnique( sequence, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( sequence ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AllItemsAreUniqueShouldNotAllowNullComparer()
        {
            // assert
            var assert = new Asserter();
            var sequence = new object[0];
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.AllItemsAreUnique( sequence, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AllItemsAreUniqueShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.AllItemsAreUnique( sequence, comparer );
        }

        [TestMethod]
        public void AllItemsAreUniqueShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var duplicate = new object();
            var sequence = new List<object>()
            {
                duplicate,
                new object(),
                duplicate,
            };
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AllItemsAreUnique( sequence, comparer );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void SequenceEqualShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var comparer = EqualityComparer<object>.Default;
            var expected = new object[0];
            var actual = new object[0];

            try
            {
                // act
                assert.SequenceEqual( expected, actual, comparer );
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
        public void SequenceEqualShouldNotAllowNullExpectedSequence()
        {
            // arrange
            var assert = new Asserter();
            var expected = default( IEnumerable<object> );
            var actual = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.SequenceEqual( expected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( expected ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void SequenceEqualShouldNotAllowNullActualSequence()
        {
            // arrange
            var assert = new Asserter();
            var expected = new object[0];
            var actual = default( IEnumerable<object> );
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.SequenceEqual( expected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( actual ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void SequenceEqualShouldNotAllowNullComparer()
        {
            // arrange
            var assert = new Asserter();
            var expected = new object[0];
            var actual = new object[0];
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.SequenceEqual( expected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void SequenceEqualShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var expected = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var actual = new List<object>()
            {
                expected[0],
                expected[1],
                expected[2],
            };
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.SequenceEqual( expected, actual, comparer );
        }

        [TestMethod]
        public void SequenceEqualShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var expected = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var actual = new List<object>()
            {
                expected[0],
                expected[1],
                new object(),
            };
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.SequenceEqual( expected, actual, comparer );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void SequenceNotEqualShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var notExpected = new object[0];
            var actual = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.SequenceNotEqual( notExpected, actual, comparer );
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
        public void SequenceNotEqualShouldNotAllowNullNotExpectedSequence()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = default( IEnumerable<object> );
            var actual = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.SequenceNotEqual( notExpected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( notExpected ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void SequenceNotEqualShouldNotAllowNullActualSequence()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = new object[0];
            var actual = default( IEnumerable<object> );
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.SequenceNotEqual( notExpected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( actual ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void SequenceNotEqualShouldNotAllowNullComparer()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = new object[0];
            var actual = new object[0];
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.SequenceNotEqual( notExpected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void SequenceNotEqualShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var actual = new List<object>()
            {
                notExpected[0],
                notExpected[1],
                new object(),
            };
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.SequenceNotEqual( notExpected, actual, comparer );
        }

        [TestMethod]
        public void SequenceNotEqualShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var actual = new List<object>()
            {
                notExpected[0],
                notExpected[1],
                notExpected[2],
            };
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.SequenceNotEqual( notExpected, actual, comparer );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AreEquivalentShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var expected = new object[0];
            var actual = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AreEquivalent( expected, actual, comparer );
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
        public void AreEquivalentShouldNotAllowNullExpectedSequence()
        {
            // arrange
            var assert = new Asserter();
            var expected = default( IEnumerable<object> );
            var actual = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AreEquivalent( expected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( expected ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AreEquivalentShouldNotAllowNullActualSequence()
        {
            // arrange
            var assert = new Asserter();
            var expected = new object[0];
            var actual = default( IEnumerable<object> );
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AreEquivalent( expected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( actual ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AreEquivalentShouldNotAllowNullComparer()
        {
            // arrange
            var assert = new Asserter();
            var expected = new object[0];
            var actual = new object[0];
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.AreEquivalent( expected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AreEquivalentShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var expected = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var actual = new List<object>()
            {
                expected[2],
                expected[1],
                expected[0],
            };
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.AreEquivalent( expected, actual, comparer );
        }

        [TestMethod]
        public void AreEquivalentShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var expected = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var actual = new List<object>()
            {
                expected[2],
                expected[1],
                new object(),
            };
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AreEquivalent( expected, actual, comparer );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AreNotEquivalentShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var notExpected = new object[0];
            var actual = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                assert.AreNotEquivalent( notExpected, actual, comparer );
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
        public void AreNotEquivalentShouldNotAllowNullExpectedSequence()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = default( IEnumerable<object> );
            var actual = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AreNotEquivalent( notExpected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( notExpected ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AreNotEquivalentShouldNotAllowNullActualSequence()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = new object[0];
            var actual = default( IEnumerable<object> );
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AreNotEquivalent( notExpected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( actual ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AreNotEquivalentShouldNotAllowNullComparer()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = new object[0];
            var actual = new object[0];
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.AreNotEquivalent( notExpected, actual, comparer );
            }
            catch ( AssertFailedException ex )
            {
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void AreNotEquivalentShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var actual = new List<object>()
            {
                notExpected[2],
                notExpected[1],
                new object(),
            };
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.AreNotEquivalent( notExpected, actual, comparer );
        }

        [TestMethod]
        public void AreNotEquivalentShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var notExpected = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var actual = new List<object>()
            {
                notExpected[2],
                notExpected[0],
                notExpected[1],
            };
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.AreNotEquivalent( notExpected, actual, comparer );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ContainsShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var sequence = new object[0];
            var element = new object();
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.Contains( sequence, element, comparer );
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
        public void ContainsShouldNotAllowNullSequence()
        {
            // arrange
            var assert = new Asserter();
            var sequence = default( IEnumerable<object> );
            var element = new object();
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.Contains( sequence, element, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( sequence ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ContainsShouldNotAllowNullComparer()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new object[0];
            var element = new object();
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.Contains( sequence, element, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void ContainsShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.Contains( sequence, sequence.Last(), comparer );
        }

        [TestMethod]
        public void ContainsShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var element = new object();
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.Contains( sequence, element, comparer );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void DoesNotContainShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var sequence = new object[0];
            var element = new object();
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.DoesNotContain( sequence, element, comparer );
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
        public void DoesNotContainShouldNotAllowNullSequence()
        {
            // arrange
            var assert = new Asserter();
            var sequence = default( IEnumerable<object> );
            var element = new object();
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.DoesNotContain( sequence, element, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( sequence ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void DoesNotContainShouldNotAllowNullComparer()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new object[0];
            var element = new object();
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.DoesNotContain( sequence, element, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void DoesNotContainShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var element = new object();
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.DoesNotContain( sequence, element, comparer );
        }

        [TestMethod]
        public void DoesNotContainShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var sequence = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var element = sequence[2];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.DoesNotContain( sequence, element, comparer );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void IsSubsetOfShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var subset = new object[0];
            var superset = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.IsSubsetOf( subset, superset, comparer );
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
        public void IsSubsetOfShouldNotAllowNullSubsetSequence()
        {
            // arrange
            var assert = new Asserter();
            var subset = default( IEnumerable<object> );
            var superset = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.IsSubsetOf( subset, superset, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( subset ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void IsSubsetOfShouldNotAllowNullSupersetSequence()
        {
            // arrange
            var assert = new Asserter();
            var subset = new object[0];
            var superset = default( IEnumerable<object> );
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.IsSubsetOf( subset, superset, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( superset ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void IsSubsetOfShouldNotAllowNullComparer()
        {
            // arrange
            var assert = new Asserter();
            var subset = new object[0];
            var superset = new object[0];
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.IsSubsetOf( subset, superset, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void IsSubsetOfShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var superset = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var subset = new List<object>()
            {
                superset[2],
                superset[0],
            };
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.IsSubsetOf( subset, superset, comparer );
        }

        [TestMethod]
        public void IsSubsetOfShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var superset = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var subset = new List<object>()
            {
                superset[2],
                superset[0],
                new object(),
            };
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.IsSubsetOf( subset, superset, comparer );
            }
            catch ( AssertFailedException )
            {
                // assert
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void IsNotSubsetOfShouldNotAllowNullExtensionObject()
        {
            // arrange
            var assert = default( Asserter );
            var subset = new object[0];
            var superset = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.IsNotSubsetOf( subset, superset, comparer );
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
        public void IsNotSubsetOfShouldNotAllowNullSubsetSequence()
        {
            // arrange
            var assert = new Asserter();
            var subset = default( IEnumerable<object> );
            var superset = new object[0];
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.IsNotSubsetOf( subset, superset, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( subset ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void IsNotSubsetOfShouldNotAllowNullSupersetSequence()
        {
            // arrange
            var assert = new Asserter();
            var subset = new object[0];
            var superset = default( IEnumerable<object> );
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.IsNotSubsetOf( subset, superset, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( superset ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void IsNotSubsetOfShouldNotAllowNullComparer()
        {
            // arrange
            var assert = new Asserter();
            var subset = new object[0];
            var superset = new object[0];
            var comparer = default( IEqualityComparer<object> );

            try
            {
                // act
                assert.IsNotSubsetOf( subset, superset, comparer );
            }
            catch ( AssertFailedException ex )
            {
                // assert
                Assert.AreEqual( GetExpectedMessage( nameof( comparer ) ), ex.Message );
                return;
            }

            Assert.Fail( "An exception was expected, but not thrown." );
        }

        [TestMethod]
        public void IsNotSubsetOfShouldPassWhenTrue()
        {
            // arrange
            var assert = new Asserter();
            var superset = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var subset = new List<object>()
            {
                superset[2],
                new object(),
            };
            var comparer = EqualityComparer<object>.Default;

            // act, assert
            assert.IsNotSubsetOf( subset, superset, comparer );
        }

        [TestMethod]
        public void IsNotSubsetOfShouldFailWhenFalse()
        {
            // arrange
            var assert = new Asserter();
            var superset = new List<object>()
            {
                new object(),
                new object(),
                new object(),
            };
            var subset = new List<object>()
            {
                superset[2],
                superset[0],
                superset[1],
            };
            var comparer = EqualityComparer<object>.Default;

            try
            {
                // act
                assert.IsNotSubsetOf( subset, superset, comparer );
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