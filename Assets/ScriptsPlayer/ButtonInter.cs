using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInter : MonoBehaviour
{   
    public bool Entered;
    public Rigidbody2D boxRB;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Entered == true)
            {
                
                boxRB.gravityScale = 2f;
            }
    }
    public void OnTriggerStay2D(Collider2D Plother)
    {
        if(Plother.gameObject.tag == "Player")
        {
            Entered = true;
        }
    }
    public void OnTriggerExit2D(Collider2D Plother)
    {
        if(Plother.gameObject.tag == "Player")
        {
            Entered = false;
        }
    }
}
