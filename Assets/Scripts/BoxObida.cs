using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BoxObida : MonoBehaviour
{   
    public bool IsRoof;
    public PlayableDirector FinicLight;
    public GameObject TriigerGame;
    public bool DoneQuest;
    public AudioSource ProvodAS;
    public void OnTriggerEnter2D(Collider2D BoxStartTime)
    {   
        if(BoxStartTime.gameObject.tag == "Box" && IsRoof == false)
        {
            FinicLight.Play();
            DoneQuest = true;
            ProvodAS.Play();
            StartCoroutine("MuteProvod");
        }
        else if(BoxStartTime.gameObject.tag == "Player" && IsRoof == true)
        {
            FinicLight.Play();
            TriigerGame.SetActive(true);
        }
    }
    IEnumerator MuteProvod()
    {
        yield return new WaitForSeconds(3);
        //LockSpriteRenderer.color = Color.green;
        ProvodAS.mute = true;
    }
}
