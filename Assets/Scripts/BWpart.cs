using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWpart : MonoBehaviour
{
    public GameObject[] Lights;
    public bool isEnd;
    public void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            if(isEnd == true)
            {
                Lights[1].SetActive(false);
                Lights[0].SetActive(true);
            }
            else
            {
                Lights[0].SetActive(false);
                Lights[1].SetActive(true);
            }
        }
    }
}
