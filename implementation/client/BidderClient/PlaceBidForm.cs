using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BidderClient.Shared;

namespace BidderClient
{
    public partial class PlaceBidForm : Form
    {
        private ClientModel itsModel;
        private ClientState itsState;
        private PlaceBidHandler placeBidHandler;
        public ClientObserver updateObserver { get; }
        public PlaceBidForm(ClientModel model, PlaceBidHandler placeBidHandler)
        {
            this.itsModel = model;
            this.itsState = ClientState.UNAUTENTIZED;
            this.placeBidHandler = placeBidHandler;
            this.updateObserver = this.update;
            this.Hide();
            InitializeComponent();

            update(this.itsState);
        }

        private void placeBidButton_Click(object sender, EventArgs e)
        {

        }

        private void update(ClientState newState)
        {
            this.itsState = newState;

            switch (this.itsState)
            {
                case ClientState.ALL_PRODUCTS_OFFERED:
                    this.productListView.Items.Clear();
                    foreach (var keyValuePair in this.itsModel.productsInventory)
                    {
                        Product product = keyValuePair.Value;
                        this.productListView.Items.Add(product.ClientToString());
                    }
                    this.Show();
                    break;

                case ClientState.PRODUCT_SELECTED:
                    break;

                case ClientState.BID_PLACED_OK:
                    break;

                case ClientState.BID_REJECTED:
                    break;
            }
        }

        private void productListView_click(object sender, EventArgs e)
        {
            int productID = getProductIDFromDescription(this.productListView.SelectedItems[0].Text);
            Product product = this.itsModel.productsInventory[productID];
            this.selectedProductName.Text = product.item.name;
            this.expirationDateLabel.Text = "1d, 4hrs, 25min left";
            this.bidNumberValue.Text = "( " + product.numberOfBids.ToString() + " bids )";
            this.minimalBidValueLabel.Text = product.currentHighestBid.value.ToString();
            if(product.productStatus == ProductStatus.ACTIVE)
            {
                this.statusColorField.BackColor = System.Drawing.SystemColors.HotTrack;
            }
            else
            {
                this.statusColorField.BackColor = System.Drawing.SystemColors.ControlDark;
            }
        }

        private int getProductIDFromDescription(string productDesc)
        {
            return Int32.Parse(productDesc.Substring(0, productDesc.IndexOf(')')));
        }
    }
}
