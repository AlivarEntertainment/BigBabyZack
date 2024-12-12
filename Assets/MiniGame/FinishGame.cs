using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public BoxObida boxObida;
    public PlayerController playerController;
    public GameObject game;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            boxObida.DoneQuest = true;
            game.SetActive(false);
            playerController.enabled = true;
        }
    }
}
