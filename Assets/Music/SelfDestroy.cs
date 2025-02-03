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
       /*if (scene > 17)
        {
            audioSource.clip = audioClips[4];
            audioSource.volume = 0.1f;
            audioSource.Play();
        }*/
        if (scene == 0 && audioSource.clip == audioClips[0] || scene >= 15 && audioSource.clip == audioClips[0] || scene == 0 && audioSource.clip != audioClips[3])
        {
            audioSource.clip = audioClips[3];
            audioSource.Play();
        }
        if (scene == 1)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (scene >= 3 && audioSource.clip != audioClips[1] && scene <= 9)
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
        if (scene == 28)
        {
            audioSource.clip = null;
            audioSource.Play();
        }

    }
    
}
