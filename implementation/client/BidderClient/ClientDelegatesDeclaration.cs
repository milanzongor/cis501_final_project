using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidderClient
{
    public delegate void LoginHandler(string name, string password);
    public delegate void PlaceBidHandler(int bidID, double price);
    public delegate void ClientObserver(ClientState newState);
}
