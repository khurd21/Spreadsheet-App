// <copyright file="MainForm.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Notepad.Forms;

using System.Windows.Forms;
using Notepad.TextReader;
using System.IO;

/// <summary>
/// Initializes the <see cref="MainForm"/> class.
/// </summary>
public partial class MainForm : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    public MainForm()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Takes a TextReader and delivers its output to the primary text box.
    /// </summary>
    /// <param name="sr">The TextReader object.</param>
    private void LoadText(TextReader sr)
    {
        this.textBoxPrimary.Text = sr.ReadToEnd();
        sr.Close();
    }

    /// <summary>
    /// The event handler for the selection to load first 50 fibonacci numbers.
    /// </summary>
    /// <param name="sender">The object calling this method.</param>
    /// <param name="e">The event arguments.</param>
    private void LoadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.LoadText(new FibonacciTextReader(50));
    }

    /// <summary>
    /// The event handler for the selection to load first 100 fibonacci numbers.
    /// </summary>
    /// <param name="sender">The object calling this method.</param>
    /// <param name="e">The event arguments.</param>
    private void LoadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.LoadText(new FibonacciTextReader(100));
    }

    /// <summary>
    /// The event handler to load a new file to the primary text box.
    /// </summary>
    /// <param name="sender">The object calling this method.</param>
    /// <param name="e">The event arguments.</param>
    private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        openFileDialog.FilterIndex = 1;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.LoadText(new StreamReader(openFileDialog.FileName));
        }
    }

    /// <summary>
    /// The event handler to save the primary text box to a file.
    /// </summary>
    /// <param name="sender">The object calling this method.</param>
    /// <param name="e">The event arguments.</param>
    private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Stream myStream;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        saveFileDialog.FilterIndex = 2;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            if ((myStream = saveFileDialog.OpenFile()) != null)
            {
                StreamWriter sw = new StreamWriter(myStream);
                sw.Write(this.textBoxPrimary.Text);
                sw.Close();
                myStream.Close();
            }
        }
    }
}
