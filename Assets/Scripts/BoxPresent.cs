using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPresent : MonoBehaviour
{
    public Animator animatorChest;
    [SerializeField]private bool IsOpened = false;
    [SerializeField]private Animator PressE;
    public StairsController stairsController;
    public PlayerController playerController;
     public void OnTriggerStay2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player" && IsOpened == false)
        {   
            PressE.SetBool("IsInFade", false);
           if (Input.GetKey(KeyCode.E) && playerController.PlayerAnimator.GetBool("IsWalking") == false)
           {
                StartCoroutine(OpneChestCor());
                animatorChest.SetTrigger("Open");
                
                playerController.enabled = false;
                
           }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
    public IEnumerator OpneChestCor()
    {
        yield return new WaitForSeconds(2.5f);
        IsOpened = true;
        PressE.SetBool("IsInFade", true);
        stairsController.enabled = true;
       playerController.enabled = true;
    }
}
