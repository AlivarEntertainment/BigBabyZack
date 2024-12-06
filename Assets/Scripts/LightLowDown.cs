using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLowDown : MonoBehaviour
{
    public Animator LightAnimator;
    public Transform PlayerTransform;

    public void FixedUpdate()
    {
        if(this.transform.position.y >= PlayerTransform.position.y)
        {
            LightAnimator.SetBool("IsUp", true);
        }
        else
        {
            LightAnimator.SetBool("IsUp", false);
        }
    }
}
