using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGates : MonoBehaviour
{
    public Animator GatesAnimator;
    [SerializeField]private Animator PressE;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {   
            PressE.SetBool("IsInFade", false);
            if (Input.GetKey(KeyCode.E))
            {
                GatesAnimator.SetTrigger("GatesOpen");
            }
        }
    }

}
