using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourClocks : MonoBehaviour
{
    public Animator LightAnimator;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Animator PlayerAnim;
    public Animator ClocksAnim;
    public bool InPast = false;
    public void ChangeDownTime()
    {
        if(InPast == true)
        {
            
            ClocksAnim.SetBool("Past", false);
            InPast = false;
        }
        else
        {   
            
            ClocksAnim.SetBool("Past", true);
            InPast = true;
        }
    }
    public void OnTriggerStay2D(Collider2D playerClock)
    {
        if(playerClock.gameObject.tag == "Player")
        {   
            LightAnimator.SetBool("DoLight", true);
            if (timeBtwAttack <= 0.1f)
                {
            
                    if(Input.GetKey(KeyCode.E))
                    {
                    timeBtwAttack = startTimeBtwAttack;
                    PlayerAnim.SetTrigger("Medal");
                    Debug.Log("clock");
                    ChangeDownTime();
                    LightAnimator.SetBool("DoLight", false);
                    }
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }
        }
    }
    public void OnTriggerExit2D(Collider2D playerClock)
    {
        if(playerClock.gameObject.tag == "Player")
        { 
            LightAnimator.SetBool("DoLight", false);
        }
    }
}
