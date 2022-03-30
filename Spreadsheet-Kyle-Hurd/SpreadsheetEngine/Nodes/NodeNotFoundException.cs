// <copyright file="NodeNotFoundException.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

/// <summary>
/// Initializes the <see cref="NodeNotFoundException"/> class.
/// </summary>
public class NodeNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NodeNotFoundException"/> class.
    /// </summary>
    public NodeNotFoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NodeNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message to be shown during throwing of the exception.</param>
    public NodeNotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NodeNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message to be shown during throwing of the <see cref="NodeNotFoundException"/>.</param>
    /// <param name="inner">The inner <see cref="Exception"/> to be thrown.</param>
    public NodeNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}