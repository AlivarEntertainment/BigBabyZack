using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NatanSpeal : MonoBehaviour
{
    [SerializeField]private PlayableDirector DialogTL;
    [SerializeField]private Animator PressE;
    bool used = false;
    public AudioSource audioSource;
    public PlayerController playerController;
    float PlayerSpeed;
    public bool UpperDialogue;
    private int SpeakTime;
    public AudioSource AchiveAudio;
    void Start()
    {
        PlayerSpeed = playerController.speed;
        SpeakTime = PlayerPrefs.GetInt("Natan");
        
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && used == false)
        {   
            PressE.SetBool("IsInFade", false);
            if(Input.GetKey(KeyCode.E))
            {   
                AchiveAudio.Play();
                DialogTL.Play();
                //PressE.SetBool("IsInFade", true);
                PressE.SetBool("IsInFade", true);
                used = true;
                SpeakTime+= 1;
                PlayerPrefs.SetInt("Natan", SpeakTime);
                
                audioSource.Play();
                if(UpperDialogue == true)
                {
                    playerController.speed = 0.4f;
                    StartCoroutine("ReturnSpeed");
                }
            }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
    IEnumerator ReturnSpeed()
    {
        yield return new WaitForSeconds(13);
        playerController.speed = PlayerSpeed;
    }
}
