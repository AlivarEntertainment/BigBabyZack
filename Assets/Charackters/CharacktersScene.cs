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
        if(PrefIdin >= 2)
        {
            ArrIdin = 1;
        }
        if (PrefIdin >= 3)
        {
            ArrIdin = 3;
        }
        if (PrefIdin >= 10)
        {
            ArrIdin = 5;
        }
        for (int i = 0; i < ArrIdin; i++)
        {
            Characters[i].SetActive(true);
        }
    }

}
