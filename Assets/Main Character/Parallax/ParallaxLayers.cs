using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayers : MonoBehaviour
{
    public float parallaxFactor;
    public bool IsFinal;
    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        if(IsFinal == false)
        {
            newPos.x -= delta * parallaxFactor;
        }
        else{
            newPos.y -= delta * parallaxFactor;
        }

        transform.localPosition = newPos;
    }
}
