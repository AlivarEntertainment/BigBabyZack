using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class FuniculerStart : MonoBehaviour
{
    public BoxObida[] boxObidas;
    public PlayableDirector playableFuniculer;
    public AudioSource FunicAs;
    public void FixedUpdate()
    {
        if(boxObidas[0].DoneQuest == true && boxObidas[1].DoneQuest == true)
        {   
            boxObidas[0].DoneQuest = false;
            StartCoroutine("PlayFunic");
            
            FunicAs.Play();
        }
    }
    IEnumerator PlayFunic()
    {
        yield return new WaitForSeconds(2f);
        playableFuniculer.Play();
        
        StartCoroutine("MuteFunic");
    }
     IEnumerator MuteFunic()
    {
        yield return new WaitForSeconds(3);
        //LockSpriteRenderer.color = Color.green;
       FunicAs.mute = true;
    }
}
