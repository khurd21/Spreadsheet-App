// <copyright file="MultipleCellCommand.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Commands;

using Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Cells;

/// <summary>
/// Initializes the <see cref="MultipleCellCommand"/> class.
/// </summary>
public class MultipleCellCommand : Command<SpreadsheetCell>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MultipleCellCommand"/> class.
    /// </summary>
    /// <param name="cells">The list of cells that have been modified.</param>
    /// <param name="command">The description of the command that took place.</param>
    public MultipleCellCommand(List<SpreadsheetCell> cells, string command)
        : base(command)
    {
        this.Cells = new ();
        foreach (SpreadsheetCell cell in cells)
        {
            this.Cells.Add(cell.ShallowCopy());
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MultipleCellCommand"/> class.
    /// Handles the event that only one cell has been modified.
    /// </summary>
    /// <param name="cell">The cell that has been modified.</param>
    /// <param name="command">The description of the command that took place.</param>
    public MultipleCellCommand(SpreadsheetCell cell, string command)
        : base(command)
    {
        this.Cells = new List<SpreadsheetCell>() { cell.ShallowCopy() };
    }

    /// <summary>
    /// Gets the cells for the command.
    /// </summary>
    public List<SpreadsheetCell> Cells { get; private set; }

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <returns>The list of cells that have been modified.</returns>
    public override List<SpreadsheetCell> Execute()
    {
        return this.Cells.ConvertAll(cell => (SpreadsheetCell)cell);
    }
}