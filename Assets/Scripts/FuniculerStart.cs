using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class FuniculerStart : MonoBehaviour
{
    public BoxObida[] boxObidas;
    public PlayableDirector playableFuniculer;
    public void FixedUpdate()
    {
        if(boxObidas[0].DoneQuest == true && boxObidas[1].DoneQuest == true)
        {
            StartCoroutine("PlayFunic");
        }
    }
    IEnumerator PlayFunic()
    {
        yield return new WaitForSeconds(2f);
        playableFuniculer.Play();
    }
}
