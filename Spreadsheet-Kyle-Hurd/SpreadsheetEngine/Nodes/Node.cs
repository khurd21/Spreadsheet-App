// <copyright file="Node.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

/// <summary>
/// Initializes the abstract <see cref="Node{T}"/> class.
/// </summary>
/// <typeparam name="T">The type to represent <see cref="Node{T}"/>.</typeparam>
public abstract class Node<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class.
    /// </summary>
    public Node()
    {
    }

    /// <summary>
    /// Evaluates the node.
    /// </summary>
    /// <returns>The result of the evaluated node.</returns>
    public abstract T Evaluate();
}