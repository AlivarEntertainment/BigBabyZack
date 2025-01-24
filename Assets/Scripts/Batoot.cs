using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batoot : MonoBehaviour
{
    public Rigidbody2D rb;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            rb.gravityScale += 7;
            StartCoroutine("BackGravity");
        }
    }
    IEnumerator BackGravity()
    {
        yield return new WaitForSeconds(1f);
        rb.gravityScale -= 7;
    }
}
