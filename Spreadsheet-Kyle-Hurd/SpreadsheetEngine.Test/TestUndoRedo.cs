// <copyright file="TestUndoRedo.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Test;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using SpreadsheetEngine.Commands;
using SpreadsheetEngine.Cells;

/// <summary>
/// Initializes the <see cref="TestUndoRedo"/> class for testing.
/// </summary>
public class TestUndoRedo
{
    /// <summary>
    /// The test cases for evaluating an expression with variables.
    /// </summary>
    private static readonly object[] CellsChanged =
    {
        new object[]
        {
            new List<SpreadsheetCell>
            {
                new SpreadsheetCell(1, 1),
                new SpreadsheetCell(2, 2),
            },
            "Cells Changed",
        },
    };

    /// <summary>
    /// Test cases for making sure the <see ref="UndoRedo.CanUndo"/>
    /// method works correctly.
    /// </summary>
    /// <param name="cells">The list of cells involved in the change.</param>
    /// <param name="command">The description of the command.</param>
    [Test]
    [TestCaseSource(nameof(CellsChanged))]
    public void TestCanUndoTrue(List<SpreadsheetCell> cells, string command)
    {
        UndoRedo undoRedo = new ();
        undoRedo.AddCommand(new MultipleCellCommand(cells, command));
        Assert.IsTrue(undoRedo.CanUndo());
    }

    /// <summary>
    /// Test cases for making sure the <see ref="UndoRedo.CanUndo"/>
    /// returns false if there is nothing to undo.
    /// </summary>
    [Test]
    public void TestCanUndoFalse()
    {
        UndoRedo undoRedo = new ();
        Assert.IsFalse(undoRedo.CanUndo());
    }

    /// <summary>
    /// Test cases for making sure the <see ref="UndoRedo.CanRedo"/>
    /// method works correctly. First undos the command, then asserts that
    /// it is able to redo the command.
    /// </summary>
    /// <param name="cells">The list of cells involved in the change.</param>
    /// <param name="command">The command description for the change.</param>
    [Test]
    [TestCaseSource(nameof(CellsChanged))]
    public void TestCanRedoTrue(List<SpreadsheetCell> cells, string command)
    {
        UndoRedo undoRedo = new ();
        undoRedo.RedoStack.Push(new MultipleCellCommand(cells, command));
        Assert.IsTrue(undoRedo.CanRedo());
    }

    /// <summary>
    /// Test cases for making sure the <see ref="UndoRedo.CanRedo"/>
    /// returns false if there is nothing to redo.
    /// </summary>
    [Test]
    public void TestCanRedoFalse()
    {
        UndoRedo undoRedo = new ();
        Assert.IsFalse(undoRedo.CanRedo());
    }

    /// <summary>
    /// Test cases for making sure the <see ref="UndoRedo.Clear"/>
    /// method clears both the undo and redo stacks.
    /// </summary>
    /// <param name="cells">The cells involved in the change.</param>
    /// <param name="command">The description of the change.</param>
    [Test]
    [TestCaseSource(nameof(CellsChanged))]
    public void TestClear(List<SpreadsheetCell> cells, string command)
    {
        UndoRedo undoRedo = new ();
        undoRedo.AddCommand(new MultipleCellCommand(cells, command));
        undoRedo.Clear();

        Console.WriteLine("Expected Both Stacks To Assert False -> ");
        Console.WriteLine($"Can Undo: {undoRedo.CanUndo()}");
        Console.WriteLine($"Can Redo: {undoRedo.CanRedo()}");

        Assert.IsFalse(undoRedo.CanUndo());
        Assert.IsFalse(undoRedo.CanRedo());
    }

    /// <summary>
    /// Test cases for making sure the <see ref="UndoRedo.Undo"/> method
    /// returns the correct list of cells.
    /// </summary>
    /// <param name="expected">The expected list of cells to get returned.</param>
    /// <param name="command">The description of the command.</param>
    [Test]
    [TestCaseSource(nameof(CellsChanged))]
    public void TestUndoNotNull(List<SpreadsheetCell> expected, string command)
    {
        UndoRedo undoRedo = new ();
        undoRedo.AddCommand(new MultipleCellCommand(expected, command));
        List<SpreadsheetCell>? actual = undoRedo.Undo();

        /**** For Viewing If Tests Fail ****/
        Console.WriteLine("Testing Undo Expected Following to Match: ");
        Console.WriteLine("Expected == Actual");
        Console.WriteLine($"Count: {expected.Count} == {actual?.Count}");
        for (int i = 0; i < expected.Count; i++)
        {
            Console.WriteLine($"{expected[i].BackColor} == {actual?[i].BackColor}");
            Console.WriteLine($"{expected[i].Text} == {actual?[i].Text}");
        }

        /**** Asertions ****/
        Assert.AreEqual(expected.Count, actual?.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.AreEqual(expected[i].BackColor, actual?[i].BackColor);
            Assert.AreEqual(expected[i].Text, actual?[i].Text);
        }
    }

    /// <summary>
    /// Test cases for making sure the <see ref="UndoRedo.Undo"/>
    /// returns null if there is nothing to undo.
    /// </summary>
    [Test]
    public void TestUndoNull()
    {
        UndoRedo undoRedo = new ();
        Assert.IsNull(undoRedo.Undo());
    }

    /// <summary>
    /// Tests for making sure the <see ref="UndoRedo.Redo"/> method
    /// returns the correct list of cells.
    /// </summary>
    /// <param name="expected">The expected list to be returned after executing redo.</param>
    /// <param name="command">The description of the change.</param>
    [Test]
    [TestCaseSource(nameof(CellsChanged))]
    public void TestRedoNotNull(List<SpreadsheetCell> expected, string command)
    {
        UndoRedo undoRedo = new ();
        undoRedo.RedoStack.Push(new MultipleCellCommand(expected, command));
        List<SpreadsheetCell>? actual = undoRedo.Redo();

        /**** For Viewing If Tests Fail ****/
        Console.WriteLine("Testing Redo Expected Following to Match: ");
        Console.WriteLine("Expected == Actual");
        Console.WriteLine($"Count: {expected.Count} == {actual?.Count}");
        for (int i = 0; i < expected.Count; i++)
        {
            Console.WriteLine($"{expected[i].BackColor} == {actual?[i].BackColor}");
            Console.WriteLine($"{expected[i].Text} == {actual?[i].Text}");
        }

        /**** Asertions ****/
        Assert.AreEqual(expected.Count, actual?.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.AreEqual(expected[i].BackColor, actual?[i].BackColor);
            Assert.AreEqual(expected[i].Text, actual?[i].Text);
        }
    }

    /// <summary>
    /// Test cases for making sure the <see ref="UndoRedo.Redo"/> method
    /// returns null if there is nothing to redo.
    /// </summary>
    [Test]
    public void TestRedoNull()
    {
        UndoRedo undoRedo = new ();
        Assert.IsNull(undoRedo.Redo());
    }
}