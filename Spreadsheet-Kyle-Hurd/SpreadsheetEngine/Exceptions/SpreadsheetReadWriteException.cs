// <copyright file="SpreadsheetReadWriteException.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Exceptions;

/// <summary>
/// Initializes the SperadsheetReadWriteException class which handles exceptions
/// regarding the reading and writing of spreadsheets.
/// </summary>
public class SpreadsheetReadWriteException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetReadWriteException"/> class.
    /// </summary>
    public SpreadsheetReadWriteException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetReadWriteException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SpreadsheetReadWriteException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetReadWriteException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public SpreadsheetReadWriteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}