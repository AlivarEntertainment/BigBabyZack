using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLyfe : MonoBehaviour
{
    public LyfeContr[] Lyfes;
    public Animator DeadPanelAnimator;
    /*public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerTakeDamage();
        }
    }*/
    public void Update()
    {
        if(Lyfes[2].IsDead == true)
        {
            Die();
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
                    break;
                }
            }
    }
    void Die()
    {   
        Debug.Log("Pomer");
        Destroy(this.gameObject);
        DeadPanelAnimator.SetTrigger("Appear");
    }
    
}
