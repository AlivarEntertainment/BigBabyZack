using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHeath = 5;
    public int currentHealth;
    bool facingRight = true;
    public Animator EnemyAnimator;
    public Collider2D EnemyCollider;
    public Rigidbody2D rigidbody;
    [Header("Patroler")]
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;

    Transform player;
    public float StoppingDistance;
    bool chill = false;
    public float Dist;
    bool angry = false;
    bool goBack = false;

    [Header("Attack")]
    public int attackRange;
    public LayerMask WhatIsPlayer;
    public Transform attackPoint;
    private float timeBtwAttack;
    public float startTimeBtwAttack = 2;
    public bool IsFast = false;
  
    //121212
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHeath;
    }
    void FixedUpdate()
    {   
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        Dist = Vector2.Distance(transform.position, player.position);
        if(Dist > StoppingDistance)
        {
            goBack = true;
            angry = false;
        }
        if(Dist < StoppingDistance)
        {
           angry = true;
           chill = false;
           goBack = false;
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
        if(IsFast == false)
        {
            speed = 2;
        }
        else
        {
            speed = 6;
        }
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
            if(facingRight != true)
            {
                Flip();
            }
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            if(facingRight == true)
            {
                Flip();
            }
        }

    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 3;
        if(Dist <= 1.7f)
        {
            EnemyAnimator.SetTrigger("Attack");
        }
        //AttackPlayer();
        if(player.position.x > transform.position.x && facingRight == false)
        {
            Flip();
        }
        else if(player.position.x < transform.position.x && facingRight != false)
        {
            Flip();
        }
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        EnemyAnimator.SetTrigger("Damage");
        if(currentHealth <= 0)
        {
            DieEnemy();
        }
    }
    public void DieEnemy()
    {
        EnemyCollider.enabled = false;
        EnemyAnimator.SetTrigger("Die");
        rigidbody.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }
    void AttackPlayer()
    {
        //if(timeBtwAttack <= 0.1f && angry == true)
        //{
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, WhatIsPlayer);
            foreach(Collider2D Playerr in hitPlayers)
            {   
                
                Playerr.GetComponent<MainLyfe>().PlayerTakeDamage();
            }
           // timeBtwAttack = startTimeBtwAttack;
        //}
       // else
        //{
            //timeBtwAttack -= Time.deltaTime;
        //}
        

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
