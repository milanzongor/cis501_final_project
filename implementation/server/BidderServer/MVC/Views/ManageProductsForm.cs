using BidderServer.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidderServer
{
    public partial class ManageProductsForm : Form
    {
        private ServerState itsState;
        private ServerModel itsModel;
        private AddProductHandler addProductHandler;
        private RemoveProductHandler removeProductHandler;
        private ModifyProductHandler modifyProductHandler;
        private StartProductAuctionHandler startProductAuctionHandler;
        private StopProductAuctionHandler stopProductAuctionHandler;
        private ProductsFormClosedHandler productsFormClosedHandler;
        public ServerObserver updateObserver { get; }

        public ManageProductsForm(
            ServerModel model,
            AddProductHandler addProductHandler,
            RemoveProductHandler removeProductHandler,
            ModifyProductHandler modifyProductHandler,
            StartProductAuctionHandler startProductAuctionHandler,
            StopProductAuctionHandler stopProductAuctionHandler,
            ProductsFormClosedHandler productsFormClosedHandler
            )
        {
            this.itsModel = model;
            this.itsState = ServerState.MONITORING_STATE;
            this.updateObserver = this.update;
            this.addProductHandler = addProductHandler;
            this.removeProductHandler = removeProductHandler;
            this.modifyProductHandler = modifyProductHandler;
            this.startProductAuctionHandler = startProductAuctionHandler;
            this.stopProductAuctionHandler = stopProductAuctionHandler;
            this.productsFormClosedHandler = productsFormClosedHandler;

            InitializeComponent();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
        }

        private void RemoveProductButton_Click(object sender, EventArgs e)
        {

        }

        private void ModifyProductButton_Click(object sender, EventArgs e)
        {

        }

        private void StartProductAuction_Click(object sender, EventArgs e)
        {

        }

        private void StopProductAuction_Click(object sender, EventArgs e)
        {

        }

        private void update(ServerState newState)
        {
            this.itsState = newState;

            if (itsState == ServerState.MANAGING_PRODUCTS || itsState == ServerState.PRODUCT_ADDED_SUCCESSFULLY || itsState == ServerState.DUPLICATE_PRODUCT_NOT_ADDED)
            {
                this.Show();
            } else
            {
                this.Hide();
            }
        }

        private void ManageProductsForm_Closing(object sender, FormClosingEventArgs e)
        {
            productsFormClosedHandler();
            e.Cancel = true; // prevents form disposure
        }
    }
}
