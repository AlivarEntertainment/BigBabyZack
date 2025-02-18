using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveDoSmth : MonoBehaviour
{
    public OpenChest openChest;
    public BoxPresent boxPresent;
    public int DoSmthID;
    public void Start()
    {
        DoSmthID = PlayerPrefs.GetInt("DoQuest");
    }
    public void FixedUpdate()
    {
        if(openChest.IsOpened == true || boxPresent.IsOpened == true)
        {
            DoSmthID += 1;
            PlayerPrefs.SetInt("DoQuest", DoSmthID);
            this.enabled = false;
        }

    }
}
