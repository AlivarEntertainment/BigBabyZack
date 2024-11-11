using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DogTimeline : MonoBehaviour
{
    public PlayableDirector DogTimelineDirector;
    public PlayerController playerController;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DogTimelineDirector.Play();
            playerController.enabled = false;
        }        
    }
}
