#if NETSTANDARD2_1_OR_GREATER
namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    /// <summary>
    /// PlaceHolder for System.Diagnostics.CodeAnalysis.NotNullAttribute for platforms where that attribute is not available.
    /// </summary>
    [AttributeUsage( AttributeTargets.Parameter )]
    internal class NotNullAttribute : Attribute
    {
    }
}
#endif