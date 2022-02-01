namespace Unique;

partial class UniqueForm
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
            this.primaryTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // primaryTextBox
            // 
            this.primaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primaryTextBox.Location = new System.Drawing.Point(0, 0);
            this.primaryTextBox.Name = "primaryTextBox";
            this.primaryTextBox.Size = new System.Drawing.Size(800, 450);
            this.primaryTextBox.TabIndex = 0;
            this.primaryTextBox.Text = "";
            this.primaryTextBox.ReadOnly = true;
            // 
            // UniqueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.primaryTextBox);
            this.Name = "UniqueForm";
            this.Text = "Kyle Hurd - 11684695";
            this.ResumeLayout(false);

    }

    #endregion

    private RichTextBox primaryTextBox;
}
