// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

#pragma warning disable CA1811

namespace Microsoft
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    static class Arg
    {
        [DebuggerStepThrough]
        [ContractArgumentValidator]
        internal static void NotNull<T>( T value, string name ) where T : class
        {
            if ( value == null )
            {
                throw new ArgumentNullException( name );
            }

            Contract.EndContractBlock();
        }

        [DebuggerStepThrough]
        [ContractArgumentValidator]
        internal static void NotNull<T>( T? value, string name ) where T : struct
        {
            if ( value == null )
            {
                throw new ArgumentNullException( name );
            }

            Contract.EndContractBlock();
        }

        [DebuggerStepThrough]
        [ContractArgumentValidator]
        internal static void NotNullOrEmpty( string value, string name )
        {
            if ( string.IsNullOrEmpty( value ) )
            {
                throw new ArgumentNullException( name );
            }

            Contract.EndContractBlock();
        }

        [DebuggerStepThrough]
        internal static void InRange<T>( T value, T minValue, string name ) where T : IComparable<T>
        {
            if ( value.CompareTo( minValue ) < 0 )
            {
                throw new ArgumentOutOfRangeException( name );
            }

            Contract.EndContractBlock();
        }

        [DebuggerStepThrough]
        internal static void InRange<T>( T value, T minValue, T maxValue, string name ) where T : IComparable<T>
        {
            if ( value.CompareTo( minValue ) < 0 || value.CompareTo( maxValue ) > 0 )
            {
                throw new ArgumentOutOfRangeException( name );
            }

            Contract.EndContractBlock();
        }

        [DebuggerStepThrough]
        internal static void LessThan<T>( T param, T value, string paramName ) where T : struct, IComparable<T>
        {
            if ( param.CompareTo( value ) >= 0 )
            {
                throw new ArgumentOutOfRangeException( paramName );
            }
        }

        [DebuggerStepThrough]
        internal static void LessThanOrEqualTo<T>( T param, T value, string paramName ) where T : struct, IComparable<T>
        {
            if ( param.CompareTo( value ) > 0 )
            {
                throw new ArgumentOutOfRangeException( paramName );
            }
        }

        [DebuggerStepThrough]
        internal static void GreaterThan<T>( T param, T value, string paramName ) where T : struct, IComparable<T>
        {
            if ( param.CompareTo( value ) <= 0 )
            {
                throw new ArgumentOutOfRangeException( paramName );
            }
        }

        [DebuggerStepThrough]
        internal static void GreaterThanOrEqualTo<T>( T param, T value, string paramName ) where T : struct, IComparable<T>
        {
            if ( param.CompareTo( value ) < 0 )
            {
                throw new ArgumentOutOfRangeException( paramName );
            }
        }
    }
}