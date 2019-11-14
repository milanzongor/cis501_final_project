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

        public ProductDialogWindow(string formHeader, string labelText, string userInputText, DialogOKButtonHandler dialogOKButtonHandler)
        {
            InitializeComponent();
            this.Text = formHeader;
            this.label.Text = labelText;
            this.userInput.Text = userInputText;
            this.dialogOKButtonHandler = dialogOKButtonHandler;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            dialogOKButtonHandler(this.userInput.Text);
            this.Close();
        }
    }
}
