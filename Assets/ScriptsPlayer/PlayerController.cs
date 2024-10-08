using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Header("StandartMove")]
    public float speed;
    public float jumpForce;
    private float MoveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;


    [Header("Jump")]
    public Transform feetPos;
    private bool IsGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    [Header("Leddering")]
    public float LedderSpeed;
    private float MoveInputYY;
    public bool IsClimbing = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(IsClimbing == true)
        {
            Laddering();
        }
        else
        {
            MoveGround();
        }
    }
    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(IsGrounded == true && Input.GetKeyDown(KeyCode.Space) && IsClimbing == false)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    public void MoveGround()
    {
        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);

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
        MoveInputYY = Input.GetAxis("Vertical");
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
