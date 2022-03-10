// <copyright file="AdderNode.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

/// <summary>
/// Initializes the <see cref="AdderNode"/> class.
/// Inherits from the abstract <see cref="OperatorNode"/> class which contains
/// left and right children for operation to be performed.
/// </summary>
public class AdderNode : OperatorNode
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdderNode"/> class.
    /// </summary>
    /// <param name="left">The left node for operation to take place.</param>
    /// <param name="right">The right node for operation to take place.</param>
    public AdderNode(Node<double> left, Node<double> right)
        : base(left, right)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AdderNode"/> class.
    /// </summary>
    public AdderNode()
        : base(null, null)
    {
    }

    /// <summary>
    /// Gets the symbol to represent the <see cref="AdderNode.Evaluate"/> operation in the expression.
    /// </summary>
    public override char Operation => '+';

    /// <summary>
    /// Gets the level of priority for the Node inheriting from <see cref="OperatorNode"/>.
    /// </summary>
    public override int Precedence => 6;

    /// <summary>
    /// Evaluates the nodes.
    /// </summary>
    /// <returns>The evaluated result from the sum of the left and right nodes.</returns>
    public override double Evaluate()
    {
        return this.Left!.Evaluate() + this.Right!.Evaluate();
    }
}