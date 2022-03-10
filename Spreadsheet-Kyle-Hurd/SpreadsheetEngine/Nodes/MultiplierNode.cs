// <copyright file="MultiplierNode.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

/// <summary>
/// Initializes the <see cref="MultiplierNode"/> class.
/// </summary>
public class MultiplierNode : OperatorNode
{
    /// <summary>
    /// The symbol to represent the <see cref="MultiplierNode.Evaluate"/> operation in the expression.
    /// </summary>
    public static readonly char Operation = '*';

    /// <summary>
    /// The level of priority for the Node inheriting from <see cref="OperatorNode"/>.
    /// </summary>
    public static readonly int Precedence = 5;

    /// <summary>
    /// Initializes a new instance of the <see cref="MultiplierNode"/> class.
    /// </summary>
    /// <param name="left">The left node for the <see cref="OperatorNode"/>.</param>
    /// <param name="right">The right node for the <see cref="OperatorNode"/>.</param>
    public MultiplierNode(Node<double> left, Node<double> right)
        : base(left, right)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MultiplierNode"/> class.
    /// </summary>
    public MultiplierNode()
        : base(null, null)
    {
    }

    /// <summary>
    /// Evaluates the node.
    /// </summary>
    /// <returns>The evaluated result from the left and right node.</returns>
    public override double Evaluate()
    {
        return this.Left!.Evaluate() * this.Right!.Evaluate();
    }
}