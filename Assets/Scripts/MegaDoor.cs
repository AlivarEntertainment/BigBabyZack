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
    public Animator LeverAnimator;
    [SerializeField] private Animator PressE;
    public AudioSource LeverAS;
    public AudioClip CartaudioClip;
    public bool IsUsed;
    public void Start()
    {
        GreenLocks = 0;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsTarget == false)
        {
            PressE.SetBool("IsInFade", false);
            if (Input.GetKey(KeyCode.E) && IsUsed == false)
            {   
                LeverAS.Play();
                StartCoroutine("greenOnCor");
                GreenLocks += 1;
                Debug.Log(GreenLocks);
                CameraToLockDirector.Play();
                IsUsed = true;
                LeverAnimator.SetTrigger("UseLever");
                if (GreenLocks == 3)
                {   
                    LeverAS.clip = CartaudioClip;
                LeverAS.Play();
                    LockDoorAnimator.SetTrigger("OpenLockDoor");
                }
            }
        }
        if(collision.gameObject.tag == "Arrow" && IsTarget == true && IsUsed == false)
        {
            StartCoroutine("greenOnCor");
            GreenLocks += 1;
            LeverAS.Play();
            CameraToLockDirector.Play();
            IsUsed = true;
            LeverAnimator.SetTrigger("UseLever");
            if (GreenLocks == 3)
            {   
                LeverAS.clip = CartaudioClip;
                LeverAS.Play();
                LockDoorAnimator.SetTrigger("OpenLockDoor");
            }
        }
    }
    public void OnTriggerExit2D()
    {
        PressE.SetBool("IsInFade", true);
    }
    IEnumerator greenOnCor()
    {
        yield return new WaitForSeconds(1.7f);
        LockSpriteRenderer.color = Color.green;
        LeverAS.mute = true;
    }
}
