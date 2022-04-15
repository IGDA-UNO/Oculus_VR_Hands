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

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting To Server...");
    }
    void Start()
    {
        ConnectToServer();
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
}
