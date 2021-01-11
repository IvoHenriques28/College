using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using System.Net;
using System.Net.Sockets;
using System;
using UnityEngine.SceneManagement;

public class HunterClient : MonoBehaviour, INetEventListener
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
    public GameObject player;

    public AudioSource ac;

    public bool youWon;
    public bool gameStarted;

    void Start()
    {
        ac = GetComponent<AudioSource>();
        client = new NetManager(this);
        client.UpdateTime = 15;
        client.Start();
       
        processor = new NetPacketProcessor();

        processor.SubscribeReusable<SpawnMobPacket, NetPeer>(spawnMobPacketHandler);
        processor.SubscribeReusable<StartPacket, NetPeer>(StartPacketHandler);
        processor.SubscribeReusable<HuntedCoordinatesPacket, NetPeer>(CoordinatePacketHandler);
        processor.SubscribeReusable<HuntedSpellPacket, NetPeer>(HuntedSpellHandler);
    }

    private void HuntedSpellHandler(HuntedSpellPacket arg1, NetPeer arg2)
    {
        player.GetComponent<RemoteHunterSpells>().Cast(arg1.index);
        player.GetComponent<RemoteHunterSpells>().spellIndex = arg1.index;
    }

    private void CoordinatePacketHandler(HuntedCoordinatesPacket arg1, NetPeer arg2)
    {
        player.GetComponent<Animator>().SetInteger("InputVertical", (int)arg1.input1);
        player.transform.position = new Vector3(arg1.x1, arg1.y1, arg1.z1);
        player.transform.rotation = Quaternion.Euler(arg1.x2, arg1.y2, arg1.z2);
    }

    private void StartPacketHandler(StartPacket arg1, NetPeer arg2)
    {
        if(arg1.role == "Hunter")
        {
            SceneManager.LoadScene(2);
        }
        if(arg1.role == "Hunted")
        {
            SceneManager.LoadScene(3);
        }
    }
    public void Disconnect()
    {
        client.DisconnectAll();
    }
    public void Connect()
    {
        client.Connect("localhost", 8080, "");
        
    }
    void Update()
    {
        if(gameStarted == true)
        {
            ac.clip = null;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            gameStarted = true;
        }
        DontDestroyOnLoad(this);
        client.PollEvents();
    }

    public void SendMobPacket(Vector3 position, Vector3 rotation, string MobType)
    {
        processor.Send(client, new SpawnMobPacket
        { x1 = position.x,
          x2 = rotation.x,
          y1 = position.y,
          y2 = rotation.y,
          z1 = position.z,
          z2 = rotation.z,
         mobType = MobType }, 
        DeliveryMethod.ReliableUnordered);
    }

    public void SendSpellPacket(int index)
    {
        processor.Send(client, new HuntedSpellPacket { index = index }, DeliveryMethod.ReliableOrdered);
    }

    public void SendCoordinatePatcket(Vector3 position, Vector3 rotation, float input1)
    {
        processor.Send(client, new HuntedCoordinatesPacket
        {
            x1 = position.x,
            y1 = position.y,
            z1 = position.z,
            x2 = rotation.x,
            y2 = rotation.y,
            z2 = rotation.z,
            input1 = input1,
        }, DeliveryMethod.ReliableOrdered);
    }
    private void spawnMobPacketHandler(SpawnMobPacket arg1, NetPeer arg2)
    {

        if (arg1.mobType == "Meteor")
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
        
    }

    public void OnNetworkError(IPEndPoint endPoint, SocketError socketError)
    {
        
    }

    public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
    {
       
    }

    public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
    {
        processor.ReadAllPackets(reader, peer);
    }

    public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
    {
        
    }

    public void OnPeerConnected(NetPeer peer)
    {
       
    }

    public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
    {
       
    }

 
}
