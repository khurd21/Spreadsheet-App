// <copyright file="Spreadsheet.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

using System.ComponentModel;

/// <summary>
/// Initializes the <see cref="Spreadsheet"/> class.
/// </summary>
public class Spreadsheet : Cell
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
    /// </summary>
    /// <param name="numRows">The number of rows for the Spreadsheet application.</param>
    /// <param name="numCols">The number of columns for the Spreadsheet application.</param>
    public Spreadsheet(int numRows, int numCols)
    {
        // To implement Cells Array.
        this.Cells = new Cell[numRows, numCols];
    }

    /// <summary>
    /// Gets the Spreadsheet array containing a list of Cell objects.
    /// </summary>
    public Cell[,] Cells { get; private set; }

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
    /// Gets the cell at the specified row and column.
    /// </summary>
    /// <param name="row">The row to access.</param>
    /// <param name="col">The column to access.</param>
    /// <returns>The cell at the specific row and column.</returns>
    private Cell GetCell(int row, int col)
    {
        // probably want to return null if not found
        return this.Cells[row, col];
    }

    /// <summary>
    /// Sets the cell at the specified row and column if there is a property change.
    /// </summary>
    /// <param name="sender">The object sending the property change.</param>
    /// <param name="e">The event arguments.</param>
    private void CellPropertyChange(object sender, PropertyChangedEventArgs e)
    {
        // To implement Cell Property Change.
    }
}