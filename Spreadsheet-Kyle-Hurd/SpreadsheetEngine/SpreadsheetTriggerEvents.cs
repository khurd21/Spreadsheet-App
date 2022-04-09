// <copyright file="SpreadsheetTriggerEvents.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

using SpreadsheetEngine.Cells;
using SpreadsheetEngine.Commands;
using System.Drawing;

/// <summary>
/// Intializes the partial <see cref="Spreadsheet"/> class that contains
/// the event handlers for the spreadsheet.
/// </summary>
public partial class Spreadsheet
{
    /// <summary>
    /// A trigger to be executed when a cell is changed from the UI side.
    /// Updates the cell colors.
    /// </summary>
    /// <param name="cells">The list of cells involved in the changed.</param>
    /// <param name="color">The color to set the cells to.</param>
    public void TriggerUpdateCellColor(List<SpreadsheetCell> cells, Color color)
    {
        this.UndoRedoManager.AddCommand(new MultipleCellCommand(cells, $"set background color to {color.Name}"));
        this.UpdateCellColor(cells, color);
    }

    /// <summary>
    /// A trigger to be executed when a cell is changed from the ui side.
    /// updates the cell color.
    /// </summary>
    /// <param name="cell">The cell involved in the changed.</param>
    /// <param name="color">The color to set the cells to.</param>
    public void TriggerUpdateCellColor(SpreadsheetCell cell, Color color)
    {
        this.UndoRedoManager.AddCommand(new MultipleCellCommand(cell, $"set background color to {color.Name}"));
        this.UpdateCellColor(cell.RowIndex, cell.ColumnIndex, color);
    }

    /// <summary>
    /// A trigger to be executed when a cell is changed from the ui side.
    /// updates the cell color.
    /// </summary>
    /// <param name="row">The row of the cell.</param>
    /// <param name="col">The column of the cell.</param>
    /// <param name="text">The text to set the cell to.</param>
    public void TriggerUpdateCellText(int row, int col, string text)
    {
        this.UndoRedoManager.AddCommand(new MultipleCellCommand((SpreadsheetCell)this.GetCell(row, col) !, $"set text to {text}"));
        this.UpdateCellText(row, col, text);
    }
}
