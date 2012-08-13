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
            
            //Application.AddMessageFilter(this);
            //this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);

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
            //TrackBar bar = this.toolStripTrackBarItem1.trackBar;
            SetCurrentCanvasSession(null);
            SetStatus("Welcome to " + Application.ProductName + " v" + Application.ProductVersion);
            this.Text = Application.ProductName;
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

                //when a canvas is selected we want to update the toolbars and such!
                newMDIChild.GotFocus += (object sender, EventArgs e) =>{
                    CanvasWindow cw = sender as CanvasWindow;
                    SetCurrentCanvasSession(cw.m_session);
                };

                //when a canvas is shut down we need to disable the toolbar if there are no other canvases left
                newMDIChild.HandleDestroyed += (object sender, EventArgs args) => {
                    if (m_currentCanvasSession != null && sender == m_currentCanvasSession.canvasWindow) {
                        SetCurrentCanvasSession(null);
                    }
                };

                //create a new canvas session to go with the canvasWindow
                CanvasSession newSession = new CanvasSession(this, newMDIChild, layerControlForm);
                m_canvasSessions.Add(newSession);
                SetCurrentCanvasSession(newSession);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveAsDialogue = new SaveFileDialog();
            saveAsDialogue.Filter = "Awsome Canvas Save|.awsomeSave";
            saveAsDialogue.FileOk += (object dialogue, CancelEventArgs arguments) => { 
                if (arguments.Cancel) { 
                    return; 
                } else {
                    m_currentCanvasSession.SaveCanvasToFile(((SaveFileDialog)dialogue).FileName);
                } 
            };
            saveAsDialogue.ShowDialog();
        }


        private void SetCurrentCanvasSession(CanvasSession pCanvasSession) {
            m_currentCanvasSession = pCanvasSession;
            if (m_currentCanvasSession == null) {
                toolPanelTop.Visible = false;
                panel1.Visible = false;
                panel1.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                viewToolStripMenuItem.Enabled = false;
                windowToolStripMenuItem.Enabled = false;
            }
            else {
                // Set up the workspace - the side pannel mostly
                // TODO: this stuff could probably be done in a seperate function that is called eveytime the canvas count changes. 
                toolPanelTop.Visible = true;
                panel1.Visible = true;
                panel1.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                viewToolStripMenuItem.Enabled = true;
                windowToolStripMenuItem.Enabled = true;
                // Set the picture as the focus of the side bar
                layerControlForm.SetCanvasSession(m_currentCanvasSession);
            }
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
        internal void SetStatus(string pString, int pProgress = -1) {
            if (pProgress == -1)
                toolStripProgressBar1.Visible = false;
            else
                toolStripProgressBar1.Value = pProgress;
            toolStripStatusLabel1.Text = pString;
            
        }
        private void pointerTools_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        /*
        protected override bool IsInputKey(Keys keyData) {
            return true;
        }
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e) {
            if (m_currentCanvasSession != null) {
                m_currentCanvasSession.canvasWindow.ProcessKeyDown(e.KeyData);

            }
        }

        Keys m_keysDown = Keys.None;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        public bool PreFilterMessage(ref Message m) {
            Keys inputKeys = (Keys)m.WParam;
            if (m.Msg == WM_KEYDOWN) {
                //Keys newKeysDown = inputKeys & ~m_keysDown;
                m_keysDown = inputKeys | m_keysDown;
                Console.WriteLine(" keys down " + m_keysDown);
                if (m_keysDown != Keys.None && m_currentCanvasSession != null) {
                    return m_currentCanvasSession.canvasWindow.ProcessKeyDown(m_keysDown);
                }
            } else if (m.Msg == WM_KEYUP) {
                Console.WriteLine(" keys up " + inputKeys);
                m_keysDown = m_keysDown & ~inputKeys;
                if (inputKeys != Keys.None && m_currentCanvasSession != null) {
                    return m_currentCanvasSession.canvasWindow.ProcessKeyUp(inputKeys);
                }
            }
            return false;
        }
        */
  
        protected override bool ProcessCmdKey(ref Message message, Keys keys) {
            if (m_currentCanvasSession != null) {
                return m_currentCanvasSession.canvasWindow.ProcessKeyDown(keys);
            }
            return base.ProcessCmdKey(ref message, keys);
        }


    }
}
