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
                    this.Show();

                    this.productListView.Items.Clear();
                    foreach (var keyValuePair in this.itsModel.productInventory)
                    {
                        Product product = keyValuePair;
                        this.productListView.Items.Add(product.ToString());
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
    }
}
