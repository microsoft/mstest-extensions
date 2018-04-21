// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Linq.Expressions;
    using static FailedTestMessage;
    using static System.Collections.Specialized.NotifyCollectionChangedAction;

    /// <summary>
    /// Provides assertion support for <see cref="INotifyCollectionChanged" />.
    /// </summary>
    public static class INotifyCollectionChangedExtensions
    {
        const int DefaultIndex = -1;

        /// <summary>
        /// Asserts that the <see cref="ICollection{T}.Add">add</see> method adds the specified element to a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="ICollection{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to add to the collection.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='AddChangedCollection`2']/example[1]" />
        public static void AddChangedCollection<TCollection, TItem>( this Asserter assert, TCollection collection, TItem item ) where TCollection : ICollection<TItem>, INotifyCollectionChanged =>
            assert.AddChangedCollection( collection, item, collection == null ? DefaultIndex : collection.Count );

        /// <summary>
        /// Asserts that the <see cref="ICollection{T}.Add">add</see> method adds the specified element to a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="ICollection{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to add to the collection.</param>
        /// <param name="expectedIndex">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='AddChangedCollection`2']/example[2]" />
        public static void AddChangedCollection<TCollection, TItem>( this Asserter assert, TCollection collection, TItem item, int expectedIndex ) where TCollection : ICollection<TItem>, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );

            var expectedCount = collection.Count + 1;

            assert.AddChangedCollection( collection, item, expectedIndex, () => collection.Add( item ) );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="ICollection{T}.Add">add</see> method adds the specified element to a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="ICollection{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to add to the collection.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='AddChangedCollection`2']/example[3]" />
        public static void AddChangedCollection<TCollection, TItem>(
            this Asserter assert,
            TCollection collection,
            TItem item,
            params Expression<Func<TCollection, object>>[] changedProperties )
            where TCollection : ICollection<TItem>,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged =>
            assert.AddChangedCollection( collection, item, collection == null ? DefaultIndex : collection.Count, changedProperties );

        /// <summary>
        /// Asserts that the <see cref="ICollection{T}.Add">add</see> method adds the specified element to a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="ICollection{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to add to the collection.</param>
        /// <param name="expectedIndex">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='AddChangedCollection`2']/example[4]" />
        public static void AddChangedCollection<TCollection, TItem>(
            this Asserter assert,
            TCollection collection,
            TItem item,
            int expectedIndex,
            params Expression<Func<TCollection, object>>[] changedProperties )
            where TCollection : ICollection<TItem>,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var expectedCount = collection.Count + 1;
            var properties = changedProperties.ToDictionary( assert );

            assert.AddChangedCollection( collection, collection, item, expectedIndex, properties, () => collection.Add( item ) );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.Add">add</see> method adds a new element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to add to the collection.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='AddChangedCollection`2']/example[1]" />
        public static void AddChangedCollection<TList>( this Asserter assert, TList collection, object item ) where TList : IList, INotifyCollectionChanged =>
            assert.AddChangedCollection( collection, item, collection == null ? DefaultIndex : collection.Count );

        /// <summary>
        /// Asserts that the <see cref="IList.Add">add</see> method adds a new element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to add to the collection.</param>
        /// <param name="expectedIndex">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='AddChangedCollection`2']/example[2]" />
        public static void AddChangedCollection<TList>( this Asserter assert, TList collection, object item, int expectedIndex ) where TList : IList, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );

            var expectedCount = collection.Count + 1;

            assert.AddChangedCollection( collection, item, expectedIndex, () => collection.Add( item ) );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.Add">add</see> method adds a new element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to add to the collection.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='AddChangedCollection`2']/example[3]" />
        public static void AddChangedCollection<TList>(
            this Asserter assert,
            TList collection,
            object item,
            params Expression<Func<TList, object>>[] changedProperties )
            where TList : IList,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged =>
            assert.AddChangedCollection( collection, item, collection == null ? 0 : collection.Count, changedProperties );

        /// <summary>
        /// Asserts that the <see cref="IList.Add">add</see> method adds a new element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to add to the collection.</param>
        /// <param name="expectedIndex">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='AddChangedCollection`2']/example[4]" />
        public static void AddChangedCollection<TList>(
            this Asserter assert,
            TList collection,
            object item,
            int expectedIndex,
            params Expression<Func<TList, object>>[] changedProperties )
            where TList : IList,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var expectedCount = collection.Count + 1;
            var properties = changedProperties.ToDictionary( assert );

            assert.AddChangedCollection( collection, collection, item, expectedIndex, properties, () => collection.Add( item ) );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="ICollection{T}.Remove">remove</see> method removes the specified element from a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="ICollection{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to remove from the collection.</param>
        /// <param name="expectedIndex">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='RemoveChangedCollection`2']/example[1]" />
        public static void RemoveChangedCollection<TCollection, TItem>( this Asserter assert, TCollection collection, TItem item, int expectedIndex ) where TCollection : ICollection<TItem>, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );

            var expectedCount = collection.Count - 1;
            var removed = false;

            assert.RemoveChangedCollection( collection, item, expectedIndex, () => removed = collection.Remove( item ) );
            assert.IsTrue( removed, CollectionItemNotRemoved );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="ICollection{T}.Remove">remove</see> method removes the specified element to a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="ICollection{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to remove from the collection.</param>
        /// <param name="expectedIndex">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='RemoveChangedCollection`2']/example[2]" />
        public static void RemoveChangedCollection<TCollection, TItem>(
            this Asserter assert,
            TCollection collection,
            TItem item,
            int expectedIndex,
            params Expression<Func<TCollection, object>>[] changedProperties )
            where TCollection : ICollection<TItem>,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var expectedCount = collection.Count - 1;
            var properties = changedProperties.ToDictionary( assert );
            var removed = false;

            assert.RemoveChangedCollection( collection, collection, item, expectedIndex, properties, () => removed = collection.Remove( item ) );
            assert.IsTrue( removed, CollectionItemNotRemoved );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.Remove">remove</see> method removes a new element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to remove from the collection.</param>
        /// <param name="expectedIndex">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='RemoveChangedCollection`2']/example[1]" />
        public static void RemoveChangedCollection<TList>( this Asserter assert, TList collection, object item, int expectedIndex ) where TList : IList, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );

            var expectedCount = collection.Count - 1;
            var removed = false;

            void RunTeset()
            {
                var count = collection.Count;
                collection.Remove( item );
                removed = collection.Count != count;
            }

            assert.RemoveChangedCollection( collection, item, expectedIndex, RunTeset );
            assert.IsTrue( removed, CollectionItemNotRemoved );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.Remove">remove</see> method removes a new element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to remove from the collection.</param>
        /// <param name="expectedIndex">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='RemoveChangedCollection`2']/example[2]" />
        public static void RemoveChangedCollection<TList>(
            this Asserter assert,
            TList collection,
            object item,
            int expectedIndex,
            params Expression<Func<TList, object>>[] changedProperties )
            where TList : IList,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var expectedCount = collection.Count - 1;
            var properties = changedProperties.ToDictionary( assert );
            var removed = false;

            void RunTest()
            {
                var count = collection.Count;
                collection.Remove( item );
                removed = collection.Count != count;
            }

            assert.RemoveChangedCollection( collection, collection, item, expectedIndex, properties, RunTest );
            assert.IsTrue( removed, CollectionItemNotRemoved );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList{T}.Insert">insert</see> method inserts the specified element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to insert into the collection.</param>
        /// <param name="index">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='InsertChangedCollection`2']/example[1]" />
        public static void InsertChangedCollection<TCollection, TItem>( this Asserter assert, TCollection collection, TItem item, int index ) where TCollection : IList<TItem>, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );

            var expectedCount = collection.Count + 1;

            assert.AddChangedCollection( collection, item, index, () => collection.Insert( index, item ) );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList{T}.Insert">insert</see> method inserts the specified element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to insert into the collection.</param>
        /// <param name="index">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='InsertChangedCollection`2']/example[2]" />
        public static void InsertChangedCollection<TCollection, TItem>(
            this Asserter assert,
            TCollection collection,
            TItem item,
            int index,
            params Expression<Func<TCollection, object>>[] changedProperties )
            where TCollection : IList<TItem>,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var expectedCount = collection.Count + 1;
            var properties = changedProperties.ToDictionary( assert );

            assert.AddChangedCollection( collection, collection, item, index, properties, () => collection.Insert( index, item ) );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.Insert">insert</see> method inserts the specified element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to insert into the collection.</param>
        /// <param name="index">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='InsertChangedCollection`2']/example[1]" />
        public static void InsertChangedCollection<TList>( this Asserter assert, TList collection, object item, int index ) where TList : IList, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );

            var expectedCount = collection.Count + 1;

            assert.AddChangedCollection( collection, item, index, () => collection.Insert( index, item ) );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.Insert">insert</see> method inserts the specified element into a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to insert into the collection.</param>
        /// <param name="index">The zero-based index where the insertion of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='InsertChangedCollection`2']/example[2]" />
        public static void InsertChangedCollection<TList>(
            this Asserter assert,
            TList collection,
            object item,
            int index,
            params Expression<Func<TList, object>>[] changedProperties )
            where TList : IList,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var expectedCount = collection.Count + 1;
            var properties = changedProperties.ToDictionary( assert );

            assert.AddChangedCollection( collection, collection, item, index, properties, () => collection.Insert( index, item ) );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList{T}.this">indexer</see> replaces the specified element in a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to replace the collection.</param>
        /// <param name="index">The zero-based index where the replacement of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='IndexerChangedCollection`2']/example[1]" />
        public static void IndexerChangedCollection<TCollection, TItem>( this Asserter assert, TCollection collection, TItem item, int index ) where TCollection : IList<TItem>, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );

            var oldItem = collection[index];
            var expectedCount = collection.Count;

            assert.IndexerChangedCollection( collection, item, oldItem, index, () => collection[index] = item );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList{T}.this">index</see> replaces the specified element in a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList{T}">collection</see> to test.</param>
        /// <param name="item">The <typeparamref name="TItem">item</typeparamref> to replace in the collection.</param>
        /// <param name="index">The zero-based index where the replacement of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='IndexerChangedCollection`2']/example[2]" />
        public static void IndexerChangedCollection<TCollection, TItem>(
            this Asserter assert,
            TCollection collection,
            TItem item,
            int index,
            params Expression<Func<TCollection, object>>[] changedProperties )
            where TCollection : IList<TItem>,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var oldItem = collection[index];
            var expectedCount = collection.Count;
            var properties = changedProperties.ToDictionary( assert );

            assert.IndexerChangedCollection( collection, collection, item, oldItem, index, properties, () => collection[index] = item );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.this">indexer</see> replaces the specified element in a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to replace in the collection.</param>
        /// <param name="index">The zero-based index where the replacement of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='IndexerChangedCollection`2']/example[1]" />
        public static void IndexerChangedCollection<TList>( this Asserter assert, TList collection, object item, int index ) where TList : IList, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );

            var oldItem = collection[index];
            var expectedCount = collection.Count;

            assert.IndexerChangedCollection( collection, item, oldItem, index, () => collection[index] = item );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.this">indexer</see> replaces the specified element in a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="item">The item to replace in the collection.</param>
        /// <param name="index">The zero-based index where the replacement of the <paramref name="item"/> is expected to
        /// take place in the <paramref name="collection"/>.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='IndexerChangedCollection`2']/example[2]" />
        public static void IndexerChangedCollection<TList>(
            this Asserter assert,
            TList collection,
            object item,
            int index,
            params Expression<Func<TList, object>>[] changedProperties )
            where TList : IList,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var oldItem = collection[index];
            var expectedCount = collection.Count;
            var properties = changedProperties.ToDictionary( assert );

            assert.IndexerChangedCollection( collection, collection, item, oldItem, index, properties, () => collection[index] = item );
            assert.AreEqual( expectedCount, collection.Count, CollectionCountUnexpected, expectedCount, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="ICollection{T}.Clear">clear</see> method removes all the elements from a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="ICollection{T}">collection</see> to test.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='ClearChangedCollection`2']/example[1]" />
        public static void ClearChangedCollection<TCollection, TItem>( this Asserter assert, TCollection collection ) where TCollection : ICollection<TItem>, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.ClearChangedCollection( collection, collection.Clear );
            assert.AreEqual( 0, collection.Count, CollectionCountUnexpected, 0, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="ICollection{T}.Clear">clear</see> method removes all the elements from a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TCollection">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <typeparam name="TItem">The <see cref="Type">type</see> of item in the collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="ICollection{T}">collection</see> to test.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='ClearChangedCollection`2']/example[2]" />
        public static void ClearChangedCollection<TCollection, TItem>(
            this Asserter assert,
            TCollection collection,
            params Expression<Func<TCollection, object>>[] changedProperties )
            where TCollection : ICollection<TItem>,
                  INotifyCollectionChanged,
                  INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var properties = changedProperties.ToDictionary( assert );

            assert.ClearChangedCollection( collection, collection, properties, collection.Clear );
            assert.AreEqual( 0, collection.Count, CollectionCountUnexpected, 0, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.Clear">clear</see> method removes all the elements from a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='ClearChangedCollection`2']/example[1]" />
        public static void ClearChangedCollection<TList>( this Asserter assert, TList collection ) where TList : IList, INotifyCollectionChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.ClearChangedCollection( collection, collection.Clear );
            assert.AreEqual( 0, collection.Count, CollectionCountUnexpected, 0, collection.Count );
        }

        /// <summary>
        /// Asserts that the <see cref="IList.Clear">clear</see> method removes all the elements from a collection
        /// and raises the appropriate <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/> events.
        /// </summary>
        /// <typeparam name="TList">The <see cref="Type">type</see> of collection to test.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="collection">The <see cref="IList">collection</see> to test.</param>
        /// <param name="changedProperties">The sequence of <see cref="Expression{T}">expressions</see> representing the
        /// collection properties that are expected to change.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyCollectionChangedExtensions']/Member[@name='ClearChangedCollection`2']/example[2]" />
        public static void ClearChangedCollection<TList>( this Asserter assert, TList collection, params Expression<Func<TList, object>>[] changedProperties ) where TList : IList, INotifyCollectionChanged, INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( collection, nameof( collection ) );
            assert.AssertParameterIsNotNull( changedProperties, nameof( changedProperties ) );

            var properties = changedProperties.ToDictionary( assert );

            assert.ClearChangedCollection( collection, collection, properties, collection.Clear );
            assert.AreEqual( 0, collection.Count, CollectionCountUnexpected, 0, collection.Count );
        }

        static IList<NotifyCollectionChangedEventArgs> CollectionChanged( this Asserter assert, INotifyCollectionChanged collectionSource, INotifyPropertyChanged propertySource, IDictionary<string, bool> properties, Action test )
        {
            Contract.Requires( assert != null );
            Contract.Requires( collectionSource != null );
            Contract.Requires( properties != null );
            Contract.Requires( test != null );
            Contract.Ensures( Contract.Result<IList<NotifyCollectionChangedEventArgs>>() != null );

            var changes = new List<NotifyCollectionChangedEventArgs>();

            void OnCollectionChanged( object sender, NotifyCollectionChangedEventArgs e ) => changes.Add( e );

            if ( propertySource != null )
            {
                var unexpected = new HashSet<string>();

                void OnPropertyChanged( object sender, PropertyChangedEventArgs e )
                {
                    if ( properties.ContainsKey( e.PropertyName ) )
                    {
                        properties[e.PropertyName] = true;
                    }
                    else
                    {
                        unexpected.Add( e.PropertyName );
                    }
                }

                collectionSource.CollectionChanged += OnCollectionChanged;
                propertySource.PropertyChanged += OnPropertyChanged;

                try
                {
                    test();
                }
                finally
                {
                    collectionSource.CollectionChanged -= OnCollectionChanged;
                    propertySource.PropertyChanged -= OnPropertyChanged;
                }

                assert.AllPropertiesWereChanged( properties );
                assert.UnexpectedPropertiesWereNotChanged( unexpected );
            }
            else
            {
                collectionSource.CollectionChanged += OnCollectionChanged;

                try
                {
                    test();
                }
                finally
                {
                    collectionSource.CollectionChanged -= OnCollectionChanged;
                }
            }

            return changes;
        }

        static void AddChangedCollection<TItem>( this Asserter assert, INotifyCollectionChanged collectionSource, TItem item, int expectedIndex, Action test ) =>
            assert.AddChangedCollection( collectionSource, default( INotifyPropertyChanged ), item, expectedIndex, new Dictionary<string, bool>(), test );

        static void AddChangedCollection<TItem>(
            this Asserter assert,
            INotifyCollectionChanged collectionSource,
            INotifyPropertyChanged propertySource,
            TItem item,
            int expectedIndex,
            IDictionary<string, bool> properties,
            Action test )
        {
            Contract.Requires( assert != null );
            Contract.Requires( collectionSource != null );
            Contract.Requires( properties != null );
            Contract.Requires( test != null );

            var changes = assert.CollectionChanged( collectionSource, propertySource, properties, test );

            // CollectionChanged event should have been raised exactly once
            assert.AreNotEqual( 0, changes.Count, CollectionChangedNotRaised );
            assert.AreEqual( 1, changes.Count, CollectionChangedMoreThanOnce );

            var e = changes.Single();

            // 1. change action should have been 'Add'
            // 2. NewItems should not be null and contain the added item
            // 3. OldItems should be null or empty
            // 4. NewStartingIndex should equal the expected index
            // 5. OldStartingIndex should equal -1 during adds
            assert.AreEqual( Add, e.Action, CollectionChangedActionNotExpected, Add, e.Action );
            assert.IsNotNull( e.NewItems, CollectionChangedNullItems, "NewItems" );
            assert.AreEqual( 1, e.NewItems.Count, CollectionChangedItemCountUnexpected, "NewItems", 1 );
            assert.AreEqual( item, (TItem) e.NewItems[0], CollectionChangedItemUnexpected, "NewItems" );
            assert.IsTrue( e.OldItems == null || e.OldItems.Count == 0, CollectionChangedWithItems, "OldItems" );
            assert.AreEqual( expectedIndex, e.NewStartingIndex, CollectionChangedNewIndexNotExpected, expectedIndex, e.NewStartingIndex );
            assert.AreEqual( DefaultIndex, e.OldStartingIndex, CollectionChangedOldIndexNotExpected, DefaultIndex, e.OldStartingIndex );
        }

        static void RemoveChangedCollection<TItem>( this Asserter assert, INotifyCollectionChanged collectionSource, TItem item, int expectedIndex, Action test ) =>
            assert.RemoveChangedCollection( collectionSource, default( INotifyPropertyChanged ), item, expectedIndex, new Dictionary<string, bool>(), test );

        static void RemoveChangedCollection<TItem>(
            this Asserter assert,
            INotifyCollectionChanged collectionSource,
            INotifyPropertyChanged propertySource,
            TItem item,
            int expectedIndex,
            IDictionary<string, bool> properties,
            Action test )
        {
            Contract.Requires( assert != null );
            Contract.Requires( collectionSource != null );
            Contract.Requires( properties != null );
            Contract.Requires( test != null );

            var changes = assert.CollectionChanged( collectionSource, propertySource, properties, test );

            // CollectionChanged event should have been raised exactly once
            assert.AreNotEqual( 0, changes.Count, CollectionChangedNotRaised );
            assert.AreEqual( 1, changes.Count, CollectionChangedMoreThanOnce );

            var e = changes.Single();

            // 1. change action should have been 'Remove'
            // 2. NewItems should be null or empty
            // 3. OldItems should not be null and contain the added item
            // 4. NewStartingIndex should equal -1 during removes
            // 5. OldStartingIndex should equal the expected index
            assert.AreEqual( Remove, e.Action, CollectionChangedActionNotExpected, Remove, e.Action );
            assert.IsNotNull( e.OldItems, CollectionChangedNullItems, "OldItems" );
            assert.AreEqual( 1, e.OldItems.Count, CollectionChangedItemCountUnexpected, "OldItems", 1 );
            assert.AreEqual( item, (TItem) e.OldItems[0], CollectionChangedItemUnexpected, "OldItems" );
            assert.IsTrue( e.NewItems == null || e.NewItems.Count == 0, CollectionChangedWithItems, "NewItems" );
            assert.AreEqual( expectedIndex, e.OldStartingIndex, CollectionChangedOldIndexNotExpected, expectedIndex, e.OldStartingIndex );
            assert.AreEqual( DefaultIndex, e.NewStartingIndex, CollectionChangedNewIndexNotExpected, DefaultIndex, e.NewStartingIndex );
        }

        static void IndexerChangedCollection<TItem>( this Asserter assert, INotifyCollectionChanged collectionSource, TItem newItem, TItem oldItem, int index, Action test ) =>
            assert.IndexerChangedCollection( collectionSource, default( INotifyPropertyChanged ), newItem, oldItem, index, new Dictionary<string, bool>(), test );

        static void IndexerChangedCollection<TItem>(
            this Asserter assert,
            INotifyCollectionChanged collectionSource,
            INotifyPropertyChanged propertySource,
            TItem newItem,
            TItem oldItem,
            int index,
            IDictionary<string, bool> properties,
            Action test )
        {
            Contract.Requires( assert != null );
            Contract.Requires( collectionSource != null );
            Contract.Requires( properties != null );
            Contract.Requires( test != null );

            var changes = assert.CollectionChanged( collectionSource, propertySource, properties, test );

            // CollectionChanged event should have been raised exactly once
            assert.AreNotEqual( 0, changes.Count, CollectionChangedNotRaised );
            assert.AreEqual( 1, changes.Count, CollectionChangedMoreThanOnce );

            var e = changes.Single();

            // 1. change action should have been 'Repalce'
            // 2. NewItems should not be null and contain the new item
            // 3. OldItems should not be null and contain the old item
            // 4. NewStartingIndex should equal the expected index
            // 5. OldStartingIndex should equal the expected index or -1
            //       Note: a property such as a dictionary indexer might
            //       perform an add in which case there is no old index
            assert.AreEqual( Replace, e.Action, CollectionChangedActionNotExpected, Replace, e.Action );
            assert.IsNotNull( e.NewItems, CollectionChangedNullItems, "NewItems" );
            assert.AreEqual( 1, e.NewItems.Count, CollectionChangedItemCountUnexpected, "NewItems", 1 );
            assert.AreEqual( newItem, (TItem) e.NewItems[0], CollectionChangedItemUnexpected, "NewItems" );
            assert.IsNotNull( e.OldItems, CollectionChangedNullItems, "OldItems" );
            assert.AreEqual( 1, e.OldItems.Count, CollectionChangedItemCountUnexpected, "OldItems", 1 );
            assert.AreEqual( oldItem, (TItem) e.OldItems[0], CollectionChangedItemUnexpected, "OldItems" );
            assert.AreEqual( index, e.NewStartingIndex, CollectionChangedNewIndexNotExpected, index, e.NewStartingIndex );
            assert.IsTrue( e.OldStartingIndex == index || e.OldStartingIndex == DefaultIndex, CollectionChangedOldIndexNotExpected, index, e.OldStartingIndex );
        }

        static void ClearChangedCollection( this Asserter assert, INotifyCollectionChanged collection, Action test ) =>
            assert.ClearChangedCollection( collection, default( INotifyPropertyChanged ), new Dictionary<string, bool>(), test );

        static void ClearChangedCollection( this Asserter assert, INotifyCollectionChanged collectionSource, INotifyPropertyChanged propertySource, IDictionary<string, bool> properties, Action test )
        {
            Contract.Requires( assert != null );
            Contract.Requires( collectionSource != null );
            Contract.Requires( properties != null );
            Contract.Requires( test != null );

            var changes = assert.CollectionChanged( collectionSource, propertySource, properties, test );

            // CollectionChanged event should have been raised exactly once
            assert.AreNotEqual( 0, changes.Count, CollectionChangedNotRaised );
            assert.AreEqual( 1, changes.Count, CollectionChangedMoreThanOnce );

            var e = changes.Single();

            // 1. change action should have been 'Reset'
            // 2. NewItems should be null or empty
            // 3. OldItems should be null or empty
            // 4. NewStartingIndex should equal -1 during clears
            // 5. OldStartingIndex should equal -1 during clears
            assert.AreEqual( Reset, e.Action, CollectionChangedActionNotExpected, Reset, e.Action );
            assert.IsTrue( e.NewItems == null || e.NewItems.Count == 0, CollectionChangedWithItems, "NewItems" );
            assert.IsTrue( e.OldItems == null || e.OldItems.Count == 0, CollectionChangedWithItems, "OldItems" );
            assert.AreEqual( DefaultIndex, e.NewStartingIndex, CollectionChangedNewIndexNotExpected, DefaultIndex, e.NewStartingIndex );
            assert.AreEqual( DefaultIndex, e.OldStartingIndex, CollectionChangedOldIndexNotExpected, DefaultIndex, e.OldStartingIndex );
        }
    }
}