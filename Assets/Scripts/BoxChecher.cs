using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChecher : MonoBehaviour
{   
    public FlourClocks flourClocks;
    public GameObject Blocker;
    public void OnTriggerStay2D(Collider2D BoxOther)
    {
        if(BoxOther.gameObject.tag == "Box")
        {
            if(flourClocks.InPast == true)
            {
                Blocker.SetActive(true);
            }
            else{
                Blocker.SetActive(false);
            }
        }
    }
}
