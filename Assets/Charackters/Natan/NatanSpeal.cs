using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NatanSpeal : MonoBehaviour
{
    [SerializeField]private PlayableDirector DialogTL;
    [SerializeField]private Animator PressE;

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {   
            PressE.SetBool("IsInFade", false);
            if(Input.GetKey(KeyCode.E))
            {
                DialogTL.Play();
                //PressE.SetBool("IsInFade", true);
            }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
}
