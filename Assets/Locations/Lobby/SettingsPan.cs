using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPan : MonoBehaviour
{
    public Animator VinietAnimator;
    public GameObject PanelSet;
    public bool Pressed;
    public void FixedUpdate()
    {   
        if(Input.GetKeyDown(KeyCode.Escape))
        {
             if(Pressed == false)
            {
            PanelSet.SetActive(true);
            VinietAnimator.SetBool("IsViniet", true);
            Pressed = true;
            }
            else
            {   
            Pressed = false;
            PanelSet.SetActive(false);
            VinietAnimator.SetBool("IsViniet", false);
            }
        }
       
    }
}
