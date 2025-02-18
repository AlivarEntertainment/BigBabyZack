using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacktersScene : MonoBehaviour
{
    public GameObject[] Characters;
    public int PrefIdin;
    public int ArrIdin;
    void Start()
    {
        PrefIdin = PlayerPrefs.GetInt("LevelReached");
        Debug.Log(PrefIdin);
        if(PrefIdin >= 4)
        {
            ArrIdin = 1;
        }
        if (PrefIdin >= 5)
        {
            ArrIdin = 3;
        }
        if (PrefIdin >= 14)
        {
            ArrIdin = 5;
        }
        if (PrefIdin >= 19)
        {
            ArrIdin = 6;
        }
        if (PrefIdin >= 24)
        {
            ArrIdin = 7;
        }
        if (PrefIdin >= 29)
        {
            ArrIdin = 8;
        }
        for (int i = 0; i < ArrIdin; i++)
        {
            Characters[i].SetActive(true);
        }
    }

}
