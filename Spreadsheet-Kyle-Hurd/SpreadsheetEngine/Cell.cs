// <copyright file="Cell.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace SpreadsheetEngine;

using System.ComponentModel;

/// <summary>
/// Initializes the <see cref="Cell"/> class.
/// </summary>
public abstract class Cell : INotifyPropertyChanged
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class.
    /// </summary>
    /// <param name="rowIndex">The row index this cell will represent.</param>
    /// <param name="columnIndex">The column index this cell will represent.</param>
    public Cell(int rowIndex, int columnIndex)
    {
        this.RowIndex = rowIndex;
        this.ColumnIndex = columnIndex;
        this.Text = string.Empty;
    }

    /// <summary>
    /// Occurs when a property value changes.j
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

    /// <summary>
    /// Gets the index pertaining to the row of the cell.
    /// </summary>
    public int RowIndex { get; }

    /// <summary>
    /// Gets the index pertaining to the column of the cell.
    /// </summary>
    public int ColumnIndex { get; }

    /// <summary>
    /// Gets or sets the value of the cell. Sets the value of the cell if the value is
    /// not already the existing string.
    /// </summary>
    public string Text
    {
        get
        {
            return this.Text;
        }

        set
        {
            if (this.Text == value)
            {
                return;
            }

            this.Text = value;
            this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.Text)));
        }
    }

    /// <summary>
    /// Gets or sets the value of the cell. Sets the value of the cell if the value is
    /// not already the existing string.
    /// </summary>
    public string Value
    {
        get
        {
            return this.Value;
        }

        protected set
        {
            if (this.Value == value)
            {
                return;
            }

            this.Value = value;
            this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.Value)));
        }
    }
}
