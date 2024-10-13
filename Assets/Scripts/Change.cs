using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Change : MonoBehaviour
{
    public int sceneNumber;
    public void Start()
    {
        Debug.Log("ûûûû");
    }
    public void OnTriggerEnter2D(Collider2D otherPlayer)
    {
        if (otherPlayer.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
