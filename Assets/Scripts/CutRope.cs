using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutRope : MonoBehaviour
{   
    [Header("ForMost")]
    public Animator MostAnimator;
    public PlayableDirector CameraToMost;
    public bool AlreadyShooted;
    public Animator RopeAnimator;
    [Header("ForStone")]
    public bool IsForStone;
    public Rigidbody2D StoneRB;
    public PlayableDirector CameraToStone;
    
    public void Start()
    {
        Debug.Log("Rope");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Arrow" && AlreadyShooted == false)
        {   
            if(IsForStone == false)
            {
                MostAnimator.SetTrigger("OpenMostR");
                CameraToMost.Play();
            }
            else
            {
                StoneRB.bodyType = RigidbodyType2D.Dynamic;
                CameraToStone.Play();
            }
            this.RopeAnimator.SetTrigger("Fall");
            AlreadyShooted = true;
        }
    }
}
