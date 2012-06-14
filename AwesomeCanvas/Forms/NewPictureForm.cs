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
    public partial class NewPictureForm : Form
    {
        public int canvasWidth;
        public int canvasHeight;
        public string canvasName;

        public NewPictureForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Check if the user entered valid input
            string exceptionText = "";

            if (!Int32.TryParse(widthBox.Text, out canvasWidth))
            {
                exceptionText += "\nWidth value is not valid. ";
            }

            if (!Int32.TryParse(heightBox.Text, out canvasHeight))
            {
                exceptionText += "\nHeight value is not valid. ";
            }

            if (nameBox.Text.Length <= 0)
            {
                exceptionText += "\nPicture must have a name. ";
            }
            else
            {
                canvasName = nameBox.Text;
            }

            // Check for exception text and show dialogue
            if (!exceptionText.Equals(""))
            {
                MessageBox.Show("Input was not valid: \n" + exceptionText);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void groupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
