using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHeath = 5;
    public int currentHealth;
    [Header("Patroler")]
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;

    Transform player;
    public float StoppingDistance;
    bool chill = false;
    bool angry = false;
    bool goBack = false;
    //121212
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHeath;
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if(Vector2.Distance(transform.position, player.position) < StoppingDistance)
        {
           angry = true;
           chill = false;
           goBack = false;
        }
        if(Vector2.Distance(transform.position, player.position) > StoppingDistance)
        {
            goBack = true;
            angry = false;
        }
        if(chill == true)
        {
            Chill();
        }
        else if(angry == true)
        {
            Angry();
        }
        else if(goBack == true)
        {
            GoBack();
        }
    }
    void Chill()
    {   
        speed = 2;
        if(transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
        }
        else if(transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        }
        if(moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        }
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 3;
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
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
