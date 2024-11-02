using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float lauchForce;
    public Transform shotPoint;
    public PlayerController playerController;
    public Vector2 direction;
    public float limiUp = 170, limitDown = 10;
    public void Update()
    {   
        Vector2 bowPosition = transform.position;
        //Vector3 currentRotation = this.transform.localEulerAngles;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(playerController.facingRight == true)
        {
            direction = mousePosition - bowPosition;
            Debug.Log("Mv");
        }
        else{
            direction = bowPosition - mousePosition;
        }
        if(direction.x >= bowPosition.x)
        {   
           // Mathf.Clamp(direction, limitDown, limiUp);
            transform.right = direction;
            //transform.position = Vector3.right(Mathf.Clamp(direction, limitDown, limiUp));
            //currentRotation.x = Mathf.Clamp(currentRotation.x, limiUp, limitDown);
        }
        

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }
    void Shoot()
    {   
        if(playerController.facingRight == true)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;
        }
        else{
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            Vector2 LeftCond = new Vector2(-lauchForce, 0);
            newArrow.GetComponent<Rigidbody2D>().velocity = LeftCond;
           // GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        }
        //GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        //newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;
    }
    
}
