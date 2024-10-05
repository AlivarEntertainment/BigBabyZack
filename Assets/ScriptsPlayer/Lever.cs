using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
   private float inputVertical;
   public float LedderSpeed;
   private Rigidbody2D rb;
   public float distance;
   public LayerMask WhatIsLadder;
   public bool Climbing;
   public PlayerController playerController;
   public Transform EndPos;

   void Start()
   {
        rb = GetComponent<Rigidbody2D>();
   }
   private void FixedUpdate()
   {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, WhatIsLadder);
        if(hitInfo.collider != null)
        { 
            Climbing = true;
        }
        if(Climbing == true)
        {   
            if(Input.GetKey(KeyCode.E))
            {   
                
                playerController.enabled = false;
                Leddering();
                rb.gravityScale = 0;
                StartCoroutine("CanMoveCor");
            }
            else if(Input.GetKeyUp(KeyCode.E))
            {
                rb.gravityScale = 1;
                playerController.enabled = true;
                Climbing = false;
            }
        }
       
   }

   public void Leddering()
   {    
        //Debug.Log("Pel");
        transform.position = Vector3.MoveTowards(transform.position, EndPos.position, 0.05f);
   }
   void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, distance);
    }
    IEnumerator CanMoveCor()
    {
        yield return new WaitForSeconds(4f);
        rb.gravityScale = 1;
        playerController.enabled = true;
        Climbing = false;
    }
}
