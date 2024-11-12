using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerberController : MonoBehaviour
{
    public Transform[] CerberPoints;
    public int NextPoint = 0;
    public float speed = 1.0f;
    public bool facingRight = true;
    public Quaternion direction;

    public void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {   
        if(NextPoint == 1 || NextPoint == 5)
        {
            direction = Quaternion.Euler(0, 0, -90);
        }
        else if (NextPoint == 3)
        {
            direction = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            direction = Quaternion.Euler(0, 0, 0);
        }
        
        float step = speed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(this.transform.rotation, direction, step);
        transform.position = Vector3.MoveTowards(transform.position, CerberPoints[NextPoint].position, step);
        if(this.transform.position == CerberPoints[NextPoint].position)
        {
            NextPoint += 1;
        }
        if(this.transform.position.x <= CerberPoints[NextPoint].position.x && facingRight == false)
        {
            Flip();
        }
        else if(this.transform.position.x >= CerberPoints[NextPoint].position.x && facingRight == true)
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
}
