using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ParallaxBackGround : MonoBehaviour
{
    

  public CamParallax parallaxCamera;
  List<ParallaxLayers> parallaxLayers = new List<ParallaxLayers>();

  void Start()
  {
    if (parallaxCamera == null)
        parallaxCamera = Camera.main.GetComponent<CamParallax>();

    if (parallaxCamera != null)
        parallaxCamera.onCameraTranslate += Move;

    SetLayers();
  }

  void SetLayers()
  {
        parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayers layer = transform.GetChild(i).GetComponent<ParallaxLayers>();

            if (layer != null)
            {
                layer.name = "Layer-" + i;
                parallaxLayers.Add(layer);
            }
        }
    }

    void Move(float delta)
    {
        foreach (ParallaxLayers layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
}

