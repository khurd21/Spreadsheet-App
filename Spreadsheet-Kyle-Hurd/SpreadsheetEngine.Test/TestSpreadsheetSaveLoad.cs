// <copyright file="TestSpreadsheetSaveLoad.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Test;

using NUnit.Framework;
using SpreadsheetEngine.Cells;
using System.Drawing;
using System.IO;
using System;

/// <summary>
/// Initializes the <see cref="TestSpreadsheetSaveLoad"/> class.
/// All TestFiles are located in the TestFiles folder. These files are directly
/// associated with this test cases and should not be modified without updating
/// the test cases.
/// </summary>
public class TestSpreadsheetSaveLoad
{
    /// <summary>
    /// The test files to load along with the expected output for each file.
    /// </summary>
    private static readonly object[] TestCaseClean =
    {
        new object[]
        {
            Path.GetFullPath("../../../TestFiles/SpreadsheetClean.xml", Environment.CurrentDirectory),
            new CellAttributes[]
            {
                new CellAttributes { Name = "A1", Contents = "1", Color = "FF8988" },
                new CellAttributes { Name = "A2", Contents = "2", Color = "FFFFFFFF" },
                new CellAttributes { Name = "A3", Contents = string.Empty, Color = "FFF999" },
                new CellAttributes { Name = "C4", Contents = string.Empty, Color = "FFFFFFFF" },
            },
        },
        new object[]
        {
            Path.GetFullPath("../../../TestFiles/SpreadsheetDirty.xml", Environment.CurrentDirectory),
            new CellAttributes[]
            {
                new CellAttributes { Name = "A2", Contents = "2", Color = "FFFFFFFF" },
                new CellAttributes { Name = "B4", Contents = "1", Color = "FFFFFFFF" },
                new CellAttributes { Name = "C5", Contents = string.Empty, Color = "FFFFFFFF" },
            },
        },
    };

    /// <summary>
    /// The test files to load that are in an invalid format.
    /// </summary>
    private static readonly object[] TestCaseInvalid =
    {
        new object[] { Path.GetFullPath("../../../TestFiles/SpreadsheetInvalid.xml", Environment.CurrentDirectory) },
    };

    /// <summary>
    /// The test files to load along with the expected output for each file.
    /// Tests that the files are properly loaded and in the correct format for
    /// the spreadsheet. Only includes valid formats.
    /// </summary>
    /// <param name="fileName">The name of the file for which to load.</param>
    /// <param name="cellAttributes">The attributes each cell is supposed to have.</param>
    [Test]
    [TestCaseSource(nameof(TestCaseClean))]
    public void TestLoadValid(string fileName, CellAttributes[] cellAttributes)
    {
        Spreadsheet spreadsheet = new Spreadsheet(10, 10);
        spreadsheet.Load(fileName);
        Assert.IsTrue(AreCellsEqual(cellAttributes, spreadsheet));
    }

    /// <summary>
    /// The test files to load that are in an invalid format.
    /// </summary>
    /// <param name="fileName">The path of the invalid file.</param>
    [Test]
    [TestCaseSource(nameof(TestCaseInvalid))]
    public void TestLoadInvalid(string fileName)
    {
        Spreadsheet spreadsheet = new Spreadsheet(10, 10);
        Assert.Throws<SpreadsheetReadWriteException>(() => spreadsheet.Load(fileName));
    }

    /// <summary>
    /// The test files to load along with the expected output for each file.
    /// </summary>
    /// <param name="fileName">The name of the file for which the spreadsheet is to be saved.</param>
    [Test]
    [TestCase("../../../TestFiles/MyTestSpreadsheet.xml")]
    public void TestSave(string fileName)
    {
        Spreadsheet spreadsheet = new Spreadsheet(10, 10);
        spreadsheet.TriggerUpdateCellText(0, 1, "Cell 01");
        spreadsheet.TriggerUpdateCellText(1, 1, "Cell 11");
        spreadsheet.TriggerUpdateCellColor(1, 1, Color.Red);
        spreadsheet.Save(fileName);
        Assert.IsTrue(File.Exists(fileName));
    }

    /// <summary>
    /// Compares the cell attributes to the expected values.
    /// </summary>
    /// <param name="expected">The expected cell attributes for a cell to have.</param>
    /// <param name="spreadsheet">The spreadsheet generated from <see cref="Spreadsheet.Load(string)"/>.</param>
    /// <returns>True if the cells are valid, false otherwise.</returns>
    private static bool AreCellsEqual(CellAttributes[] expected, Spreadsheet spreadsheet)
    {
        bool areEqual = true;
        foreach (CellAttributes cell in expected)
        {
            PrivateObject privateSpreadsheet = new PrivateObject(spreadsheet);
            SpreadsheetCell? spreadsheetCell = (SpreadsheetCell?)privateSpreadsheet.Invoke("GetCellFromName", cell.Name);
            if (spreadsheetCell == null ||
                    spreadsheetCell.Text != cell.Contents ||
                    spreadsheetCell.BackColor.ToArgb().ToString("X") != cell.Color)
            {
                areEqual = false;
                break;
            }
        }

        return areEqual;
    }

    /// <summary>
    /// Contains the cell attributes that need to be compared when
    /// under test.
    /// </summary>
    public struct CellAttributes
    {
        /// <summary>
        /// Gets or sets the name of the cell.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the contents / text of the cell.
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Gets or sets the color of the cell (as a hex string).
        /// </summary>
        public string Color { get; set; }
    }
}