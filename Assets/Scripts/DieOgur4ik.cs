using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DieOgur4ik : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D PlayerCol)
    {
        if(PlayerCol.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("OgurecLocation", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(34);
        }
    }
}
