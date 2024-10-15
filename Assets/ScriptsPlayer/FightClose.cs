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
    public void Update()
    {
        if(pressedAttacking == true)
        {   
            TimeStart += Time.deltaTime;
            if(TimeStart >= timeToHold)
            {
                Debug.Log("Колющий удар");
              
                AttackDamage = 3;
                AttackRub();
                TimeStart = 0;
                pressedAttacking = false;
                IsDashing = true;
            }
            
        }
        else
        {   
            if(TimeStart < timeToHold && TimeStart >= 0.01f)
            {
                Debug.Log("рубящий удар");
                AttackDamage = 1;
                AttackRub();
                TimeStart = 0;
            }
            
        }
        if(IsDashing == true)
        {
            if(playerController.facingRight == true)
            {   
                if(TimeDashing <= TimeToDash)
                {   
                    TimeDashing += Time.deltaTime;
                    playerController.rb.AddForce(Vector3.right * 100);
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
                    playerController.rb.AddForce(Vector3.right * -100);
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
    public void OnAttackButDown()
    {
        pressedAttacking = true;
    }
    public void OnAttackButUp()
    {
        pressedAttacking = false;
    }
}
