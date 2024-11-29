using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Change : MonoBehaviour
{
    public int sceneNumber;
    public Animator FadeAnimator;
    public void Start()
    {
        Debug.Log("����");
    }
    public void OnTriggerEnter2D(Collider2D otherPlayer)
    {
        if (otherPlayer.gameObject.tag == "Player")
        {   
            StartCoroutine("FadeEndCor");
            FadeAnimator.SetTrigger("EndLevel");
            
        }
    }
    public void ChangeSvene()
    {
        Debug.Log("Change");
        SceneManager.LoadScene(sceneNumber);
    }
    IEnumerator FadeEndCor()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(sceneNumber);
    }
}
