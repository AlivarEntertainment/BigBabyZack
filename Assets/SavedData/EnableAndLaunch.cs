using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnableAndLaunch : MonoBehaviour
{
   public int SceneToReach;
   public bool IsStart= false; 
    void Start()
    {
        int y = PlayerPrefs.GetInt("LevelReached");
        if(SceneToReach > y && IsStart == false)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnLoadLevelButtonClick()
    {
        SceneManager.LoadScene(SceneToReach);
    }
    
}
