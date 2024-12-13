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
            Destroy(game);
            playerController.enabled = true;
            FinishLight.Play();
        }
    }
}
