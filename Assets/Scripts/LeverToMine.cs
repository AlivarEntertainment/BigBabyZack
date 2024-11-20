using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverToMine : MonoBehaviour
{
    public Animator animatorPressed;
    public bool UsedLever;
    public GameObject Blocker;
    public Cart cart;
    [SerializeField]private Animator PressE;
    public Animator TrolleyAnimator;
    public void OnTriggerStay2D(Collider2D PlayerCol)
    {
        if(PlayerCol.gameObject.tag == "Player")
        {   
            
            
                UsedLever = true;
                Blocker.SetActive(false);
                cart.CanRide = true;
                PressE.SetBool("IsInFade", true);
                TrolleyAnimator.SetTrigger("OpenBlock");
                animatorPressed.SetTrigger("Pressed");
            
        }
    }
}
