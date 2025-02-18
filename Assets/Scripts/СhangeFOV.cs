using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class СhangeFOV : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float TargetFov;
    public bool CanChange = false;
    public bool IsFinal;
    public void Update()
    {
        if(vcam.m_Lens.OrthographicSize <= TargetFov && CanChange == true && IsFinal == false)
            {
                vcam.m_Lens.OrthographicSize += Time.deltaTime / 2;
            }
        else if(vcam.m_Lens.OrthographicSize >= TargetFov && CanChange == true && IsFinal == true)
            {
                vcam.m_Lens.OrthographicSize -= Time.deltaTime;
            }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   
            CanChange = true;
            if(IsFinal == true)
            {
                 Screen.SetResolution(1920, 1080, true);
            }
        }
    }
}
