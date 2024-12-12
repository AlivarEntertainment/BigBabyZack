using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelfDestroy : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;
<<<<<<< HEAD

=======
    public bool IsAlreadyStarted = false;
    public void Awake()
    {
        IsAlreadyStarted = true;
    }
>>>>>>> b1046b8 (Roof)
    public void OnLevelWasLoaded()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(scene);
<<<<<<< HEAD
        if (scene == 2)
=======
        if (scene == 0 || scene == 25 || scene == 18)
        {
            audioSource.clip = audioClips[3];
            audioSource.Play();
        }
        if (scene == 1)
>>>>>>> b1046b8 (Roof)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
<<<<<<< HEAD
        if (scene == 3)
=======
        if (scene >= 3 && audioSource.clip != audioClips[1] && scene <= 9)
>>>>>>> b1046b8 (Roof)
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
