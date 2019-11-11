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
        }

        private void ManageProductsButton_Click(object sender, EventArgs e)
        {
            manageProductsHandler();
        }

        private void update(ServerState newState)
        {
            this.itsState = newState;

            if (itsState == ServerState.MONITORING_STATE || itsState == ServerState.NEW_CLIENT_CONNECTED)
            {
                this.Show();
            } else
            {
                this.Hide();
            }
        }
    }
}
