using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cart : MonoBehaviour
{
    public bool CanRide;
    public PlayableDirector CartAnimator;
    public GameObject playerController;
    public ChaneAndPlay chaneAndPlay;
    public AudioSource audioSource;
    
    public void OnTriggerEnter2D(Collider2D PlayerInCart)
    {
        if(PlayerInCart.gameObject.tag == "Player" && CanRide == true)
        {
            CartAnimator.Play();
            Destroy(playerController);
            StartCoroutine("PlayTimeLine");
            audioSource.Play();
        }
    }
    IEnumerator PlayTimeLine()
    {
        yield return new WaitForSeconds(2.3f);
        chaneAndPlay.PlayTime();
    }
}
