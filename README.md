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

## License

[Ms-PL](https://msdn.microsoft.com/library/gg592960.aspx "Ms-PL")
