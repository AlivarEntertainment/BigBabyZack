using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelfDestroy : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public void OnLevelWasLoaded()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(scene);
        if (scene == 2)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (scene == 3)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
        if (scene == 10)
        {
            audioSource.clip = null;
            audioSource.Play();
        }
        if (scene == 11)
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();
        }
    }
    
}
