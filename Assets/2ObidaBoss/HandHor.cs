using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHor : MonoBehaviour
{
    [SerializeField] private Vector2 VectorMove;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity -= VectorMove;
    }
    public void OnCollisionEnter2D(Collision2D Destroyer)
    {
        if(Destroyer.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
    }
}
