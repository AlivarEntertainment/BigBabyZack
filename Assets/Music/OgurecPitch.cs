using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgurecPitch : MonoBehaviour
{
    private AudioSource audioSource12;
    public float pitchAudio;
    public PlayerController playerController;
    public ChuchukaController chuchukaController;
    [SerializeField]public bool IsLimbo;
    [SerializeField] public bool IsTrainsOgurec;
    [Header("ChangeOboi")]
    public GameObject OboiFr;
    public GameObject OboiSc;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   
            OboiFr.SetActive(false);
            OboiSc.SetActive(true);
            
                playerController.jumpForce = 18;
                Debug.Log("1");
            if(IsLimbo == false)
            {
                playerController.jumpForce = 14;
                playerController.checkRadius = 1.1f;
                chuchukaController.speed = 5f;
            }
            if(IsTrainsOgurec == true)
            {
                 Screen.SetResolution(700, 300, true);
                 chuchukaController.speed = 8f;
                 Debug.Log("Chanh");
            }
           audioSource12 = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
            audioSource12.pitch = pitchAudio;
            
            
        }
    }
}
