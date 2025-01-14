using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVertical : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator CameraAnimator;
    public Vector2 TargetPos;
    public Transform[] TargetTrans;
    public Collider2D HandCollider;
    public int CurrentTarget = 0;
    public float speed = 10.0f;
    public bool FinPos = false;
    void Start()
    {
        HandCollider.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(CurrentTarget != 3)
        {
            TargetPos = new Vector2(this.transform.position.x, TargetTrans[CurrentTarget].position.y);
        }
        
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, step);
        if(transform.position.y == TargetTrans[CurrentTarget].position.y)
        {
            CurrentTarget += 1;
            if(CurrentTarget == 2)
            {
            CameraAnimator.SetTrigger("Punch");
            }
            if(CurrentTarget == 3)
            {   
                HandCollider.enabled = true;
                TargetPos = new Vector2(this.transform.position.x + Random.Range(-8, 8), TargetTrans[CurrentTarget].position.y);
            }
        }
        
        else if(CurrentTarget == 4 && FinPos == false)
        {
            CameraAnimator.SetTrigger("Punch");
            StartCoroutine("FlyAway");
            HandCollider.enabled = false;
            FinPos = true;
        }
        
        if(CurrentTarget == 0)
        {
            spriteRenderer.sortingOrder = -1;
        }
        else if(CurrentTarget == 1){
            spriteRenderer.sortingOrder = 4;
            HandCollider.enabled = true;

        }
        
    }
    IEnumerator FlyAway()
    {
        yield return new WaitForSeconds(2.3f);
        CurrentTarget += 1;

    }
}
