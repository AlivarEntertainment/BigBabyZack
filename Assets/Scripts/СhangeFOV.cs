using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class СhangeFOV : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float TargetFov;
    public bool CanChange = false;
    public void Update()
    {
        if(vcam.m_Lens.OrthographicSize <= TargetFov && CanChange == true)
            {
                vcam.m_Lens.OrthographicSize += Time.deltaTime * 2;
            }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   
            CanChange = true;
        }
    }
}
