﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BidderClient.Shared;
using BidderClient.Shared.Communication;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace BidderClient.Proxy
{
    public class ServerProxy : ServerAPI
    {
        private WebSocket webSocketToRealServer;
        private Dictionary<int, Product> productsInventory;
        private static string REAL_SERVER_URL = "ws://192.168.137.63:80/bidder";
        private DidUserAutentizeWrapper didUserAutentizeWrapper;
        private WasBidPlacedWrapper wasBidPlacedWrapper;
        private ClientController clientController;

        public ServerProxy(ClientController clientController)
        {
            this.clientController = clientController;
            this.productsInventory = new Dictionary<int, Product>();

            this.webSocketToRealServer = new WebSocket(REAL_SERVER_URL);
            // this.webSocketToRealServer.Log.Level = LogLevel.Debug;
            this.webSocketToRealServer.Connect();
            this.webSocketToRealServer.OnMessage += (sender, e) =>
            {
                Console.WriteLine("Server says: " + e.Data);
                UpdateProductsParamWrapper updateProductsParam = JsonConvert.DeserializeObject<UpdateProductsParamWrapper>(e.Data);
                if (updateProductsParam.hasValidValues())
                {
                    // update products message came
                    Console.WriteLine("Update products inventory message came");
                    this.productsInventory = updateProductsParam.productsInventory;
                    this.clientController.updateProductList(updateProductsParam.productsInventory);
                }
                else
                {   // information about result of either previous authentization or previous bidding must have come or action result message
                    DidUserAutentizeWrapper didUserAutentize = JsonConvert.DeserializeObject<DidUserAutentizeWrapper>(e.Data);
                    if (didUserAutentize.hasValidValues())
                    {
                        // autentization result message came
                        Console.WriteLine("Autentization result message came");
                        this.didUserAutentizeWrapper = didUserAutentize;
                    }
                    else
                    {
                        ProductAuctionResultWrapper productAuctionResultWrapper = JsonConvert.DeserializeObject<ProductAuctionResultWrapper>(e.Data);
                        if (productAuctionResultWrapper.hasValidValues())
                        {
                            // product auction result message came
                            Console.WriteLine("Product auction result message came");
                            this.clientController.productAuctionResultMessage(productAuctionResultWrapper);
                        } else { 
                            // bidding result message came
                            Console.WriteLine("Bidding result message came");
                            WasBidPlacedWrapper wasBidPlaced = JsonConvert.DeserializeObject<WasBidPlacedWrapper>(e.Data);
                            this.wasBidPlacedWrapper = wasBidPlaced;
                        }
                    }
                }
            };
        }

        ~ServerProxy()
        {
            this.webSocketToRealServer.Close();
        }

        public User autentizate(Credentials credentials)
        {
            if (webSocketToRealServer.IsAlive)
            {
                webSocketToRealServer.Send(JsonConvert.SerializeObject(credentials));
                while (didUserAutentizeWrapper == null) // while no response from server came
                {
                    Thread.Sleep(50); // slow poll wait for response
                }
                if (didUserAutentizeWrapper.wasSuccessful)
                {
                    return didUserAutentizeWrapper.autentizedUser;
                } else
                {
                    didUserAutentizeWrapper = null;
                    return null;
                }
            }
            else
            {
                didUserAutentizeWrapper = null;
                return null;
            }
        }

        public bool bidProduct(int productID, double bidValue, User bidder)
        {
            if (webSocketToRealServer.IsAlive)
            {
                this.wasBidPlacedWrapper = null;
                webSocketToRealServer.Send(JsonConvert.SerializeObject(
                    new BidProductParamsWrapper(productID, bidValue, bidder))
                );
                while (wasBidPlacedWrapper == null)
                {
                    Thread.Sleep(50); // slow poll wait for response
                }
                return wasBidPlacedWrapper.wasSuccessful;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<int, Product> getUpToDateProductsInventory()
        {
            return productsInventory;
        }

    }
}
