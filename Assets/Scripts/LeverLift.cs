using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LeverLift : MonoBehaviour
{
    public GameObject LowBox;
    public GameObject HighBox;
    public PlayableDirector BoxDirector;
    public Animator LiftAnimator;
    public bool BoxInPosition;
    [SerializeField]private Animator PressE;
    [SerializeField]private Animator LeverAnimator;
    public void OnTriggerStay2D(Collider2D PlayerLever)
    {
        if(PlayerLever.gameObject.tag == "Player")
        {   
            PressE.SetBool("IsInFade", false);
            if(Input.GetKey(KeyCode.E))
            {
                UseLever();
                LeverAnimator.SetTrigger("UseLever");
            }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            BoxInPosition = true;
            Debug.Log("Box");
        }
    }
     
    public void UseLever()
    {   
        if(BoxInPosition == true)
        {
            LiftAnimator.SetTrigger("TakeBox");
            BoxDirector.Play();
            LowBox.SetActive(false);
            
            StartCoroutine("AfterLift");
        }
        else if(BoxInPosition == false)
        {   
            BoxDirector.Play();
            //LowBox.SetActive(false);
            LiftAnimator.SetTrigger("UseEmpty");
        } 
    }
    IEnumerator AfterLift()
    {
        yield return new WaitForSeconds(4.5f);
        HighBox.SetActive(true);
    }
}