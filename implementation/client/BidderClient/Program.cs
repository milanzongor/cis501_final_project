using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BidderClient.Shared;

namespace BidderClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ClientModel model = new ClientModel();
          
            ClientController controller = new ClientController(model);
        
            // create login form
            LoginForm loginForm = new LoginForm(controller.loginHandler);
            controller.registerObserver(loginForm.updateObserver);

            // create place bid form
            PlaceBidForm placeBidForm = new PlaceBidForm(model, controller.placeBidHandler, controller.productListViewHandler);
            controller.registerObserver(placeBidForm.updateObserver);

            controller.notifyObservers(); // force form to render initial state
            
            Application.Run(loginForm);
        }
    }
}
