using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRegen : MonoBehaviour
{
    public PlayerController playerController;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   
            if(Input.GetKey(KeyCode.E))
            {
                playerController.PlayerAnimator.SetTrigger("GoRedd");
            }
            
        }
    }
}
