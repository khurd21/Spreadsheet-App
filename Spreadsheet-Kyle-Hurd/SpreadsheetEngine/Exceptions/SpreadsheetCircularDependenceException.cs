// <copyright file="SpreadsheetCircularDependenceException.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Exceptions;

/// <summary>
/// The error thrown when a circular dependency is detected.
/// </summary>
public class SpreadsheetCircularDependenceException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetCircularDependenceException"/> class.
    /// </summary>
    public SpreadsheetCircularDependenceException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetCircularDependenceException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SpreadsheetCircularDependenceException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetCircularDependenceException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public SpreadsheetCircularDependenceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}