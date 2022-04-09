// <copyright file="TestSpreadsheetCell.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Test;

using NUnit.Framework;
using System.Drawing;
using Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Cells;

/// <summary>
/// Tests the SpreadsheetCell class.
/// </summary>
public class TestSpreadsheetCell
{
    /// <summary>
    /// The test cases for setting the color of a <see cref="SpreadsheetCell"/>.
    /// </summary>
    private static readonly object[] TestCaseColors =
    {
        new object[] { Color.White },
        new object[] { Color.Red },
        new object[] { Color.Green },
    };

    /// <summary>
    /// Tests the correct colors are returned.
    /// </summary>
    /// <param name="color">The color to set the <see cref="SpreadsheetCell"/> to.</param>
    [Test]
    [TestCaseSource(nameof(TestCaseColors))]
    public void TestGetColor(Color color)
    {
        SpreadsheetCell cell = new SpreadsheetCell();
        cell.SetBackColor(color);
        Assert.AreEqual(color, cell.BackColor);
    }

    /// <summary>
    /// Tests the default color of <see cref="Color.White"/> is returned.
    /// </summary>
    [Test]
    public void TestGetColorDefault()
    {
        SpreadsheetCell cell = new SpreadsheetCell();
        Assert.AreEqual(Color.White, cell.BackColor);
    }

    /// <summary>
    /// Tests the shallow copy of a <see cref="SpreadsheetCell"/>
    /// does not change the original.
    /// </summary>
    [Test]
    public void TestShallowCopy()
    {
        SpreadsheetCell cell = new SpreadsheetCell();
        SpreadsheetCell copy = cell.ShallowCopy();
        Assert.AreNotEqual(cell, copy);
    }
}