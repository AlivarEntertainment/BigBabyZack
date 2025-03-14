using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamParallax : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;

    private float oldPosition;
    public bool IsFinal;

    void Start()
    {   
        if(IsFinal == false)
        {
            oldPosition = transform.position.x;
        }
        else if(IsFinal == true)
        {
            oldPosition = transform.position.y;
        }
        
    }

    void FixedUpdate()
    {
        if (transform.position.x != oldPosition && IsFinal == false)
        {
            if (onCameraTranslate != null)
            {
                float delta = oldPosition - transform.position.x;
                onCameraTranslate(delta);
            }

            oldPosition = transform.position.x;
        }
        else if (transform.position.y != oldPosition && IsFinal == true)
        {
            if (onCameraTranslate != null)
            {
                float delta = oldPosition - transform.position.y;
                onCameraTranslate(delta);
            }

            oldPosition = transform.position.y;
        }
    }
}
