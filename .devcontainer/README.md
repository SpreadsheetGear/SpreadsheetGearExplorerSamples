# WebExplorer Codespace

This codespace has been pre-configured to quickly and easily run the ASP.NET Core `WebExplorer` samples in the browser with just a few clicks:

* If you've not yet created a new codespace, do so now:
    * Ensure you are logged into your GitHub account and navigate to this repository's main page (https://github.com/SpreadsheetGear/SpreadsheetGearExplorerSamples).
    * From the "Code" dropdown button, click on the "Codespaces" tab and then click on the "Create codespace on master" button and wait for the codespace to be created.
* Click on the "Run and Debug" icon in the Side Bar.
* Click the run icon next to the selected "Launch Web Explorer" item in this panel (or first select this option from the dropdown if it is not selected).
* Launch the web app:
  * After building the project and running, a new browser tab may automatically open and launch the app, but this might get blocked by your browser.  Allow popups in your browser to launch the WebExplorer web app.
  * Alternatively, a notification may also appear in the bottom-right corner, providing you with an "Open in Browser" button to launch the web app.
  * Another option is to click on the "Ports" tab at the bottom of the codespace window and click on the "Open in Browser" icon (an icon of the globe) when hovering over the URL in the "Forwarded Address" column.

*NOTE:* the other sample projects (`WindowsFormsExplorer` and `WpfExplorer`) cannot be run in this codespace because they depend on Windows and this codespace runs on a non-Windows OS.  

There is a "Launch Web Explorer *(Windows-Only)*" option that can be run from this codespace; however, any image-rendering capabilities will not work because this feature depends on Windows-specific APIs.  

To run any of these Windows-based samples, please clone a copy of this repository onto a Windows-based machine and run in either Visual Studio Code or Visual Studio 2022.