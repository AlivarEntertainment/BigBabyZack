using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFlyObject : MonoBehaviour
{
    public float SecondsToAudio;
    public Animator FlyAssetAnimator;
    public AudioSource audioSource;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine("PlayAudio");
            FlyAssetAnimator.SetTrigger("Fly");
        }
    }
    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(SecondsToAudio);
        audioSource.Play();
    }
}
