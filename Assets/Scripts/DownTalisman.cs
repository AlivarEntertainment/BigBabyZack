using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTalisman : MonoBehaviour
{
    public Animator LightAnimator;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Animator PlayerAnim;
    public Animator ProjectorBlockers;
    public bool InPast = false;
    public AudioSource StairsAs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeDownTime()
    {   
        StairsAs.mute = false;
        StartCoroutine("MuteAudio");
        if(InPast == true)
        {   
            StairsAs.pitch = 1.4f;
                    StairsAs.Play();
            ProjectorBlockers.SetBool("First", true);
            InPast = false;
        }
        else
        {   
            StairsAs.pitch = 0.7f;
                    StairsAs.Play();
            ProjectorBlockers.SetBool("First", false);
            InPast = true;
        }
    }
     public void OnTriggerStay2D(Collider2D playerClock)
    {
        if(playerClock.gameObject.tag == "Player")
        {   
            LightAnimator.SetBool("ClosePrj", true);
            if (timeBtwAttack <= 0)
                {
            
                    if(Input.GetKey(KeyCode.E))
                    {
                    timeBtwAttack = startTimeBtwAttack;
                    PlayerAnim.SetTrigger("Medal");
                    ChangeDownTime();
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
            LightAnimator.SetBool("ClosePrj", false);
        }
    }
    IEnumerator MuteAudio()
    {
        yield return new WaitForSeconds(2);
        StairsAs.mute = true;
    }
}
