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
        if (scene == 0 && audioSource.clip == audioClips[0] || scene == 0 && audioSource.clip != audioClips[3])
        {
            audioSource.clip = audioClips[3];
            audioSource.Play();
        }
        if (scene >= 4 && scene <= 5)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (scene >= 6 && audioSource.clip != audioClips[1] && scene <= 12)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
        if (scene == 13)
        {
            audioSource.clip = null;
            audioSource.Play();
        }
        if (scene == 14 || scene == 24)
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();
        }
        if (scene >= 19 && scene <= 23)
        {
            audioSource.clip = audioClips[6];
            audioSource.Play();
        }
        if (scene == 28)
        {
            audioSource.clip = null;
            audioSource.Play();
        }
        if(scene == 33)
        {
            audioSource.clip = audioClips[5];
            audioSource.Play();
        }

    }
    
}
