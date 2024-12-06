using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{
    public Animator ClockAnimator;
    public Animator StairsAnimator;
    public Collider2D StairsCollider;
    public Animator PlayerAnim;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public bool InPast = false;
    public void OnTriggerStay2D(Collider2D playerClock)
    {
        if(playerClock.gameObject.tag == "Player")
        {   
            StairsAnimator.SetBool("InStaurZone", true);
            
             
                if (timeBtwAttack <= 0)
                {
            
                    if(Input.GetKey(KeyCode.E))
                    {
                    timeBtwAttack = startTimeBtwAttack;
                    PlayerAnim.SetTrigger("Medal");
                    ChangeTime();
                    }
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }
                
                
            
        }
    }
    public void ChangeTime()
    {
                if(InPast == true)
                {
                    
                    StairsAnimator.SetTrigger("Destroy");
                    StairsCollider.enabled = false;
                    ClockAnimator.SetTrigger("Future");
                    InPast = false;
                }
                else
                {   
                    Debug.Log("ch");
                    StairsAnimator.SetTrigger("Build");
                    StartCoroutine("ColliderCoroutine");
                    ClockAnimator.SetTrigger("Past");
                    InPast = true;
                }
    }
    public void OnTriggerExit2D(Collider2D playerClock)
    {
        if(playerClock.gameObject.tag == "Player")
        { 
            StairsAnimator.SetBool("InStaurZone", false);
        }
    }
    IEnumerator ColliderCoroutine()
    {
        yield return new WaitForSeconds(1.8f);
        StairsCollider.enabled = true;
    }
}
