using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatanSpeal : MonoBehaviour
{
    public Animator NatanDialogue;

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                NatanDialogue.SetTrigger("Speak");
                Debug.Log("Speak");
            }
        }
    }
}
