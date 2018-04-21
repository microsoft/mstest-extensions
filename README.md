![VSTS Build Status](https://microsoft.visualstudio.com/_apis/public/build/definitions/8d47e068-03c8-4cdc-aa9b-fc6929290322/26038/badge "Build Status")

# Microsoft Test Framework Extensions
This project provides extensions to the Microsoft Visual Studio Team Test unit testing framework. Features include alternatives to **ExpectedExceptionAttribute** and a fully extensible assertion application programming interface. The extensibility model is designed to allow swapping out the default **Assert** class and still maintain source code compatibility with the same intrinsic built-in functionality. You're then free to change, customize, or leverage the many built-in extensions.

## Example Usage
To switch from a typical assertion model to the extensible assertion model, simply have your test class inherit from the **UnitTest** base class. This isn't a requirement to make things work, but it's the simplest model for consumption out-of-the-box.

```c#
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
        
public class Person
{
    public Person( string name ) =>
        Name = name ?? throw new ArgumentNullException( nameof( name ), "The name cannot be null." );
            
    public string Name { get; }
}
        
[TestClass]
public class PersonTest : UnitTest
{
    [TestMethod]
    public void ConstructorShouldNotAllowNullName()
    {
        Assert.ThrowsIfArgumentNull( ( string name ) => new Person( name ) )
              .Verify( e => e.Message == "The name cannot be null." );
    }
}
```

If you don't want to use a base class, simply add a property to your existing test class:

```c#
[TestClass]
public class PersonTest
{
    Asserter Assert { get; } = new Asserter();

    [TestMethod]
    public void ConstructorShouldNotAllowNullName()
    {
        // arrange
        var person = new Person( "Bob" );

        // act
        var result = person.Name;

        // assert
        Assert.AreEqual( "Bob", result );
    }
}
```

## Features
The following outlines the features and extensions provided out-of-the-box:

* **Asserter** - Base assertion class and adapts over **Assert** for its default implemention
* **CollectionAsserter** - Collection assertion class and adapts over **CollectionAssert** for its default implemention
* **ExceptionAsserter** - Exception assertion class to further verify parameter names, messages, etc
* **IEnumerable&lt;T&gt;** - Extension methods to verify various implementations of collections and sequences
* **INotifyPropertyChanged** - Extension methods to verify implementations of the **INotifyPropertyChanged** interface
* **INotifyCollectionChanged** - Extension methods to verify implementations of the **INotifyCollectionChanged** interface

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
