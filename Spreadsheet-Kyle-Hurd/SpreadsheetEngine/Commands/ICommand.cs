// <copyright file="ICommand.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Commands;

/// <summary>
/// Initializes the <see cref="ICommand{T}"/> interface.
/// </summary>
/// <typeparam name="T">The type of the command.</typeparam>
public interface ICommand<T>
{
    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <returns>The list of cells that have been modified.</returns>
    List<T> Execute();
}