using BidderServer.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;

namespace BidderServer
{
    static class Program
    {
        private static void initAppSettings()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            initAppSettings();
            ServerModel model = new ServerModel();
            ServerController controller = new ServerController(model);

            ServerDashBoardForm serverDashBoardForm = new ServerDashBoardForm(model, controller.manageProductsHandler);
            ManageProductsForm manageProductsForm = new ManageProductsForm(
                model,
                controller.addProductHandler,
                controller.removeProductHandler,
                controller.modifyProductHandler,
                controller.startProductAuctionHandler,
                controller.stopProductAuctionHandler,
                controller.productsFormClosedHandler
                );

            controller.registerObserver(serverDashBoardForm.updateObserver);
            controller.registerObserver(manageProductsForm.updateObserver);

            var wss = new WebSocketServer(80);
            wss.AddWebSocketService<ServerControllerService>("/bidder", () => new ServerControllerService(controller));
            wss.Start();

            /* forcing creation of handle to make Invoke work correctly 
             https://stackoverflow.com/questions/808867/invoke-or-begininvoke-cannot-be-called-on-a-control-until-the-window-handle-has
             */
            manageProductsForm.Show();
            manageProductsForm.Hide();

            Application.Run(serverDashBoardForm);
            wss.Stop();
        }
    }
}
