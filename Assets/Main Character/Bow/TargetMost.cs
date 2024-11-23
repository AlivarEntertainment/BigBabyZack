using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMost : MonoBehaviour
{
    public Animator TargetAnimator;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            TargetAnimator.SetTrigger("OpenMost");
        }
    }
}
