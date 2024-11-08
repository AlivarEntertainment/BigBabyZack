using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MegaDoor : MonoBehaviour
{
    public SpriteRenderer LockSpriteRenderer;
    public static int GreenLocks = 0;
    public bool IsTarget;
    public PlayableDirector CameraToLockDirector;
    public Animator LockDoorAnimator;
    public bool IsUsed;
    public void Start()
    {
        GreenLocks = 0;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsTarget == false)
        {
            if (Input.GetKey(KeyCode.E) && IsUsed == false)
            {
                LockSpriteRenderer.color = Color.green;
                GreenLocks += 1;
                Debug.Log(GreenLocks);
                CameraToLockDirector.Play();
                IsUsed = true;
                if (GreenLocks == 3)
                {
                    LockDoorAnimator.SetTrigger("OpenLockDoor");
                }
            }
        }
        if(collision.gameObject.tag == "Arrow" && IsTarget == true && IsUsed == false)
        {
            LockSpriteRenderer.color = Color.green;
            GreenLocks += 1;
            CameraToLockDirector.Play();
            IsUsed = true;
            if (GreenLocks == 3)
            {
                LockDoorAnimator.SetTrigger("OpenLockDoor");
            }
        }
    }
    
}
