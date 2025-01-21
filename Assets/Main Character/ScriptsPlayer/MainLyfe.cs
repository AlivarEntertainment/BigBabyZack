using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLyfe : MonoBehaviour
{
    public LyfeContr[] Lyfes;
    public Animator DeadPanelAnimator;
    public Animator BloodAnim;
    public int lives = 3;
    public void Start()
    {   
        if(PlayerPrefs.HasKey("Lives"))
        {
            lives = PlayerPrefs.GetInt("Lives");
        }
        else
        {
            lives = 3;
        }
        if(lives <= 2)
        {   
            Debug.Log(lives);
            Lyfes[0].RedNGreen[0].SetActive(true);
            Lyfes[0].RedNGreen[1].SetActive(false);
            Lyfes[0].IsDead = true;
            if((lives <= 1))
            {
                Lyfes[1].RedNGreen[0].SetActive(true);
                Lyfes[1].RedNGreen[1].SetActive(false);
                Lyfes[1].IsDead = true;
            }
        }
    }
    public void Update()
    {
        if(Lyfes[2].IsDead == true)
        {
            Die();
        }
        if(Lyfes[1].IsDead == true)
        {
            BloodAnim.SetBool("IsLow", true);
        }
        else
        {
            BloodAnim.SetBool("IsLow", false);
        }
    }
    public void PlayerTakeDamage()
    {
        for(int i = 0; i <= Lyfes.Length; i++)
            {
                if(Lyfes[i].IsDead != true)
                {
                    Lyfes[i].RedNGreen[0].SetActive(true);
                    Lyfes[i].RedNGreen[1].SetActive(false);
                    Lyfes[i].IsDead = true;
                    lives -= 1;
                    PlayerPrefs.SetInt("Lives", lives);
                    break;
                }
            }
    }
    public void GetHeal()
    {
        for(int i = 2; i <= Lyfes.Length; i--)
            {
                if(Lyfes[i].IsDead == true)
                {
                    Lyfes[i].RedNGreen[1].SetActive(true);
                    Lyfes[i].RedNGreen[0].SetActive(false);
                    Lyfes[i].IsDead = false;
                    lives += 1;
                    PlayerPrefs.SetInt("Lives", lives);
                    break;
                }
            }
    }
    void Die()
    {   
        Debug.Log("Pomer");
        Destroy(this.gameObject);
        //DeadPanelAnimator.SetTrigger("Appear");
        lives = 3;
        PlayerPrefs.SetInt("GnevLocation", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Lives", 3);
        SceneManager.LoadScene(17);
    }
    
}
