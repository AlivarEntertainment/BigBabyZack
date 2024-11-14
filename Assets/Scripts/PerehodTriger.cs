using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PerehodTriger : MonoBehaviour
{
    public PlayableDirector PerehodDirector;
    public void OnTriggerEnter2D(Collider2D otherPlayer)
    {
        if (otherPlayer.gameObject.tag == "Player")
        {   
            PerehodDirector.Play();
        }
    }
}
