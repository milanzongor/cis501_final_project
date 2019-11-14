using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidderServer.MVC.Views.DialogForms
{
    public partial class ProductDialogWindow : Form
    {
        private DialogOKButtonHandler dialogOKButtonHandler;

        public ProductDialogWindow(
            string formHeader, 
            string label1Text, 
            string userInput1Text,
            string label2Text,
            string userInput2Text,
            DialogOKButtonHandler dialogOKButtonHandler)
        {
            InitializeComponent();
            this.Text = formHeader;
            this.label1.Text = label1Text;
            this.userInput1.Text = userInput1Text;
            this.label2.Text = label2Text;
            this.userInput2.Text = userInput2Text;
            this.dialogOKButtonHandler = dialogOKButtonHandler;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            double userInput2;
            try
            {
                userInput2 = Double.Parse(this.userInput2.Text);
            } catch (Exception)
            {
                userInput2 = 10;
            }
            
            dialogOKButtonHandler(this.userInput1.Text, userInput2); 
            this.Close();
        }
    }
}
