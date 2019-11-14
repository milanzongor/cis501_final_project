﻿using BidderClient.Shared;
using BidderServer.MVC;
using BidderServer.MVC.Views.DialogForms;
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
            this.update(itsState);
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            ProductDialogWindow productDialogWindow = new ProductDialogWindow(
                "Add Product Form", 
                "Enter new product name:",
                "",
                this.handleDialogOKButtonWhenAddingProduct);

            productDialogWindow.ShowDialog();
        }

        private void handleDialogOKButtonWhenAddingProduct(string userInput)
        {
            addProductHandler(userInput);
        }

        private void RemoveProductButton_Click(object sender, EventArgs e)
        {
            removeProductHandler(getProductIDFromDescription(this.productsList.SelectedItems[0].Text));
        }

        private void handleDialogOKButtonWhenModifyingProduct(string userInput)
        {

        }

        private void ModifyProductButton_Click(object sender, EventArgs e)
        {
            ProductDialogWindow productDialogWindow = new ProductDialogWindow(
                "Add Product Form",
                "Enter new product name:",
                "TODO",
            this.handleDialogOKButtonWhenModifyingProduct);

            productDialogWindow.ShowDialog();
        }

        private void StartProductAuction_Click(object sender, EventArgs e)
        {
            startProductAuctionHandler(getProductIDFromDescription(this.productsList.SelectedItems[0].Text));
        }

        private void StopProductAuction_Click(object sender, EventArgs e)
        {
            stopProductAuctionHandler(getProductIDFromDescription(this.productsList.SelectedItems[0].Text));
        }

        private int getProductIDFromDescription(string productDesc)
        {
            return Int32.Parse(productDesc.Substring(0, productDesc.IndexOf(')')));
        }

        private void update(ServerState newState)
        {
            this.itsState = newState;

            if (itsState == ServerState.MANAGING_PRODUCTS || itsState == ServerState.PRODUCT_ADDED_SUCCESSFULLY || itsState == ServerState.DUPLICATE_PRODUCT_NOT_ADDED)
            {
                this.Show();

                this.productsList.Items.Clear();
                foreach (var keyValuePair in this.itsModel.productsInventory)
                {
                    Product product = keyValuePair.Value;
                    this.productsList.Items.Add(product.productID + ") " + product.item.name + " - " + product.productStatus);
                }
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

        private void ManageProductsForm_VisibleChanged(object sender, EventArgs e)
        {
            this.removeProductButton.Enabled = false;
            this.modifyProductButton.Enabled = false;
            this.startProductAuction.Enabled = false;
            this.stopProductAuction.Enabled = false;
        }

        private void ProductsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.removeProductButton.Enabled = true;
            this.modifyProductButton.Enabled = true;
            this.startProductAuction.Enabled = true;
            this.stopProductAuction.Enabled = true;
        }
    }
}
