namespace AwesomeCanvas
{
    partial class LayerControl
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
            this.layerControlSplitContainer = new System.Windows.Forms.SplitContainer();
            this.previewImageBox = new System.Windows.Forms.PictureBox();
            this.layerNameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.layerControlSplitContainer)).BeginInit();
            this.layerControlSplitContainer.Panel1.SuspendLayout();
            this.layerControlSplitContainer.Panel2.SuspendLayout();
            this.layerControlSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // layerControlSplitContainer
            // 
            this.layerControlSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerControlSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.layerControlSplitContainer.Name = "layerControlSplitContainer";
            // 
            // layerControlSplitContainer.Panel1
            // 
            this.layerControlSplitContainer.Panel1.Controls.Add(this.previewImageBox);
            // 
            // layerControlSplitContainer.Panel2
            // 
            this.layerControlSplitContainer.Panel2.Controls.Add(this.layerNameBox);
            this.layerControlSplitContainer.Size = new System.Drawing.Size(200, 40);
            this.layerControlSplitContainer.SplitterDistance = 59;
            this.layerControlSplitContainer.TabIndex = 0;
            // 
            // previewImageBox
            // 
            this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImageBox.Location = new System.Drawing.Point(0, 0);
            this.previewImageBox.Name = "previewImageBox";
            this.previewImageBox.Size = new System.Drawing.Size(59, 40);
            this.previewImageBox.TabIndex = 0;
            this.previewImageBox.TabStop = false;
            // 
            // layerNameBox
            // 
            this.layerNameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.layerNameBox.BackColor = System.Drawing.SystemColors.Control;
            this.layerNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layerNameBox.Enabled = false;
            this.layerNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerNameBox.Location = new System.Drawing.Point(2, 11);
            this.layerNameBox.Name = "layerNameBox";
            this.layerNameBox.Size = new System.Drawing.Size(132, 19);
            this.layerNameBox.TabIndex = 0;
            this.layerNameBox.Text = "Name";
            this.layerNameBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.layerNameBox_KeyUp);
            this.layerNameBox.Leave += new System.EventHandler(this.layerNameBox_Leave);
            this.layerNameBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.layerNameBox_MouseDoubleClick);
            // 
            // LayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layerControlSplitContainer);
            this.Name = "LayerControl";
            this.Size = new System.Drawing.Size(200, 40);
            this.layerControlSplitContainer.Panel1.ResumeLayout(false);
            this.layerControlSplitContainer.Panel2.ResumeLayout(false);
            this.layerControlSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerControlSplitContainer)).EndInit();
            this.layerControlSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer layerControlSplitContainer;
        private System.Windows.Forms.PictureBox previewImageBox;
        private System.Windows.Forms.TextBox layerNameBox;
    }
}
