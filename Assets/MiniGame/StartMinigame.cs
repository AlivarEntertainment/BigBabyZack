using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MonoBehaviour
{
    public GameObject MiniGame;
    public PlayerController playerController;
    public bool PlayMode = false;
    [SerializeField] private Animator PressE;
    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PressE.SetBool("IsInFade", false);
            if (Input.GetKey(KeyCode.E) && PlayMode == false)
            {   
                MiniGame.SetActive(true);
                PlayMode = true;
                playerController.enabled = false;
                PressE.SetBool("IsInFade", true);
                StartCoroutine("LeaveCol");
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
            PressE.SetBool("IsInFade", true);
            StartCoroutine("LeaveCol");
        }
    }
    IEnumerator LeaveCol()
    {
        yield return new WaitForSeconds(4);
         PressE.SetBool("IsInFade", true);
    }
}
