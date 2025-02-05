using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSecondLobby : MonoBehaviour
{
    public GameObject LobbyFirst;
    public GameObject LobbySecond;
    public GameObject LobbyThird;
    public void Start()
    {
        string boss = PlayerPrefs.GetString("Cerber");
        int ObidaFin = PlayerPrefs.GetInt("LevelReached");
        if(boss == "finish" && ObidaFin <= 23)
        {
            LobbySecond.SetActive(true);
        }
        else if (ObidaFin <= 23)
        {
            LobbyFirst.SetActive(true);
        }
        else if(ObidaFin >= 24)
        {
            LobbyThird.SetActive(true);
        }
    }
}
