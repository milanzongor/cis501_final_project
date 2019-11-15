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
            
            // !!!!!!!!!!!! delete this part after getting it from communication
            Item item1 = new Item("IPhone7", 5.33);
            Product product1 = new Product(0001, item1, ProductStatus.ACTIVE);
            product1.currentHighestBid = new Bid(null, 15.55, DateTime.Now);
            product1.numberOfBids = 5;
            model.productsInventory.Add(product1.productID, product1);

            Item item2 = new Item("Lenovo", 885.33);
            Product product2 = new Product(0002, item2, ProductStatus.DISABLED);
            product2.currentHighestBid = new Bid(null, 150.99, DateTime.Now);
            product2.numberOfBids = 34;
            model.productsInventory.Add(product2.productID, product2);

            ClientController controller = new ClientController(model);
        
            // create login form
            LoginForm loginForm = new LoginForm(controller.loginHandler);
            controller.registerObserver(loginForm.updateObserver);

            // create place bid form
            PlaceBidForm placeBidForm = new PlaceBidForm(model, controller.placeBidHandler);
            controller.registerObserver(placeBidForm.updateObserver);

            controller.notifyObservers(); // force form to render initial state
            
            Application.Run(loginForm);
        }
    }
}
