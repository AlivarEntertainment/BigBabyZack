using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeaGetDamage : MonoBehaviour
{
    public Slider CerberHealthSlider;
    public static int Health = 50;

    public void Start()
    {
        Health = 50;
    }
    public void OnTriggerEnter2D(Collider2D ArrowOther)
    {
        if(ArrowOther.gameObject.tag == "Arrow")
        {   
            Debug.Log("He");
            Health -= 1;
            CerberHealthSlider.value = Health;
        }
        if(ArrowOther.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(13);
        }
    }
}
