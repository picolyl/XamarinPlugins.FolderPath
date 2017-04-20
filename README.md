# FolderPath

It is Xamarin.Plugins to get the path of the folder.

## Support platform

||Desktop|Win8.1|WP8.1|UWP|Android|iOS|Mac|
| --- |:---:|:---:|:---:|:---:|:---:|:---:|:---:|
|Local    |o|o|o|o|o|o|o|
|Roaming  |o|o|o|o|-|-|-|
|Temporary|o|o|o|o|-|o|o|
|Cache    |o|-|o|o|o|o|o|
|Documents|o|-|-|-|-|o|o|
|Pictures |o|-|-|-|o|o|o|
|Music    |o|-|-|-|o|o|o|
|Videos   |o|-|-|-|o|o|o|
|App      |o|o|o|o|-|o|o|

## Usage

```C#
using PCLStorage;
var localFolderPath = FolderPath.Current.Local;
```

### Desktop

You need to set the company name in the AssemblyInfo.cs.

```
AssemblyInfo.cs
[assembly: AssemblyCompany("TestApp")]
```

If you can't set the company name in the AssemblyInfo.cs for some reason, in unit tests for example. 
You can:
1. Use your implementation or a mock of IFolderPath.
This is a common way for Xamarin Plugins described by James Montemagno in post:
http://motzcod.es/post/159267241302/unit-testing-plugins-for-xamarin
```C#
var folderPath = new Moq.Mock<IFolderPath>();
folderPath.Setup(f => f.Local).Returns(TestContext.DeploymentDirectory);

FolderPath.Current = folderPath.Object;
```

2. Override AppName manually 
```C#
((FolderPathImplementation)FolderPath.Current).AppName = "TestApp";
((FolderPathImplementation)FolderPath.Current).CompanyName = "TestCompany";
```


## License

[Ms-PL](https://msdn.microsoft.com/library/gg592960.aspx "Ms-PL")
