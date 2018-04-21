// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using static FailedTestMessage;

    internal static class ExpressionExtensions
    {
        static bool IsIndexer( this Expression expression ) => expression is MethodCallExpression methodCall && methodCall.Method.Name == "get_Item";

        internal static PropertyInfo GetPropertyFromExpression<TObject, TValue>( this Expression<Func<TObject, TValue>> expression, Asserter assert )
        {
            Contract.Requires( expression != null );
            Contract.Requires( assert != null );
            Contract.Ensures( Contract.Result<PropertyInfo>() != null );

            var body = expression.Body.TryReduce();

            if ( body is MemberExpression memberExpression )
            {
                if ( memberExpression.Member is PropertyInfo property )
                {
                    return property;
                }

                assert.Fail( ExpressionMustReferToPropertyOfDeclaredType, memberExpression, typeof( TObject ) );
            }

            if ( body.IsIndexer() )
            {
                return typeof( TObject ).GetRuntimeProperty( "Item" );
            }

            assert.Fail( ExpresssionMustReferToProperty, expression );

            return default( PropertyInfo );
        }

        internal static IDictionary<string, bool> ToDictionary<TObject>( this IEnumerable<Expression<Func<TObject, object>>> expressions, Asserter assert )
        {
            Contract.Requires( expressions != null );
            Contract.Requires( assert != null );

            // note: the indexer property is "Item", but the CollectionChanged event raises the event with the name "Item[]"
            var names = from expression in expressions
                        let property = expression.GetPropertyFromExpression( assert )
                        let propertyName = property.Name == "Item" ? "Item[]" : property.Name
                        select propertyName;

            return names.Distinct().ToDictionary( key => key, key => false );
        }

        internal static void AllPropertiesWereChanged( this Asserter assert, IDictionary<string, bool> properties )
        {
            Contract.Requires( assert != null );
            Contract.Requires( properties != null );

            var changed = properties.All( kp => kp.Value );

            if ( changed )
            {
                return;
            }

            var unchanged = properties.Where( kp => !kp.Value ).Select( kp => kp.Key ).GetEnumerator();
            var names = new StringBuilder();

            unchanged.MoveNext();
            names.Append( '\'' );
            names.Append( unchanged.Current );
            names.Append( '\'' );

            while ( unchanged.MoveNext() )
            {
                names.Append( ", '" );
                names.Append( unchanged.Current );
                names.Append( '\'' );
            }

            assert.Fail( PropertyChangedNotRaisedForExpectedProperties, names );
        }

        internal static void UnexpectedPropertiesWereNotChanged( this Asserter assert, IEnumerable<string> properties )
        {
            Contract.Requires( assert != null );
            Contract.Requires( properties != null );

            if ( !properties.Any() )
            {
                return;
            }

            var unchanged = properties.GetEnumerator();
            var names = new StringBuilder();

            unchanged.MoveNext();
            names.Append( '\'' );
            names.Append( unchanged.Current );
            names.Append( '\'' );

            while ( unchanged.MoveNext() )
            {
                names.Append( ", '" );
                names.Append( unchanged.Current );
                names.Append( '\'' );
            }

            assert.Fail( PropertyChangedRaisedForUnexpectedProperties, names );
        }

        static Expression TryReduce( this Expression expression ) => expression is UnaryExpression unary ? unary.Operand : expression;
    }
}