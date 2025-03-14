using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgurecFly : MonoBehaviour
{
    public Animator OgurecAnimator;
    private GameObject target=null;
    private Vector3 offset;

    void Start(){
	target = null;
}

    void OnTriggerStay2D(Collider2D col)
    {
	target = col.gameObject;
	offset = target.transform.position - transform.position;
    }
    void OnTriggerExit2D(Collider2D col)
    {
	target = null;
    }

    void LateUpdate()
    {
	if (target != null) 
    {
		target.transform.position = transform.position+offset;
	}

    }
    public void OnTriggerEnter2D()
    {
        OgurecAnimator.SetTrigger("GoOgurec");
    }
    
}
