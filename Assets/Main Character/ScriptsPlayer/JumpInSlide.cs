using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInSlide : MonoBehaviour
{
     public Animator PlayerAnimator;
     public float speed;

    private float MoveInput;
 
    public Rigidbody2D rb;
   
    [Header("Jump")]
        public float jumpForce;
    public Transform feetPos;
    private bool IsGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    private void Update()
    {   
        
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
         if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(1.3f, 1) * jumpForce;
            PlayerAnimator.SetTrigger("Jump");
        }
    }
    void FixedUpdate()
    {
       
    }
}
