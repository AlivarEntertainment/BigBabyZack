using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeaGetDamage : MonoBehaviour
{
    public Slider CerberHealthSlider;
    public CerberController cerberController;
    public static int Health = 100;

    public void Start()
    {
        Health = 100;
    }
    public void Update()
    {
        if(cerberController.NextFinalPoint == 1 && Health <= 0 || cerberController.NextFinalPoint == 3  && Health <= 0)
        {   
            cerberController.CanGoRL = false;
            cerberController.GoRight();
        }
        else if(Health <= 1 && cerberController.CanGoRL == false)
        {
            cerberController.CerberAnimator.SetTrigger("Die");
            cerberController.enabled = false;
        }
       
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
            SceneManager.LoadScene(12);
        }
    }
}
