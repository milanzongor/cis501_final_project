using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        
            LoginForm view = new LoginForm(
                controller.loginHangler,
                controller.loginHangler,
                controller.timerTickHandler); // delegates provide compile protecting agains swapping args: cannot convert from 'AlarmClock.Button2ClickHandler' to 'AlarmClock.Button1ClickHandler'
            controller.registerObserver(view.updateDelegate);
            controller.notifyObservers(); // force form to render initial state
            Application.Run(view);
        }
    }
}
