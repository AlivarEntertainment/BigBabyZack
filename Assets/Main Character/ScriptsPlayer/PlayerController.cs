using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Header("StandartMove")]
    public float speed;
    public float jumpForce;
    public static float MoveInput;
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
    public bool OnOgurec;
    public Transform PlayerPos;
    public bool InWall;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(OnBoss == true)
        {
            PlayerAnimator.speed = 1.7f;
        }
        if(OnOgurec == true)
        {
                rb.gravityScale = 2.2f;
        }
    }
    private void FixedUpdate()
    {   
        PlayerPos.position = transform.position;
        
        if (IsClimbing == true)
        {
            Laddering();
        }
        else if(IsClimbing == false)
        {   
            if(OnBoss == true)
            {
                rb.gravityScale = 2.5f;
            }
            if(OnOgurec == false){
                rb.gravityScale = 1;
            }
            if(OnBoss == false)
            {
                 PlayerAnimator.speed = 1;
            }
            else if(OnBoss == true)
            {
                 PlayerAnimator.speed = 1.7f;
            }
            
            MoveGround();
            PlayerAnimator.SetBool("Leddering", false);
        }
        if (InWall == true)
        {
            Flip();
            if (facingRight == false)
            {
                rb.velocity = new Vector2(-1, 2) * speed;
            }
            else
            {
                rb.velocity = new Vector2(1, 2) * speed;
            }
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
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            StartCoroutine("SmallCor");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            InWall = false;
        }
    }
    IEnumerator SmallCor()
    {
        yield return new WaitForSeconds(0.3f);
        InWall = true;
    }
}
