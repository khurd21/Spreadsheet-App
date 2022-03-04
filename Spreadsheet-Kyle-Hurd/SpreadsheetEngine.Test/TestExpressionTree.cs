// <copyright file="TestExpressionTree.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Test;

using NUnit.Framework;
using System;

/// <summary>
/// Initializes the <see cref="TestExpressionTree"/> class.
/// </summary>
public class TestExpressionTree
{
    /// <summary>
    /// The test cases for evaluating an expression with variables.
    /// </summary>
    public static readonly object[] EvaluateWithVariablesTestCases =
    {
        new object[]
        {
            "A1 + B6 + B6",
            new Tuple<string, double>[]
            {
                new Tuple<string, double>("A1", 1.0),
                new Tuple<string, double>("B6", 2.0),
            },
            5.0,
        },
        new object[]
        {
            "A1 - B6 - 3",
            new Tuple<string, double>[]
            {
                new Tuple<string, double>("A1", 1.0),
                new Tuple<string, double>("B6", 2.0),
            },
            -4.0,
        },
        new object[]
        {
            "A1 * B6",
            new Tuple<string, double>[]
            {
                new Tuple<string, double>("A1", 7.0),
                new Tuple<string, double>("B6", 2.0),
            },
            14.0,
        },
        new object[]
        {
            "A1 / B6",
            new Tuple<string, double>[]
            {
                new Tuple<string, double>("A1", 7.0),
                new Tuple<string, double>("B6", 2.0),
            },
            3.5,
        },
    };

    /// <summary>
    /// Tests to make sure the <see cref="ExpressionTree"/> class can reject
    /// invalid expressions and accept valid ones.
    /// </summary>
    /// <param name="expression">The expression to be used.</param>
    /// <param name="expected">Whether the expression is valid or not.</param>
    [Test]
    [TestCase("1A + 2B", false)]
    [TestCase("A1 + B2", true)]
    [TestCase("A1+B2 +C3", true)]
    [TestCase("1+2* 5", true)]
    [TestCase("(4 + 5) * 6", true)]
    [TestCase("(( 8 + 2))", true)]
    [TestCase("(( 8 * 4)", false)]
    [TestCase("8.56 + 2", true)]
    public void TestExpressionTreeConstructorException(string expression, bool expected)
    {
        Console.WriteLine($"Testing {expression}, expected: {expected}");
        if (expected == false)
        {
            Assert.Throws<ArgumentException>(() => new ExpressionTree(expression));
        }
        else
        {
            Assert.DoesNotThrow(() => new ExpressionTree(expression));
        }
    }

    /// <summary>
    /// Tests the <see cref="ExpressionTree.Evaluate"/> method.
    /// Currently only tests expressions that are of the same type of operation.
    /// </summary>
    /// <param name="expression">The given expression to evaluate.</param>
    /// <param name="expected">The expected result for the given expression.</param>
    [Test]
    [TestCase("1 + 2 + 3", 6.0)]
    [TestCase("4 * 2 * 3", 24.0)]
    [TestCase("16 / 4 / 2", 2.0)]
    [TestCase("9 - 0 - 1 - 12", -4.0)]
    [TestCase("0/10", 0.0)]
    [TestCase("9/0", double.PositiveInfinity)]
    [TestCase("0/0", double.NaN)]
    public void TestEvaluate(string expression, double expected)
    {
        ExpressionTree tree = new ExpressionTree(expression);
        double actual = tree.Evaluate();
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests the <see cref="ExpressionTree.Evaluate"/> method for expressions that
    /// have a variable set to a value.
    /// </summary>
    /// <param name="expression">The expresion to be evaluated.</param>
    /// <param name="variables">The variables to replace in the expression.</param>
    /// <param name="expected">The expected result.</param>
    [Test]
    [TestCase("1 + 2 + 3", null, 6.0)]
    [TestCase("4 * 2 * 3", null, 24.0)]
    [TestCase("16 / 4 / 2", null, 2.0)]
    [TestCase("9 - 0 - 1 - 12", null, -4.0)]
    [TestCaseSource(nameof(EvaluateWithVariablesTestCases))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "Competing with `?` should not be preceded by a space.")]
    public void TestEvaluateWithVariables(string expression, Tuple<string, double>[]? variables, double expected)
    {
        ExpressionTree tree = new ExpressionTree(expression);
        if (variables != null)
        {
            foreach (Tuple<string, double> variable in variables)
            {
                Console.WriteLine($"Setting {variable.Item1} to {variable.Item2}");
                tree.SetVariableValue(variable.Item1, variable.Item2);
            }
        }

        double actual = tree.Evaluate();
        Console.WriteLine($"Testing {expression} with variables {variables}, expected: {expected}, actual: {actual}");
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests the <see cref="ExpressionTree.Evaluate"/> method for expressions that
    /// have no value set to one or more variables.
    /// </summary>
    /// <param name="expression">The expression to be evaluated.</param>
    [Test]
    [TestCase("1 + 2 + A1")]
    [TestCase("A1 * B2 * C3")]
    [TestCase("A1 / B2 / C3")]
    [TestCase("A1 - B2 - C3")]
    public void TestEvaluateWithException(string expression)
    {
        ExpressionTree tree = new ExpressionTree(expression);
        Assert.Throws<ArgumentException>(() => tree.Evaluate());
    }
}