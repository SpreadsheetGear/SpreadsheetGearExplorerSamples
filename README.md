# <img src="images/logo-sg.svg" style="width: 70px; vertical-align: middle;" alt="SpreadsheetGear Logo"> SpreadsheetGear Explorer Samples
This repository contains samples demonstrating many features available in the products **SpreadsheetGear Engine for .NET** and **SpreadsheetGear for Windows**, including:

* Cell formatting such as Fonts, Borders, Interior, Orientation, Hyperlinks, Validation, Cell Comments, Number Formats, Conditional Formatting.
* Working with Cell Formulas and Values.
* Range operations such as Auto-Filters, Cell Protection, Group and Outline, Sorting, Merge Cells, Fill Data Series
* Worksheet features such as Worksheet Protection, Evaluating Ranges and Values from Formulas, Sheet Tab Colors, Named Ranges, Sheet Visibility, Move and Copy Sheets, Display Options.
* Workbook features such as Reading and Writing Workbook Files from Disk, Stream or Byte Array, Workbook Encryption, Cell Styles, Protecting Workbook Structures and Windows, Sheet Management, Workbook and Worksheet "Window Info", Built-In and Custom Document Properties, DateTimes and Serial Numeric Dates.
* Charting features including the various Chart Types (Column, Line, Pie, Bar, Area, Stock, Scatter, Bubble, Radar, Gantt and Combination), Embedding Pictures in Charts, Creating Chart Sheets.
* Shape features including Form Controls (Button, CheckBox, ComboBox, ListBox, Spinner, ScrollBar, GroupBox and OptionButton), Lines (with Weight, Dash Style and Arrowhead options), Pictures, TextBoxes and AutoShapes.
* Printing features (Headers and Footers, Zooom and FitToPages, PrintArea, PrintTitles, Orientation and Manual Page Breaks).
* Image Rendering and User Interface Features (**Windows Only**)
  * Interactive WorkbookView and FormulaBar controls for Windows Forms and WPF.
  * High DPI image rendering of Ranges, Charts and other Shapes.
  * WorkbookDesigner dialog and "Explorer" dialogs to modify various aspects of a workbook such as worksheets, ranges, charts, shapes, etc.

## SpreadsheetGear Products and Supported Platforms

### <img src="images/logo-eng.svg" style="width: 25px; vertical-align: middle;" alt="Logo for 'SpreadsheetGear Engine for .NET' product"> SpreadsheetGear Engine for .NET
*SpreadsheetGear Engine for .NET* provides a core set of APIs to read, write, manipulate and calculate workbooks, build charts, format worksheets and cells, and more.   

This product targets both .NET 6 (`net6.0`) and .NET Standard 2.0 (`netstandard2.0`), providing a wide array of supported platforms and OS including:
  - .NET Core 2.0 - .NET 6
  - .NET Framework 4.6.2+
  - Windows
  - MacOS
  - Linux
  - Mono
  - Xamarin (iOS, Android, etc.)

### <img src="images/logo-windows-11.svg" style="width: 25px; vertical-align: middle;" alt="Logo for Windows 11"> SpreadsheetGear for Windows
Builds on *SpreadsheetGear Engine for .NET* to add powerful Excel-compatible image rendering, viewing, editing, formatting, calculating, filtering, sorting, charting, printing and more to your Windows Forms and WPF applications with the easy-to-use WorkbookView and FormulaBar controls.  

*SpreadsheetGear for Windows* targets .NET 6 for Windows (`net6.0-windows`).

Learn more about these products on our [Features Page](https://www.spreadsheetgear.com/Products/Features) and more details on their differences on our [Comparison Page](https://www.spreadsheetgear.com/Products/Compare).


## Sample Projects

There are 3 executable Visual Studio Projects (\*.csproj) in this repository, pictured and described in more detail below.  These projects work with Visual Studio 2022, Visual Studio Code (VSCode) and Visual Studio for Mac.  See the [Running the Samples](#section-running-the-samples) section for more details on running these projects in your preferred IDE.  

### Web Explorer Samples
![Screenshot of the WPF Explorer](WebExplorer/screenshot.png)

The Web Explorer presents **SpreadsheetGear Engine for .NET** samples using an ASP.NET Core Web App.  Note this VS Project targets both `net6.0` and `net6.0-windows`:
  - `net6.0`: Use this target framework to run the samples on a wide variety of platforms such as Windows, MacOS and Linux. Most samples provide an option to download an Excel workbook file with the results of the sample.
  - `net6.0-windows`: Use this target framework when running on Windows to provide an additional option to render an image of many of sample results.  Image rendering is accomplished by utilizing the *SpreadsheetGear for Windows* product, which has a `SpreadsheetGear.Drawing.Image` class that renders images of ranges, charts and other shapes.  For more samples that demonstrate this `Image` class please see our website's [Excel Chart and Range Imaging Razor Pages Samples](https://www.spreadsheetgear.com/Support/Samples/RazorPages/Category/Imaging).


### WPF Explorer Samples
![Screenshot of the WPF Explorer](WpfExplorer/screenshot.png)

The WPF Explorer presents samples applicable to both the **SpreadsheetGear Engine for .NET** and **SpreadsheetGear for Windows** products in the context of a WPF Desktop App, where the WPF WorkbookView and FormulaBar controls are utilized to provide an interactive Excel-like experience when presenting the results of a given sample.  

These samples target `net6.0-windows` and so requires running on Windows.

### Windows Forms Explorer Samples
![Screenshot of the WPF Explorer](WindowsFormsExplorer/screenshot.png)
The Windows Forms Explorer presents samples applicable to both the **SpreadsheetGear Engine for .NET** and **SpreadsheetGear for Windows** products in the context of a Windows Forms Desktop App, where the Windows Forms WorkbookView and FormulaBar controls are utilized to provide an interactive Excel-like experience when presenting the results of a given sample.  

These samples target `net6.0-windows` and so requires running on Windows.


<a name="section-running-the-samples"></a>
## Running the Samples
Depending on your development environment, you can access the samples in a variety of ways using Visual Studio 2022, Visual Studio Code (VSCode) and Visual Studio for Mac.

### Visual Studio 2022
Three Visual Studio Solutions (\*.sln) are provided in the repository root folder to use with Visual Studio 2022.  Below is a list of the "Explorer" Visual Studio Projects that are included in each of the Solutions:

 - **SpreadsheetGearExplorerSamples.sln** (Requires the "ASP.NET and web development" and ".NET desktop development" workloads)
   - **Web Explorer Samples**
   - **WPF Explorer Samples**
   - **Windows Forms Explorer Samples**

 - **SpreadsheetGearExplorerSamples_Windows.sln** (Requires the ".NET desktop development" workload)
   - **WPF Explorer Samples**
   - **Windows Forms Explorer Samples**

 - **SpreadsheetGearExplorerSamples_Web.sln** - (Requires the "ASP.NET and web development" workload)
   - **Web Explorer Samples**


### Visual Studio for Mac
Please use the **SpreadsheetGearExplorerSamples_Web.sln** in the repository root folder to access the **Web Explorer Samples**.  The other 2 Solutions include Windows-only VS Projects that utilize the *SpreadsheetGear for Windows* product, which is not supported on a Mac.

### Visual Studio Code
Visual Studio Code (VSCode) is a cross-platform code editor, supported on Windows, MacOS and Linux; however, keep in mind that some of the SpreadsheetGear Explorer Samples run only on Windows:
  - **Web Explorer Samples** - Windows, MacOS, Linux
  - **WPF Explorer Samples** - Windows Only
  - **Windows Forms Explorer Samples** - Windows Only

To run applicable samples with Visual Studio Code, please also install at minimum the [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download) and the [.NET Extension Pack for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-dotnet-pack).  After cloning the repo, open the root `SpreadsheetGearExplorerSamples` folder in VSCode and build & launch any of the above Explorer sample projects from the *Run and Debug* Side Bar.

![Visual Studio Code's Run and Debug Side Bar](images/vs-code-run-and-debug.png)

> If you are on MacOS or Linux, the WPF and Windows Forms Explorer samples will not be runnable, nor will the version of the WebExplorer samples that depend on Windows to render images.  The "Web Explorer" samples are runnable from MacOS and Linux.

The below individual folders can also be opened in VSCode, and relevant options will be provided to build & run the samples.  These folders also contain `*.code-workspace` files that you can open in VSCode (instead of opening the folder) if you would like to have all dependent projects included when viewing VSCode's Explorer Side Bar:
  - SpreadsheetGearExplorerSamples/WebExplorer
  - SpreadsheetGearExplorerSamples/WPFExplorer
  - SpreadsheetGearExplorerSamples/WindowsFormsExplorer