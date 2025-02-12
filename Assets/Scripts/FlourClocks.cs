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
    public GameObject boxSoftBlocker;
    public AudioSource StairsAs;
    public void ChangeDownTime()
    {   
        StairsAs.mute = false;
        StartCoroutine("MuteAudio");
        if(InPast == true)
        {
            StairsAs.pitch = 1.4f;
                    StairsAs.Play();
            ClocksAnim.SetBool("Past", false);
            InPast = false;
            boxSoftBlocker.SetActive(true);
        }
        else
        {   
            StairsAs.pitch = 0.7f;
                    StairsAs.Play();
            ClocksAnim.SetBool("Past", true);
            InPast = true;
            boxSoftBlocker.SetActive(false);
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
    IEnumerator MuteAudio()
    {
        yield return new WaitForSeconds(2);
        StairsAs.mute = true;
    }
}
