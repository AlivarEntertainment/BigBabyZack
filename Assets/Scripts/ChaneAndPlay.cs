using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class ChaneAndPlay : MonoBehaviour
{
     public int sceneNumber;
     public PlayableDirector playableDirector;
    public void Start()
    {
        Debug.Log("����");
    }
    public void OnTriggerEnter2D(Collider2D otherPlayer)
    {
        if (otherPlayer.gameObject.tag == "Player")
        {   
            playableDirector.Play();
            StartCoroutine("TimelineCor");
            
        }
    }
    public IEnumerator TimelineCor()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneNumber);
    }
}