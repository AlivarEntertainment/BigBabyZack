using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    private SelfDestroy audioSource12;
    public bool IsFearStart;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource12 = GameObject.FindGameObjectWithTag("Sound").GetComponent<SelfDestroy>();
            if (IsFearStart == true)
            {
                audioSource12.audioSource.clip = audioSource12.audioClips[6];
                
            }
            else
            {
                audioSource12.audioSource.clip = audioSource12.audioClips[5];
                audioSource12.audioSource.Play();
            }
            
        }
    }
}
