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
        private int productID;
        private DialogOKButtonHandler dialogOKButtonHandler;

        public ProductDialogWindow(
            string formHeader,
            int productID,
            DialogOKButtonHandler dialogOKButtonHandler)
        {
            InitializeComponent();
            this.Text = formHeader;
            this.productID = productID;
            if (productID != -1)
            {
                this.userInput1.Text = "New name for product with id = " + productID;
            } else
            {
                this.userInput1.Text = "";
            }
            
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
            
            dialogOKButtonHandler(productID, userInput1.Text, userInput2); 
            this.Close();
        }
    }
}
