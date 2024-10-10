using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject sword;
    public void OnTriggerStay2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player")
        {
           if (Input.GetKey(KeyCode.E))
            {
                sword.SetActive(true);
            }
        }
    }
}
