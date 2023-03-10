# Spreadsheet Application

<img
    src="https://img.shields.io/badge/dotnet-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"
    alt="Dotnet Badge" />
<img
    src="https://img.shields.io/badge/CSharp-239120?style=for-the-badge&logo=csharp&logoColor=white"
    alt="CSharp Badge" />
<img
    src="https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white"
    alt="Windows Badge" />

The spreadsheet application is a Windows Application designed with Winforms.
It allows you to save and load spreadsheets, modify the color
of cells, perform arithmetic operations, and reference other cells.
Additionally, it supports the ability to undo and redo actions
performed in the app.

# Tools Used

- Dotnet CLI (6.0)
- Windows OS
- Winforms
- VSCode

# How To Build

__Only compatible with Windows OS__

In the root directory of the project run the following:

1. __Build Solution__
```bash
dotnet build
```

2. __Run Tests__
```bash
dotnet test .\Spreadsheet-Kyle-Hurd\SpreadsheetEngine.Test\
```


3. __Run UI__
```bash
dotnet run --project .\Spreadsheet-Kyle-Hurd\Spreadsheet-UI\
```

4. __Run Console For Expression Tree__
```bash
dotnet run --project .\Spreadsheet-Kyle-Hurd\ExpressionTreeConsole\
```

# Examples of Program

Blank Spreadsheet
![Blank Spreadsheet](./imgs/BlankSpreadsheet.png)

Populated Spreadhseet
![Populated Spreadsheet](./imgs/PopulatedSpreadsheet.png)

Colorized Spreadsheet
![Colorized Spreadhseet](./imgs/ColorizedSpreadsheet.png)