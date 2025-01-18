using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public class PlayFearTime : MonoBehaviour
{
    public PlayableDirector SpiderDirector;
    public GameObject playerPlayable;
    
    public void OnTriggerEnter2D(Collider2D PlayerLever)
    {
        if(PlayerLever.gameObject.tag == "Player")
        {   
            SpiderDirector.Play();
            playerPlayable.SetActive(false);
            StartCoroutine("ChangeScene");
        }
    }
   IEnumerator ChangeScene()
   {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(21);
   }
}
