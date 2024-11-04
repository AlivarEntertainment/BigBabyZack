using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatanSpeal : MonoBehaviour
{
    [SerializeField]private Animator NatanDialogue;
    [SerializeField]private Animator NatanAnimator;
    [SerializeField]private Animator PressE;

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {   
            PressE.SetBool("IsInFade", false);
            if(Input.GetKey(KeyCode.E))
            {
                NatanDialogue.SetTrigger("Speak");
                NatanAnimator.SetBool("Speak", true);
                //PressE.SetBool("IsInFade", true);
            }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
}
