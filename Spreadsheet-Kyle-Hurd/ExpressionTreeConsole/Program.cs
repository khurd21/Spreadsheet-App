// <copyright file="Program.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.ExpressionTreeConsole;

using Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Expressions;
using System;

/// <summary>
/// This class is the entry point for the Expression Tree Console application.
/// </summary>
public static class Program
{
    /// <summary>
    /// Prints the options available for the console application.
    /// </summary>
    /// <param name="expression">The expression the current <see cref="ExpressionTree"/> expression.</param>
    private static void PrintMenu(string expression)
    {
        Console.WriteLine($"Menu - Current Expression: {expression}");
        Console.WriteLine("1. Enter a new expression");
        Console.WriteLine("2. Set a variable value");
        Console.WriteLine("3. Evaluate the expression");
        Console.WriteLine("4. Quit");
    }

    /// <summary>
    /// The main entry point for the console application.
    /// </summary>
    private static void Main()
    {
        ExpressionTree? tree = null;
        while (true)
        {
            PrintMenu(tree?.Expression ?? string.Empty);
            string input = Console.ReadLine() !;
            if (input == "1")
            {
                Console.WriteLine("Enter an expression:");
                string expression = Console.ReadLine() !;
                try
                {
                    tree = new ExpressionTree(expression);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("Enter a variable name:");
                string variable = Console.ReadLine() !;
                Console.WriteLine("Enter a value:");
                string value = Console.ReadLine() !;
                if (double.TryParse(value, out double doubleValue))
                {
                    tree?.SetVariableValue(variable, doubleValue);
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
            else if (input == "3")
            {
                try
                {
                    Console.WriteLine($"Result: {tree?.Evaluate()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            else if (input == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}