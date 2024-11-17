using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
   
   //public Transform UpPosition;
   private PlayerController player;
   public bool IsLeddering;
   [SerializeField]private Animator PressE;
    public Collider2D WayPlatform;
    public Transform myTransform;
    public float MoveInputYY;
    public bool OnLedder;
    public SpriteRenderer platformSpriteRenderer;
   public void Start()
   {

   }    

    
//this variable will be made true when the players is just below the platform so that the Box collider of collision checking game object can be disabled that will allow the player to pass through the platform

    
   public void Update()
   {    
     MoveInputYY = Input.GetAxis("Vertical");
        if(MoveInputYY != 0&& OnLedder == true)
        {   
            player.IsClimbing = true;
            IsLeddering = true;
        }
    	if( IsLeddering == true)    
    	{   
            platformSpriteRenderer.sortingOrder = 4;
    		WayPlatform.enabled= false;    
             
    	}    
    	else if(IsLeddering == false)
    	{    
    		WayPlatform.enabled=true;    
            platformSpriteRenderer.sortingOrder = 2;

    	}    
       
    		 
   }
   public void OnTriggerStay2D(Collider2D other)
   {
    if(other.gameObject.tag == "Player")
    {   
         OnLedder = true;
        player = other.GetComponent<PlayerController>();
         
         
        if(MoveInputYY == 0)
        {   
            player.PlayerAnimator.SetBool("Leddering", false);
            player.IsClimbing = false;
            IsLeddering=false;
        }
      
    }
   }
    public void OnTriggerExit2D()
    {
        OnLedder = false;
        IsLeddering = false;
        player.IsClimbing = false;
            
    }
   
}

