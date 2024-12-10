using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthOnBoss : MonoBehaviour
{
    public MainLyfe mainLyfe;
    public PlayerController playerController;
    public Collider2D playerCollider;
    public void OnTriggerEnter2D(Collider2D BossCollider)
    {
        if(BossCollider.gameObject.tag == "CerberJump")
        {   
            if(mainLyfe.Lyfes[1].IsDead == true)
            {
                mainLyfe.lives = 3;
                PlayerPrefs.SetInt("Lives", 3);
                SceneManager.LoadScene(24);
            }
            else
            {   
                playerCollider.isTrigger = true;
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
        yield return new WaitForSeconds(2f);
        
            playerController.enabled = true;
            playerController.rb.bodyType = RigidbodyType2D.Dynamic;
            playerCollider.isTrigger = false;
        
    }
}
