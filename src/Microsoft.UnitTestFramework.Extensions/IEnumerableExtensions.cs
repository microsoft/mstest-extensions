// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static FailedTestMessage;

    /// <summary>
    /// Provides assertion support for <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Verifies that all items in the specified sequence are not null. The assertion fails if any element is null.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for elements that are null.</param>
        /// <exception cref="AssertFailedException">An element which is null is found in <paramref name="sequence" />.</exception>
        public static void AllItemsAreNotNull<T>( this Asserter assert, IEnumerable<T> sequence ) where T : class => assert.AllItemsAreNotNull( sequence, SomeItemsAreNull );

        /// <summary>
        /// Verifies that all items in the specified sequence are not null. The assertion fails if any element is null.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for elements that are null.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">An element which is null is found in <paramref name="sequence" />.</exception>
        public static void AllItemsAreNotNull<T>( this Asserter assert, IEnumerable<T> sequence, string message, params object[] parameters ) where T : class
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( sequence, nameof( sequence ) );

            if ( sequence.Any( item => item == null ) )
            {
                assert.Fail( message, parameters );
            }
        }

        /// <summary>
        /// Verifies that all items in the specified sequence are unique. The assertion fails if any two elements in the sequence are equal.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for duplicate elements.</param>
        /// <exception cref="AssertFailedException">Two or more equal elements are found in <paramref name="sequence" />.</exception>
        public static void AllItemsAreUnique<T>( this Asserter assert, IEnumerable<T> sequence ) =>
            assert.AllItemsAreUnique( sequence, EqualityComparer<T>.Default, AllItemsAreNotUnique );

        /// <summary>
        /// Verifies that all items in the specified sequence are unique. The assertion fails if any two elements in the sequence are equal.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for duplicate elements.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> used to compare elements.</param>
        /// <exception cref="AssertFailedException">Two or more equal elements are found in <paramref name="sequence" />.</exception>
        public static void AllItemsAreUnique<T>( this Asserter assert, IEnumerable<T> sequence, IEqualityComparer<T> comparer ) =>
            assert.AllItemsAreUnique( sequence, comparer, AllItemsAreNotUnique );

        /// <summary>
        /// Verifies that all items in the specified sequence are unique. The assertion fails if any two elements in the sequence are equal.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for duplicate elements.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">Two or more equal elements are found in <paramref name="sequence" />.</exception>
        public static void AllItemsAreUnique<T>( this Asserter assert, IEnumerable<T> sequence, string message, params object[] parameters ) =>
            assert.AllItemsAreUnique( sequence, EqualityComparer<T>.Default, message, parameters );

        /// <summary>
        /// Verifies that all items in the specified sequence are unique. The assertion fails if any two elements in the sequence are equal.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for duplicate elements.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> used to compare elements.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">Two or more equal elements are found in <paramref name="sequence" />.</exception>
        public static void AllItemsAreUnique<T>( this Asserter assert, IEnumerable<T> sequence, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( sequence, nameof( sequence ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            var unique = new HashSet<T>( comparer );
            var iterator = sequence.GetEnumerator();
            var count = 0;

            while ( iterator.MoveNext() )
            {
                unique.Add( iterator.Current );

                if ( ++count != unique.Count )
                {
                    assert.Fail( message, parameters );
                }
            }
        }

        /// <summary>
        /// Verifies that two specified sequences are equal, using the specified method to compare the values of elements.
        /// The assertion fails if the sequences are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <remarks>Sequences that are equal must have the same elements, in the same order.</remarks>
        /// <exception cref="AssertFailedException"><paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public static void SequenceEqual<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual ) =>
            assert.SequenceEqual( expected, actual, EqualityComparer<T>.Default, SequencesAreNotEqual );

        /// <summary>
        /// Verifies that two specified sequences are equal, using the specified method to compare the values of elements.
        /// The assertion fails if the sequences are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <remarks>Sequences that are equal must have the same elements, in the same order.</remarks>
        /// <exception cref="AssertFailedException"><paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public static void SequenceEqual<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer ) =>
            assert.SequenceEqual( expected, actual, comparer, SequencesAreNotEqual );

        /// <summary>
        /// Verifies that two specified sequences are equal, using the specified method to compare the values of elements.
        /// The assertion fails if the sequences are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <remarks>Sequences that are equal must have the same elements, in the same order.</remarks>
        /// <exception cref="AssertFailedException"><paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public static void SequenceEqual<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual, string message, params object[] parameters ) =>
            assert.SequenceEqual( expected, actual, EqualityComparer<T>.Default, message, parameters );

        /// <summary>
        /// Verifies that two specified sequences are equal, using the specified method to compare the values of elements.
        /// The assertion fails if the sequences are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <remarks>Sequences that are equal must have the same elements, in the same order.</remarks>
        /// <exception cref="AssertFailedException"><paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public static void SequenceEqual<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( expected, nameof( expected ) );
            assert.AssertParameterIsNotNull( actual, nameof( actual ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            if ( !actual.SequenceEqual( expected, comparer ) )
            {
                assert.Fail( message, parameters );
            }
        }

        /// <summary>
        /// Verifies that two specified sequences are not equal, using the specified method to compare the values of elements.
        /// The assertion fails if the sequences are equal. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="notExpected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <remarks>Sequences that are not equal must have different elements or be in different orders.</remarks>
        /// <exception cref="AssertFailedException"><paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public static void SequenceNotEqual<T>( this Asserter assert, IEnumerable<T> notExpected, IEnumerable<T> actual ) =>
            assert.SequenceNotEqual( notExpected, actual, EqualityComparer<T>.Default, SequencesAreEqual );

        /// <summary>
        /// Verifies that two specified sequences are not equal, using the specified method to compare the values of elements.
        /// The assertion fails if the sequences are equal. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="notExpected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <remarks>Sequences that are not equal must have different elements or be in different orders.</remarks>
        /// <exception cref="AssertFailedException"><paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public static void SequenceNotEqual<T>( this Asserter assert, IEnumerable<T> notExpected, IEnumerable<T> actual, IEqualityComparer<T> comparer ) =>
            assert.SequenceNotEqual( notExpected, actual, comparer, SequencesAreEqual );

        /// <summary>
        /// Verifies that two specified sequences are not equal, using the specified method to compare the values of elements.
        /// The assertion fails if the sequences are equal. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="notExpected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <remarks>Sequences that are not equal must have different elements or be in different orders.</remarks>
        /// <exception cref="AssertFailedException"><paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public static void SequenceNotEqual<T>( this Asserter assert, IEnumerable<T> notExpected, IEnumerable<T> actual, string message, params object[] parameters ) =>
            assert.SequenceNotEqual( notExpected, actual, EqualityComparer<T>.Default, message, parameters );

        /// <summary>
        /// Verifies that two specified sequences are not equal, using the specified method to compare the values of elements.
        /// The assertion fails if the sequences are equal. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="notExpected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <remarks>Sequences that are not equal must have different elements or be in different orders.</remarks>
        /// <exception cref="AssertFailedException"><paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public static void SequenceNotEqual<T>( this Asserter assert, IEnumerable<T> notExpected, IEnumerable<T> actual, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( notExpected, nameof( notExpected ) );
            assert.AssertParameterIsNotNull( actual, nameof( actual ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            if ( actual.SequenceEqual( notExpected, comparer ) )
            {
                assert.Fail( message, parameters );
            }
        }

        /// <summary>
        /// Verifies that two specified sequences are equivalent. The assertion fails if the sequences are not equivalent.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <remarks>Sequences that are equivalent must have the same elements, but may be in a different order.</remarks>
        /// <exception cref="AssertFailedException">An element was found in one of the sequences but not the other.</exception>
        public static void AreEquivalent<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual ) =>
            assert.AreEquivalent( expected, actual, EqualityComparer<T>.Default, SequencesAreNotEquivalent );

        /// <summary>
        /// Verifies that two specified sequences are equivalent. The assertion fails if the sequences are not equivalent.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <remarks>Sequences that are equivalent must have the same elements, but may be in a different order.</remarks>
        /// <exception cref="AssertFailedException">An element was found in one of the sequences but not the other.</exception>
        public static void AreEquivalent<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer ) =>
            assert.AreEquivalent( expected, actual, comparer, SequencesAreNotEquivalent );

        /// <summary>
        /// Verifies that two specified sequences are equivalent. The assertion fails if the sequences are not equivalent.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <remarks>Sequences that are equivalent must have the same elements, but may be in a different order.</remarks>
        /// <exception cref="AssertFailedException">An element was found in one of the sequences but not the other.</exception>
        public static void AreEquivalent<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual, string message, params object[] parameters ) =>
            assert.AreEquivalent( expected, actual, EqualityComparer<T>.Default, message, parameters );

        /// <summary>
        /// Verifies that two specified sequences are equivalent. The assertion fails if the sequences are not equivalent.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <remarks>Sequences that are equivalent must have the same elements, but may be in a different order.</remarks>
        /// <exception cref="AssertFailedException">An element was found in one of the sequences but not the other.</exception>
        public static void AreEquivalent<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( expected, nameof( expected ) );
            assert.AssertParameterIsNotNull( actual, nameof( actual ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            var x = actual.ToArray();
            var y = expected.ToArray();

            if ( x.Length != y.Length || x.Except( y, comparer ).Any() )
            {
                assert.Fail( message, parameters );
            }
        }

        /// <summary>
        /// Verifies that two specified sequences are not equivalent. The assertion fails if the sequences are equivalent.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="notExpected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects to be different from the <paramref name="actual"/> sequence.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <remarks>Sequences are not equivalent if they contain different elements and in different orders.</remarks>
        /// <exception cref="AssertFailedException">The two sequences contain the same elements, including the same number of duplicate occurrences of each element.</exception>
        public static void AreNotEquivalent<T>( this Asserter assert, IEnumerable<T> notExpected, IEnumerable<T> actual ) =>
            assert.AreNotEquivalent( notExpected, actual, EqualityComparer<T>.Default, SequencesAreEquivalent );

        /// <summary>
        /// Verifies that two specified sequences are not equivalent. The assertion fails if the sequences are equivalent.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="notExpected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects to be different from the <paramref name="actual"/> sequence.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <remarks>Sequences are not equivalent if they contain different elements and in different orders.</remarks>
        /// <exception cref="AssertFailedException">The two sequences contain the same elements, including the same number of duplicate occurrences of each element.</exception>
        public static void AreNotEquivalent<T>( this Asserter assert, IEnumerable<T> notExpected, IEnumerable<T> actual, IEqualityComparer<T> comparer ) =>
            assert.AreNotEquivalent( notExpected, actual, comparer, SequencesAreEquivalent );

        /// <summary>
        /// Verifies that two specified sequences are not equivalent. The assertion fails if the sequences are equivalent.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="expected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects to be different from the <paramref name="actual"/> sequence.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="notExpected">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="notExpected" />.</param>
        /// <remarks>Sequences are not equivalent if they contain different elements and in different orders.</remarks>
        /// <exception cref="AssertFailedException">The two sequences contain the same elements, including the same number of duplicate occurrences of each element.</exception>
        public static void AreNotEquivalent<T>( this Asserter assert, IEnumerable<T> expected, IEnumerable<T> actual, string notExpected, params object[] parameters ) =>
            assert.AreNotEquivalent( expected, actual, EqualityComparer<T>.Default, notExpected, parameters );

        /// <summary>
        /// Verifies that two specified sequences are not equivalent. The assertion fails if the sequences are equivalent.
        /// Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="notExpected">The first <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequence the unit test expects to be different from the <paramref name="actual"/> sequence.</param>
        /// <param name="actual">The second <see cref="IEnumerable{T}">sequence</see> to compare. This is the sequencce the unit test produced.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <remarks>Sequences are not equivalent if they contain different elements and in different orders.</remarks>
        /// <exception cref="AssertFailedException">The two sequences contain the same elements, including the same number of duplicate occurrences of each element.</exception>
        public static void AreNotEquivalent<T>( this Asserter assert, IEnumerable<T> notExpected, IEnumerable<T> actual, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( notExpected, nameof( notExpected ) );
            assert.AssertParameterIsNotNull( actual, nameof( actual ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            var x = actual.ToArray();
            var y = notExpected.ToArray();

            if ( x.Length == y.Length && !x.Except( y, comparer ).Any() )
            {
                assert.Fail( message, parameters );
            }
        }

        /// <summary>
        /// Verifies that the specified sequence contains the specified element. The assertion fails if the element is not
        /// found in the sequence. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the sequence.</param>
        /// <exception cref="AssertFailedException"><paramref name="element" /> is not found in <paramref name="sequence" />.</exception>
        public static void Contains<T>( this Asserter assert, IEnumerable<T> sequence, T element ) =>
            assert.Contains( sequence, element, EqualityComparer<T>.Default, SequenceDoesNotContain, element );

        /// <summary>
        /// Verifies that the specified sequence contains the specified element. The assertion fails if the element is not
        /// found in the sequence. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the sequence.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <exception cref="AssertFailedException"><paramref name="element" /> is not found in <paramref name="sequence" />.</exception>
        public static void Contains<T>( this Asserter assert, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer ) =>
            assert.Contains( sequence, element, comparer, SequenceDoesNotContain, element );

        /// <summary>
        /// Verifies that the specified sequence contains the specified element. The assertion fails if the element is not
        /// found in the sequence. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException"><paramref name="element" /> is not found in <paramref name="sequence" />.</exception>
        public static void Contains<T>( this Asserter assert, IEnumerable<T> sequence, T element, string message, params object[] parameters ) =>
            assert.Contains( sequence, element, EqualityComparer<T>.Default, message, parameters );

        /// <summary>
        /// Verifies that the specified sequence contains the specified element. The assertion fails if the element is not
        /// found in the sequence. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the sequence.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException"><paramref name="element" /> is not found in <paramref name="sequence" />.</exception>
        public static void Contains<T>( this Asserter assert, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( sequence, nameof( sequence ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            if ( !sequence.Contains( element, comparer ) )
            {
                assert.Fail( message, parameters );
            }
        }

        /// <summary>
        /// Verifies that the specified sequence does not contain the specified element. The assertion fails if the element is
        /// found in the sequence. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for the element.</param>
        /// <param name="element">The element that is not expected to be in the sequence.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is found in <paramref name="sequence" />.</exception>
        public static void DoesNotContain<T>( this Asserter assert, IEnumerable<T> sequence, T element ) =>
            assert.DoesNotContain( sequence, element, EqualityComparer<T>.Default, SequenceContains, element );

        /// <summary>
        /// Verifies that the specified sequence does not contain the specified element. The assertion fails if the element is
        /// found in the sequence. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for the element.</param>
        /// <param name="element">The element that is not expected to be in the sequence.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is found in <paramref name="sequence" />.</exception>
        public static void DoesNotContain<T>( this Asserter assert, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer ) =>
            assert.DoesNotContain( sequence, element, comparer, SequenceContains, element );

        /// <summary>
        /// Verifies that the specified sequence does not contain the specified element. The assertion fails if the element is
        /// found in the sequence. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for the element.</param>
        /// <param name="element">The element that is not expected to be in the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is found in <paramref name="sequence" />.</exception>
        public static void DoesNotContain<T>( this Asserter assert, IEnumerable<T> sequence, T element, string message, params object[] parameters ) =>
            assert.DoesNotContain( sequence, element, EqualityComparer<T>.Default, message, parameters );

        /// <summary>
        /// Verifies that the specified sequence does not contain the specified element. The assertion fails if the element is
        /// found in the sequence. Displays a message if the assertion fails, and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="sequence">The <see cref="IEnumerable{T}">sequence</see> in which to search for the element.</param>
        /// <param name="element">The element that is not expected to be in the sequence.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is found in <paramref name="sequence" />.</exception>
        public static void DoesNotContain<T>( this Asserter assert, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( sequence, nameof( sequence ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            if ( sequence.Contains( element, comparer ) )
            {
                assert.Fail( message, parameters );
            }
        }

        /// <summary>
        /// Verifies that the first sequence is a subset of the second sequence. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subset">The <see cref="IEnumerable{T}">sequence</see> expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The <see cref="IEnumerable{T}">sequence</see> expected to be a superset of <paramref name="subset" />.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="subset" /> is not found in <paramref name="superset" /> or
        /// an element in <paramref name="subset" /> is not found in <paramref name="superset" /> in sufficient quantity.</exception>
        public static void IsSubsetOf<T>( this Asserter assert, IEnumerable<T> subset, IEnumerable<T> superset ) =>
            assert.IsSubsetOf( subset, superset, EqualityComparer<T>.Default, SequenceIsNotSubsetOf );

        /// <summary>
        /// Verifies that the first sequence is a subset of the second sequence. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subset">The <see cref="IEnumerable{T}">sequence</see> expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The <see cref="IEnumerable{T}">sequence</see> expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="subset" /> is not found in <paramref name="superset" /> or
        /// an element in <paramref name="subset" /> is not found in <paramref name="superset" /> in sufficient quantity.</exception>
        public static void IsSubsetOf<T>( this Asserter assert, IEnumerable<T> subset, IEnumerable<T> superset, IEqualityComparer<T> comparer ) =>
            assert.IsSubsetOf( subset, superset, comparer, SequenceIsNotSubsetOf );

        /// <summary>
        /// Verifies that the first sequence is a subset of the second sequence. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subset">The <see cref="IEnumerable{T}">sequence</see> expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The <see cref="IEnumerable{T}">sequence</see> expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="subset" /> is not found in <paramref name="superset" /> or
        /// an element in <paramref name="subset" /> is not found in <paramref name="superset" /> in sufficient quantity.</exception>
        public static void IsSubsetOf<T>( this Asserter assert, IEnumerable<T> subset, IEnumerable<T> superset, string message, params object[] parameters ) =>
            assert.IsSubsetOf( subset, superset, EqualityComparer<T>.Default, message, parameters );

        /// <summary>
        /// Verifies that the first sequence is a subset of the second sequence. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subset">The <see cref="IEnumerable{T}">sequence</see> expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The <see cref="IEnumerable{T}">sequence</see> expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="subset" /> is not found in <paramref name="superset" /> or
        /// an element in <paramref name="subset" /> is not found in <paramref name="superset" /> in sufficient quantity.</exception>
        public static void IsSubsetOf<T>( this Asserter assert, IEnumerable<T> subset, IEnumerable<T> superset, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( subset, nameof( subset ) );
            assert.AssertParameterIsNotNull( superset, nameof( superset ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            var x = subset.ToArray();

            if ( x.Intersect( superset, comparer ).Count() != x.Length )
            {
                assert.Fail( message, parameters );
            }
        }

        /// <summary>
        /// Verifies that the first sequence is not a subset of the second sequence. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subset">The <see cref="IEnumerable{T}">sequence</see> not expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The <see cref="IEnumerable{T}">sequence</see> not expected to be a superset of <paramref name="subset" />.</param>
        /// <exception cref="AssertFailedException">All elements in <paramref name="subset" /> are found in <paramref name="superset" /> and are found in sufficient quantity.</exception>
        public static void IsNotSubsetOf<T>( this Asserter assert, IEnumerable<T> subset, IEnumerable<T> superset ) =>
            assert.IsNotSubsetOf( subset, superset, EqualityComparer<T>.Default, SequenceIsSubsetOf );

        /// <summary>
        /// Verifies that the first sequence is not a subset of the second sequence. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subset">The <see cref="IEnumerable{T}">sequence</see> not expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The <see cref="IEnumerable{T}">sequence</see> not expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <exception cref="AssertFailedException">All elements in <paramref name="subset" /> are found in <paramref name="superset" /> and are found in sufficient quantity.</exception>
        public static void IsNotSubsetOf<T>( this Asserter assert, IEnumerable<T> subset, IEnumerable<T> superset, IEqualityComparer<T> comparer ) =>
            assert.IsNotSubsetOf( subset, superset, comparer, SequenceIsSubsetOf );

        /// <summary>
        /// Verifies that the first sequence is not a subset of the second sequence. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subset">The <see cref="IEnumerable{T}">sequence</see> not expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The <see cref="IEnumerable{T}">sequence</see> not expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">All elements in <paramref name="subset" /> are found in <paramref name="superset" /> and are found in sufficient quantity.</exception>
        public static void IsNotSubsetOf<T>( this Asserter assert, IEnumerable<T> subset, IEnumerable<T> superset, string message, params object[] parameters ) =>
            assert.IsNotSubsetOf( subset, superset, EqualityComparer<T>.Default, message, parameters );

        /// <summary>
        /// Verifies that the first sequence is not a subset of the second sequence. Displays a message if the assertion fails,
        /// and applies the specified formatting to it.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> of elements in the <see cref="IEnumerable{T}">sequence</see>.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subset">The <see cref="IEnumerable{T}">sequence</see> not expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The <see cref="IEnumerable{T}">sequence</see> not expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}">comparer</see> implementation to use when comparing elements of the sequence.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">All elements in <paramref name="subset" /> are found in <paramref name="superset" /> and are found in sufficient quantity.</exception>
        public static void IsNotSubsetOf<T>( this Asserter assert, IEnumerable<T> subset, IEnumerable<T> superset, IEqualityComparer<T> comparer, string message, params object[] parameters )
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( subset, nameof( subset ) );
            assert.AssertParameterIsNotNull( superset, nameof( superset ) );
            assert.AssertParameterIsNotNull( comparer, nameof( comparer ) );

            var x = subset.ToList();

            if ( x.Intersect( superset, comparer ).Count() == x.Count )
            {
                assert.Fail( message, parameters );
            }
        }
    }
}