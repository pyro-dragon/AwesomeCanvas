namespace AwesomeCanvas
{
    partial class LayerControlForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sidePannelSplitContainer = new System.Windows.Forms.SplitContainer();
            this.previewImageBox = new System.Windows.Forms.PictureBox();
            this.layerControlSplitContainer = new System.Windows.Forms.SplitContainer();
            this.deleteLayerButton = new System.Windows.Forms.Button();
            this.newLayerButton = new System.Windows.Forms.Button();
            this.LayerDisplayPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.sidePannelSplitContainer)).BeginInit();
            this.sidePannelSplitContainer.Panel1.SuspendLayout();
            this.sidePannelSplitContainer.Panel2.SuspendLayout();
            this.sidePannelSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerControlSplitContainer)).BeginInit();
            this.layerControlSplitContainer.Panel1.SuspendLayout();
            this.layerControlSplitContainer.Panel2.SuspendLayout();
            this.layerControlSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePannelSplitContainer
            // 
            this.sidePannelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidePannelSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.sidePannelSplitContainer.Name = "sidePannelSplitContainer";
            this.sidePannelSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sidePannelSplitContainer.Panel1
            // 
            this.sidePannelSplitContainer.Panel1.Controls.Add(this.previewImageBox);
            // 
            // sidePannelSplitContainer.Panel2
            // 
            this.sidePannelSplitContainer.Panel2.Controls.Add(this.layerControlSplitContainer);
            this.sidePannelSplitContainer.Size = new System.Drawing.Size(215, 351);
            this.sidePannelSplitContainer.SplitterDistance = 102;
            this.sidePannelSplitContainer.TabIndex = 0;
            // 
            // previewImageBox
            // 
            this.previewImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImageBox.Location = new System.Drawing.Point(0, 0);
            this.previewImageBox.Name = "previewImageBox";
            this.previewImageBox.Size = new System.Drawing.Size(215, 102);
            this.previewImageBox.TabIndex = 0;
            this.previewImageBox.TabStop = false;
            // 
            // layerControlSplitContainer
            // 
            this.layerControlSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerControlSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.layerControlSplitContainer.Name = "layerControlSplitContainer";
            this.layerControlSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // layerControlSplitContainer.Panel1
            // 
            this.layerControlSplitContainer.Panel1.AutoScroll = true;
            this.layerControlSplitContainer.Panel1.Controls.Add(this.LayerDisplayPanel);
            // 
            // layerControlSplitContainer.Panel2
            // 
            this.layerControlSplitContainer.Panel2.Controls.Add(this.deleteLayerButton);
            this.layerControlSplitContainer.Panel2.Controls.Add(this.newLayerButton);
            this.layerControlSplitContainer.Size = new System.Drawing.Size(215, 245);
            this.layerControlSplitContainer.SplitterDistance = 215;
            this.layerControlSplitContainer.TabIndex = 0;
            // 
            // deleteLayerButton
            // 
            this.deleteLayerButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteLayerButton.Location = new System.Drawing.Point(140, 0);
            this.deleteLayerButton.Name = "deleteLayerButton";
            this.deleteLayerButton.Size = new System.Drawing.Size(75, 26);
            this.deleteLayerButton.TabIndex = 1;
            this.deleteLayerButton.Text = "Delete Layer";
            this.deleteLayerButton.UseVisualStyleBackColor = true;
            // 
            // newLayerButton
            // 
            this.newLayerButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.newLayerButton.Location = new System.Drawing.Point(0, 0);
            this.newLayerButton.Name = "newLayerButton";
            this.newLayerButton.Size = new System.Drawing.Size(75, 26);
            this.newLayerButton.TabIndex = 0;
            this.newLayerButton.Text = "New Layer";
            this.newLayerButton.UseVisualStyleBackColor = true;
            this.newLayerButton.Click += new System.EventHandler(this.newLayerButton_Click);
            // 
            // LayerDisplayPanel
            // 
            this.LayerDisplayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LayerDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayerDisplayPanel.Location = new System.Drawing.Point(0, 0);
            this.LayerDisplayPanel.Name = "LayerDisplayPanel";
            this.LayerDisplayPanel.Size = new System.Drawing.Size(215, 215);
            this.LayerDisplayPanel.TabIndex = 0;
            // 
            // LayerControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sidePannelSplitContainer);
            this.Name = "LayerControlForm";
            this.Size = new System.Drawing.Size(215, 351);
            this.sidePannelSplitContainer.Panel1.ResumeLayout(false);
            this.sidePannelSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sidePannelSplitContainer)).EndInit();
            this.sidePannelSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).EndInit();
            this.layerControlSplitContainer.Panel1.ResumeLayout(false);
            this.layerControlSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerControlSplitContainer)).EndInit();
            this.layerControlSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sidePannelSplitContainer;
        private System.Windows.Forms.PictureBox previewImageBox;
        private System.Windows.Forms.SplitContainer layerControlSplitContainer;
        private System.Windows.Forms.Button deleteLayerButton;
        private System.Windows.Forms.Button newLayerButton;
        private System.Windows.Forms.FlowLayoutPanel LayerDisplayPanel;
    }
}
