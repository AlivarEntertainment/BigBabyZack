using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class DogTimeline : MonoBehaviour
{
    public PlayableDirector DogTimelineDirector;
    public PlayerController playerController;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && playerController.facingRight == false)
        {
            DogTimelineDirector.Play();
            playerController.enabled = false;
            StartCoroutine("ToBossScene2");
        }        
    }
    public IEnumerator ToBossScene2()
    {
        yield return new WaitForSeconds(18f);
        SceneManager.LoadScene(14);
    }
}
