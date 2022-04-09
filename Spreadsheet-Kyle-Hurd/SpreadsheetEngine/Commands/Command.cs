// <copyright file="Command.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Commands;

using SpreadsheetEngine.Cells;

/// <summary>
/// Initializes the base <see cref="Command{T}"/> class.
/// </summary>
/// <typeparam name="T">The type of the command.</typeparam>
public abstract class Command<T> : ICommand<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Command{T}"/> class.
    /// </summary>
    /// <param name="commandName">The name given to the command.</param>
    public Command(string commandName)
    {
        this.CommandName = commandName;
    }

    /// <summary>
    /// Gets the name of the command.
    /// </summary>
    public string? CommandName { get; }

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <returns>The list of cells that have been modified.</returns>
    public abstract List<T> Execute();
}
