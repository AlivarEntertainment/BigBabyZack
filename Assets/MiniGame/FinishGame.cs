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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            boxObida.DoneQuest = true;
            StartCoroutine("DestroyGame");
            playerController.enabled = true;
            FinishLight.Play();
        }
    }
    IEnumerator DestroyGame()
    {
        yield return new WaitForSeconds(3f);
        Destroy(game);
        
    }
}
