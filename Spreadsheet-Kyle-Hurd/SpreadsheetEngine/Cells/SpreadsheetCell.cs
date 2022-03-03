// <copyright file="SpreadsheetCell.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Cells;

/// <summary>
/// Initializes the <see cref="Spreadsheet"/> class.
/// </summary>
public class SpreadsheetCell : Cell
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
    /// </summary>
    /// <param name="rowIndex">The row index this cell will represent.</param>
    /// <param name="columnIndex">The column index this cell will represent.</param>
    public SpreadsheetCell(int rowIndex, int columnIndex)
        : base(rowIndex, columnIndex)
        {
        }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
    /// The index of the cell is automatically set to -1.
    /// </summary>
    public SpreadsheetCell()
        : base()
        {
        }
}