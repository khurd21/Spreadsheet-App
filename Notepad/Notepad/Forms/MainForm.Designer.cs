namespace Notepad.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.menuStripPrimary = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFibonacciNumbersfirst50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFibonacciNumbersfirst100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxPrimary = new System.Windows.Forms.TextBox();
            this.menuStripPrimary.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripPrimary
            // 
            this.menuStripPrimary.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStripPrimary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripPrimary.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrimary.Name = "menuStripPrimary";
            this.menuStripPrimary.Size = new System.Drawing.Size(940, 42);
            this.menuStripPrimary.TabIndex = 0;
            this.menuStripPrimary.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFromFileToolStripMenuItem,
            this.loadFibonacciNumbersfirst50ToolStripMenuItem,
            this.loadFibonacciNumbersfirst100ToolStripMenuItem,
            this.toolStripSeparator1,
            this.SaveFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // LoadFromFileToolStripMenuItem
            // 
            this.LoadFromFileToolStripMenuItem.Name = "LoadFromFileToolStripMenuItem";
            this.LoadFromFileToolStripMenuItem.Size = new System.Drawing.Size(529, 44);
            this.LoadFromFileToolStripMenuItem.Text = "Load from file....";
            this.LoadFromFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFromFileToolStripMenuItem_Click);
            // 
            // loadFibonacciNumbersfirst50ToolStripMenuItem
            // 
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.Name = "loadFibonacciNumbersfirst50ToolStripMenuItem";
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.Size = new System.Drawing.Size(529, 44);
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.Text = "Load fibonacci numbers (first 50)....";
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.Click += new System.EventHandler(this.LoadFibonacciNumbersfirst50ToolStripMenuItem_Click);
            // 
            // loadFibonacciNumbersfirst100ToolStripMenuItem
            // 
            this.loadFibonacciNumbersfirst100ToolStripMenuItem.Name = "loadFibonacciNumbersfirst100ToolStripMenuItem";
            this.loadFibonacciNumbersfirst100ToolStripMenuItem.Size = new System.Drawing.Size(529, 44);
            this.loadFibonacciNumbersfirst100ToolStripMenuItem.Text = "Load fibonacci numbers (first 100)....";
            this.loadFibonacciNumbersfirst100ToolStripMenuItem.Click += new System.EventHandler(this.LoadFibonacciNumbersfirst100ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(526, 6);
            // 
            // SaveFileToolStripMenuItem
            // 
            this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            this.SaveFileToolStripMenuItem.Size = new System.Drawing.Size(529, 44);
            this.SaveFileToolStripMenuItem.Text = "Save file....";
            this.SaveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
            // 
            // textBoxPrimary
            // 
            this.textBoxPrimary.Location = new System.Drawing.Point(13, 43);
            this.textBoxPrimary.Multiline = true;
            this.textBoxPrimary.Name = "textBoxPrimary";
            this.textBoxPrimary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPrimary.Size = new System.Drawing.Size(915, 831);
            this.textBoxPrimary.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 912);
            this.Controls.Add(this.textBoxPrimary);
            this.Controls.Add(this.menuStripPrimary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripPrimary;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStripPrimary.ResumeLayout(false);
            this.menuStripPrimary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private MenuStrip menuStripPrimary;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem LoadFromFileToolStripMenuItem;
    private ToolStripMenuItem loadFibonacciNumbersfirst50ToolStripMenuItem;
    private ToolStripMenuItem loadFibonacciNumbersfirst100ToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem SaveFileToolStripMenuItem;
    private TextBox textBoxPrimary;
}
