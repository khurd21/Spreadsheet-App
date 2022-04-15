// <copyright file="SpreadsheetSaveLoad.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine;

using System.Xml.Linq;
using SpreadsheetEngine.Cells;
using System.Drawing;

/// <summary>
/// Initializes the <see cref="Spreadsheet"/> class which
/// focuses on saving and loading spreadsheets.
///
/// Ex. format of XML file.
/// <Spreadsheet>
///     <Cell>
///         <Name>A1</Name>
///         <Contents>1</Contents>
///         <Color>FF8000</Color>
///     </Cell>
/// </Spreadsheet>
/// </summary>
public partial class Spreadsheet
{
    /// <summary>
    /// Saves the current spreadsheet to a file.
    /// </summary>
    /// <param name="fileName">The name of the file for which to save.</param>
    public void Save(string fileName)
    {
        XDocument doc = new XDocument();
        XElement spreadsheet = new XElement("Spreadsheet");
        foreach (SpreadsheetCell cell in this.Cells)
        {
            if (cell.Text == string.Empty && cell.BackColor == SpreadsheetCell.DefaultBackColor)
            {
                continue;
            }

            XElement cellElement = new XElement("Cell");
            string cellName = this.GetCellNameFromIndex(cell.RowIndex, cell.ColumnIndex);
            cellElement.Add(new XElement("Name", cellName));
            if (cell.Text != string.Empty)
            {
                XElement textElement = new XElement("Contents", cell.Text);
                cellElement.Add(textElement);
            }

            if (cell.BackColor != SpreadsheetCell.DefaultBackColor)
            {
                XElement colorElement = new XElement("Color", cell.BackColor.ToArgb().ToString("X"));
                cellElement.Add(colorElement);
            }

            spreadsheet.Add(cellElement);
        }

        doc.Add(spreadsheet);
        doc.Save(fileName);
    }

    /// <summary>
    /// Loads a spreadsheet from a file.
    /// </summary>
    /// <param name="fileName">The name of the file for which to load.</param>
    public void Load(string fileName)
    {
        XDocument doc = XDocument.Load(fileName);

        // Parse the XML file and load the spreadsheet.
        // Parse all the elements inside the Spreadsheet element, and load them.
        XElement? spreadsheet = doc.Element("Spreadsheet");
        if (spreadsheet == null)
        {
            throw new SpreadsheetReadWriteException("Invalid XML file.");
        }

        // Get the Cell elements.
        this.ClearCells();
        this.UndoRedoManager.RedoStack.Clear();
        this.UndoRedoManager.UndoStack.Clear();
        IEnumerable<XElement> cells = spreadsheet.Elements("Cell");
        foreach (XElement cell in cells)
        {
            string? name = cell.Element("Name")?.Value;
            string? contents = cell.Element("Contents")?.Value;

            // Color need be a hex string (e.g. #FF8000).
            string? color = cell.Element("Color")?.Value;

            if (name == null)
            {
                continue;
            }

            // Create a new cell with the name and contents.
            SpreadsheetCell? refCell = (SpreadsheetCell?)this.GetCellFromName(name);
            if (refCell == null)
            {
                continue;
            }

            // Set the color of the cell.
            // Color is a hex string value. Need to convert it to a color object
            // before setting the color.
            if (color != null)
            {
                try
                {
                    int colorInt = int.Parse(color.Replace("#", string.Empty), System.Globalization.NumberStyles.HexNumber);
                    refCell.SetBackColor(Color.FromArgb(colorInt));
                }
                catch (Exception)
                {
                    // Do nothing. Input is invalid.
                }
            }

            // Set the text of the cell.
            if (contents != null)
            {
                refCell.Text = contents;
            }
        }

        return;
    }
}