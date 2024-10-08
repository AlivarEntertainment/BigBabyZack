using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
   
   public Transform UpPosition;
   private PlayerController player;
   public bool IsLeddering;

   void Start()
   {
       
   }
   public void FixedUpdate()
   {
        if(IsLeddering == true)
        {   
            //Debug.Log("Update");
            player.IsClimbing = true;
            if(Input.GetKey(KeyCode.E))
            {
                IsLeddering = false;
                player.IsClimbing = false;
            }
        }
   }
   public void OnTriggerStay2D(Collider2D other)
   {
    if(other.gameObject.tag == "Player")
    {   
        //Debug.Log("Tag");
        if(Input.GetKey(KeyCode.E) && IsLeddering == false)
        {   
            Debug.Log("E");
            IsLeddering = true;
            player = other.GetComponent<PlayerController>();
        }
    }
   }
   
   
}

