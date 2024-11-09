using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public bool CanRide;
    public Animator CartAnimator;
    
    public void OnTriggerEnter2D(Collider2D PlayerInCart)
    {
        if(PlayerInCart.gameObject.tag == "Player" && CanRide == true)
        {
            CartAnimator.SetTrigger("Ride");
        }
    }
}
