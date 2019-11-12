using BidderServer.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Application.Run(serverDashBoardForm);
        }
    }
}
