using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWithBox : MonoBehaviour
{
    public Animator LockAnimator;
    public void OnTriggerStay2D(Collider2D BoxCol)
    {
        if(BoxCol.gameObject.tag == "Box")
        {
            LockAnimator.SetBool("Open", true);
        }
    }
}
