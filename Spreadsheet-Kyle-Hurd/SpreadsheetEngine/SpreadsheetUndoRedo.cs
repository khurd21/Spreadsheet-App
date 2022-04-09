// <copyright file="SpreadsheetUndoRedo.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

using SpreadsheetEngine.Cells;
using SpreadsheetEngine.Commands;

/// <summary>
/// Initializes the <see cref="Spreadsheet"/> class.
/// </summary>
public partial class Spreadsheet
{
    /// <summary>
    /// Gets or sets the Cell object at the specified row and column.
    /// </summary>
    private UndoRedo UndoRedoManager { get; set; }

    /// <summary>
    /// Determines whether an undo operation is currently valid.
    /// </summary>
    /// <returns>True if an undo operation is valid, false otherwise.</returns>
    public bool CanUndo() => this.UndoRedoManager.CanUndo();

    /// <summary>
    /// Determines whether a redo operation is currently valid.
    /// </summary>
    /// <returns>True if a redo operation is valid, false otherwise.</returns>
    public bool CanRedo() => this.UndoRedoManager.CanRedo();

    /// <summary>
    /// Gets the description of the top action on the undo stack.
    /// </summary>
    /// <returns>The description of the top action.</returns>
    public string? GetUndoTopAction() => this.UndoRedoManager.GetUndoTopAction();

    /// <summary>
    /// Gets the description of the top action on the redo stack.
    /// </summary>
    /// <returns>The description of the top action.</returns>
    public string? GetRedoTopAction() => this.UndoRedoManager.GetRedoTopAction();

    /// <summary>
    /// Undoes the top action on the undo stack.
    /// </summary>
    public void Undo()
    {
        // int row = this.UndoRedoManager.GetUndoTopRow();
        // int col = this.UndoRedoManager.GetUndoTopColumn();
        // SpreadsheetCell? currentCell = (SpreadsheetCell?)this.GetCell(row, col);
        List<SpreadsheetCell>? topCells = this.UndoRedoManager.UndoStack.Peek().Cells;
        if (topCells == null)
        {
            return;
        }

        List<SpreadsheetCell> currentCells = new List<SpreadsheetCell>();
        foreach (SpreadsheetCell cell in topCells)
        {
            currentCells.Add(((SpreadsheetCell?)this.GetCell(cell.RowIndex, cell.ColumnIndex) !).ShallowCopy());
        }

        this.UndoRedoManager.RedoStack.Push(new MultipleCellCommand(currentCells, this.UndoRedoManager.UndoStack.Peek().CommandName ?? string.Empty));

        bool isColor = this.UndoRedoManager.GetUndoTopAction() !.Contains("color");
        List<SpreadsheetCell>? cells = this.UndoRedoManager.Undo();
        if (cells == null)
        {
            return;
        }

        foreach (SpreadsheetCell cell in cells)
        {
            if (isColor == false)
            {
                this.UpdateCellText(cell.RowIndex, cell.ColumnIndex, cell.Text);
            }
            else
            {
                this.UpdateCellColor(cell.RowIndex, cell.ColumnIndex, cell.BackColor);
            }
        }
    }

    /// <summary>
    /// Redoes the top action on the redo stack.
    /// </summary>
    public void Redo()
    {
        string command = this.UndoRedoManager.RedoStack.Peek().CommandName ?? string.Empty;
        List<SpreadsheetCell>? topCells = this.UndoRedoManager.RedoStack.Peek().Cells;
        if (topCells == null)
        {
            return;
        }

        List<SpreadsheetCell> currentCells = new List<SpreadsheetCell>();
        foreach (SpreadsheetCell cell in topCells)
        {
            currentCells.Add(((SpreadsheetCell?)this.GetCell(cell.RowIndex, cell.ColumnIndex) !).ShallowCopy());
        }

        this.UndoRedoManager.UndoStack.Push(new MultipleCellCommand(currentCells, command));

        bool isColor = this.UndoRedoManager.GetRedoTopAction() !.Contains("color");
        List<SpreadsheetCell>? cells = this.UndoRedoManager.Redo();
        foreach (SpreadsheetCell cell in topCells)
        {
            if (isColor == false)
            {
                this.UpdateCellText(cell.RowIndex, cell.ColumnIndex, cell.Text);
            }
            else
            {
                this.UpdateCellColor(cell.RowIndex, cell.ColumnIndex, cell.BackColor);
            }
        }
    }
}