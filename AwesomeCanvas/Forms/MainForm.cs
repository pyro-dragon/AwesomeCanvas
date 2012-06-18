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
        private BaseApp m_baseApp;          // A pointer to the base application
        private ToolStripButton m_activeToolButton;  // The currently active tool button
        
        public event GUIToolChange OnGUIToolChanged;
        public event GUINewPictureCreated OnGUINewPicture;

        // Constructor
        public MainForm()
        {
            InitializeComponent();

            // Allow this form to hold sub-windows
            this.IsMdiContainer = true;

            // Initialise the application core
            // TODO: Make this a Singlton
            m_baseApp = new BaseApp(this);

            // Associeate a handler for the New Picture event
            //m_baseApp.NewPictureEv += new NewPictureDel(NewPic);

            m_activeToolButton = this.pointerButton;
        }

        //---------------------------------------------------------------------
        // Create a new picture and window
        //---------------------------------------------------------------------
        public void CreateNewPicture()
        {
            // Launch a dialogue to ask the user for the properties of the new picture
            NewPictureForm newPictureForm = new NewPictureForm();
            newPictureForm.Owner = this;
            newPictureForm.ShowDialog();

            // Check if the user hit OK or Cancel
            if (newPictureForm.DialogResult == DialogResult.OK)
            {
                // Create a new form to hold the picture
                CanvasWindow newMDIChild = new CanvasWindow(m_baseApp, newPictureForm.canvasWidth, newPictureForm.canvasHeight, newPictureForm.canvasName);

                // Set the parent form the main form
                newMDIChild.MdiParent = this;

                // Make the form visible
                newMDIChild.Show();

                // Put the form on top of the others
                newMDIChild.BringToFront();

                // Add new picture to the base application
                m_baseApp.AddPicture(newMDIChild.GetPicture());

                // Prepare the tool bar
                toolPanelTop.Visible = true;

                // Tell everything about the new picture
                OnGUINewPicture(newMDIChild);
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
        // The function for when the New menu item is clicked
        //---------------------------------------------------------------------
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Launch the New Picture funtion
            CreateNewPicture();
        }

        //---------------------------------------------------------------------
        // Bush tool button was clicked
        //---------------------------------------------------------------------
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            m_activeToolButton.Checked = false;
            m_activeToolButton = (ToolStripButton)sender;

            // Send tool change event
            OnGUIToolChanged((ToolStripButton)sender);
        }
    }
}
