using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using LiteNetLib;
using LiteNetLib.Utils;
using LiteNetLibShared;


namespace LiteNetServer
{
    public class DemoServer : INetEventListener
    {
        public NetManager Server { get; set; }
        private NetPacketProcessor processor;
        

        public DemoServer()
        {
            processor = new NetPacketProcessor();
            processor.SubscribeReusable<SpawnMobPacket, NetPeer>(SpawnMobPacketHandler);
            processor.SubscribeReusable<HuntedCoordinatesPacket, NetPeer>(CoordinatePacketHandler);
            processor.SubscribeReusable<HuntedSpellPacket, NetPeer>(HuntedSpellHandler);

        }

        private void HuntedSpellHandler(HuntedSpellPacket arg1, NetPeer arg2)
        {
            if (Server.ConnectedPeerList.Count == 2)
            {
                processor.Send(Server.ConnectedPeerList[1], arg1, DeliveryMethod.ReliableOrdered);
            }
        }

        private void CoordinatePacketHandler(HuntedCoordinatesPacket arg1, NetPeer arg2)
        {
            if(Server.ConnectedPeerList.Count == 2)
            {
                processor.Send(Server.ConnectedPeerList[1], arg1, DeliveryMethod.ReliableOrdered);
            }

        }

        private void SpawnMobPacketHandler(SpawnMobPacket arg1, NetPeer arg2)
        {

            if (Server.ConnectedPeerList.Count == 2)
            {
                processor.Send(Server.ConnectedPeerList[0], arg1, DeliveryMethod.ReliableOrdered);
            }

        }

        public void OnPeerConnected(NetPeer peer)
        {
            Console.WriteLine("Client connected");
        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            
        }

        public void OnNetworkError(IPEndPoint endPoint, SocketError socketError)
        {
            
        }

        public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
        {
            processor.ReadAllPackets(reader, peer);
            Console.WriteLine("Received Packet");
        }

        public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
        {
      
        }

        public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
        {
        }

        public void OnConnectionRequest(ConnectionRequest request)
        {
            request.Accept();
        }
    }
}
