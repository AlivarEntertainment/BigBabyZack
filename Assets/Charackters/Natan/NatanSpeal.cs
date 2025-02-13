using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NatanSpeal : MonoBehaviour
{
    [SerializeField]private PlayableDirector DialogTL;
    [SerializeField]private Animator PressE;
    bool used = false;
    public AudioSource audioSource;
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && used == false)
        {   
            PressE.SetBool("IsInFade", false);
            if(Input.GetKey(KeyCode.E))
            {
                DialogTL.Play();
                //PressE.SetBool("IsInFade", true);
                PressE.SetBool("IsInFade", true);
                used = true;
                audioSource.Play();
            }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
}
