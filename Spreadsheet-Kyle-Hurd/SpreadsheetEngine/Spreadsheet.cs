// <copyright file="Spreadsheet.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

using System.ComponentModel;
using SpreadsheetEngine.Cells;

/// <summary>
/// Initializes the <see cref="Spreadsheet"/> class.
/// </summary>
public class Spreadsheet
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
    /// The set qualification for <see cref="Cell"/> is internal, so only this class can
    /// access the constructor. I was not able to make it readonly due to constraint of a
    /// abstract class.
    /// </summary>
    /// <param name="numRows">The number of rows for the Spreadsheet application.</param>
    /// <param name="numCols">The number of columns for the Spreadsheet application.</param>
    public Spreadsheet(int numRows, int numCols)
    {
        this.Cells = new Cell[numRows, numCols];

        Parallel.For(0, numRows, i =>
        {
            for (int j = 0; j < numCols; j++)
            {
                this.Cells[i, j] = new SpreadsheetCell(i, j);
                this.Cells[i, j].PropertyChanged += this.CellPropertyChanged;
            }
        });
    }

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

    /// <summary>
    /// Gets the number of rows in the Spreadsheet application.
    /// </summary>
    public int NumRows
    {
        get
        {
            return this.Cells.GetLength(0);
        }
    }

    /// <summary>
    /// Gets the number of columns in the Spreadsheet application.
    /// </summary>
    public int NumColumns
    {
        get
        {
            return this.Cells.GetLength(1);
        }
    }

    /// <summary>
    /// Gets or sets the Spreadsheet array containing a list of Cell objects.
    /// </summary>
    private Cell[,] Cells { get; set; }

    /// <summary>
    /// Updates the cell text at the specified row and column.
    /// </summary>
    /// <param name="row">The row to find the cell.</param>
    /// <param name="col">The column to find the cell.</param>
    /// <param name="text">The text to set the cell to.</param>
    /// <returns>0 if no errors, -1 otherwise.</returns>
    public int UpdateCellText(int row, int col, string text)
    {
        Cell? cell = this.GetCell(row, col);
        if (cell != null)
        {
            cell.Text = text;
            return 0;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// Clears all cell content in the Spreadsheet application.
    /// </summary>
    public void ClearCells()
    {
        Parallel.For(0, this.NumRows, i =>
        {
            for (int j = 0; j < this.NumColumns; j++)
            {
                this.Cells[i, j].Text = string.Empty;
                this.Cells[i, j].Value = string.Empty;
            }
        });
    }

    /// <summary>
    /// Gets the cell at the specified row and column.
    /// </summary>
    /// <param name="row">The row to access.</param>
    /// <param name="col">The column to access.</param>
    /// <returns>The cell at the specific row and column, null if does not exist.</returns>
    private Cell? GetCell(int row, int col)
    {
        try
        {
            return this.Cells[row, col];
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the cell index given a character from A to Z.
    /// </summary>
    /// <param name="c">The character to be converted to an index.</param>
    /// <returns>The index of the specific letter.</returns>
    private int GetAZIndex(char c)
    {
        return c - 'A';
    }

    /// <summary>
    /// Sets the cell at the specified row and column if there is a property change.
    /// </summary>
    /// <param name="sender">The object sending the property change.</param>
    /// <param name="e">The event arguments.</param>
    private void CellPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        Cell? cell = sender as SpreadsheetCell;
        if (cell == null)
        {
            return;
        }

        Cell? spreadsheetCell = this.GetCell(cell.RowIndex, cell.ColumnIndex);
        if (spreadsheetCell != null)
        {
            if (spreadsheetCell.Text.Length > 2 && spreadsheetCell.Text[0] == '=')
            {
                int row = int.Parse(spreadsheetCell.Text.Substring(2)) - 1;
                int col = this.GetAZIndex(char.ToUpper(spreadsheetCell.Text[1]));
                Cell? cellToCopy = this.GetCell(row, col);
                if (cellToCopy != null)
                {
                    spreadsheetCell.Value = cellToCopy.Text;
                }
            }
            else
            {
                spreadsheetCell.Value = spreadsheetCell.Text;
            }

            this.PropertyChanged?.Invoke(spreadsheetCell, new PropertyChangedEventArgs(nameof(Cell)));
        }
    }
}