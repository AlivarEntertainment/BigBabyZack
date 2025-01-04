using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCityCont : MonoBehaviour
{   
    public Animator BoxAnimator;
    public void OnTriggerEnter2D(Collider2D other)
    {
       /* if(other.gameObject.tag == "Player")
        {
            //reloadLevel
        }*/
        if(other.gameObject.tag == "Box")
        {
            BoxAnimator.SetTrigger("Boom");
        }
    }
}
