@echo off
set mypath=%cd%
cd ..
cd ..
IF exist "SpreadsheetGearExplorerSamples" goto COPYTOSMALLREPOS
	echo "You need to run this script from the folder SpreadsheetGearExplorerSamples\Scripts"
	goto END
:COPYTOSMALLREPOS
	echo "Delete files and folders in SpreadsheetGearExplorerSamples_Web..."
	cd SpreadsheetGearExplorerSamples_Web
	git clean -d -x -f
	cd ..
	echo "Copy to repo SpreadsheetGearExplorerSamples_Web..."
	XCOPY SpreadsheetGearExplorerSamples SpreadsheetGearExplorerSamples_Web /E /C /I /Y /Exclude:%mypath%\excludedFiles.txt
	XCOPY SpreadsheetGearExplorerSamples\WebApplication1 SpreadsheetGearExplorerSamples_Web\Webapplication1 /E /C /I /Y /Exclude:%mypath%\excludedFiles2.txt
	XCOPY SpreadsheetGearExplorerSamples\WebApplication.sln SpreadsheetGearExplorerSamples_Web /C /Y
	XCOPY SpreadsheetGearExplorerSamples\CopyToSmallRepos\ReadMe_Web.md SpreadsheetGearExplorerSamples_Web\ReadMe.md* /C /Y
	echo "Delete files and folders in SpreadsheetGearExplorerSamples_Windows..."
	cd SpreadsheetGearExplorerSamples_Windows
	git clean -d -x -f
	cd ..
	echo "Copy to repo SpreadsheetGearExplorerSamples_Windows..."
	XCOPY SpreadsheetGearExplorerSamples SpreadsheetGearExplorerSamples_Windows /E /C /I /Y /Exclude:%mypath%\excludedFiles.txt
	XCOPY SpreadsheetGearExplorerSamples\WinFormsApp1 SpreadsheetGearExplorerSamples_Windows\WinFormsApp1 /E /C /I /Y /Exclude:%mypath%\excludedFiles2.txt
	XCOPY SpreadsheetGearExplorerSamples\WPFApp1 SpreadsheetGearExplorerSamples_Windows\WPFApp1 /E /C /I /Y /Exclude:%mypath%\excludedFiles2.txt
	XCOPY SpreadsheetGearExplorerSamples\WindowsApplications.sln SpreadsheetGearExplorerSamples_Windows /C /Y
	XCOPY SpreadsheetGearExplorerSamples\CopyToSmallRepos\ReadMe_Windows.md SpreadsheetGearExplorerSamples_Windows\ReadMe.md* /C /Y
:END
	echo "finished"
	pause
