using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class ChaneAndPlay : MonoBehaviour
{
     public int sceneNumber;
     public PlayableDirector playableDirector;
    public bool IsPerehod;
    public void Start()
    {
        Debug.Log("����");
    }
    public void OnTriggerEnter2D(Collider2D otherPlayer)
    {
        if (otherPlayer.gameObject.tag == "Player")
        {   
            PlayTime();
            
        }
    }
    public void PlayTime()
    {
        Debug.Log("Start");
            playableDirector.Play();
            if (IsPerehod == false) {
                StartCoroutine("TimelineCor");
            }
    }
    public IEnumerator TimelineCor()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneNumber);
    }
}
