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
    [Fact]
    [InlineData("42 68 0 32 12", 5)]
    [InlineData("42 68 0 32 12 12 68", 5)]
    [InlineData("", 0)]
    public void TestInsertListConstructor(string input, uint expected)
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
    [Fact]
    [InlineData("42 68", 42, false)]
    [InlineData("42 68", 0, true)]
    [InlineData("", 0, true)]
    public void TestInsertMethod(string input, uint insert, bool expected)
    {
        BinaryTree bst = new BinaryTree(input);
        Assert.Equal<bool>(expected, bst.Insert(insert));
    }
}