using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BoxObida : MonoBehaviour
{   
    public bool IsRoof;
    public PlayableDirector FinicLight;
    public GameObject TriggerMinigame;
    public bool DoneQuest;
    public void OnTriggerEnter2D(Collider2D BoxStartTime)
    {
        if(BoxStartTime.gameObject.tag == "Box" && IsRoof == false)
        {
            FinicLight.Play();
            DoneQuest = true;
        }
        else if(BoxStartTime.gameObject.tag == "Player" && IsRoof == true)
        {
            FinicLight.Play();
            
            TriggerMinigame.SetActive(true);
        }
    }
}
