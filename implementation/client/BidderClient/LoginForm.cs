using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidderClient
{
    public partial class LoginForm : Form
    {
        private ClientState itsState;
        private LoginHandler loginHandler;
        public LoginForm(LoginHandler loginHandler, ClientState itsState)
        {
            this.itsState = itsState;
            this.loginHandler = loginHandler;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void update(ClientState newState)
        {
            this.itsState = newState;

            switch (this.itsState)
            {
                case ClientState.AUTENTIZATION_FAILED:
                    MessageBox.Show("Login failed.");
                    this.itsState = ClientState.UNAUTENTIZED;
                    break;

                case ClientState.AUTENTIZED_SUCCESSFULLY:

                    break;
            }
        }
    }
}
