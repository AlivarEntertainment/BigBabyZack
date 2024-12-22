using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PlayFearTime : MonoBehaviour
{
    public PlayableDirector SpiderDirector;
    public GameObject playerPlayable;
    
    public void OnTriggerEnter2D(Collider2D PlayerLever)
    {
        if(PlayerLever.gameObject.tag == "Player")
        {   
            SpiderDirector.Play();
            playerPlayable.SetActive(false);
        }
    }
   
}
