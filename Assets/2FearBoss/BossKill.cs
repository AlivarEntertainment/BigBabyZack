using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossKill : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("OgurecLocation", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(35);
        }
    }
}
