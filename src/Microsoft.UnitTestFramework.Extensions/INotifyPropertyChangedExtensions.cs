// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Linq.Expressions;
    using static FailedTestMessage;
    using static System.Linq.Expressions.Expression;

    /// <summary>
    /// Provides assertion support for <see cref="INotifyPropertyChanged" />.
    /// </summary>
    public static class INotifyPropertyChangedExtensions
    {
        /// <summary>
        /// Asserts that the specified object raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event for the specified property.
        /// </summary>
        /// <typeparam name="TObject">The <see cref="Type">type</see> of <see cref="INotifyPropertyChanged">object</see> to test.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type">type</see> of value to assign to the property.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subject">The <see cref="INotifyPropertyChanged">object</see> to test.</param>
        /// <param name="testProperty">The <see cref="Expression{T}"/> representing the test property.</param>
        /// <param name="value">The value to to assign to the tested property.</param>
        /// <param name="otherProperties">A sequence of other property <see cref="Expression{T}">expressions</see> representing the additional properties
        /// that are expected to change and raise the <see cref="INotifyPropertyChanged.PropertyChanged"/> event as a result of changing the
        /// <paramref name="testProperty">tested property</paramref>.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyPropertyChangedExtensions']/Member[@name='PropertyChanged`2']/example" />
        public static void PropertyChanged<TObject, TValue>(
            this Asserter assert,
            TObject subject,
            Expression<Func<TObject, TValue>> testProperty,
            TValue value,
            params Expression<Func<TObject, object>>[] otherProperties ) where TObject : INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( subject, nameof( subject ) );
            assert.AssertParameterIsNotNull( testProperty, nameof( testProperty ) );
            assert.AssertParameterIsNotNull( otherProperties, nameof( otherProperties ) );

            var test = subject.GetTestForProperty( assert, testProperty, out var propertyName );
            var unexpected = new HashSet<string>();
            var properties = otherProperties.ToDictionary( assert );

            properties.Add( propertyName, false );

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

            subject.PropertyChanged += OnPropertyChanged;

            try
            {
                test( subject, value );
            }
            finally
            {
                subject.PropertyChanged -= OnPropertyChanged;
            }

            assert.AllPropertiesWereChanged( properties );
            assert.UnexpectedPropertiesWereNotChanged( unexpected );
        }

        /// <summary>
        /// Asserts that the specified object does not raise the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <typeparam name="TObject">The <see cref="Type">type</see> of <see cref="INotifyPropertyChanged">object</see> to test.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type">type</see> of value to assign to the property.</typeparam>
        /// <param name="assert">The extended <see cref="Asserter"/>.</param>
        /// <param name="subject">The <see cref="INotifyPropertyChanged">object</see> to test.</param>
        /// <param name="testProperty">The <see cref="Expression{T}">expression</see> representing the test property.</param>
        /// <param name="value">The value to to assign to the tested property.</param>
        /// <include file="examples.xml" path="Types/Type[@name='INotifyPropertyChangedExtensions']/Member[@name='PropertyNotChanged`2']/example" />
        public static void PropertyNotChanged<TObject, TValue>( this Asserter assert, TObject subject, Expression<Func<TObject, TValue>> testProperty, TValue value ) where TObject : INotifyPropertyChanged
        {
            Arg.NotNull( assert, nameof( assert ) );

            assert.AssertParameterIsNotNull( subject, nameof( subject ) );
            assert.AssertParameterIsNotNull( testProperty, nameof( testProperty ) );

            var changed = false;
            var test = subject.GetTestForProperty( assert, testProperty, out var propertyName );

            void OnPropertyChanged( object sender, PropertyChangedEventArgs e )
            {
                changed = true;
                propertyName = e.PropertyName;
            }

            subject.PropertyChanged += OnPropertyChanged;

            try
            {
                test( subject, value );
            }
            finally
            {
                subject.PropertyChanged -= OnPropertyChanged;
            }

            if ( string.IsNullOrEmpty( propertyName ) )
            {
                assert.IsFalse( changed, AllPropertiesChangedRaised );
            }
            else
            {
                assert.IsFalse( changed, PropertyChangedRaised, propertyName );
            }
        }

        static Action<TObject, TValue> GetTestForProperty<TObject, TValue>( this TObject subject, Asserter assert, Expression<Func<TObject, TValue>> testProperty, out string propertyName ) where TObject : INotifyPropertyChanged
        {
            Contract.Requires( assert != null );
            Contract.Requires( subject != null );
            Contract.Requires( testProperty != null );
            Contract.Ensures( !string.IsNullOrWhiteSpace( Contract.ValueAtReturn( out propertyName ) ) );
            Contract.Ensures( Contract.Result<Action<TObject, TValue>>() != null );

            var property = testProperty.GetPropertyFromExpression( assert );

            propertyName = property.Name;

            // the compiler doesn't support expression assignments. to overcome this, we'll build the appropriate expression here by hand.
            var @this = testProperty.Parameters[0];
            var value = Parameter( typeof( TValue ), "value" );
            var setterBlock = Block( Assign( testProperty.Body, value ) );
            var setter = Lambda<Action<TObject, TValue>>( setterBlock, @this, value );
            var test = setter.Compile();

            return test;
        }
    }
}