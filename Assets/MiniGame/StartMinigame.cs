using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MonoBehaviour
{
    public GameObject MiniGame;
    public PlayerController playerController;
    public bool PlayMode = false;
    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            if(Input.GetKey(KeyCode.E) && PlayMode == false)
            {   
                MiniGame.SetActive(true);
                PlayMode = true;
                playerController.enabled = false;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MiniGame.SetActive(false);
            PlayMode = false;
            playerController.enabled = true;
        }
    }
}
