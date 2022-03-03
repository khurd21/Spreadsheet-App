// <copyright file="NodeFactory.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

using System.Collections.Generic;

/// <summary>
/// Initializes the <see cref="NodeFactory"/> class.
/// </summary>
public static class NodeFactory
{
    /// <summary>
    /// Creates a node from the given token.
    /// </summary>
    public static readonly Dictionary<char, Type> NodeDictionary = new Dictionary<char, Type>()
    {
        { AdderNode.Operation, typeof(AdderNode) },
        { SubtractorNode.Operation, typeof(SubtractorNode) },
        { MultiplierNode.Operation, typeof(MultiplierNode) },
        { DivisorNode.Operation, typeof(DivisorNode) },
    };

    /// <summary>
    /// Creates a list of supported operators for user reference.
    /// </summary>
    /// <returns>A list of characters that represent supported operators.</returns>
    public static List<char> GetOperators()
    {
        return NodeDictionary.Keys.ToList();
    }

    /// <summary>
    /// Factory to return <see cref="Node{T}"/> objects.
    /// </summary>
    /// <param name="symbol">The symbol to create a node.</param>
    /// <returns>The <see cref="Node{T}"/> object, null if no appropriate Node types exist.</returns>
    public static Node<double>? CreateNode(string symbol)
    {
        if (NodeDictionary.ContainsKey(symbol[0]))
        {
            return (Node<double>?)Activator.CreateInstance(NodeDictionary[symbol[0]]);
        }
        else if (double.TryParse(symbol, out double _))
        {
            return new ValueNode(double.Parse(symbol));
        }
        else if (char.IsLetter(symbol[0]))
        {
            return new VariableNode(symbol);
        }

        return null;
    }
}