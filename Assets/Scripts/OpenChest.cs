using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{   
    [SerializeField]private bool IsOpened = false;
    public GameObject sword;
    public Animator animatorChest;
    [SerializeField]private Animator PressE;
    [SerializeField] private GameObject FightButton;
    public void OnTriggerStay2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player" && IsOpened == false)
        {   
            PressE.SetBool("IsInFade", false);
           if (Input.GetKey(KeyCode.E))
           {
                StartCoroutine(OpneChestCor());
                animatorChest.SetTrigger("Open");
                FightButton.SetActive(true);
           }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
    public IEnumerator OpneChestCor()
    {
        yield return new WaitForSeconds(0.65f);
        IsOpened = true;
        PressE.SetBool("IsInFade", true);
        sword.SetActive(true);
    }
}
