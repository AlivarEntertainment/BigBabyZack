using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGates : MonoBehaviour
{
    public Animator GatesAnimator;
    public Animator PlateAnimator;
    [SerializeField]private Animator PressE;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {   
            PressE.SetBool("IsInFade", false);
            if (Input.GetKey(KeyCode.E))
            {
                GatesAnimator.SetTrigger("GatesOpen");
                PlateAnimator.SetTrigger("OpenBlock");
            }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }

}
