using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRegen : MonoBehaviour
{
    public PlayerController playerController;
    bool CanPrees = true;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   
            if(Input.GetKey(KeyCode.E ) && CanPrees == true)
            {
                playerController.PlayerAnimator.SetTrigger("GoRedd");
                CanPrees = false;
            }
            
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag == "Player")
        {
            CanPrees = true;
        }
    }
}
