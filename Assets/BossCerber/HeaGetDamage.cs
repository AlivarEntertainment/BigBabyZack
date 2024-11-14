using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeaGetDamage : MonoBehaviour
{
    public Slider CerberHealthSlider;
    public CerberController cerberController;
    public static int Health = 75;

    public void Start()
    {
        Health = 75;
    }
    public void Update()
    {
        if(Health <= 1 )
        {
            cerberController.CerberAnimator.SetTrigger("Die");
            cerberController.enabled = false;
        }
       
    }
    public void OnTriggerEnter2D(Collider2D ArrowOther)
    {
        if(ArrowOther.gameObject.tag == "Arrow")
        {   
            
            Health -= 1;
            CerberHealthSlider.value = Health;
        }
        if(ArrowOther.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(12);
        }
    }
}
