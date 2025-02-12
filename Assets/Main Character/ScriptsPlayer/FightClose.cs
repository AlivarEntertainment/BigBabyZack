using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightClose : MonoBehaviour
{   
    public bool pressedAttacking;
    public Transform attackPoint;

    public int AttackDamage;
    public int attackRange;
    public LayerMask WhatIsEnemy;
    public float timeToHold;
    public float TimeStart = 0;
    //public Rigidbody2D playerRB;
    public PlayerController playerController;
    public float TimeToDash;
    public float TimeDashing;
    public bool IsDashing = true;
    public Animator playerAnim;
    public AudioSource SwordAuSor;
    public void Start()
    {
        SwordAuSor = attackPoint.gameObject.GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressedAttacking = true;
            

        }
        if (Input.GetMouseButtonUp(0))
        {
            pressedAttacking = false;
        }
    }
    public void FixedUpdate()
    {
        if(pressedAttacking == true)
        {   
            TimeStart += Time.deltaTime;
            if(TimeStart >= timeToHold)
            {   
                SwordAuSor.pitch = Random.Range(0.8f, 1.2f);
                SwordAuSor.Play();
                Debug.Log("Колющий удар");
                playerAnim.SetTrigger("Kolit");
                AttackDamage = 3;
                AttackRub();
                TimeStart = 0;
                pressedAttacking = false;
                IsDashing = true;
            }
            
        }
        else if (TimeStart < timeToHold && TimeStart >= 0.01f)
        {
            SwordAuSor.pitch = Random.Range(0.8f, 1.2f);
            SwordAuSor.Play();
            Debug.Log("рубящий удар");
            playerAnim.SetTrigger("Rubit");
            AttackDamage = 1;
            AttackRub();
            TimeStart = 0;
            pressedAttacking = false;
        }
        if (IsDashing == true)
        {
            if(playerController.facingRight == true)
            {   
                if(TimeDashing <= TimeToDash)
                {   
                    TimeDashing += Time.deltaTime;
                    playerController.rb.AddForce(Vector3.right * 600);
                }
                else
                {
                    IsDashing = false;
                    TimeDashing = 0;
                }
            }
            else
            {
                if(TimeDashing <= TimeToDash)
                {   
                    TimeDashing += Time.deltaTime;
                    playerController.rb.AddForce(Vector3.right * -600);
                }
                else
                {
                    IsDashing = false;
                    TimeDashing = 0;
                }
            }
        }
        
    }
    void AttackRub()
    {
        //animator attackRub
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, WhatIsEnemy);
        foreach(Collider2D enemy in hitEnemies)
        {   
            enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
        }

    }
    /*public void OnDown()
    {
        pressedAttacking = true;
    }
    public void OnAttackButUp()
    {
        pressedAttacking = false;
    }*/
}
