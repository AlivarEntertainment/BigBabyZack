using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveKey : MonoBehaviour
{   
    public int ThisLevelId;
   void Start()
    { 
        ThisLevelId = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LevelReached", ThisLevelId);
    } 
}
