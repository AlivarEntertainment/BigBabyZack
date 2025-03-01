using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinishGame : MonoBehaviour
{
    public BoxObida boxObida;
    public PlayerController playerController;
    public GameObject game;
    public PlayableDirector FinishLight;
    public AudioSource ProvodAS;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            boxObida.DoneQuest = true;
            StartCoroutine("DestroyGame");
            
            FinishLight.Play();
            ProvodAS.Play();
            StartCoroutine("MuteProvod");
        }
    }   
    IEnumerator MuteProvod()
    {
        yield return new WaitForSeconds(2f);
        //LockSpriteRenderer.color = Color.green;
        ProvodAS.mute = true;
        playerController.enabled = true;
    }
    IEnumerator DestroyGame()
    {   
        yield return new WaitForSeconds(3f);
        Destroy(game);
        
    }
}
