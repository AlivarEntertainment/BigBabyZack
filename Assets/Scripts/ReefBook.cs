using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReefBook : MonoBehaviour
{   
    public GameObject BookUI;
    [SerializeField]private Animator PressE;
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {   
            PressE.SetBool("IsInFade", false);
            if(Input.GetKey(KeyCode.E))
            {   
                
                BookUI.SetActive(true);
            }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
    public void OnLeaveButtonClick()
    {
        BookUI.SetActive(false);
    }
}
