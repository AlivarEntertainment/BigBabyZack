using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{   
    public bool CanWork = false;
    public Animator ClockAnimator;
    public Animator StairsAnimator;
    public Collider2D StairsCollider;
    public Animator PlayerAnim;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public bool InPast = false;
    public AudioSource StairsAs;
    public void Start()
    {
        Debug.Log("7");
    }
    public void OnTriggerStay2D(Collider2D playerClock)
    {
        if(playerClock.gameObject.tag == "Player")
        {   
            StairsAnimator.SetBool("InStaurZone", true);
            
             
                if (timeBtwAttack <= 0)
                {
            
                    if(Input.GetKey(KeyCode.E) && CanWork == true)
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
        StairsAs.mute = false;
        StartCoroutine("MuteAudio");
                if(InPast == true)
                {   
                    
                    StairsAs.pitch = 1.4f;
                    StairsAs.Play();
                    StairsAnimator.SetTrigger("Destroy");
                    StairsCollider.enabled = false;
                    ClockAnimator.SetTrigger("Future");
                    InPast = false;
                }
                else
                {   
                    StairsAs.pitch = 0.7f;
                    StairsAs.Play();
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
        StairsAs.mute = true;
    }
    IEnumerator MuteAudio()
    {
        yield return new WaitForSeconds(2);
        StairsAs.mute = true;
    }
}
