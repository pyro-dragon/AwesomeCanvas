using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AwesomeCanvas
{
    public delegate void GUIToolChange(ToolStripButton name);
    public delegate void GUINewPictureCreated(CanvasWindow window);

    //-------------------------------------------------------------------------
    // The main application form. 
    //-------------------------------------------------------------------------
    public partial class MainForm : Form
    {
        // Member variables
        private List<CanvasSession> m_canvasSessions = new List<CanvasSession>();
        private CanvasSession m_currentCanvasSession;
        private ToolStripButton m_activeToolButton;  // The currently active tool button
        public GUIToolChange OnGUIToolChanged;        
        // Constructor
        public MainForm()
        {
            InitializeComponent();

            // Allow this form to hold sub-windows
            this.IsMdiContainer = true;

            // Initialise the application core
            // TODO: Make this a Singlton
            this.toolStripTrackBarItem1.trackBar.ValueChanged += OnGUISizeChanged;
            this.toolStripNumericUpDownItem1.numericUpDown.ValueChanged += OnGUISizeChanged;
            this.m_activeToolButton = this.pointerButton; 
            NumericUpDown number = this.toolStripNumericUpDownItem1.numericUpDown;
            number.Value = 17;
   
        }

        //---------------------------------------------------------------------
        // The function for when the New menu item is clicked
        //---------------------------------------------------------------------
        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            // Launch the New Picture funtion
            CreateNewPicture();
        }
        //---------------------------------------------------------------------
        // Create a new picture and window
        //---------------------------------------------------------------------
        public void CreateNewPicture() {
            // Launch a dialogue to ask the user for the properties of the new picture
            NewPictureForm newPictureForm = new NewPictureForm();
            newPictureForm.Owner = this;
            newPictureForm.ShowDialog();

            // Check if the user hit OK or Cancel
            if (newPictureForm.DialogResult == DialogResult.OK) {
                // Create a new form to hold the picture
                CanvasWindow newMDIChild = new CanvasWindow(newPictureForm.canvasWidth, newPictureForm.canvasHeight, newPictureForm.canvasName);

                // Set the parent form the main form
                newMDIChild.MdiParent = this;

                // Make the form visible
                newMDIChild.Show();

                // Put the form on top of the others
                newMDIChild.BringToFront();

                newMDIChild.GotFocus += OnCanvasWindowGotFocus;

                // Add new picture to the base application
                SetCurrentCanvasSession(new CanvasSession(this, newMDIChild));
                m_canvasSessions.Add(m_currentCanvasSession);

                toolPanelTop.Visible = true;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (m_currentCanvasSession != null) {
                return m_currentCanvasSession.GuiInput_KeyDown(keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Swap Active Canvas Session
        /// </summary>
        private void OnCanvasWindowGotFocus(object sender, EventArgs e) {
  //          Console.WriteLine("Canvas Got Focus!");
            CanvasWindow cw = sender as CanvasWindow;
            SetCurrentCanvasSession(cw.m_session);
        }

        private void SetCurrentCanvasSession(CanvasSession pCanvasSession) {
            m_currentCanvasSession = pCanvasSession;
            m_currentCanvasSession.OnFocus();
        }
        //---------------------------------------------------------------------
        ///  Deactivate the current tool and activate the new tool
        //---------------------------------------------------------------------
        private void SwitchToolButton(ToolStripButton sender)
        {
            m_activeToolButton.Checked = false;
        }

        //---------------------------------------------------------------------
        // The function for when tool size changes in the GUI
        //---------------------------------------------------------------------
        private void OnGUISizeChanged(object sender, EventArgs e) {
            TrackBar bar = this.toolStripTrackBarItem1.trackBar;
            NumericUpDown number = this.toolStripNumericUpDownItem1.numericUpDown;
            if (sender == bar && bar.Value != (int)number.Value) {
                number.Value = bar.Value;
            }
            if (sender == number && bar.Value != number.Value) {
                bar.Value = Math.Max(0, Math.Min((int)number.Value, bar.Maximum));
            }
        }
        
        //---------------------------------------------------------------------
        // Bush tool button was clicked
        //---------------------------------------------------------------------
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            m_activeToolButton.Checked = false;
            m_activeToolButton = (ToolStripButton)sender;
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }
        internal string GetToolName() {
            return m_activeToolButton.Text.ToLower();
        }

        private int GetToolSize() {
            return (int)this.toolStripNumericUpDownItem1.numericUpDown.Value;
        }
        /// later we will collect information from diffrent option forms (color wheel, brush options etc)
        internal BrushTool.Options GetBrushOptions() {
            return new BrushTool.Options {
                color = Color.Linen,
                size = GetToolSize(),
                pressureSensitive = false
            };
        }
        /// later we will collect information from diffrent option forms (color wheel, pen options etc)
        internal PenTool.Options GetPenOptions() {
            return new PenTool.Options {
                color = Color.OrangeRed,
                size = GetToolSize()
            };
        }

        internal int GetCurrentLayer() {
            return 0;
        }
    }
}
