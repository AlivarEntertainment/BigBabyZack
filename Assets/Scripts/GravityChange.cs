using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{   
    public GameObject PlayeroObj;
    public Quaternion direction;
     public float timeBtwAttack = 0;
    public float startTimeBtwAttack = 1f;
    public float RotationStep;
    public bool Flipped;
    public PlayerController playerController;
    public Collider2D[] colliders;
    int CurrentCol = -1;
    public void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.81f);
        Screen.SetResolution(1920, 1080, true);
    }
    public void Update()
    {
        PlayeroObj.transform.rotation = Quaternion.Lerp(PlayeroObj.transform.rotation, direction, RotationStep);
        if (timeBtwAttack >= 0)
        {   
            
             timeBtwAttack -= Time.deltaTime;
             RotationStep = 5 * Time.deltaTime;
        }
       
        
    }
    public void OnTriggerEnter2D(Collider2D playerCol)
    {
        if(playerCol.gameObject.tag == "Player" || playerCol.gameObject.tag == "Box")
        {
            
            if(Flipped == true)
            {
                direction = Quaternion.Euler(0, 0, 0);
                Physics2D.gravity = new Vector2(0, -9.81f);
                Flipped = false;
                playerController.jumpForce *= -1;
                
            }
            else if(Flipped == false)
            {
                direction = Quaternion.Euler(0, 0, 180);
                Physics2D.gravity = new Vector2(0, 9.81f);
                Flipped = true;
                playerController.jumpForce *= -1;
            }
            if(playerController.facingRight == true)
            {
                playerController.facingRight = false;
            }
            else
            {
                 playerController.facingRight = true;
            }
            timeBtwAttack = startTimeBtwAttack;
            //RotationStep = 7 * Time.deltaTime;
            CurrentCol += 1;
            colliders[CurrentCol].enabled = false;
        }
    }
}
