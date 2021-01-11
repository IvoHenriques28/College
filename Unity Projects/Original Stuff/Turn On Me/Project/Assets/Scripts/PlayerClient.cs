using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using System.Net;
using System.Net.Sockets;
using System;

public class PlayerClient : MonoBehaviour , INetEventListener
{
    NetManager client;
    NetDataWriter writer;
    NetDataReader reader;

    NetPacketProcessor processor;

    public GameObject meteor;
    public GameObject zombieHorde;
    public GameObject MeleeWizard;
    public GameObject RangedWizard;
    public GameObject wolfPack;
    public GameObject troll;

    void Start()
    {
        client = new NetManager(this);
        client.Start();
        client.Connect("localhost", 8080, "");
        processor = new NetPacketProcessor();
        processor.SubscribeReusable<SpawnMobPacket, NetPeer>(spawnMobPacketHandler);
    }

    void Update()
    {
        client.PollEvents();
    }
    private void spawnMobPacketHandler(SpawnMobPacket arg1, NetPeer arg2)
    {
        
       if(arg1.mobType == "Meteor")
        {
            GameObject mob = Instantiate(meteor, new Vector3(arg1.x1, arg1.y1, arg1.z1), Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2));
            mob.transform.rotation = Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2);
        }
        if (arg1.mobType == "Horde")
        {
            GameObject mob = Instantiate(zombieHorde, new Vector3(arg1.x1, arg1.y1, arg1.z1), Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2));
            mob.transform.rotation = Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2);
        }
        if (arg1.mobType == "RangedWizard")
        {
            GameObject mob = Instantiate(RangedWizard, new Vector3(arg1.x1, arg1.y1, arg1.z1), Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2));
            mob.transform.rotation = Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2);
        }
        if (arg1.mobType == "MeleeWizard")
        {
            GameObject mob = Instantiate(MeleeWizard, new Vector3(arg1.x1, arg1.y1, arg1.z1), Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2));
            mob.transform.rotation = Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2);
        }
        if (arg1.mobType == "Troll")
        {
            GameObject mob = Instantiate(troll, new Vector3(arg1.x1, arg1.y1, arg1.z1), Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2));
            mob.transform.rotation = Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2);
        }
        if (arg1.mobType == "WolfPack")
        {
            GameObject mob = Instantiate(wolfPack, new Vector3(arg1.x1, arg1.y1, arg1.z1), Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2));
            mob.transform.rotation = Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2);
        }
    }

    public void OnConnectionRequest(ConnectionRequest request)
    {
        throw new System.NotImplementedException();
    }

    public void OnNetworkError(IPEndPoint endPoint, SocketError socketError)
    {
        throw new System.NotImplementedException();
    }

    public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
    {

    }

    public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
    {
        processor.ReadAllPackets(reader, peer);
        Debug.LogError("Packet Received");
    }

    public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
    {
        throw new System.NotImplementedException();
    }

    public void OnPeerConnected(NetPeer peer)
    {

    }

    public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
    {

    }


}
