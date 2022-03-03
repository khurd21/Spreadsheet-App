// <copyright file="ValueNode.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

/// <summary>
/// Initializes the <see cref="ValueNode"/> class.
/// This class is intended for use with the Expression Tree in which it
/// only need store a value (constant numerical) for a leaf node.
/// </summary>
public class ValueNode : Node<double>
{
    /// <summary>
    /// The value of the node.
    /// </summary>
    private double value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueNode"/> class.
    /// </summary>
    /// <param name="value">The value of the node.</param>
    public ValueNode(double value)
        : base()
    {
        this.value = value;
    }

    /// <summary>
    /// Gets the value of the node.
    /// </summary>
    public double Value
    {
        get
        {
            return this.value;
        }

        private set
        {
            this.value = value;
        }
    }

    /// <summary>
    /// Evaluates the node.
    /// </summary>
    /// <returns>The result of the evaluated node.</returns>
    public override double Evaluate()
    {
        return this.Value;
    }
}