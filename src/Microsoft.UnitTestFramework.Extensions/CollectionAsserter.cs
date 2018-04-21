// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    using System.Collections;

    /// <summary>
    /// Represents support for asserting unit tests.
    /// </summary>
    /// <remarks>This class exposes all of the methods provided by <see cref="CollectionAssert"/> as instance methods.</remarks>
    public class CollectionAsserter
    {
        /// <summary>Verifies that the specified collection contains the specified element. The assertion fails if the element is not found in the collection.</summary>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is not found in <paramref name="collection" />.</exception>
        public virtual void Contains( ICollection collection, object element ) => CollectionAssert.Contains( collection, element );

        /// <summary>Verifies that the specified collection contains the specified element. The assertion fails if the element is not found in the collection. Displays a message if the assertion fails.</summary>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is not found in <paramref name="collection" />.</exception>
        public virtual void Contains( ICollection collection, object element, string message ) => CollectionAssert.Contains( collection, element, message, null );

        /// <summary>Verifies that the specified collection contains the specified element. The assertion fails if the element is not found in the collection. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is expected to be in the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is not found in <paramref name="collection" />.</exception>
        public virtual void Contains( ICollection collection, object element, string message, params object[] parameters ) => CollectionAssert.Contains( collection, element, message, parameters );

        /// <summary>Verifies that the specified collection does not contain the specified element. The assertion fails if the element is found in the collection.</summary>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is not expected to be in the collection.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is found in <paramref name="collection" />.</exception>
        public virtual void DoesNotContain( ICollection collection, object element ) => CollectionAssert.DoesNotContain( collection, element, string.Empty, null );

        /// <summary>Verifies that the specified collection does not contain the specified element. The assertion fails if the element is found in the collection. Displays a message if the assertion fails.</summary>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is not expected to be in the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is found in <paramref name="collection" />.</exception>
        public virtual void DoesNotContain( ICollection collection, object element, string message ) => CollectionAssert.DoesNotContain( collection, element, message, null );

        /// <summary>Verifies that the specified collection does not contain the specified element. The assertion fails if the element is found in the collection. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="collection">The collection in which to search for the element.</param>
        /// <param name="element">The element that is not expected to be in the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="element" /> is found in <paramref name="collection" />.</exception>
        public virtual void DoesNotContain( ICollection collection, object element, string message, params object[] parameters ) => CollectionAssert.DoesNotContain( collection, element, message, parameters );

        /// <summary>Verifies that all items in the specified collection are not null. The assertion fails if any element is null.</summary>
        /// <param name="collection">The collection in which to search for elements that are null.</param>
        /// <exception cref="AssertFailedException">An element which is null is found in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreNotNull( ICollection collection ) => CollectionAssert.AllItemsAreNotNull( collection, string.Empty, null );

        /// <summary>Verifies that all items in the specified collection are not null. The assertion fails if any element is null. Displays a message if the assertion fails.</summary>
        /// <param name="collection">The collection in which to search for elements that are null.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">An element which is null is found in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreNotNull( ICollection collection, string message ) => CollectionAssert.AllItemsAreNotNull( collection, message, null );

        /// <summary>Verifies that all items in the specified collection are not null. The assertion fails if any element is null. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="collection">The collection in which to search for elements that are null.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">An element which is null is found in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreNotNull( ICollection collection, string message, params object[] parameters ) => CollectionAssert.AllItemsAreNotNull( collection, message, parameters );

        /// <summary>Verifies that all items in the specified collection are unique. The assertion fails if any two elements in the collection are equal.</summary>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <exception cref="AssertFailedException">Two or more equal elements are found in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreUnique( ICollection collection ) => CollectionAssert.AllItemsAreUnique( collection, string.Empty, null );

        /// <summary>Verifies that all items in the specified collection are unique. The assertion fails if any two elements in the collection are equal. Displays a message if the assertion fails.</summary>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">Two or more equal elements are found in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreUnique( ICollection collection, string message ) => CollectionAssert.AllItemsAreUnique( collection, message, null );

        /// <summary>Verifies that all items in the specified collection are unique. The assertion fails if any two elements in the collection are equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="collection">The collection in which to search for duplicate elements.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">Two or more equal elements are found in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreUnique( ICollection collection, string message, params object[] parameters ) => CollectionAssert.AllItemsAreUnique( collection, message, parameters );

        /// <summary>Verifies that the first collection is a subset of the second collection.</summary>
        /// <param name="subset">The collection expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="subset" />.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="subset" /> is not found in <paramref name="superset" /> or an element in <paramref name="subset" /> is not found in <paramref name="superset" /> in sufficient quantity.</exception>
        public virtual void IsSubsetOf( ICollection subset, ICollection superset ) => CollectionAssert.IsSubsetOf( subset, superset, string.Empty, null );

        /// <summary>Verifies that the first collection is a subset of the second collection. Displays a message if the assertion fails.</summary>
        /// <param name="subset">The collection expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="subset" /> is not found in <paramref name="superset" /> or an element in <paramref name="subset" /> is not found in <paramref name="superset" /> in sufficient quantity.</exception>
        public virtual void IsSubsetOf( ICollection subset, ICollection superset, string message ) => CollectionAssert.IsSubsetOf( subset, superset, message, null );

        /// <summary>Verifies that the first collection is a subset of the second collection. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="subset">The collection expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The collection expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="subset" /> is not found in <paramref name="superset" /> or an element in <paramref name="subset" /> is not found in <paramref name="superset" /> in sufficient quantity.</exception>
        public virtual void IsSubsetOf( ICollection subset, ICollection superset, string message, params object[] parameters ) => CollectionAssert.IsSubsetOf( subset, superset, message, parameters );

        /// <summary>Verifies that the first collection is not a subset of the second collection.</summary>
        /// <param name="subset">The collection not expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="subset" />.</param>
        /// <exception cref="AssertFailedException">All elements in <paramref name="subset" /> are found in <paramref name="superset" /> and are found in sufficient quantity.</exception>
        public virtual void IsNotSubsetOf( ICollection subset, ICollection superset ) => CollectionAssert.IsNotSubsetOf( subset, superset, string.Empty, null );

        /// <summary>Verifies that the first collection is not a subset of the second collection. Displays a message if the assertion fails.</summary>
        /// <param name="subset">The collection not expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">All elements in <paramref name="subset" /> are found in <paramref name="superset" /> and are found in sufficient quantity.</exception>
        public virtual void IsNotSubsetOf( ICollection subset, ICollection superset, string message ) => CollectionAssert.IsNotSubsetOf( subset, superset, message, null );

        /// <summary>Verifies that the first collection is not a subset of the second collection. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="subset">The collection not expected to be a subset of <paramref name="superset" />.</param>
        /// <param name="superset">The collection not expected to be a superset of <paramref name="subset" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">All elements in <paramref name="subset" /> are found in <paramref name="superset" /> and are found in sufficient quantity.</exception>
        public virtual void IsNotSubsetOf( ICollection subset, ICollection superset, string message, params object[] parameters ) => CollectionAssert.IsNotSubsetOf( subset, superset, message, parameters );

        /// <summary>Verifies that two specified collections are equivalent. The assertion fails if the collections are not equivalent.</summary>
        /// <param name="expected">The first collection to compare. This contains the elements the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <exception cref="AssertFailedException">An element was found in one of the collections but not in the other.</exception>
        public virtual void AreEquivalent( ICollection expected, ICollection actual ) => CollectionAssert.AreEquivalent( expected, actual, string.Empty, null );

        /// <summary>Verifies that two specified collections are equivalent. The assertion fails if the collections are not equivalent. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first collection to compare. This contains the elements the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">An element was found in one of the collections but not in the other.</exception>
        public virtual void AreEquivalent( ICollection expected, ICollection actual, string message ) => CollectionAssert.AreEquivalent( expected, actual, message, null );

        /// <summary>Verifies that two specified collections are equivalent. The assertion fails if the collections are not equivalent. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first collection to compare. This contains the elements the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">An element was found in one of the collections but not the other.</exception>
        public virtual void AreEquivalent( ICollection expected, ICollection actual, string message, params object[] parameters ) => CollectionAssert.AreEquivalent( expected, actual, message, parameters );

        /// <summary>Verifies that two specified collections are not equivalent. The assertion fails if the collections are equivalent.</summary>
        /// <param name="expected">The first collection to compare. This contains the elements the unit test expects to be different from the actual collection.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <exception cref="AssertFailedException">The two collections contain the same elements, including the same number of duplicate occurrences of each element.</exception>
        public virtual void AreNotEquivalent( ICollection expected, ICollection actual ) => CollectionAssert.AreNotEquivalent( expected, actual, string.Empty, null );

        /// <summary>Verifies that two specified collections are not equivalent. The assertion fails if the collections are equivalent. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first collection to compare. This contains the elements the unit test expects to be different from the actual collection.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">The two collections contain the same elements, including the same number of duplicate occurrences of each element.</exception>
        public virtual void AreNotEquivalent( ICollection expected, ICollection actual, string message ) => CollectionAssert.AreNotEquivalent( expected, actual, message, null );

        /// <summary>Verifies that two specified collections are not equivalent. The assertion fails if the collections are equivalent. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first collection to compare. This contains the elements the unit test expects to be different from the actual collection.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">The two collections contain the same elements, including the same number of duplicate occurrences of each element.</exception>
        public virtual void AreNotEquivalent( ICollection expected, ICollection actual, string message, params object[] parameters ) => CollectionAssert.AreNotEquivalent( expected, actual, message, parameters );

        /// <summary>Verifies that all elements in the specified collection are instances of the specified type. The assertion fails if for any element the type is not found in its inheritance hierarchy.</summary>
        /// <param name="collection">The collection to verify.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of every element in <paramref name="collection" />.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="collection" /> is null or <paramref name="expectedType" /> is not found in the inheritance hierarchy of all elements  in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreInstancesOfType( ICollection collection, Type expectedType ) => CollectionAssert.AllItemsAreInstancesOfType( collection, expectedType, string.Empty, null );

        /// <summary>Verifies that all elements in the specified collection are instances of the specified type. The assertion fails if there exists one element in the collection for which the specified type is not found in its inheritance hierarchy. Displays a message if the assertion fails.</summary>
        /// <param name="collection">The collection to verify.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of every element in <paramref name="collection" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="collection" /> is null or <paramref name="expectedType" /> is not found in the inheritance hierarchy of all elements in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreInstancesOfType( ICollection collection, Type expectedType, string message ) => CollectionAssert.AllItemsAreInstancesOfType( collection, expectedType, message, null );

        /// <summary>Verifies that all elements in the specified collection are instances of the specified type. The assertion fails if there exists one element in the collection for which the specified type is not found in its inheritance hierarchy. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="collection">The collection to verify.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of every element in <paramref name="collection" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">An element in <paramref name="collection" /> is null or <paramref name="expectedType" /> is not found in the inheritance hierarchy of all elements in <paramref name="collection" />.</exception>
        public virtual void AllItemsAreInstancesOfType( ICollection collection, Type expectedType, string message, params object[] parameters ) => CollectionAssert.AllItemsAreInstancesOfType( collection, expectedType, message, parameters );

        /// <summary>Verifies that two specified collections are equal. The assertion fails if the collections are not equal.</summary>
        /// <param name="expected">The first collection to compare. This is the collection the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( ICollection expected, ICollection actual ) => CollectionAssert.AreEqual( expected, actual, string.Empty, null );

        /// <summary>Verifies that two specified collections are equal. The assertion fails if the collections are not equal. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first collection to compare. This is the collection the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( ICollection expected, ICollection actual, string message ) => CollectionAssert.AreEqual( expected, actual, message, null );

        /// <summary>Verifies that two specified collections are equal. The assertion fails if the collections are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first collection to compare. This is the collection the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( ICollection expected, ICollection actual, string message, params object[] parameters ) => CollectionAssert.AreEqual( expected, actual, message, parameters );

        /// <summary>Verifies that two specified collections are not equal. The assertion fails if the collections are equal.</summary>
        /// <param name="notExpected">The first collection to compare. This is the collection that the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( ICollection notExpected, ICollection actual ) => CollectionAssert.AreNotEqual( notExpected, actual, string.Empty, null );

        /// <summary>Verifies that two specified collections are not equal. The assertion fails if the collections are equal. Displays a message if the assertion fails.</summary>
        /// <param name="notExpected">The first collection to compare. This is the collection that the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( ICollection notExpected, ICollection actual, string message ) => CollectionAssert.AreNotEqual( notExpected, actual, message, null );

        /// <summary>Verifies that two specified collections are not equal. The assertion fails if the collections are equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="notExpected">The first collection to compare. This is the collection that the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( ICollection notExpected, ICollection actual, string message, params object[] parameters ) => CollectionAssert.AreNotEqual( notExpected, actual, message, parameters );

        /// <summary>Verifies that two specified collections are equal, using the specified method to compare the values of elements. The assertion fails if the collections are not equal.</summary>
        /// <param name="expected">The first collection to compare. This is the collection the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( ICollection expected, ICollection actual, IComparer comparer ) => CollectionAssert.AreEqual( expected, actual, comparer, string.Empty, null );

        /// <summary>Verifies that two specified collections are equal, using the specified method to compare the values of elements. The assertion fails if the collections are not equal. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first collection to compare. This is the collection the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( ICollection expected, ICollection actual, IComparer comparer, string message ) => CollectionAssert.AreEqual( expected, actual, comparer, message, null );

        /// <summary>Verifies that two specified collections are equal, using the specified method to compare the values of elements. The assertion fails if the collections are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first collection to compare. This is the collection the unit test expects.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters ) => CollectionAssert.AreEqual( expected, actual, comparer, message, parameters );

        /// <summary>Verifies that two specified collections are not equal, using the specified method to compare the values of elements. The assertion fails if the collections are equal.</summary>
        /// <param name="notExpected">The first collection to compare. This is the collection that the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( ICollection notExpected, ICollection actual, IComparer comparer ) => CollectionAssert.AreNotEqual( notExpected, actual, comparer, string.Empty, null );

        /// <summary>Verifies that two specified collections are not equal, using the specified method to compare the values of elements. The assertion fails if the collections are equal. Displays a message if the assertion fails.</summary>
        /// <param name="notExpected">The first collection to compare. This is the collection that the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( ICollection notExpected, ICollection actual, IComparer comparer, string message ) => CollectionAssert.AreNotEqual( notExpected, actual, comparer, message, null );

        /// <summary>Verifies that two specified collections are not equal, using the specified method to compare the values of elements. The assertion fails if the collections are equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="notExpected">The first collection to compare. This is the collection that the unit test does not expect to match <paramref name="actual" />.</param>
        /// <param name="actual">The second collection to compare. This is the collection the unit test produced.</param>
        /// <param name="comparer">The compare implementation to use when comparing elements of the collection.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        ///   <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( ICollection notExpected, ICollection actual, IComparer comparer, string message, params object[] parameters ) => CollectionAssert.AreNotEqual( notExpected, actual, comparer, message, parameters );
    }
}