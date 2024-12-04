using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguinLight : MonoBehaviour
{   
    public Animator LightAnimator;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Animator PlayerAnim;
    public Animator EyesLight;
    public Collider2D[] LightTrigger;
    public bool InPast = true;
    public void ChangeDownTime()
    {
        if(InPast == true)
        {
            LightTrigger[0].enabled = false;
            LightTrigger[1].enabled = false;
            EyesLight.SetBool("DoLight", false);
            InPast = false;
        }
        else
        {   
            LightTrigger[0].enabled = true;
            LightTrigger[1].enabled = true;
            EyesLight.SetBool("DoLight", true);
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
