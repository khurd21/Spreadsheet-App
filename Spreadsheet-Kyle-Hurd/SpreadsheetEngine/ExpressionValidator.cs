// <copyright file="ExpressionValidator.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

/// <summary>
/// Initializes the <see cref="ExpressionValidator"/> class.
/// A static class that validates an expression.
/// </summary>
public static class ExpressionValidator
{
    /// <summary>
    /// The enumerated possible states of an expression.
    /// </summary>
    private enum States
    {
        /// <summary>
        /// State is not yet determined.
        /// </summary>
        None = 0,

        /// <summary>
        /// State is a number.
        /// </summary>
        Number = 1,

        /// <summary>
        /// State is a variable.
        /// </summary>
        Variable = 2,

        /// <summary>
        /// State is an operator.
        /// </summary>
        Operator = 3,

        /// <summary>
        /// State is a left parenthesis.
        /// </summary>
        OpenParen = 4,

        /// <summary>
        /// State is a right parenthesis.
        /// </summary>
        CloseParen = 5,
    }

    /// <summary>
    /// Determines if the string is a valid expression.
    /// </summary>
    /// <param name="expression">The expression to verify.</param>
    /// <param name="supportedOperators">List of operators that can be used in the expression.</param>
    /// <returns>True if it is an expression, false otherwise.</returns>
    public static bool IsExpression(string expression, List<char> supportedOperators)
    {
        bool isDouble = false;
        string formattedExpression = Format(expression);
        if (formattedExpression.Length == 0)
        {
            return false;
        }

        if (formattedExpression[formattedExpression.Length - 1] == '(')
        {
            return false;
        }

        States state = States.None;
        int openParens = 0;
        for (int i = 0; i < formattedExpression.Length; ++i)
        {
            char c = formattedExpression[i];
            if (state == States.None)
            {
                if (c == '(')
                {
                    state = States.OpenParen;
                    ++openParens;
                }
                else if (char.IsDigit(c))
                {
                    state = States.Number;
                }
                else if (c == '`')
                {
                    state = States.Variable;
                    isDouble = false;
                }
                else
                {
                    return false;
                }
            }
            else if (state == States.Variable)
            {
                if (char.IsLetterOrDigit(c))
                {
                    state = States.Variable;
                }
                else if (c == '`')
                {
                    ++i;
                    if (i >= formattedExpression.Length)
                    {
                        break;
                    }

                    c = formattedExpression[i];
                    if (supportedOperators.Contains(c))
                    {
                        state = States.Operator;
                    }
                    else if (c == ')')
                    {
                        state = States.CloseParen;
                        --openParens;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (state == States.Number)
            {
                if (char.IsDigit(c))
                {
                    state = States.Number;
                }
                else if (c == '.')
                {
                    if (isDouble == true)
                    {
                        return false;
                    }

                    isDouble = true;
                }
                else if (supportedOperators.Contains(c))
                {
                    state = States.Operator;
                    isDouble = false;
                }
                else if (c == ')')
                {
                    state = States.CloseParen;
                    --openParens;
                    isDouble = false;
                }
                else
                {
                    return false;
                }
            }
            else if (state == States.OpenParen)
            {
                if (char.IsDigit(c))
                {
                    state = States.Number;
                }
                else if (c == '`')
                {
                    state = States.Variable;
                }
                else if (c == '(')
                {
                    state = States.OpenParen;
                    ++openParens;
                }
                else
                {
                    return false;
                }
            }
            else if (state == States.CloseParen)
            {
                if (supportedOperators.Contains(c))
                {
                    state = States.Operator;
                }
                else if (c == ')')
                {
                    state = States.CloseParen;
                    --openParens;
                }
                else
                {
                    return false;
                }
            }
            else if (state == States.Operator)
            {
                if (c == '(')
                {
                    state = States.OpenParen;
                    ++openParens;
                }
                else if (char.IsDigit(c))
                {
                    state = States.Number;
                }
                else if (c == '`')
                {
                    state = States.Variable;
                }
                else
                {
                    return false;
                }
            }
        }

        bool res = true;
        res &= openParens == 0;
        res &= state == States.Number || state == States.Variable || state == States.CloseParen;
        return res;
    }

    /// <summary>
    /// Formats the expression so as to be easier to parse.
    /// </summary>
    /// <param name="expression">The expression to format.</param>
    /// <returns>The formatted expression.</returns>
    public static string Format(string expression)
    {
        bool isNumber = false;
        string formattedExpression = string.Empty;
        for (int i = 0; i < expression.Length; ++i)
        {
            if (expression[i] == ' ')
            {
                if (int.TryParse(expression[i - 1].ToString(), out int x))
                {
                    isNumber = true;
                }

                continue;
            }
            else if (char.IsLetter(expression[i]))
            {
                formattedExpression += $"`{expression[i]}";
                while (i + 1 < expression.Length && char.IsLetterOrDigit(expression[i + 1]))
                {
                    ++i;
                    formattedExpression += $"{expression[i]}";
                }

                formattedExpression += "`";
            }
            else if (isNumber == true && int.TryParse(expression[i].ToString(), out int x))
            {
                return string.Empty;
            }
            else
            {
                isNumber = false;
                formattedExpression += expression[i];
            }
        }

        return formattedExpression;
    }
}