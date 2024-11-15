using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSecondLobby : MonoBehaviour
{
    public GameObject LobbyFirst;
    public GameObject LobbySecond;
    public void Start()
    {
        string boss = PlayerPrefs.GetString("Cerber");
        if(boss == "finish")
        {
            LobbySecond.SetActive(true);
        }
        else
        {
            LobbyFirst.SetActive(true);
        }
    }
}
