using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgurecPitch : MonoBehaviour
{
    private AudioSource audioSource12;
    public float pitchAudio;
    public PlayerController playerController;
    [SerializeField]public bool IsLimbo;
    [SerializeField] public bool IsStartOgurec;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           audioSource12 = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
            audioSource12.pitch = pitchAudio;
            if(IsLimbo == true)
            {
                playerController.jumpForce = 18;
            }
            else
            {
                playerController.jumpForce = 14;
                playerController.checkRadius = 1.1f;
            }
        }
    }
}
