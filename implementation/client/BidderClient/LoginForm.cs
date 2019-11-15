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
        public ClientObserver updateObserver { get; }

        public LoginForm(LoginHandler loginHandler)
        {
            this.itsState = ClientState.UNAUTENTIZED;
            this.loginHandler = loginHandler;
            this.updateObserver = this.update;
            InitializeComponent();
        }

        private void update(ClientState newState)
        {
            this.itsState = newState;

            switch (this.itsState)
            {
                case ClientState.UNAUTENTIZED:
                    userNameInput.Clear();
                    userPasswordInput.Clear();
                    break;

                case ClientState.AUTENTIZATION_FAILED:
                    MessageBox.Show("Login failed.");
                    break;

                case ClientState.AUTENTIZED_SUCCESSFULLY:
                    this.Hide();
                    break;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginHandler(userNameInput.Text, userPasswordInput.Text);
        }
    }
}
