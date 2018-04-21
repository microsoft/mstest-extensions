// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using System;

    static class StringExtensions
    {
        internal static string GetExpectedMessage( string paramName ) => $"Assert.IsNotNull failed. The parameter '{paramName}' is invalid. The value cannot be null.";
    }
}