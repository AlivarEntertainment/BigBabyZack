using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Header("StandartMove")]
    public float speed;
    public float jumpForce;
    private float MoveInput;
    public Rigidbody2D rb;
    public bool facingRight = true;
    public Animator PlayerAnimator;

    [Header("Jump")]
    public Transform feetPos;
    private bool IsGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    [Header("Leddering")]
    public float LedderSpeed;
    public float MoveInputYY;
    public bool IsClimbing = false;

    public bool OnBoss;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(OnBoss == true)
        {
            PlayerAnimator.speed = 1.7f;
        }
    }
    private void FixedUpdate()
    {
        if(IsClimbing == true)
        {
            Laddering();
        }
        else
        {   
            if(OnBoss == true)
            {
                rb.gravityScale = 2.5f;
            }
            else{
                rb.gravityScale = 1;
            }
            
            MoveGround();
            PlayerAnimator.SetBool("Leddering", false);
        }
    }
    private void Update()
    {   
        
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space) && IsClimbing == false)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
        else if (IsGrounded == false && IsClimbing == false)
        {
            PlayerAnimator.SetBool("Falling", true);
        }
        else if (IsGrounded == true)
        {
            PlayerAnimator.SetBool("Falling", false);
        }
        
    }
    public void MoveGround()
    {
        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);
        if(MoveInput != 0)
        {
            PlayerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            PlayerAnimator.SetBool("IsWalking", false);
        }
       
        if(facingRight == false && MoveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && MoveInput < 0)
        {
            Flip();
        }
    }
    public void Laddering()
    {
        PlayerAnimator.SetBool("IsWalking", false);
        //PlayerAnimator.SetBool("Leddering", true);
        MoveInputYY = Input.GetAxis("Vertical");
        rb.gravityScale = 0;
        if(MoveInputYY != 0)
        {
            PlayerAnimator.SetBool("Leddering", true);
            if(OnBoss == false)
            {
                 PlayerAnimator.speed = 1;
            }
            else if(OnBoss == true)
            {
                 PlayerAnimator.speed = 1.7f;
            }
            
        }
        else 
        {
            PlayerAnimator.SetBool("Leddering", true);
            PlayerAnimator.speed = 0;
        }
        rb.velocity = new Vector2(0, MoveInputYY * LedderSpeed);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
}
