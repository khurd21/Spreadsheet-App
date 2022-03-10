// <copyright file="SubtractorNode.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

/// <summary>
/// Initializes the <see cref="SubtractorNode"/> class.
/// </summary>
public class SubtractorNode : OperatorNode
{
    /// <summary>
    /// The symbol to represent the <see cref="SubtractorNode.Evaluate"/> operation in the expression.
    /// </summary>
    public static readonly char Operation = '-';

    /// <summary>
    /// The level of priority for the Node inheriting from <see cref="OperatorNode"/>.
    /// </summary>
    public static readonly int Precedence = 6;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubtractorNode"/> class.
    /// </summary>
    /// <param name="left">The left node.</param>
    /// <param name="right">The right node.</param>
    public SubtractorNode(Node<double> left, Node<double> right)
        : base(left, right)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SubtractorNode"/> class.
    /// </summary>
    public SubtractorNode()
        : base(null, null)
    {
    }

    /// <summary>
    /// Evaluates the node.
    /// </summary>
    /// <returns>The result of the evaluated node.</returns>
    public override double Evaluate()
    {
        return this.Left!.Evaluate() - this.Right!.Evaluate();
    }
}