using BidderClient.Shared;
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
        private Product product;
        private DialogOKButtonHandler dialogOKButtonHandler;

        public ProductDialogWindow(
            string formHeader,
            Product product,
            DialogOKButtonHandler dialogOKButtonHandler)
        {
            InitializeComponent();
            this.Text = formHeader;
            this.product = product;
            if (product != null)
            {
                this.userInput1.Text = product.item.name;
                this.userInput2.Text = product.item.startingBidPrice.ToString();
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
            
            if (product != null)
            {
                dialogOKButtonHandler(product.productID, userInput1.Text, userInput2);
            } else
            {
                dialogOKButtonHandler(-1, userInput1.Text, userInput2); // -1 won't be used
            }
            
            this.Close();
        }
    }
}
