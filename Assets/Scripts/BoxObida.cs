using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BoxObida : MonoBehaviour
{   
    public bool IsRoof;
    public PlayableDirector FinicLight;
<<<<<<< HEAD
=======
    public GameObject TriggerMinigame;
>>>>>>> b1046b8 (Roof)
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
<<<<<<< HEAD
            DoneQuest = true;
=======
            
            TriggerMinigame.SetActive(true);
>>>>>>> b1046b8 (Roof)
        }
    }
}
