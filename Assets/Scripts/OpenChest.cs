using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{   
    [SerializeField]public bool IsOpened = false;
    public GameObject sword;
    public Animator animatorChest;
    [SerializeField]private Animator PressE;
    [SerializeField] private FightClose FightButton;
    [SerializeField] private GameObject leverGameObject;
    [SerializeField] private Bow bowScr;
    [SerializeField] private Lever Lever;
    public AudioSource ChestAudioSource;
    public AudioSource AchiveAudio;
    public void Start()
    {
        //bowScr.enabled = false;
    }
    public void OnTriggerStay2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player" && IsOpened == false)
        {   
            PressE.SetBool("IsInFade", false);
           if (Input.GetKey(KeyCode.E))
           {    
            AchiveAudio.Play();
            ChestAudioSource.Play();
                StartCoroutine(OpneChestCor());
                animatorChest.SetTrigger("Open");
                FightButton.enabled = true;
                leverGameObject.SetActive(true);
                
                Lever.enabled = true;
           }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
    public IEnumerator OpneChestCor()
    {
        yield return new WaitForSeconds(0.65f);
        IsOpened = true;
        PressE.SetBool("IsInFade", true);
        sword.SetActive(true);
        bowScr.enabled = true;
    }
}
