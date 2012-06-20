namespace AwesomeCanvas
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peviewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerWindowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.previewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pointerTools = new System.Windows.Forms.ToolStrip();
            this.pointerButton = new System.Windows.Forms.ToolStripButton();
            this.brushTools = new System.Windows.Forms.ToolStrip();
            this.pencilButton = new System.Windows.Forms.ToolStripButton();
            this.brushButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripNumericUpDownItem1 = new ToolStripNumericUpDownItem();
            this.toolStripTrackBarItem1 = new ToolStripTrackBarItem();
            this.toolPanelTop = new System.Windows.Forms.ToolStripPanel();
            this.toolPanelBottom = new System.Windows.Forms.ToolStripPanel();
            this.toolPanelLeft = new System.Windows.Forms.ToolStripPanel();
            this.toolPanelRight = new System.Windows.Forms.ToolStripPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            this.pointerTools.SuspendLayout();
            this.brushTools.SuspendLayout();
            this.toolPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageSizeToolStripMenuItem,
            this.imagePropertiesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // imageSizeToolStripMenuItem
            // 
            this.imageSizeToolStripMenuItem.Name = "imageSizeToolStripMenuItem";
            this.imageSizeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.imageSizeToolStripMenuItem.Text = "Image Size";
            // 
            // imagePropertiesToolStripMenuItem
            // 
            this.imagePropertiesToolStripMenuItem.Name = "imagePropertiesToolStripMenuItem";
            this.imagePropertiesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.imagePropertiesToolStripMenuItem.Text = "Image Properties";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layerWindowToolStripMenuItem,
            this.peviewWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // layerWindowToolStripMenuItem
            // 
            this.layerWindowToolStripMenuItem.Checked = true;
            this.layerWindowToolStripMenuItem.CheckOnClick = true;
            this.layerWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.layerWindowToolStripMenuItem.Name = "layerWindowToolStripMenuItem";
            this.layerWindowToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.layerWindowToolStripMenuItem.Text = "Paint Tools";
            // 
            // peviewWindowToolStripMenuItem
            // 
            this.peviewWindowToolStripMenuItem.Checked = true;
            this.peviewWindowToolStripMenuItem.CheckOnClick = true;
            this.peviewWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.peviewWindowToolStripMenuItem.Name = "peviewWindowToolStripMenuItem";
            this.peviewWindowToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.peviewWindowToolStripMenuItem.Text = "Selection Tools";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layerWindowToolStripMenuItem1,
            this.previewWindowToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // layerWindowToolStripMenuItem1
            // 
            this.layerWindowToolStripMenuItem1.Checked = true;
            this.layerWindowToolStripMenuItem1.CheckOnClick = true;
            this.layerWindowToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.layerWindowToolStripMenuItem1.Name = "layerWindowToolStripMenuItem1";
            this.layerWindowToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.layerWindowToolStripMenuItem1.Text = "Layer Window";
            // 
            // previewWindowToolStripMenuItem
            // 
            this.previewWindowToolStripMenuItem.Checked = true;
            this.previewWindowToolStripMenuItem.CheckOnClick = true;
            this.previewWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.previewWindowToolStripMenuItem.Name = "previewWindowToolStripMenuItem";
            this.previewWindowToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.previewWindowToolStripMenuItem.Text = "Preview Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(850, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pointerTools
            // 
            this.pointerTools.Dock = System.Windows.Forms.DockStyle.None;
            this.pointerTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerButton});
            this.pointerTools.Location = new System.Drawing.Point(6, 0);
            this.pointerTools.Name = "pointerTools";
            this.pointerTools.Size = new System.Drawing.Size(35, 25);
            this.pointerTools.TabIndex = 0;
            // 
            // pointerButton
            // 
            this.pointerButton.Checked = true;
            this.pointerButton.CheckOnClick = true;
            this.pointerButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
            this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerButton.Name = "pointerButton";
            this.pointerButton.Size = new System.Drawing.Size(23, 22);
            this.pointerButton.Text = "Pointer";
            this.pointerButton.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // brushTools
            // 
            this.brushTools.Dock = System.Windows.Forms.DockStyle.None;
            this.brushTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pencilButton,
            this.brushButton,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.toolStripNumericUpDownItem1,
            this.toolStripTrackBarItem1});
            this.brushTools.Location = new System.Drawing.Point(41, 0);
            this.brushTools.Name = "brushTools";
            this.brushTools.Size = new System.Drawing.Size(365, 26);
            this.brushTools.TabIndex = 1;
            // 
            // pencilButton
            // 
            this.pencilButton.CheckOnClick = true;
            this.pencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pencilButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilButton.Image")));
            this.pencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.Size = new System.Drawing.Size(23, 23);
            this.pencilButton.Text = "Pen";
            this.pencilButton.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // brushButton
            // 
            this.brushButton.CheckOnClick = true;
            this.brushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brushButton.Image = ((System.Drawing.Image)(resources.GetObject("brushButton.Image")));
            this.brushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brushButton.Name = "brushButton";
            this.brushButton.Size = new System.Drawing.Size(23, 23);
            this.brushButton.Text = "Brush";
            this.brushButton.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 23);
            this.toolStripLabel1.Text = "Tool Size: ";
            // 
            // toolStripNumericUpDownItem1
            // 
            this.toolStripNumericUpDownItem1.Name = "toolStripNumericUpDownItem1";
            this.toolStripNumericUpDownItem1.Size = new System.Drawing.Size(41, 23);
            this.toolStripNumericUpDownItem1.Text = "0";
            // 
            // toolStripTrackBarItem1
            // 
            this.toolStripTrackBarItem1.Name = "toolStripTrackBarItem1";
            this.toolStripTrackBarItem1.Size = new System.Drawing.Size(200, 23);
            this.toolStripTrackBarItem1.Text = "toolStripTrackBarItem1";
            // 
            // toolPanelTop
            // 
            this.toolPanelTop.Controls.Add(this.pointerTools);
            this.toolPanelTop.Controls.Add(this.brushTools);
            this.toolPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolPanelTop.Location = new System.Drawing.Point(0, 24);
            this.toolPanelTop.Name = "toolPanelTop";
            this.toolPanelTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolPanelTop.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolPanelTop.Size = new System.Drawing.Size(850, 26);
            this.toolPanelTop.Visible = false;
            // 
            // toolPanelBottom
            // 
            this.toolPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolPanelBottom.Location = new System.Drawing.Point(0, 540);
            this.toolPanelBottom.Name = "toolPanelBottom";
            this.toolPanelBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolPanelBottom.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolPanelBottom.Size = new System.Drawing.Size(850, 0);
            // 
            // toolPanelLeft
            // 
            this.toolPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolPanelLeft.Location = new System.Drawing.Point(0, 24);
            this.toolPanelLeft.Name = "toolPanelLeft";
            this.toolPanelLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.toolPanelLeft.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolPanelLeft.Size = new System.Drawing.Size(0, 516);
            // 
            // toolPanelRight
            // 
            this.toolPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolPanelRight.Location = new System.Drawing.Point(850, 24);
            this.toolPanelRight.Name = "toolPanelRight";
            this.toolPanelRight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.toolPanelRight.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolPanelRight.Size = new System.Drawing.Size(0, 516);
            // 
            // toolStrip
            // 
            this.toolStrip.AllowDrop = true;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Location = new System.Drawing.Point(3, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(111, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Visible = false;
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 562);
            this.Controls.Add(this.toolPanelTop);
            this.Controls.Add(this.toolPanelBottom);
            this.Controls.Add(this.toolPanelLeft);
            this.Controls.Add(this.toolPanelRight);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Awesome Canvas 3";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pointerTools.ResumeLayout(false);
            this.pointerTools.PerformLayout();
            this.brushTools.ResumeLayout(false);
            this.brushTools.PerformLayout();
            this.toolPanelTop.ResumeLayout(false);
            this.toolPanelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagePropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layerWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peviewWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layerWindowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem previewWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip pointerTools;
        private System.Windows.Forms.ToolStrip brushTools;
        private System.Windows.Forms.ToolStripButton pointerButton;
        private System.Windows.Forms.ToolStripButton pencilButton;
        private System.Windows.Forms.ToolStripButton brushButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ToolStripNumericUpDownItem toolStripNumericUpDownItem1;
        private ToolStripTrackBarItem toolStripTrackBarItem1;
        private System.Windows.Forms.ToolStripPanel toolPanelTop;
        private System.Windows.Forms.ToolStripPanel toolPanelBottom;
        private System.Windows.Forms.ToolStripPanel toolPanelLeft;
        private System.Windows.Forms.ToolStripPanel toolPanelRight;
        private System.Windows.Forms.ToolStrip toolStrip;
    }
}

