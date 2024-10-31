using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverToMine : MonoBehaviour
{   
    public bool UsedLever;
    public GameObject Blocker;
    public Rigidbody2D MinecartRB;
    public void OnTriggerStay2D(Collider2D PlayerCol)
    {
        if(PlayerCol.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                UsedLever = true;
                Blocker.SetActive(false);
                MinecartRB.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
