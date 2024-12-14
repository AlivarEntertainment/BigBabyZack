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
    public Vector2 bowPosition;
    public Vector2 mousePosition;
    public float limiUp = 170, limitDown = 10;
    private float timeBtwAttack;
    public float startTimeBtwAttack = 0.35f;
    public void Update()
    {   
        bowPosition = transform.position;
        //Vector3 currentRotation = this.transform.localEulerAngles;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(playerController.facingRight == true)
        {
            direction = mousePosition - bowPosition;
           
        }
        else{
            direction = bowPosition - mousePosition;
        }
        if(direction.x >= 0)
        {   
           // Mathf.Clamp(direction, limitDown, limiUp);
            transform.right = direction;
            //transform.position = Vector3.right(Mathf.Clamp(direction, limitDown, limiUp));
            //currentRotation.x = Mathf.Clamp(currentRotation.x, limiUp, limitDown);
        }
        

        
        if (timeBtwAttack <= 0)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                timeBtwAttack = startTimeBtwAttack;
                Shoot();
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        playerController.PlayerAnimator.SetTrigger("BowShot");
        if(playerController.facingRight == true)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;
        }
        else{
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * -1 * lauchForce;
           // GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        }
        //GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        //newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;
    }
    
}
