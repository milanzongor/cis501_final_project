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
        private ProductListViewHandler handleProductListClick;
        public ClientObserver updateObserver { get; }
        public PlaceBidForm(ClientModel model, PlaceBidHandler placeBidHandler, ProductListViewHandler productListViewHandler)
        {
            this.itsModel = model;
            this.itsState = ClientState.UNAUTENTIZED;
            this.handleProductListClick = productListViewHandler;
            this.placeBidHandler = placeBidHandler;
            this.updateObserver = this.update;
            this.Hide();
            InitializeComponent();

            update(this.itsState);
        }

        private void placeBidButton_Click(object sender, EventArgs e)
        {
            int productID = getProductIDFromDescription(this.productListView.SelectedItems[0].Text);
            double price = -1.0;
            if (double.TryParse(biddingInput.Text, out price))
            {
                placeBidHandler(productID, price);
            }
            else
            {
                MessageBox.Show("Invalid bidding value (cannot be converted to double).");
            }
            
        }

        private void update(ClientState newState)
        {
            this.itsState = newState;

            switch (this.itsState)
            {
                case ClientState.ALL_PRODUCTS_OFFERED:
                    disableIfNothingIsSelected();
                    this.productListView.Items.Clear();
                    foreach (var keyValuePair in this.itsModel.productsInventory)
                    {
                        this.productListView.Items.Add(keyValuePair.Value.ClientToString());
                    }
                    this.Show();
                    break;

                case ClientState.PRODUCT_SELECTED:
                    enableIfAnythingSelected();
                    
                    int productID = getProductIDFromDescription(this.productListView.SelectedItems[0].Text);
                    Product product = this.itsModel.productsInventory[productID];

                    this.selectedProductNameLabel.Text = product.item.name;
                    this.expirationDateLabel.Text = "1d, 4hrs, 25min left";
                    this.bidNumberLabel.Text = "( " + product.numberOfBids.ToString() + " bids )";
                    double minBidValue;
                    if(product.currentHighestBid == null)
                    {
                        minBidValue = product.item.startingBidPrice;
                    }
                    else
                    {
                        minBidValue = product.currentHighestBid.value;
                    }
                    this.minimalBidValueLabel.Text = "Minimum bid $ " + minBidValue.ToString();
                    if (product.productStatus == ProductStatus.ACTIVE)
                    {
                        this.statusColorField.BackColor = System.Drawing.SystemColors.HotTrack;
                    }
                    else
                    {
                        this.statusColorField.BackColor = System.Drawing.SystemColors.ControlDark;
                    }
                    break;

                case ClientState.BID_PLACED_OK:
                    MessageBox.Show("Your bid was succesfully added.");
                    break;

                case ClientState.BID_REJECTED:
                    MessageBox.Show("Bid rejected - your bid must be higher that minimal bid value.");
                    break;
            }
        }

        private void productListView_click(object sender, EventArgs e)
        {
            int productID = getProductIDFromDescription(this.productListView.SelectedItems[0].Text);
            handleProductListClick(productID);
        }

        private int getProductIDFromDescription(string productDesc)
        {
            return Int32.Parse(productDesc.Substring(0, productDesc.IndexOf(')')));
        }

        private void disableIfNothingIsSelected()
        {
            this.selectedProductNameLabel.Visible = false;
            this.expirationDateLabel.Visible = false;
            this.statusLabel.Visible = false;
            this.statusColorField.Visible = false;
            this.biddingInput.Visible = false;
            this.bidNumberLabel.Visible = false;
            this.minimalBidValueLabel.Visible = false;

            this.placeBidButton.Enabled = false;
        }

        private void enableIfAnythingSelected()
        {
            this.selectedProductNameLabel.Visible = true;
            this.expirationDateLabel.Visible = true;
            this.statusLabel.Visible = true;
            this.statusColorField.Visible = true;
            this.biddingInput.Visible = true;
            this.bidNumberLabel.Visible = true;
            this.minimalBidValueLabel.Visible = true;

            this.placeBidButton.Enabled = true;
        }

        private void PlaceBidForm_Closing(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
