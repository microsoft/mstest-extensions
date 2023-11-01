﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
#if NETSTANDARD2_1_OR_GREATER
    using System.Diagnostics.CodeAnalysis;
#endif
    using System.Linq;
    using static FailedTestMessage;

    /// <summary>
    /// Represents support for asserting unit tests.
    /// </summary>
    /// <remarks>This class exposes all of the methods provided by <see cref="Assert"/>. All other assertion
    /// extensions are expected to be typically provided by defining extension methods.</remarks>
    public class Asserter
    {
        /// <summary>Verifies that two specified objects are equal. The assertion fails if the objects are not equal.</summary>
        /// <param name="expected">The first object to compare. This is the object the unit test expects.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( object expected, object actual ) => Assert.AreEqual( expected, actual );

        /// <summary>Verifies that two specified generic type data are equal. The assertion fails if they are not equal.</summary>
        /// <param name="expected">The first generic type data to compare. This is the generic type data the unit test expects.</param>
        /// <param name="actual">The second generic type data to compare. This is the generic type data the unit test produced.</param>
        /// <typeparam name="T">The <see cref="Type">type</see> of expected value.</typeparam>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual<T>( T expected, T actual ) => Assert.AreEqual<T>( expected, actual );

        /// <summary>Verifies that two specified doubles are equal, or within the specified accuracy of each other. The assertion fails if they are not within the specified accuracy of each other.</summary>
        /// <param name="expected">The first double to compare. This is the double the unit test expects.</param>
        /// <param name="actual">The second double to compare. This is the double the unit test produced.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</exception>
        public virtual void AreEqual( double expected, double actual, double delta ) => Assert.AreEqual( expected, actual, delta );

        /// <summary>Verifies that two specified singles are equal, or within the specified accuracy of each other. The assertion fails if they are not within the specified accuracy of each other.</summary>
        /// <param name="expected">The first single to compare. This is the single the unit test expects.</param>
        /// <param name="actual">The second single to compare. This is the single the unit test produced.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( float expected, float actual, float delta ) => Assert.AreEqual( expected, actual, delta );

        /// <summary>Verifies that two specified objects are equal. The assertion fails if the objects are not equal. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first object to compare. This is the object the unit test expects.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( object expected, object actual, string message ) => Assert.AreEqual( expected, actual, message );

        /// <summary>Verifies that two specified strings are equal, ignoring case or not as specified. The assertion fails if they are not equal.</summary>
        /// <param name="expected">The first string to compare. This is the string the unit test expects.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
#pragma warning disable CA1304 // Specify CultureInfo
        public virtual void AreEqual( string expected, string actual, bool ignoreCase ) => Assert.AreEqual( expected, actual, ignoreCase );
#pragma warning restore CA1304 // Specify CultureInfo

        /// <summary>Verifies that two specified generic type data are equal. The assertion fails if they are not equal. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first generic type data to compare. This is the generic type data the unit test expects.</param>
        /// <param name="actual">The second generic type data to compare. This is the generic type data the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <typeparam name="T">The <see cref="Type">type</see> of expected value.</typeparam>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual<T>( T expected, T actual, string message ) => Assert.AreEqual<T>( expected, actual, message );

        /// <summary>Verifies that two specified doubles are equal, or within the specified accuracy of each other. The assertion fails if they are not within the specified accuracy of each other. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first double to compare. This is the double the unit test expects.</param>
        /// <param name="actual">The second double to compare. This is the double the unit test produced.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</exception>
        public virtual void AreEqual( double expected, double actual, double delta, string message ) => Assert.AreEqual( expected, actual, delta, message );

        /// <summary>Verifies that two specified singles are equal, or within the specified accuracy of each other. The assertion fails if they are not within the specified accuracy of each other. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first single to compare. This is the single the unit test expects.</param>
        /// <param name="actual">The second single to compare. This is the single the unit test produced.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( float expected, float actual, float delta, string message ) => Assert.AreEqual( expected, actual, delta, message );

        /// <summary>Verifies that two specified objects are equal. The assertion fails if the objects are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first object to compare. This is the object the unit test expects.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( object expected, object actual, string message, params object[] parameters ) => Assert.AreEqual( expected, actual, message, parameters );

        /// <summary>Verifies that two specified strings are equal, ignoring case or not as specified, and using the culture info specified. The assertion fails if they are not equal.</summary>
        /// <param name="expected">The first string to compare. This is the string the unit test expects.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="culture">A <see cref="CultureInfo" /> object that supplies culture-specific comparison information.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( string expected, string actual, bool ignoreCase, CultureInfo culture ) => Assert.AreEqual( expected, actual, ignoreCase, culture );

        /// <summary>Verifies that two specified strings are equal, ignoring case or not as specified. The assertion fails if they are not equal. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first string to compare. This is the string the unit test expects.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( string expected, string actual, bool ignoreCase, string message ) => Assert.AreEqual( expected, actual, ignoreCase, message );

        /// <summary>Verifies that two specified generic type data are equal. The assertion fails if they are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first generic type data to compare. This is the generic type data the unit test expects.</param>
        /// <param name="actual">The second generic type data to compare. This is the generic type data the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <typeparam name="T">The <see cref="Type">type</see> of expected value.</typeparam>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual<T>( T expected, T actual, string message, params object[] parameters ) => Assert.AreEqual<T>( expected, actual, message, parameters );

        /// <summary>Verifies that two specified doubles are equal, or within the specified accuracy of each other. The assertion fails if they are not within the specified accuracy of each other. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first double to compare. This is the double the unit tests expects.</param>
        /// <param name="actual">The second double to compare. This is the double the unit test produced.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</exception>
        public virtual void AreEqual( double expected, double actual, double delta, string message, params object[] parameters ) => Assert.AreEqual( expected, actual, delta, message, parameters );

        /// <summary>Verifies that two specified singles are equal, or within the specified accuracy of each other. The assertion fails if they are not within the specified accuracy of each other. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first single to compare. This is the single the unit test expects.</param>
        /// <param name="actual">The second single to compare. This is the single the unit test produced.</param>
        /// <param name="delta">The required accuracy. The assertion will fail only if <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is different from <paramref name="actual" /> by more than <paramref name="delta" />.</exception>
        public virtual void AreEqual( float expected, float actual, float delta, string message, params object[] parameters ) => Assert.AreEqual( expected, actual, delta, message, parameters );

        /// <summary>Verifies that two specified strings are equal, ignoring case or not as specified, and using the culture info specified. The assertion fails if they are not equal. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first string to compare. This is the string the unit test expects.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="culture">A <see cref="CultureInfo" /> object that supplies culture-specific comparison information.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( string expected, string actual, bool ignoreCase, CultureInfo culture, string message ) => Assert.AreEqual( expected, actual, ignoreCase, culture, message );

        /// <summary>Verifies that two specified strings are equal, ignoring case or not as specified. The assertion fails if they are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first string to compare. This is the string the unit test expects.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( string expected, string actual, bool ignoreCase, string message, params object[] parameters ) => Assert.AreEqual( expected, actual, ignoreCase, message, parameters );

        /// <summary>Verifies that two specified strings are equal, ignoring case or not as specified, and using the culture info specified. The assertion fails if they are not equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first string to compare. This is the string the unit test expects.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="culture">A <see cref="CultureInfo" /> object that supplies culture-specific comparison information.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> is not equal to <paramref name="actual" />.</exception>
        public virtual void AreEqual( string expected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters ) => Assert.AreEqual( expected, actual, ignoreCase, culture, message, parameters );

        /// <summary>Verifies that two specified objects are not equal. The assertion fails if the objects are equal.</summary>
        /// <param name="notExpected">The first object to compare. This is the object the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( object notExpected, object actual ) => Assert.AreNotEqual( notExpected, actual );

        /// <summary>Verifies that two specified generic type data are not equal. The assertion fails if they are equal.</summary>
        /// <param name="notExpected">The first generic type data to compare. This is the generic type data the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second generic type data to compare. This is the generic type data the unit test produced.</param>
        /// <typeparam name="T">The <see cref="Type">type</see> of expected value.</typeparam>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual<T>( T notExpected, T actual ) => Assert.AreNotEqual<T>( notExpected, actual );

        /// <summary>Verifies that two specified doubles are not equal, and not within the specified accuracy of each other. The assertion fails if they are equal or within the specified accuracy of each other.</summary>
        /// <param name="notExpected">The first double to compare. This is the double the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second double to compare. This is the double the unit test produced.</param>
        /// <param name="delta">The required inaccuracy. The assertion fails only if <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</exception>
        public virtual void AreNotEqual( double notExpected, double actual, double delta ) => Assert.AreNotEqual( notExpected, actual, delta );

        /// <summary>Verifies that two specified singles are not equal, and not within the specified accuracy of each other. The assertion fails if they are equal or within the specified accuracy of each other.</summary>
        /// <param name="notExpected">The first single to compare. This is the single the unit test expects.</param>
        /// <param name="actual">The second single to compare. This is the single the unit test produced.</param>
        /// <param name="delta">The required inaccuracy. The assertion will fail only if <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</exception>
        public virtual void AreNotEqual( float notExpected, float actual, float delta ) => Assert.AreNotEqual( notExpected, actual, delta );

        /// <summary>Verifies that two specified objects are not equal. The assertion fails if the objects are equal. Displays a message if the assertion fails.</summary>
        /// <param name="notExpected">The first object to compare. This is the object the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( object notExpected, object actual, string message ) => Assert.AreNotEqual( notExpected, actual, message );

        /// <summary>Verifies that two specified strings are not equal, ignoring case or not as specified. The assertion fails if they are equal.</summary>
        /// <param name="notExpected">The first string to compare. This is the string the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
#pragma warning disable CA1304 // Specify CultureInfo
        public virtual void AreNotEqual( string notExpected, string actual, bool ignoreCase ) => Assert.AreNotEqual( notExpected, actual, ignoreCase );
#pragma warning restore CA1304 // Specify CultureInfo

        /// <summary>Verifies that two specified generic type data are not equal. The assertion fails if they are equal. Displays a message if the assertion fails.</summary>
        /// <param name="notExpected">The first generic type data to compare. This is the generic type data the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second generic type data to compare. This is the generic type data the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <typeparam name="T">The <see cref="Type">type</see> of expected value.</typeparam>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual<T>( T notExpected, T actual, string message ) => Assert.AreNotEqual<T>( notExpected, actual, message );

        /// <summary>Verifies that two specified doubles are not equal, and not within the specified accuracy of each other. The assertion fails if they are equal or within the specified accuracy of each other. Displays a message if the assertion fails.</summary>
        /// <param name="notExpected">The first double to compare. This is the double the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second double to compare. This is the double the unit test produced.</param>
        /// <param name="delta">The required inaccuracy. The assertion fails only if <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</exception>
        public virtual void AreNotEqual( double notExpected, double actual, double delta, string message ) => Assert.AreNotEqual( notExpected, actual, delta, message );

        /// <summary>Verifies that two specified singles are not equal, and not within the specified accuracy of each other. The assertion fails if they are equal or within the specified accuracy of each other. Displays a message if the assertion fails.</summary>
        /// <param name="notExpected">The first single to compare. This is the single the unit test expects.</param>
        /// <param name="actual">The second single to compare. This is the single the unit test produced.</param>
        /// <param name="delta">The required inaccuracy. The assertion will fail only if <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</exception>
        public virtual void AreNotEqual( float notExpected, float actual, float delta, string message ) => Assert.AreNotEqual( notExpected, actual, delta, message );

        /// <summary>Verifies that two specified objects are not equal. The assertion fails if the objects are equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="notExpected">The first object to compare. This is the object the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( object notExpected, object actual, string message, params object[] parameters ) => Assert.AreNotEqual( notExpected, actual, message, parameters );

        /// <summary>Verifies that two specified strings are not equal, ignoring case or not as specified, and using the culture info specified. The assertion fails if they are equal.</summary>
        /// <param name="notExpected">The first string to compare. This is the string the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="culture">A <see cref="CultureInfo" /> object that supplies culture-specific comparison information.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( string notExpected, string actual, bool ignoreCase, CultureInfo culture ) => Assert.AreNotEqual( notExpected, actual, ignoreCase, culture );

        /// <summary>Verifies that two specified strings are not equal, ignoring case or not as specified. The assertion fails if they are equal. Displays a message if the assertion fails.</summary>
        /// <param name="notExpected">The first string to compare. This is the string the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( string notExpected, string actual, bool ignoreCase, string message ) => Assert.AreNotEqual( notExpected, actual, ignoreCase, message );

        /// <summary>Verifies that two specified generic type data are not equal. The assertion fails if they are equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="notExpected">The first generic type data to compare. This is the generic type data the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second generic type data to compare. This is the generic type data the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <typeparam name="T">The <see cref="Type">type</see> of expected value.</typeparam>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual<T>( T notExpected, T actual, string message, params object[] parameters ) => Assert.AreNotEqual<T>( notExpected, actual, message, parameters );

        /// <summary>Verifies that two specified doubles are not equal, and not within the specified accuracy of each other. The assertion fails if they are equal or within the specified accuracy of each other. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="notExpected">The first double to compare. This is the double the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second double to compare. This is the double the unit test produced.</param>
        /// <param name="delta">The required inaccuracy. The assertion will fail only if <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</exception>
        public virtual void AreNotEqual( double notExpected, double actual, double delta, string message, params object[] parameters ) => Assert.AreNotEqual( notExpected, actual, delta, message, parameters );

        /// <summary>Verifies that two specified singles are not equal, and not within the specified accuracy of each other. The assertion fails if they are equal or within the specified accuracy of each other. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="notExpected">The first single to compare. This is the single the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second single to compare. This is the single the unit test produced.</param>
        /// <param name="delta">The required inaccuracy. The assertion will fail only if <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" /> or different from it by less than <paramref name="delta" />.</exception>
        public virtual void AreNotEqual( float notExpected, float actual, float delta, string message, params object[] parameters ) => Assert.AreNotEqual( notExpected, actual, delta, message, parameters );

        /// <summary>Verifies that two specified strings are not equal, ignoring case or not as specified, and using the culture info specified. The assertion fails if they are equal. Displays a message if the assertion fails.</summary>
        /// <param name="notExpected">The first string to compare. This is the string the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="culture">A <see cref="CultureInfo" /> object that supplies culture-specific comparison information.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message ) => Assert.AreNotEqual( notExpected, actual, ignoreCase, culture, message );

        /// <summary>Verifies that two specified strings are not equal, ignoring case or not as specified. The assertion fails if they are equal. Displays a message if the assertion fails, and applies the specified formatting to it. </summary>
        /// <param name="notExpected">The first string to compare. This is the string the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( string notExpected, string actual, bool ignoreCase, string message, params object[] parameters ) => Assert.AreNotEqual( notExpected, actual, ignoreCase, message, parameters );

        /// <summary>Verifies that two specified strings are not equal, ignoring case or not as specified, and using the culture info specified. The assertion fails if they are equal. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="notExpected">The first string to compare. This is the string the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second string to compare. This is the string the unit test produced.</param>
        /// <param name="ignoreCase">A Boolean value that indicates a case-sensitive or insensitive comparison. true indicates a case-insensitive comparison.</param>
        /// <param name="culture">A <see cref="CultureInfo" /> object that supplies culture-specific comparison information.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> is equal to <paramref name="actual" />.</exception>
        public virtual void AreNotEqual( string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters ) => Assert.AreNotEqual( notExpected, actual, ignoreCase, culture, message, parameters );

        /// <summary>Verifies that two specified object variables refer to different objects. The assertion fails if they refer to the same object.</summary>
        /// <param name="notExpected">The first object to compare. This is the object the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> refers to the same object as <paramref name="actual" />.</exception>
        public virtual void AreNotSame( object notExpected, object actual ) => Assert.AreNotSame( notExpected, actual );

        /// <summary>Verifies that two specified object variables refer to different objects. The assertion fails if they refer to the same object. Displays a message if the assertion fails. </summary>
        /// <param name="notExpected">The first object to compare. This is the object the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> refers to the same object as <paramref name="actual" />.</exception>
        public virtual void AreNotSame( object notExpected, object actual, string message ) => Assert.AreNotSame( notExpected, actual, message );

        /// <summary>Verifies that two specified object variables refer to different objects. The assertion fails if they refer to the same object. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="notExpected">The first object to compare. This is the object the unit test expects not to match <paramref name="actual" />.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="notExpected" /> refers to the same object as <paramref name="actual" />.</exception>
        public virtual void AreNotSame( object notExpected, object actual, string message, params object[] parameters ) => Assert.AreNotSame( notExpected, actual, message, parameters );

        /// <summary>Verifies that two specified object variables refer to the same object. The assertion fails if they refer to different objects.</summary>
        /// <param name="expected">The first object to compare. This is the object the unit test expects.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> does not refer to the same object as <paramref name="actual" />.</exception>
        public virtual void AreSame( object expected, object actual ) => Assert.AreSame( expected, actual );

        /// <summary>Verifies that two specified object variables refer to the same object. The assertion fails if they refer to different objects. Displays a message if the assertion fails.</summary>
        /// <param name="expected">The first object to compare. This is the object the unit test expects.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> does not refer to the same object as <paramref name="actual" />.</exception>
        public virtual void AreSame( object expected, object actual, string message ) => Assert.AreSame( expected, actual, message );

        /// <summary>Verifies that two specified object variables refer to the same object. The assertion fails if they refer to different objects. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="expected">The first object to compare. This is the object the unit test expects.</param>
        /// <param name="actual">The second object to compare. This is the object the unit test produced.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="expected" /> does not refer to the same object as <paramref name="actual" />.</exception>
        public virtual void AreSame( object expected, object actual, string message, params object[] parameters ) => Assert.AreSame( expected, actual, message, parameters );

        /// <summary>Fails the assertion without checking any conditions.</summary>
        /// <exception cref="AssertFailedException">Always thrown.</exception>
        public virtual void Fail() => Assert.Fail();

        /// <summary>Fails the assertion without checking any conditions. Displays a message.</summary>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">Always thrown.</exception>
        public virtual void Fail( string message ) => Assert.Fail( message );

        /// <summary>Fails the assertion without checking any conditions. Displays a message, and applies the specified formatting to it.</summary>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">Always thrown.</exception>
        public virtual void Fail( string message, params object[] parameters ) => Assert.Fail( message, parameters );

        /// <summary>Indicates that the assertion cannot be verified.</summary>
        /// <exception cref="AssertInconclusiveException">Always thrown.</exception>
        public virtual void Inconclusive() => Assert.Inconclusive();

        /// <summary>Indicates that the assertion can not be verified. Displays a message.</summary>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertInconclusiveException">Always thrown.</exception>
        public virtual void Inconclusive( string message ) => Assert.Inconclusive( message );

        /// <summary>Indicates that an assertion can not be verified. Displays a message, and applies the specified formatting to it.</summary>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertInconclusiveException">Always thrown.</exception>
        public virtual void Inconclusive( string message, params object[] parameters ) => Assert.Inconclusive( message, parameters );

        /// <summary>Verifies that the specified condition is false. The assertion fails if the condition is true.</summary>
        /// <param name="condition">The condition to verify is false.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="condition" /> evaluates to true.</exception>
        public virtual void IsFalse( bool condition ) => Assert.IsFalse( condition );

        /// <summary>Verifies that the specified condition is false. The assertion fails if the condition is true. Displays a message if the assertion fails.</summary>
        /// <param name="condition">The condition to verify is false.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="condition" /> evaluates to true.</exception>
        public virtual void IsFalse( bool condition, string message ) => Assert.IsFalse( condition, message );

        /// <summary>Verifies that the specified condition is false. The assertion fails if the condition is true. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="condition">The condition to verify is false.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="condition" /> evaluates to true.</exception>
        public virtual void IsFalse( bool condition, string message, params object[] parameters ) => Assert.IsFalse( condition, message, parameters );

        /// <summary>Verifies that the specified object is an instance of the specified type. The assertion fails if the type is not found in the inheritance hierarchy of the object.</summary>
        /// <param name="value">The object to verify is of <paramref name="expectedType" />.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of <paramref name="value" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is null or <paramref name="expectedType" /> is not found in the inheritance hierarchy of <paramref name="value" />.</exception>
        public virtual void IsInstanceOfType( object value, Type expectedType ) => Assert.IsInstanceOfType( value, expectedType );

        /// <summary>Verifies that the specified object is an instance of the specified type. The assertion fails if the type is not found in the inheritance hierarchy of the object. Displays a message if the assertion fails.</summary>
        /// <param name="value">The object to verify is of <paramref name="expectedType" />.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of <paramref name="value" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is null or <paramref name="expectedType" /> is not found in the inheritance hierarchy of <paramref name="value" />.</exception>
        public virtual void IsInstanceOfType( object value, Type expectedType, string message ) => Assert.IsInstanceOfType( value, expectedType, message );

        /// <summary>Verifies that the specified object is an instance of the specified type. The assertion fails if the type is not found in the inheritance hierarchy of the object. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="value">The object to verify is of <paramref name="expectedType" />.</param>
        /// <param name="expectedType">The type expected to be found in the inheritance hierarchy of <paramref name="value" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is null or <paramref name="expectedType" /> is not found in the inheritance hierarchy of <paramref name="value" />.</exception>
        public virtual void IsInstanceOfType( object value, Type expectedType, string message, params object[] parameters ) => Assert.IsInstanceOfType( value, expectedType, message, parameters );

        /// <summary>Verifies that the specified object is not an instance of the specified type. The assertion fails if the type is found in the inheritance hierarchy of the object.</summary>
        /// <param name="value">The object to verify is not of <paramref name="wrongType" />.</param>
        /// <param name="wrongType">The type that should not be found in the inheritance hierarchy of <paramref name="value" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is not null and <paramref name="wrongType" /> is found in the inheritance hierarchy of <paramref name="value" />.</exception>
        public virtual void IsNotInstanceOfType( object value, Type wrongType ) => Assert.IsNotInstanceOfType( value, wrongType );

        /// <summary>Verifies that the specified object is not an instance of the specified type. The assertion fails if the type is found in the inheritance hierarchy of the object. Displays a message if the assertion fails.</summary>
        /// <param name="value">The object to verify is not of <paramref name="wrongType" />.</param>
        /// <param name="wrongType">The type that should not be found in the inheritance hierarchy of <paramref name="value" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results. </param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is not null and <paramref name="wrongType" /> is found in the inheritance hierarchy of <paramref name="value" />.</exception>
        public virtual void IsNotInstanceOfType( object value, Type wrongType, string message ) => Assert.IsNotInstanceOfType( value, wrongType, message );

        /// <summary>Verifies that the specified object is not an instance of the specified type. The assertion fails if the type is found in the inheritance hierarchy of the object. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="value">The object to verify is not of <paramref name="wrongType" />.</param>
        /// <param name="wrongType">The type that should not be found in the inheritance hierarchy of <paramref name="value" />.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results. </param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is not null and <paramref name="wrongType" /> is found in the inheritance hierarchy of <paramref name="value" />.</exception>
        public virtual void IsNotInstanceOfType( object value, Type wrongType, string message, params object[] parameters ) => Assert.IsNotInstanceOfType( value, wrongType, message, parameters );

        /// <summary>Verifies that the specified object is not null. The assertion fails if it is null.</summary>
        /// <param name="value">The object to verify is not null.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is null.</exception>
        public virtual void IsNotNull( [NotNull] object value ) => Assert.IsNotNull( value );

        /// <summary>Verifies that the specified object is not null. The assertion fails if it is null. Displays a message if the assertion fails.</summary>
        /// <param name="value">The object to verify is not null.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is null.</exception>
        public virtual void IsNotNull( [NotNull] object value, string message ) => Assert.IsNotNull( value, message );

        /// <summary>Verifies that the specified object is not null. The assertion fails if it is null. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="value">The object to verify is not null.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is null.</exception>
        public virtual void IsNotNull( [NotNull] object value, string message, params object[] parameters ) => Assert.IsNotNull( value, message, parameters );

        /// <summary>Verifies that the specified object is null. The assertion fails if it is not null.</summary>
        /// <param name="value">The object to verify is null.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is not null.</exception>
        public virtual void IsNull( object value ) => Assert.IsNull( value );

        /// <summary>Verifies that the specified object is null. The assertion fails if it is not null. Displays a message if the assertion fails.</summary>
        /// <param name="value">The object to verify is null.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is not null.</exception>
        public virtual void IsNull( object value, string message ) => Assert.IsNull( value, message );

        /// <summary>Verifies that the specified object is null. The assertion fails if it is not null. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="value">The object to verify is null.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="value" /> is not null.</exception>
        public virtual void IsNull( object value, string message, params object[] parameters ) => Assert.IsNull( value, message, parameters );

        /// <summary>Verifies that the specified condition is true. The assertion fails if the condition is false.</summary>
        /// <param name="condition">The condition to verify is true.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="condition" /> evaluates to false.</exception>
        public virtual void IsTrue( bool condition ) => Assert.IsTrue( condition );

        /// <summary>Verifies that the specified condition is true. The assertion fails if the condition is false. Displays a message if the assertion fails.</summary>
        /// <param name="condition">The condition to verify is true.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="condition" /> evaluates to false.</exception>
        public virtual void IsTrue( bool condition, string message ) => Assert.IsTrue( condition, message );

        /// <summary>Verifies that the specified condition is true. The assertion fails if the condition is false. Displays a message if the assertion fails, and applies the specified formatting to it.</summary>
        /// <param name="condition">The condition to verify is true.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message" />.</param>
        /// <exception cref="AssertFailedException">
        /// <paramref name="condition" /> evaluates to false.</exception>
        public virtual void IsTrue( bool condition, string message, params object[] parameters ) => Assert.IsTrue( condition, message, parameters );

        /// <summary>
        /// Asserts the specified assertion test parameter is not null.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> to evaluate.</typeparam>
        /// <param name="parameter">The parameter to evaluate.</param>
        /// <param name="parameterName">The parameter name.</param>
        public virtual void AssertParameterIsNotNull<T>( T parameter, string parameterName )
        {
            if ( default( T ) == null )
            {
                IsNotNull( parameter, NullParameterToAssert, parameterName );
            }
        }

        /// <summary>
        /// Asserts the specified assertion test parameter is not null.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type">type</see> to evaluate.</typeparam>
        /// <param name="parameter">The array parameter to evaluate.</param>
        /// <param name="parameterName">The parameter name.</param>
        public virtual void AssertParameterIsNotNull<T>( T[] parameter, string parameterName )
        {
            IsNotNull( parameter, NullParameterToAssert, parameterName );
            AssertParameterIsNotNull( parameter.AsEnumerable(), parameterName );
        }

        /// <summary>
        /// Asserts the specified assertion test parameter is not null.
        /// </summary>
        /// <typeparam name="T">The nullable <see cref="Type">type</see> to evaluate.</typeparam>
        /// <param name="parameter">The <see cref="IEnumerable{T}">parameter</see> to evaluate.</param>
        /// <param name="parameterName">The parameter name.</param>
        public virtual void AssertParameterIsNotNull<T>( IEnumerable<T> parameter, string parameterName )
        {
            IsNotNull( parameter, NullParameterToAssert, parameterName );

            if ( default( T ) != null )
            {
                return;
            }

            parameterName += "[]";

            foreach ( var item in parameter )
            {
                IsNotNull( item, NullParameterToAssert, parameterName );
            }
        }
    }
}