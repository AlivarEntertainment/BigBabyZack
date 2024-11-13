using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberController : MonoBehaviour
{
    public Transform[] CerberPoints;
    public int NextPoint = 0;
    public int LastPoint = 0;
    public float speed = 1.0f;
    public bool facingRight = true;
    public Quaternion direction;
    public float RotationStep;
    public Animator CerberAnimator;
    public bool IsInFinalPos;
    public bool CanMove;
    public Animator LavaAnimator;
    public void Awake()
    {
        StartCoroutine("StartKD");
    }
    public void FixedUpdate()
    {   
        if(IsInFinalPos == false && CanMove == true && NextPoint < 13)
        {
            Move();
        }
        else if(IsInFinalPos == true && CanMove == false)
        {
            SecondState();
        }
        else if(IsInFinalPos == false && CanMove == true && NextPoint >= 13)
        {
            ThirdState();
        }
         

    }
    public void Move()
    {   
        if(CerberPoints[LastPoint].transform.position.y < CerberPoints[NextPoint].transform.position.y && facingRight == false && NextPoint != 0)
        {
            direction = Quaternion.Euler(0, 0, -90);
            RotationStep = 7 * Time.deltaTime;
        }
        else if (CerberPoints[LastPoint].transform.position.y > CerberPoints[NextPoint].transform.position.y && NextPoint != 0)
        {
            direction = Quaternion.Euler(0, 0, 90);
            RotationStep = 7 * Time.deltaTime;
        }
        else if (CerberPoints[LastPoint].transform.position.y < CerberPoints[NextPoint].transform.position.y && facingRight == true && NextPoint != 0)
        {
            direction = Quaternion.Euler(0, 0, 90);
            RotationStep = 7 * Time.deltaTime;
        }
        else if(CerberPoints[LastPoint].transform.position.y == CerberPoints[NextPoint].transform.position.y)
        {
            direction = Quaternion.Euler(0, 0, 0);
            RotationStep = 7 * Time.deltaTime;
        }
        
        float step = speed * Time.deltaTime;
        //float RotationStep = speed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(this.transform.rotation, direction, RotationStep);
        transform.position = Vector3.MoveTowards(transform.position, CerberPoints[NextPoint].position, step);
        if(this.transform.position == CerberPoints[NextPoint].position)
        {
            NextPoint += 1;
            if(NextPoint >= 2)
            {
                LastPoint += 1;
            }
             if(NextPoint == 13)
            {
            IsInFinalPos = true;
            //Flip();
            CanMove = false;
            }
        }
        if(this.transform.position.x <= CerberPoints[NextPoint].position.x && facingRight == false)
        {
            Flip();
        }
        else if(this.transform.position.x >= CerberPoints[NextPoint].position.x && facingRight == true)
        {
            Flip();
        }
        if(NextPoint >= 7)
        {
            IsInFinalPos = true;
            //Flip();
            CanMove = false;
          
        }
       
       
    }
    void SecondState()
    {
        CerberAnimator.SetBool("IsIdle", true);
        StartCoroutine("StopChill");
    }
    public void ThirdState()
    {
        LavaAnimator.SetBool("GoUp", true);
        CerberAnimator.SetBool("IsIdle", true);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void OnTriggerEnter2D(Collider2D OtherJump)
    {
        if(OtherJump.gameObject.tag == "CerberJump")
        {
            CerberAnimator.SetTrigger("Jump");
            Debug.Log("Entered");
        }
    }
    IEnumerator StartKD()
    {
        yield return new WaitForSeconds(1.5f);
        CanMove = true;

    }
    IEnumerator StopChill()
    {
        yield return new WaitForSeconds(4f);
        CanMove = true;
        IsInFinalPos = false;
        CerberAnimator.SetBool("IsIdle", false);
    }
}
