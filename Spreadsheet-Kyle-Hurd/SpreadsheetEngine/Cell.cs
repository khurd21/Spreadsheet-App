// <copyright file="Cell.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

using System.ComponentModel;

/// <summary>
/// Initializes the <see cref="Cell"/> class.
/// </summary>
public abstract class Cell : INotifyPropertyChanged
{
    /// <summary>
    /// Index of the row this cell is in.
    /// </summary>
    private readonly int rowIndex;

    /// <summary>
    /// Index of the column this cell is in.
    /// </summary>
    private readonly int columnIndex;

    /// <summary>
    /// String handled by Text property.
    /// </summary>
    private string text;

    /// <summary>
    /// String handled by Value property.
    /// </summary>
    private string value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class.
    /// </summary>
    /// <param name="rowIndex">The row index this cell will represent.</param>
    /// <param name="columnIndex">The column index this cell will represent.</param>
    public Cell(int rowIndex, int columnIndex)
    {
        this.rowIndex = rowIndex;
        this.columnIndex = columnIndex;
        this.text = string.Empty;
        this.value = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class.
    /// The index of the cell is automatically set to -1.
    /// </summary>
    public Cell()
    {
        this.rowIndex = -1;
        this.columnIndex = -1;
        this.text = string.Empty;
        this.value = string.Empty;
    }

    /// <summary>
    /// Occurs when a property value changes.j
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

    /// <summary>
    /// Gets the index pertaining to the row of the cell.
    /// </summary>
    public int RowIndex
    {
        get
        {
            return this.rowIndex;
        }
    }

    /// <summary>
    /// Gets the index pertaining to the column of the cell.
    /// </summary>
    public int ColumnIndex
    {
        get
        {
            return this.columnIndex;
        }
    }

    /// <summary>
    /// Gets or sets the value of the cell. Sets the value of the cell if the value is
    /// not already the existing string.
    /// </summary>
    public string Text
    {
        get
        {
            return this.text;
        }

        set
        {
            if (this.text == value)
            {
                return;
            }

            this.text = value;
            this.OnPropertyChanged(nameof(this.text));
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
            return this.value;
        }

        set
        {
            if (this.value == value)
            {
                return;
            }

            this.value = value;
            this.OnPropertyChanged(nameof(this.value));
        }
    }

    /// <summary>
    /// Function to be called when a property value changes. This helps
    /// avoid the null reference exception.
    /// </summary>
    /// <param name="propertyName">The property name that is to trigger event change.</param>
    private void OnPropertyChanged(string propertyName)
    {
        var handler = this.PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }

        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
