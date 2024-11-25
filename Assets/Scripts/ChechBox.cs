using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechBox : MonoBehaviour
{
    public Collider2D EdgeCol;
    //public PhysicMaterial2D physicMaterial2D;
    public PhysicsMaterial2D physics1;
    public void OnTriggerEnter2D(Collider2D BoxCol)
    {
        if(BoxCol.gameObject.name == "Box")
        {   
           
            EdgeCol.sharedMaterial = physics1;
        }
    }
}
