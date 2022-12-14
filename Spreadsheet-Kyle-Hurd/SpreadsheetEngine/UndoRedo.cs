// <copyright file="UndoRedo.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

using SpreadsheetEngine.Commands;
using SpreadsheetEngine.Cells;

// Probably want to have this wrapped around another class and make
// Protected

/// <summary>
/// Initializes the <see cref="UndoRedo"/> class.
/// </summary>
public class UndoRedo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UndoRedo"/> class.
    /// </summary>
    public UndoRedo()
    {
        this.UndoStack = new Stack<MultipleCellCommand>();
        this.RedoStack = new Stack<MultipleCellCommand>();
    }

    /// <summary>
    /// Gets or sets the undo stack for the undo/redo functionality.
    /// </summary>
    public Stack<MultipleCellCommand> UndoStack { get; set; }

    /// <summary>
    /// Gets or sets the redo stack for the undo/redo functionality.
    /// </summary>
    public Stack<MultipleCellCommand> RedoStack { get; set; }

    /// <summary>
    /// Returns the description of the top action on the undo stack.
    /// </summary>
    /// <returns>The description of the top action, if available.</returns>
    public string? GetUndoTopAction()
    {
        if (this.CanUndo() == false)
        {
            return null;
        }

        return this.UndoStack.Peek().CommandName;
    }

    /// <summary>
    /// Returns the description of the top action on the redo stack.
    /// </summary>
    /// <returns>The description of the top action, if available.</returns>
    public string? GetRedoTopAction()
    {
        if (this.CanRedo() == false)
        {
            return null;
        }

        return this.RedoStack.Peek().CommandName;
    }

    /// <summary>
    /// Returns the top command on the undo stack. The command
    /// is then removed from the stack.
    /// </summary>
    /// <returns>The list of items involved in the command.</returns>
    public List<SpreadsheetCell>? Undo()
    {
        if (this.CanUndo() == false)
        {
            return null;
        }

        MultipleCellCommand command = this.UndoStack.Pop();

        return command.Execute();
    }

    /// <summary>
    /// Returns the top command on the redo stack. The command
    /// is then removed from the stack.
    /// </summary>
    /// <returns>The list generated by <see cref="Command{T}.Execute"/>.</returns>
    public List<SpreadsheetCell>? Redo()
    {
        if (this.CanRedo() == false)
        {
            return null;
        }

        MultipleCellCommand command = this.RedoStack.Pop();

        return command.Execute();
    }

    /// <summary>
    /// Adds a command to the undo stack.
    /// </summary>
    /// <param name="command">The command to add to the stack.</param>
    public void AddCommand(MultipleCellCommand command)
    {
        this.UndoStack.Push(command);
        this.RedoStack.Clear();
    }

    /// <summary>
    /// Clears the undo and redo stacks.
    /// </summary>
    public void Clear()
    {
        this.UndoStack.Clear();
        this.RedoStack.Clear();
    }

    /// <summary>
    /// Determines whether the undo stack is empty.
    /// </summary>
    /// <returns>True if undo is possible. False otherwise.</returns>
    public bool CanUndo()
    {
        return this.UndoStack.Count > 0;
    }

    /// <summary>
    /// Determines whether the redo stack is empty.
    /// </summary>
    /// <returns>True if redo is possible. False otherwise.</returns>
    public bool CanRedo()
    {
        return this.RedoStack.Count > 0;
    }
}