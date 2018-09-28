# SeleniumBrowserFilter
.Net attribute to allow execution of test cases only for the provided browsers selected according to a customize configuration

## Requirements:
1. A base test class is required. This class normally contains setup and teardown information, it also includes the tests to be executed by all the browsers.

```csharp
public class BaseTest
{
    [SetUp]
    public void Initialize(){ ... }
    
    [TearDown]
    public void Finalize(){ ... }
    
    [Test]
    public void Test_1(){
      // my test
    }
    
    [Test]
    public void Test_N(){
      // my test
    }
}
```

2. Specific browser classes. These will derive the base test class and they only are intented to set up specific browser settings.

```csharp
public class ChromeTests: BaseTest
{
    // specific configuration for chrome
}
```

3. A resource configuration file that contains the keywords for the available browsers.

```xml
<data name="Browsers" xml:space="preserve">
    <value>Chrome, Firefox, InternetExplorer, Safari</value>
    <comment>All the available browsers</comment>
  </data>
```

How to use it:
```csharp
[Test]
[ApplyTo("Safari", "Chrome")]
    public void Test_N(){
      .....
    }
```
    
