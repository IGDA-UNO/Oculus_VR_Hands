using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    /// <summary>
    /// Connect to a server
    /// </summary>
    public static NetworkManager instance;
    public Transform[] spawnPoints;
    public Transform[] taken = new Transform[10];

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting To Server...");
    }
    void Start()
    {
        instance = this;
        ConnectToServer();
    }

    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server.");
        base.OnConnectedToMaster();

        //Creates the room
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room.");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("A new player joined the room.");
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public Transform RandomizeSpawnPoint()
    {
        int i = 0;
        int randIndex = Random.Range(0, spawnPoints.Length);

        while (taken[i] != null) 
        {
            if (i < spawnPoints.Length - 1)
            { 
                taken[i] = spawnPoints[randIndex];
                i++;
            }
        }

        return spawnPoints[randIndex];
    }
}
