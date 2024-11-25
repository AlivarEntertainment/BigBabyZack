using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{   
    public Animator HealAnimator;
    public MainLyfe mainLyfe;
    bool IsUsed = false;
    public void Start()
    {
        Debug.Log("PotStart");
    }
    public void OnTriggerEnter2D(Collider2D otherHeal)
    {
        if(otherHeal.gameObject.tag == "Player" && IsUsed == false)
        {
            HealAnimator.SetTrigger("TakePotion");
            mainLyfe.GetHeal();
            IsUsed = true;
        }

    }
}
