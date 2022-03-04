// <copyright file="TestExpressionValidator.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Test;

using NUnit.Framework;
using System.Linq;
using System;

/// <summary>
/// Initializes the <see cref="TestExpressionValidator"/> class.
/// </summary>
public class TestExpressionValidator
{
    /// <summary>
    /// Test cases for making sure an expression evaluates correctly.
    /// LHS: The expression to be evaluated.
    /// RHS: The expected evaluation of the expression.
    /// </summary>
    public static readonly object[] IsExpressionTestCases = new object[]
    {
        new object[]
        {
            "1",
            true,
            new char[] { '+', '-', '*', '/', '^' },
        },
        new object[]
        {
            "1.0",
            true,
            new char[] { '+', '-', '*', '/', '^' },
        },
        new object[]
        {
            "((1/2)-3)",
            true,
            new char[] { '+', '-', '*', '/', '^' },
        },
        new object[]
        {
            "((1+2)*3*)",
            false,
            new char[] { '+', '-', '*', '/', '^' },
        },
        new object[]
        {
            "*",
            false,
            new char[] { '+', '-', '*', '/', '^' },
        },
        new object[]
        {
            "1 + 2 2",
            false,
            new char[] { '+', '-', '*', '/', '^' },
        },
    };

    /// <summary>
    /// Tests the <see cref="ExpressionValidator.IsExpression"/> method.
    /// </summary>
    /// <param name="expression">The expression to be evaluated.</param>
    /// <param name="expected">The expected result from the evaluated expression.</param>
    /// <param name="supportedOperators">The list of operators to support.</param>
    [Test]
    [TestCaseSource(nameof(IsExpressionTestCases))]
    public void TestIsExpression(string expression, bool expected, char[] supportedOperators)
    {
        bool actual = ExpressionValidator.IsExpression(expression, supportedOperators.ToList());

        Console.WriteLine($"Testing {expression}");
        Console.WriteLine($"Expected: {expected}, Actual: {actual}");
        Assert.AreEqual(expected, ExpressionValidator.IsExpression(expression, supportedOperators.ToList()));
    }

    /// <summary>
    /// Tests the format method to make sure the inputted expressions are formatted to the correct
    /// string format for the expression validator.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="expected">The expected formatted output.</param>
    [Test]
    [TestCase("1", "1")]
    [TestCase("1.0", "1.0")]
    [TestCase("1.0+2.0", "1.0+2.0")]
    [TestCase("1  #x=42.0", "1#`x`=42.0")]
    [TestCase("32..42A321/2", "32..42`A321`/2")]
    public void TestFormat(string input, string expected)
    {
        string actual = ExpressionValidator.Format(input);
        Assert.AreEqual(expected, actual);
    }
}