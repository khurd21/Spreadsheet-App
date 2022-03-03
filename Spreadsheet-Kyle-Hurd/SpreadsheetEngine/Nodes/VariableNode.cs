// <copyright file="VariableNode.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

/// <summary>
/// Initializes the <see cref="VariableNode"/> class.
/// </summary>
public class VariableNode : Node<double>
{
    /// <summary>
    /// The variable name of the node.
    /// </summary>
    private string variable;

    /// <summary>
    /// The value of the node.
    /// </summary>
    private double? value;

    /// <summary>
    /// Initializes a new instance of the <see cref="VariableNode"/> class.
    /// </summary>
    /// <param name="variableName">The variable name to represent <see cref="VariableNode"/>.</param>
    /// <param name="value">The value assigned to variableName.</param>
    public VariableNode(string variableName, double? value = null)
    {
        this.variable = variableName;
        this.value = value;
    }

    /// <summary>
    /// Gets the variable name.
    /// </summary>
    /// <returns>The variable name.</returns>
    public string Variable
    {
        get
        {
            return this.variable;
        }

        private set
        {
            this.variable = value;
        }
    }

    /// <summary>
    /// Gets or sets the value of the node.
    /// </summary>
    /// <returns>The value <see ref="VariableName"/> represents.</returns>
    public double? Value
    {
        get
        {
            return this.value;
        }

        set
        {
            this.value = value;
        }
    }

    /// <summary>
    /// Evaluates the nodes value.
    /// </summary>
    /// <returns><see ref="value"/> if it has been set.</returns>
    /// <exception cref="Exception">Thrown if the <see ref="value"/> has not been set.</exception>
    public override double Evaluate()
    {
        return this.Value ?? throw new Exception($"Variable {this.variable} has not been set.");
    }
}