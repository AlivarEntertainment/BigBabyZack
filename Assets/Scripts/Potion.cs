using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{   
    public Animator HealAnimator;
    public MainLyfe mainLyfe;
    public void OnTriggerEnter2D(Collider2D otherHeal)
    {
        if(otherHeal.gameObject.tag == "Player")
        {
            HealAnimator.SetTrigger("TakePotion");
            mainLyfe.GetHeal();
        }
    }
}
