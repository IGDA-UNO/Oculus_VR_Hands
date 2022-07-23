using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    public string networkPlayer;
    public NetworkManager networkManager;
    public Transform mySpawnPoint;
    public bool taken;


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        if (!taken) { 
        mySpawnPoint = networkManager.RandomizeSpawnPoint();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate(networkPlayer, mySpawnPoint.position, transform.rotation);
        }

        taken = true;

   
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }

}