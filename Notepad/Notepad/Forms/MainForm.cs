// <copyright file="MainForm.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Notepad.Forms;

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
    }
}
