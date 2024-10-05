using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHeath = 5;
    public int currentHealth;
    //121212
    void Start()
    {
        currentHealth = maxHeath;
    }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {   
        Debug.Log("Pomer");
        //animator
    }
}
