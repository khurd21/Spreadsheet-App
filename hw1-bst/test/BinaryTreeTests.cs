using System;
using System.IO;
using Xunit;
using BST;


namespace test;

/// <summary>
/// Unit tests for BinaryTree Class.
/// </summary>
public class BinaryTreeTests
{
    /// <summary>
    /// Tests the <c>BinaryTree</c> constructor insertion.
    /// Three different cases are provided that test basic insertion,
    /// insertion of duplicate values, and insertion of an empty tree.
    /// </summary>
    [Theory]
    [InlineData("42 68 0 32 12", 5)]
    [InlineData("42 68 0 32 12 12 68", 5)]
    [InlineData("", 0)]
    public void TestNumItems(string input, uint expected)
    {
        BinaryTree bst = new BinaryTree(input);
        Assert.Equal<uint>(expected, bst.numItems);
    }

    /// <summary>
    /// Tests the <c>Insert</c> method for the <c>BinaryTree</c> class.
    /// Three different cases are provided that test basic insertion,
    /// insertion of duplicate values, insertion of non-duplicate values,
    /// and insertion of an empty tree.
    /// </summary>
    [Theory]
    [InlineData("42 68", 42, false)]
    [InlineData("42 68", 0, true)]
    [InlineData("", 0, true)]
    public void TestInsertMethod(string input, uint insert, bool expected)
    {
        BinaryTree bst = new BinaryTree(input);
        Assert.Equal<bool>(expected, bst.Insert(insert));
    }

    /// <summary>
    /// Tests the <c>inorderTraversal</c> method for the <c>BinaryTree</c> class.
    /// </summary>
    [Theory]
    [InlineData("42 68 0 32 12", "0 12 32 42 68 \r\n")]
    [InlineData("42 68 0 32 12 12 68", "0 12 32 42 68 \r\n")]
    [InlineData("0 1 2 3 4", "0 1 2 3 4 \r\n")]
    [InlineData("", "Empty tree\r\n")]
    public void TestInorderTraversal(string input, string expected)
    {
        BinaryTree bst = new BinaryTree(input);
        var stringWriter = new StringWriter();

        Console.SetOut(stringWriter);
        bst.inorderTraversal();

        Assert.Equal(expected, stringWriter.ToString());
    }

    /// <summary>
    /// Tests the <c>getNumLevels</c> method for the <c>BinaryTree</c> class.
    /// </summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData("9", 1)]
    [InlineData("42 68 0 32 12", 4)]
    [InlineData("4 68 0 1 2 3 54", 5)]
    [InlineData("1 2 3 4 5 6 7 8 9", 9)]
    public void TestGetNumLevels(string input, uint expected)
    {
        BinaryTree bst = new BinaryTree(input);
        Assert.Equal<uint>(expected, bst.getNumLevels());
    }

    /// <summary>
    /// Tests the <c>theoreticalHeight</c> method for the <c>BinaryTree</c> class.
    /// </summary>
    [Theory]
    [InlineData("", 0)]
    [InlineData("4", 1)]
    [InlineData("42 68 0 32 12", 2)]
    [InlineData("1 2 3 4 5 6 7 8 9", 3)]
    public void TestTheoreticalHeight(string input, uint expected)
    {
        BinaryTree bst = new BinaryTree(input);
        Assert.Equal<uint>(expected, bst.theoreticalHeight());
    }
}