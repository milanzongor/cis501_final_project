﻿using BidderServer.MVC;
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
        public ServerObserver updateDelegate { get; }

        public ManageProductsForm(
            ServerModel model,
            AddProductHandler addProductHandler,
            RemoveProductHandler removeProductHandler,
            ModifyProductHandler modifyProductHandler,
            StartProductAuctionHandler startProductAuctionHandler,
            StopProductAuctionHandler stopProductAuctionHandler
            )
        {
            this.itsModel = model;
            this.itsState = ServerState.MONITORING_STATE;
            this.updateDelegate = this.update;
            this.addProductHandler = addProductHandler;
            this.removeProductHandler = removeProductHandler;
            this.modifyProductHandler = modifyProductHandler;
            this.startProductAuctionHandler = startProductAuctionHandler;
            this.stopProductAuctionHandler = stopProductAuctionHandler;

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
            // TODO
        }
    }
}
