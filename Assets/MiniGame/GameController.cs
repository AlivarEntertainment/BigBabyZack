using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private KeyCode KeyOne;
    [SerializeField] private KeyCode KeyTwo;
    [SerializeField] private Vector2 VectorMove;
<<<<<<< HEAD
=======
    
>>>>>>> b1046b8 (Roof)

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyOne))
        {
            GetComponent<Rigidbody2D>().velocity -= VectorMove;
        }
        if (Input.GetKey(KeyTwo))
        {
            GetComponent<Rigidbody2D>().velocity += VectorMove;
        }
        if (Input.GetKeyUp(KeyTwo))
        {   
            Debug.Log("@@");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (Input.GetKeyUp(KeyOne))
        {
            Debug.Log("@@");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
