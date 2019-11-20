using BidderClient.Shared;
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
    public partial class ServerDashBoardForm : Form
    {
        private ServerState itsState;
        private ServerModel itsModel;
        private ManageProductsHandler manageProductsHandler;
        public ServerObserver updateObserver { get; }

        public ServerDashBoardForm(ServerModel model, ManageProductsHandler manageProductsHandler)
        {
            this.itsModel = model;
            this.itsState = ServerState.MONITORING_STATE;
            this.updateObserver = this.update;
            this.manageProductsHandler = manageProductsHandler;

            InitializeComponent();
            render(itsState);
        }

        private void ManageProductsButton_Click(object sender, EventArgs e)
        {
            manageProductsHandler();
        }

        private void update(ServerState newState)
        {
            this.Invoke(new Action(() =>
            {
                render(newState);
            }));
        }

        private void render(ServerState newState)
        {
                this.itsState = newState;

                if (itsState == ServerState.MONITORING_STATE || itsState == ServerState.NEW_CLIENT_CONNECTED)
                {
                    this.Show();

                    this.productsDetailsList.Items.Clear();
                    foreach (var keyValuePair in this.itsModel.productsInventory)
                    {
                        Product product = keyValuePair.Value;
                        this.productsDetailsList.Items.Add(product.ToString());
                    }

                    this.connectedUsersList.Items.Clear();
                    foreach (var entry in this.itsModel.connectedUsers)
                    {
                        User user = entry.Value;
                        this.connectedUsersList.Items.Add(user.credentials.userName);
                    }
                }
                else
                {
                    this.Hide();
                }
        }
    }
}
