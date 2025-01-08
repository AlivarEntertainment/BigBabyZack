using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RunToSlidePlayer : MonoBehaviour
{
    public GameObject[] PlayersObj;
    public Transform NewPlayer;
    public CinemachineVirtualCamera virtualCamera;
    public void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            virtualCamera.Follow = NewPlayer;
            PlayersObj[0].SetActive(false);
            PlayersObj[1].SetActive(true);
        }
    }
}
