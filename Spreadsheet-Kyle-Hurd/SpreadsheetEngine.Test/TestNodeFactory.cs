// <copyright file="TestNodeFactory.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Test;

using MVT = Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using Nodes;

/// <summary>
/// Initializes the <see cref="TestNodeFactory"/> class.
/// </summary>
public class TestNodeFactory
{
    /// <summary>
    /// Test cases of valid Operation Symbols.
    /// </summary>
    private static readonly ReadOnlyCollection<char> OperationSymbols = new ReadOnlyCollection<char>(NodeFactory.GetOperators());

    /// <summary>
    /// Tests that the operation symbols <see cref="NodeFactory"/> claims to have
    /// actually returns the correct type of <see cref="OperatorNode"/>.
    /// </summary>
    /// <param name="op">The operation symbol that is supported.</param>
    [Test]
    [TestCaseSource(nameof(OperationSymbols))]
    public void TestCreateOperatorNodeChar(char op)
    {
        Node<double>? node = NodeFactory.CreateNode(op);
        Console.WriteLine($"Testing {op} to match type: {typeof(OperatorNode)}");
        Console.WriteLine($"Actual: {node?.GetType()}, Expected: {typeof(OperatorNode)}");
        Assert.IsInstanceOf<OperatorNode>(node);
    }

    /// <summary>
    /// Tests that the operation symbols <see cref="NodeFactory"/> claims to have
    /// actually returns the correct type of <see cref="OperatorNode"/>.
    /// This is made to test the overloaded functionality of <see cref="NodeFactory.CreateNode(string)"/>.
    /// </summary>
    /// <param name="op">The operation that is supported.</param>
    [Test]
    [TestCaseSource(nameof(OperationSymbols))]
    public void TestCreateOperatorNodeString(char op)
    {
        Node<double>? node = NodeFactory.CreateNode(op.ToString());
        Console.WriteLine($"Testing {op} to match type: {typeof(OperatorNode)}");
        Console.WriteLine($"Actual: {node?.GetType()}, Expected: {typeof(OperatorNode)}");
        Assert.IsInstanceOf<OperatorNode>(node);
    }

    /// <summary>
    /// Tests the the protected symbols do not return a <see cref="OperatorNode"/> type.
    /// </summary>
    /// <param name="op">The op for which to create a node for.</param>
    /// <param name="type">The type of <see cref="Node{T}"/> that is expected to be made.</param>
    [Test]
    [TestCase('7', typeof(ValueNode))]
    [TestCase('a', typeof(VariableNode))]
    [TestCase('Z', typeof(VariableNode))]
    public void TestNullCreateNodeChar(char op, Type type)
    {
        Node<double>? node = NodeFactory.CreateNode(op);
        Console.WriteLine($"Testing {op} to match type: null");
        Console.WriteLine($"Actual: {node?.GetType()}, Expected: null");
        MVT.Assert.IsInstanceOfType(node, type);
    }

    /// <summary>
    /// Tests the the protected symbols do not return a <see cref="OperatorNode"/> type.
    /// This tests the overloaded <see cref="NodeFactory.CreateNode(string)"/> functionality.
    /// </summary>
    /// <param name="op">The op for which to create a node for.</param>
    /// <param name="type">The type of <see cref="Node{T}"/> that is expected to be made.</param>
    [Test]
    [TestCase("7", typeof(ValueNode))]
    [TestCase("a", typeof(VariableNode))]
    [TestCase("Z", typeof(VariableNode))]
    public void TestNullCreateNodeString(string op, Type type)
    {
        Node<double>? node = NodeFactory.CreateNode(op);
        Console.WriteLine($"Testing {op} to match type: null");
        Console.WriteLine($"Actual: {node?.GetType()}, Expected: null");
        MVT.Assert.IsInstanceOfType(node, type);
    }
}