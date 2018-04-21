// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.ObjectModel;

    [TestClass]
    public class INotifyCollectionChangedExtensionsTest
    {
        [TestMethod]
        public void AddShouldInsertItem()
        {
            // arrange
            var collection = new ObservableCollection<int>();
            var assert = new Asserter();

            // act, assert
            assert.AddChangedCollection( collection, 1 );
        }

        [TestMethod]
        public void AddShouldInsertItemAndRaiseEvents()
        {
            // arrange
            var collection = new ObservableCollection<int>();
            var assert = new Asserter();

            // act, assert (Count and Item[])
            assert.AddChangedCollection( collection, 1, c => c.Count, c => c[0] );
        }

        [TestMethod]
        public void InsertShouldInsertItem()
        {
            // arrange
            var collection = new ObservableCollection<int>( new[] { 1, 2, 3 } );
            var assert = new Asserter();

            // act, assert
            assert.InsertChangedCollection( collection, 4, 1 );
        }

        [TestMethod]
        public void InsertShouldInsertItemAndRaiseEvents()
        {
            // arrange
            var collection = new ObservableCollection<int>( new[] { 1, 2, 3 } );
            var assert = new Asserter();

            // act, assert (Count and Item[])
            assert.InsertChangedCollection( collection, 4, 1, c => c.Count, c => c[0] );
        }

        [TestMethod]
        public void RemoveShouldRemoveItem()
        {
            // arrange
            var collection = new ObservableCollection<int>( new[] { 1, 2, 3 } );
            var assert = new Asserter();

            // act, assert
            assert.RemoveChangedCollection( collection, 2, 1 );
        }

        [TestMethod]
        public void RemoveShouldRemoveItemAndRaiseEvents()
        {
            // arrange
            var collection = new ObservableCollection<int>( new[] { 1, 2, 3 } );
            var assert = new Asserter();

            // act, assert (Count and Item[])
            assert.RemoveChangedCollection( collection, 2, 1, c => c.Count, c => c[0] );
        }

        [TestMethod]
        public void IndexerShouldIndexerItem()
        {
            // arrange
            var collection = new ObservableCollection<int>( new[] { 1, 2, 3 } );
            var assert = new Asserter();

            // act, assert
            assert.IndexerChangedCollection( collection, 4, 1 );
        }

        [TestMethod]
        public void IndexerShouldIndexerItemAndRaiseEvents()
        {
            // arrange
            var collection = new ObservableCollection<int>( new[] { 1, 2, 3 } );
            var assert = new Asserter();

            // act, assert (Count and Item[])
            assert.IndexerChangedCollection( collection, 4, 1, c => c[0] );
        }

        [TestMethod]
        public void ClearShouldRemoveItemsFromCollection()
        {
            // arrange
            var collection = new ObservableCollection<int>( new[] { 1, 2, 3 } );
            var assert = new Asserter();

            // act, assert
            assert.ClearChangedCollection( collection );
        }

        [TestMethod]
        public void ClearShouldRemoveItemsFromCollectionAndRaiseEvents()
        {
            // arrange
            var collection = new ObservableCollection<int>( new[] { 1, 2, 3 } );
            var assert = new Asserter();

            // act, assert (Count and Item[])
            assert.ClearChangedCollection( collection, c => c.Count, c => c[0] );
        }
    }
}