// <copyright file="NodeFactory.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Nodes;

using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Initializes the <see cref="NodeFactory"/> class.
/// </summary>
public static class NodeFactory
{
    /// <summary>
    /// Initializes static members of the <see cref="NodeFactory"/> class.
    /// </summary>
    static NodeFactory()
    {
        NodeDictionary = GetEnumerableOfTypeOperatorNode();
    }

    /// <summary>
    /// Gets the dictionary of operators and their corresponding node types.
    /// </summary>
    public static Dictionary<char, Type> NodeDictionary { get; }

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
        else if (double.TryParse(symbol, out double val))
        {
            return new ValueNode(val);
        }
        else if (char.IsLetter(symbol[0]))
        {
            return new VariableNode(symbol);
        }

        return null;
    }

    /// <summary>
    /// Factory to return <see cref="Node{T}"/> objects.
    /// This is an overloaded method that takes a character symbol instead of a string.
    /// </summary>
    /// <param name="symbol">The symbol to create a node.</param>
    /// <returns>The <see cref="Node{T}"/> object, null if no appropriate Node types exist.</returns>
    public static Node<double>? CreateNode(char symbol)
    {
        if (NodeDictionary.ContainsKey(symbol))
        {
            return (Node<double>?)Activator.CreateInstance(NodeDictionary[symbol]);
        }
        else if (double.TryParse(symbol.ToString(), out double val))
        {
            return new ValueNode(val);
        }
        else if (char.IsLetter(symbol))
        {
            return new VariableNode(symbol.ToString());
        }

        return null;
    }

    /// <summary>
    /// Adapted from https://stackoverflow.com/questions/5411694/get-all-inherited-classes-of-an-abstract-class
    /// Allows for classes inheriting from <see cref="OperatorNode"/> to be added to the dictionary.
    /// </summary>
    /// <returns>The dictionary of types that inherit from <see cref="OperatorNode"/>.</returns>
    private static Dictionary<char, Type> GetEnumerableOfTypeOperatorNode()
    {
        Dictionary<char, Type> tempDictionary = new Dictionary<char, Type>();
        foreach (Type type in
            Assembly.GetAssembly(typeof(OperatorNode)) !.GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(OperatorNode))))
        {
            char? op = (char?)type.GetField("Operation")?.GetValue(null);

            // `type.Name` only gets the name of the class, not the namespace.
            string tmp = $"{type}";
            Type? nodeType = Type.GetType(tmp);
            if (op != null && type != null && nodeType != null)
            {
                tempDictionary.Add(op.Value, nodeType);
            }
        }

        Console.WriteLine("Found Nodes:");
        foreach (var item in tempDictionary)
        {
            Console.WriteLine($"{item.Key}, {item.Value}");
        }

        return tempDictionary;
    }
}