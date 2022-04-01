// <copyright file="TestSpreadsheet.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

using NUnit.Framework;

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Test;

using System;
using Spreadsheet_Kyle_Hurd.SpreadsheetEngine;
using Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Cells;

/// <summary>
/// Initializes the <see cref="TestSpreadsheet"/> class.
/// </summary>
public class TestSpreadsheet
{
    /// <summary>
    /// The TestCases for constructing a Spreadsheet with a given number of rows and columns.
    /// </summary>
    private static readonly object[] TestCases =
    {
        new object[] { 0, 0 },
        new object[] { 1, 1 },
        new object[] { 5, 5 },
        new object[] { 10, 5 },
        new object[] { 5, 10 },
    };

    /// <summary>
    /// Temlate test for the Cell class.
    /// </summary>
    /// <param name="numRows">The number of rows to be given to Spreadsheet.</param>
    /// <param name="numColumns">The number of columns to be given to Spreadsheet.</param>
    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void TestNumRows(int numRows, int numColumns)
    {
        Spreadsheet spreadsheet = new Spreadsheet(numRows, numColumns);
        Console.WriteLine($"TestNumColumns: {numRows}, {numColumns} - expected: {numColumns} actual: {spreadsheet.NumColumns}");
        Assert.AreEqual(numRows, spreadsheet.NumRows);
    }

    /// <summary>
    /// Tests the NumColumns property.
    /// </summary>
    /// <param name="numRows">The number of rows to be given to Spreadsheet.</param>
    /// <param name="numColumns">The number of columns to be given to Spreadsheet.</param>
    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void TestNumColumns(int numRows, int numColumns)
    {
        Spreadsheet spreadsheet = new Spreadsheet(numRows, numColumns);
        Console.WriteLine($"TestNumColumns: {numRows}, {numColumns} - expected: {numColumns} actual: {spreadsheet.NumColumns}");
        Assert.AreEqual(numColumns, spreadsheet.NumColumns);
    }

    /// <summary>
    /// Tests the GetCell method.
    /// </summary>
    /// <param name="numRows">The number of rows for the spreadsheet.</param>
    /// <param name="numColumns">The number of columns for the sreadsheet.</param>
    /// <param name="row">The row to get.</param>
    /// <param name="col">The column to get.</param>
    [Test]
    [TestCase(5, 5, 2, 3)]
    [TestCase(5, 5, 4, 4)]
    public void TestGetCell(int numRows, int numColumns, int row, int col)
    {
        Spreadsheet spreadsheet = new Spreadsheet(numRows, numColumns);
        PrivateObject privateSpreadsheet = new PrivateObject(spreadsheet);
        Cell? actual = (Cell?)privateSpreadsheet.Invoke("GetCell", row, col);
        Assert.NotNull(actual);
        if (actual != null)
        {
            Assert.AreEqual(actual.RowIndex, row);
            Assert.AreEqual(actual.ColumnIndex, col);
        }
    }

    /// <summary>
    /// Tests the GetCellFromName method where a cell name indicates
    /// a cell location such as "A1".
    /// </summary>
    /// <param name="numRows">The number of rows in the <see cref="Spreadsheet"/>.</param>
    /// <param name="numColumns">The number of columns in the <see cref="Spreadsheet"/>.</param>
    /// <param name="cellName">The name of the cell to search for.</param>
    [Test]
    [TestCase(5, 5, "A4")]
    [TestCase(5, 5, "b3")]
    public void TestGetCellFromName(int numRows, int numColumns, string cellName)
    {
        Spreadsheet spreadsheet = new Spreadsheet(numRows, numColumns);
        PrivateObject privateSpreadsheet = new PrivateObject(spreadsheet);
        Cell? actual = (Cell?)privateSpreadsheet.Invoke("GetCellFromName", cellName);
        Assert.NotNull(actual);
        cellName = cellName.ToUpper();
        if (actual != null)
        {
            Assert.AreEqual(actual.ColumnIndex, cellName[0] - 'A');
            Assert.AreEqual(actual.RowIndex, int.Parse(cellName.Substring(1)) - 1);
        }
    }

    /// <summary>
    /// Tests the GetCell method for returning a null value if row and column do not exist.
    /// </summary>
    /// <param name="numRows">The number of rows for the spreadsheet.</param>
    /// <param name="numColumns">The number of columns for the sreadsheet.</param>
    /// <param name="row">The row to get.</param>
    /// <param name="col">The column to get.</param>
    [Test]
    [TestCase(5, 5, 6, 6)]
    [TestCase(0, 0, 0, 0)]
    public void TestGetCellNull(int numRows, int numColumns, int row, int col)
    {
        Spreadsheet spreadsheet = new Spreadsheet(numRows, numColumns);
        PrivateObject privateSpreadsheet = new PrivateObject(spreadsheet);
        Cell? actual = (Cell?)privateSpreadsheet.Invoke("GetCell", row, col);
        Assert.IsNull(actual);
    }
}