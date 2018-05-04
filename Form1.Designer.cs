namespace BiblioRenamer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteOriginalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNameFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(749, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(749, 544);
            this.listBox1.TabIndex = 1;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.importToolStripMenuItem.Text = "&Import RefWorks Tagged";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteOriginalFileToolStripMenuItem,
            this.removeNameFromListToolStripMenuItem,
            this.copyToDirToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // deleteOriginalFileToolStripMenuItem
            // 
            this.deleteOriginalFileToolStripMenuItem.Name = "deleteOriginalFileToolStripMenuItem";
            this.deleteOriginalFileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.deleteOriginalFileToolStripMenuItem.Text = "&Delete original file";
            this.deleteOriginalFileToolStripMenuItem.Click += new System.EventHandler(this.deleteOriginalFileToolStripMenuItem_Click);
            // 
            // removeNameFromListToolStripMenuItem
            // 
            this.removeNameFromListToolStripMenuItem.Name = "removeNameFromListToolStripMenuItem";
            this.removeNameFromListToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.removeNameFromListToolStripMenuItem.Text = "&Remove name from list";
            this.removeNameFromListToolStripMenuItem.Click += new System.EventHandler(this.removeNameFromListToolStripMenuItem_Click);
            // 
            // copyToDirToolStripMenuItem
            // 
            this.copyToDirToolStripMenuItem.Name = "copyToDirToolStripMenuItem";
            this.copyToDirToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyToDirToolStripMenuItem.Text = "&Copy to dir";
            this.copyToDirToolStripMenuItem.Click += new System.EventHandler(this.copyToDirToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 568);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Bibliography File Renamer ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteOriginalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNameFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToDirToolStripMenuItem;
    }
}

