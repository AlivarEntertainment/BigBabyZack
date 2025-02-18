using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimboBox : MonoBehaviour
{
    public Rigidbody2D rb;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.mass = 1;
            rb.drag  = 1.6f;
            rb.gravityScale= 10f;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
