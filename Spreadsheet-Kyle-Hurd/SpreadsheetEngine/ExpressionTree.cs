// <copyright file="ExpressionTree.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

/// <summary>
/// Initializes the <see cref="ExpressionTree"/> class.
/// </summary>
public class ExpressionTree
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
    /// Constructs an expression tree from the given expression.
    /// </summary>
    /// <param name="expression">The expression to be created.</param>
    /// <exception cref="ArgumentException">Thrown when the expression is invalid.</exception>
    public ExpressionTree(string expression)
    {
        List<char> keys = Nodes.NodeFactory.GetOperators();
        if (ExpressionValidator.IsExpression(expression, keys))
        {
            this.Expression = expression.ToLower();
            this.PostFixTokens = BuildPostFixTokens(this.Expression);
            this.Root = CreateTree(this.PostFixTokens);
        }
        else
        {
            throw new ArgumentException("Invalid expression given to ExpressionTree.");
        }
    }

    /// <summary>
    /// Gets the expression to represent the tree.
    /// </summary>
    public string Expression { get; }

    /// <summary>
    /// Gets or sets the root of the tree.
    /// </summary>
    private Nodes.Node<double> Root { get; set; }

    /// <summary>
    /// Gets the post fix tokens that represent the tree.
    /// </summary>
    private List<string> PostFixTokens { get; }

    /// <summary>
    /// Evaluates the expression tree.
    /// </summary>
    /// <returns>The result of the evalutated tree.</returns>
    public double Evaluate()
    {
        try
        {
            return this.Root.Evaluate();
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Evaluating expression tree:\n\t{e.Message}", e);
        }
    }

    /// <summary>
    /// Sets a variable in the expression tree.
    /// </summary>
    /// <param name="variable">The variable to set in the expression.</param>
    /// <param name="value">The value to set the variable to.</param>
    public void SetVariableValue(string variable, double value)
    {
        variable = variable.ToLower();
        SetVariableNodes(variable, value, this.Root);
    }

    /// <summary>
    /// Creates the expression tree from the given postfix expression
    /// represented as a list of tokens. Must be a valid expression before
    /// calling this method.
    /// </summary>
    /// <param name="tokens">The list of tokens to create the tree from.</param>
    /// <returns>The root of the tree.</returns>
    private static Nodes.Node<double> CreateTree(List<string> tokens)
    {
        Stack<Nodes.Node<double>> postfixStack = new Stack<Nodes.Node<double>>();

        // Stack<Nodes.OperatorNode> operatorStack = new Stack<Nodes.OperatorNode>();
        foreach (string token in tokens)
        {
            Nodes.Node<double>? node = Nodes.NodeFactory.CreateNode(token);
            /*if (node != null)
            {
                if (node is Nodes.OperatorNode)
                {
                    Nodes.OperatorNode opNode = (node as Nodes.OperatorNode) !;
                    while (operatorStack.Count > 0 && operatorStack.Peek().Precedence >= opNode.Precedence)
                    {
                        postfixStack.Push(operatorStack.Pop());
                    }

                    operatorStack.Push(opNode);
                }
                else
                {
                    postfixStack.Push(node);
                }
            }*/

            // Prev implementation
            if (node != null && node is Nodes.OperatorNode)
            {
                Nodes.OperatorNode? opNode = node as Nodes.OperatorNode;
                opNode!.Right = postfixStack.Pop();
                opNode!.Left = postfixStack.Pop();
                postfixStack.Push(opNode);
            }
            else if (node != null)
            {
                postfixStack.Push(node);
            }
        }

        return postfixStack.Peek();
    }

    /// <summary>
    /// Builds the post fix tokens to be used to construct the tree.
    /// Currently only supports numbers and variables and operators.
    /// Parantheses are not supported.
    /// </summary>
    /// <param name="expression">The expression to parse. Must be a valid expression.</param>
    /// <returns>A list of tokens in post fix order.</returns>
    /// <exception cref="ArgumentException">Thrown when an operator in expression is invalid.</exception>
    private static List<string> BuildPostFixTokens(string expression)
    {
        Stack<string> stack = new Stack<string>();
        List<string> tokens = new List<string>();

        for (int i = 0; i < expression.Length; ++i)
        {
            char c = expression[i];
            if (char.IsDigit(c))
            {
                string number = string.Empty;
                while (i < expression.Length && (char.IsDigit(c = expression[i]) || expression[i] == '.'))
                {
                    number += c;
                    ++i;
                }

                --i; // Due to the for loop incrementing i.
                tokens.Add(number);
            }
            else if (char.IsLetter(c))
            {
                string variable = string.Empty;
                while (i < expression.Length && char.IsLetterOrDigit(c = expression[i]))
                {
                    variable += c;
                    ++i;
                }

                --i; // Due to `i++` in the for loop.
                tokens.Add(variable);
            }
            else if (Nodes.NodeFactory.GetOperators().Contains(c))
            {
                Nodes.Node<double>? node = Nodes.NodeFactory.CreateNode(c.ToString());
                if (node != null)
                {
                    while (stack.Count > 0)
                    {
                        var top = stack.Pop();
                        tokens.Add(top);
                    }

                    stack.Push(c.ToString());
                }
                else
                {
                    throw new ArgumentException($"Invalid expression given to ExpressionTree. Could not create node `{c}`.");
                }
            }
        }

        while (stack.Count > 0)
        {
            tokens.Add(stack.Pop());
        }

        return tokens;
    }

    /// <summary>
    /// Finds the Node with the given name.
    /// </summary>
    /// <param name="variable">The variable name for which to search.</param>
    /// <param name="value">The value to set variable to in tree.</param>
    /// <param name="node">The current node method is at during its traversal.</param>
    private static void SetVariableNodes(string variable, double value, Nodes.Node<double>? node)
    {
        if (node == null)
        {
            return;
        }

        if (node is Nodes.VariableNode variableNode)
        {
            if (variableNode.Variable == variable)
            {
                variableNode.Value = value;
            }
        }

        if (node is Nodes.OperatorNode operatorNode)
        {
            SetVariableNodes(variable, value, operatorNode.Left);
            SetVariableNodes(variable, value, operatorNode.Right);
        }
    }
}