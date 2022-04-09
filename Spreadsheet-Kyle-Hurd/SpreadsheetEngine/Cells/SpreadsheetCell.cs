// <copyright file="SpreadsheetCell.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Cells;

using SpreadsheetEngine.Expressions;
using System.Drawing;

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
            this.BackColor = Color.White;
        }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
    /// The index of the cell is automatically set to -1.
    /// </summary>
    public SpreadsheetCell()
        : base()
        {
            this.BackColor = Color.White;
        }

    /// <summary>
    /// Gets or sets the expression tree for this cell.
    /// </summary>
    public ExpressionTree? ExpressionTree { get; set; }

    /// <summary>
    /// Gets the color of this cell.
    /// </summary>
    public Color BackColor { get; private set; }

    /// <summary>
    /// Produces a shallow copy of the cell.
    /// </summary>
    /// <returns>A copy of its cell.</returns>
    public override SpreadsheetCell ShallowCopy()
    {
        SpreadsheetCell copy = (SpreadsheetCell)this.MemberwiseClone();
        return copy;
    }

    /// <summary>
    /// Sets the color of this cell.
    /// </summary>
    /// <param name="color">The color to set this cell to.</param>
    public void SetBackColor(Color color)
    {
        if (this.BackColor == color)
        {
            return;
        }

        this.BackColor = color;
        this.OnPropertyChanged(nameof(this.BackColor));
    }
}