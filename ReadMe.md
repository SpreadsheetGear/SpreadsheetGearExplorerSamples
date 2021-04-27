### SpreadsheetGearExplorerSamples

#### This chrish_play branch contains a script to split up the SpreadsheetGearExplorerSamples repository into smaller targeted repositories. The thought is do maintenance in the larger private repository and then the split into smaller public repositories.

SpreadsheetGearExplorerSamples is a large repository containing .Net Web and Windows solutions and a shared class library named SharedSamples. A script copies the appropriate folders and files into smaller repositories named SpreadsheetGearExplorerSamples_Web and SpreadsheetGearExplorerSamples_Windows.

In a cmd window clone the following repos into the same parent folder: <br>
```
cd c:\GithubRepos\SpreadsheetGear
git clone https://github.com/SpreadsheetGear/SpreadsheetGearExplorerSamples
git clone https://github.com/SpreadsheetGear/SpreadsheetGearExplorerSamples_Windows
git clone https://github.com/SpreadsheetGear/SpreadsheetGearExplorerSamples_Web
```

The workflow:
1. Use VisualStudio to make changes in the local repository for SpreadsheetGearExplorerSamples.
2. In Windows Explorer double-click SpreadsheetGearExplorerSamples\CopyToSmallRepos\copyToSmallRepos.bat to copy your changes to the smaller repos SpreadsheetGearExplorerSamples_Web and SpreadsheetGearExplorerSamples_Windows.
3. Test solutions and projects in SpreadsheetGearExplorerSamples_Web and SpreadsheetGearExplorerSamples_Windows.
4. Commit and push changes in SpreadsheetGearExplorerSamples_Web and SpreadsheetGearExplorerSamples_Windows to Github.
