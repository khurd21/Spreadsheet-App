// <copyright file="Spreadsheet.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

using System.ComponentModel;
using SpreadsheetEngine.Cells;
using SpreadsheetEngine.Nodes;

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

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                this.Cells[i, j] = new SpreadsheetCell(i, j);
                this.Cells[i, j].PropertyChanged += this.CellPropertyChanged;
            }
        }
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
            if (cell.Text != text)
            {
                cell.Text = text;
            }
            else
            {
                this.PropertyChanged?.Invoke(cell, new PropertyChangedEventArgs(nameof(Cell)));
            }

            return 0;
        }

        return -1;
    }

    /// <summary>
    /// Gets the <see cref="Cell.Text"/> at the specified row and column.
    /// </summary>
    /// <param name="row">The specified row for the cell.</param>
    /// <param name="col">The specified column for the cell.</param>
    /// <returns>The cell text, if any.</returns>
    public string GetCellText(int row, int col)
    {
        Cell? cell = this.GetCell(row, col);
        if (cell != null)
        {
            return cell.Text;
        }

        return string.Empty;
    }

    /// <summary>
    /// Clears all cell content in the Spreadsheet application.
    /// </summary>
    public void ClearCells()
    {
        for (int i = 0; i < this.NumRows; ++i)
        {
            for (int j = 0; j < this.NumColumns; ++j)
            {
                this.Cells[i, j].Text = string.Empty;
                this.Cells[i, j].Value = string.Empty;
            }
        }
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
    /// Gets the cell at the specified cellName.
    /// A cellName is a string in the format of "A1".
    /// </summary>
    /// <param name="cellName">The cellname is the address to locate its cell.</param>
    /// <returns>The <see cref="Cell"/> at cellName, if it exists.</returns>
    private Cell? GetCellFromName(string cellName)
    {
        cellName = cellName.ToUpper();
        try
        {
            int row = int.Parse(cellName.Substring(1)) - 1;
            int col = this.GetAZIndex(cellName[0]);
            return this.GetCell(row, col);
        }
        catch (Exception)
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
    /// Given a <see cref="Cell"/> object, this method will unsubscribe all other cells that were
    /// previously subscribed to the <see cref="Cell"/>. This is done to ensure the previous <see cref="ExpressionTree"/>
    /// does not influence the new <see cref="ExpressionTree"/>.
    /// </summary>
    /// <param name="cell">The cell for which to make the unsubriptions.</param>
    /// <exception cref="NodeNotFoundException">Node could not be found.</exception>
    private void UnsubscribeToEvents(SpreadsheetCell cell)
    {
        if (cell.ExpressionTree != null)
        {
            VariableNode[] variables = cell.ExpressionTree.GetVariables();
            foreach (var treeNode in variables)
            {
                string variable = treeNode.Variable.ToUpper();
                Cell? cellToUnsubscribe = this.GetCellFromName(variable);
                if (cellToUnsubscribe != null)
                {
                    cellToUnsubscribe.PropertyChanged -= cell.CellPropertyChanged; // I think I need to have CellpropertyChanged for cells
                }
                else
                {
                    throw new NodeNotFoundException($"The variable {variable} was not found in the spreadsheet.");
                }
            }
        }
    }

    /// <summary>
    /// Given a <see cref="Cell"/> object, this method will subscribe all other cells that are
    /// referencing the given <see cref="Cell"/>.
    /// </summary>
    /// <param name="cell">The cell for which to make the subscriptions.</param>
    /// <exception cref="NodeNotFoundException">The node could not be found with the current expression.</exception>
    private void SubscribeToEvents(SpreadsheetCell cell)
    {
        if (cell.ExpressionTree != null)
        {
            VariableNode[] variables = cell.ExpressionTree.GetVariables();
            foreach (var variable in variables)
            {
                string variableName = variable.Variable.ToUpper();
                Cell? cellToSubscribe = this.GetCellFromName(variableName);
                if (cellToSubscribe != null)
                {
                    cellToSubscribe.PropertyChanged += cell.CellPropertyChanged;
                }
                else
                {
                    throw new NodeNotFoundException($"The variable {variableName} was not found in the spreadsheet.");
                }
            }
        }
    }

    /// <summary>
    /// Given a <see cref="Cell"/> object, this method will update the <see cref="Cell"/>'s <see cref="Cell.Value"/>.
    /// </summary>
    /// <param name="cell">The cell to set.</param>
    /// <exception cref="NodeNotFoundException">Thrown when Node not found.</exception>
    private void SetVariables(SpreadsheetCell cell)
    {
        ExpressionTree? tree = cell.ExpressionTree;
        if (tree != null)
        {
            VariableNode[] variables = tree.GetVariables();
            foreach (var variable in variables)
            {
                string variableName = variable.Variable.ToUpper();
                SpreadsheetCell? cellToSubscribe = this.GetCellFromName(variableName) as SpreadsheetCell;
                if (cellToSubscribe != null)
                {
                    double.TryParse(cellToSubscribe.Value, out double value);
                    variable.Value = value;

                    // What if the cell has a string value?
                    // Below is skeleton code if ever need be written.
                    /*if (double.TryParse(cellToSubscribe.Value, out double value))
                    {
                        tree.SetVariableValue(variable.Variable, value);
                    }
                    else
                    {
                        // Thrown when parsing value is not a number value.
                        // https://docs.microsoft.com/en-us/dotnet/api/system.double.parse?view=net-6.0
                        throw new FormatException("The variable value could not be parsed to a double.");
                    }*/
                }
                else
                {
                    throw new NodeNotFoundException($"The variable {variableName} was not found in the spreadsheet.");
                }
            }
        }
    }

    /// <summary>
    /// Sets the cell at the specified row and column if there is a property change.
    /// </summary>
    /// <param name="sender">The object sending the property change.</param>
    /// <param name="e">The event arguments.</param>
    private void CellPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        SpreadsheetCell? spreadsheetCell = sender as SpreadsheetCell;
        if (spreadsheetCell != null)
        {
            if (e.PropertyName == nameof(Cell.Text).ToLower())
            {
                if (spreadsheetCell.Text.StartsWith("="))
                {
                    string expression = spreadsheetCell.Text.Substring(1);
                    try
                    {
                        this.UnsubscribeToEvents(spreadsheetCell);
                        spreadsheetCell.ExpressionTree = new ExpressionTree(expression);
                        this.SubscribeToEvents(spreadsheetCell);
                        this.SetVariables(spreadsheetCell);

                        int row = spreadsheetCell.RowIndex;
                        int col = spreadsheetCell.ColumnIndex;
                        string value = spreadsheetCell.ExpressionTree.Evaluate().ToString();
                        spreadsheetCell.Value = value;
                    }
                    catch (FormatException)
                    {
                        int col = this.GetAZIndex(expression[0]);
                        int row = int.Parse(expression.Substring(1)) - 1;
                        string? value = this.GetCell(row, col)?.Value;
                        if (value != null)
                        {
                            spreadsheetCell.Value = value;
                        }
                        else
                        {
                            spreadsheetCell.Value = "Not found.";
                        }
                    }
                    catch (Exception exception)
                    {
                        spreadsheetCell.Value = exception.Message;
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
}