using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    public Transform attackPoint;
    public int attackRange;
    public LayerMask WhatIsEnemy;
    public int AttackDamage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("SelfDestroyer");
    }

    // Update is called once per frame
    void Update()
    {   
        if(hasHit == false)
        {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        AttackArrow();
        }
    }
    private void OnCollisionEnter2D(Collision collision)
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        if(collision.gameObject.tag == "GroundTag")
        {
            this.enabled = false;
        }
    }
    void AttackArrow()
    {
        //animator attackRub
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, WhatIsEnemy);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
            Destroy(this.gameObject);
        }
        
    }
    IEnumerator SelfDestroyer()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
