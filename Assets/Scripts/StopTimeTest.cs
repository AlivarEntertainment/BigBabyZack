using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimeTest : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D otherPlayer)
    {
        if (otherPlayer.gameObject.tag == "Player")
        {   
            Time.timeScale = 0;
            
        }
    }
}
