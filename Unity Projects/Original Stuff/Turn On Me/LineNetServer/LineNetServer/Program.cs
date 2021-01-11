using System;
using System.Numerics;
using System.Linq;
using System.Threading;
using LiteNetLib;
using LiteNetLib.Utils;
using LiteNetLibShared;
using LiteNetServer;

namespace LineNetServer
{
    public class Program
    {
       
        static void Main(string[] args)
        {
           Console.WriteLine("starting server");


            Run();            
        }

        static void Run()
        {
            DemoServer netListener = new DemoServer();
            NetManager netManager  = new NetManager(netListener);
            netManager.Start(8080);
            netListener.Server = netManager;
            NetPacketProcessor processor = new NetPacketProcessor();
            NetDataReader reader = new NetDataReader();
            bool gameStart = false;

            while (!Console.KeyAvailable)
            {
         
                netManager.PollEvents();
                Thread.Sleep(15);
                if(netManager.ConnectedPeerList.Count < 2)
                {
                    gameStart = false;
                }

                if (netManager.ConnectedPeerList.Count == 2 && gameStart == false)
                {
                    processor.Send(netManager.ConnectedPeerList[1], new StartPacket { role = "Hunter" }, DeliveryMethod.ReliableOrdered);
                    processor.Send(netManager.ConnectedPeerList[0], new StartPacket { role = "Hunted" }, DeliveryMethod.ReliableOrdered);
                    gameStart = true;
                }
            }
        }
    }
}
