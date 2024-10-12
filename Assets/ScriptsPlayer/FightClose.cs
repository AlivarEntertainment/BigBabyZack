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
