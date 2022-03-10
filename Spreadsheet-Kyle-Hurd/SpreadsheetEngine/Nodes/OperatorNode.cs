// <copyright file="OperatorNode.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

/// <summary>
/// Initializes the <see cref="OperatorNode"/> class.
/// Note, any class that inherits from OperatorNode must implement the
/// `Operation` and `Precedence` properties. These cannot be enforeced
/// by an interface because the properties are static variables.
/// Precedence should follow the order of operations from the following source:
/// https://en.cppreference.com/w/cpp/language/operator_precedence.
/// </summary>
public abstract class OperatorNode : Node<double>
{
    /// <summary>
    /// The left child of the node.
    /// </summary>
    private Node<double>? left; // May not want to be readonly

    /// <summary>
    /// The right child of the node.
    /// </summary>
    private Node<double>? right;

    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorNode"/> class.
    /// </summary>
    /// <param name="left">The left node.</param>
    /// <param name="right">The right node.</param>
    public OperatorNode(Node<double>? left = null, Node<double>? right = null)
    {
        this.left = left;
        this.right = right;
    }

    /// <summary>
    /// Gets the symbol to represent the <see cref="Node{T}.Evaluate"/> operation in the expression.
    /// This will be declared a value of the child class.
    /// </summary>
    public abstract char Operation { get; }

    /// <summary>
    /// Gets the level of priority for the Node inheriting from <see cref="OperatorNode"/>.
    /// This will be declared a value of the child class.
    /// </summary>
    public abstract int Precedence { get; }

    /// <summary>
    /// Gets or sets the left child of the node.
    /// </summary>
    public Node<double>? Left { get => this.left; set => this.left = value; }

    /// <summary>
    /// Gets or sets the right child of the node.
    /// </summary>
    public Node<double>? Right { get => this.right; set => this.right = value; }
}