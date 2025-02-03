using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickerRun : MonoBehaviour
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
    [Header("WallKicker")]
    private float rotateSpeed = 720;
    public bool IsRotation;
    public GameObject MyWall;
    bool IsStucked;
    public int JumpCharges, JumpChargesMax;
    public Vector2 HorMove = new Vector2(1, 0);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {   
        if(IsStucked == false)
        {
            MoveGround();
        }
        else
        {
            WallJump();
        }
    }
    private void Update()
    {

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;

        }
        else if (IsGrounded == false)
        {
            PlayerAnimator.SetBool("Falling", true);
        }
        else if (IsGrounded == true)
        {
            PlayerAnimator.SetBool("Falling", false);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            WallJump();
        }
    }
    public void WallJump()
    {
        if (JumpCharges == 0) return;
        if (IsStucked || JumpCharges == 1)
        {
            facingRight = !facingRight;
        }
        rb.velocity = Vector2.up * jumpForce;
        HorMove = new Vector2(-HorMove.x, 0);
        IsStucked = false;
        JumpCharges--;
        rb.isKinematic = false;
        if (JumpCharges == 0)
        {
            IsRotation = true;
            MyWall = null;
        }
    }
    public void MoveGround()
    {
        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);
        if (MoveInput != 0)
        {
            PlayerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            PlayerAnimator.SetBool("IsWalking", false);
        }

        if (facingRight == false && MoveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && MoveInput < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsRotation = false;
        transform.rotation = Quaternion.identity;
        if(collision.transform.gameObject.tag == "wall")
        {
            if (collision.transform.gameObject == MyWall) return;
            ContactPoint2D c = collision.GetContact(0);
            if(Mathf.Abs(c.normal.y) > 0.1f)
            {
                JumpCharges = JumpChargesMax;
                MyWall = null;
                return;
            }
            MyWall = collision.transform.gameObject;
            IsStucked = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            
        }
        else
        {
            MyWall = null;
        }
        JumpCharges = JumpChargesMax;
    }
}

