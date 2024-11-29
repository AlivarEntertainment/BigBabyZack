using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeaGetDamage : MonoBehaviour
{
    public Slider CerberHealthSlider;
    public CerberController cerberController;
    public MainLyfe mainLyfe;
    
    public static int Health = 65;
    public PlayerController playerController;

    public void Start()
    {
        Health = 65;
        PlayerPrefs.SetString("Cerber", "start");
    }
    public void Update()
    {
        if(Health <= 1 )
        {
            cerberController.CerberAnimator.SetTrigger("Die");
            cerberController.enabled = false;
            PlayerPrefs.SetString("Cerber", "finish");
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
            if(mainLyfe.Lyfes[1].IsDead == true)
            {
                mainLyfe.lives = 3;
                PlayerPrefs.SetInt("Lives", 3);
                SceneManager.LoadScene(12);
            }
            else
            {   
                mainLyfe.PlayerTakeDamage();
                playerController.PlayerAnimator.SetTrigger("Stan");
                playerController.enabled = false;
                StartCoroutine("PlayerStan");
                playerController.rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }
    IEnumerator PlayerStan()
    {
        yield return new WaitForSeconds(1.5f);
        
            playerController.enabled = true;
            playerController.rb.bodyType = RigidbodyType2D.Dynamic;
        
    }
}
