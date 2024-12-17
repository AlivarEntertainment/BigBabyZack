using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPan : MonoBehaviour
{
    public Animator VinietAnimator;
    public GameObject PanelSet;
    public bool Pressed;
    public void Start()
    {
        Time.timeScale = 1f;
    }
    public void Update()
    {   
        if(Input.GetKey(KeyCode.Escape))
        {
             if(Pressed == false)
            {
            PanelSet.SetActive(true);
            VinietAnimator.SetBool("IsViniet", true);
            
                //Pressed = true;
            }
            else
            {   
           // Pressed = false;
            PanelSet.SetActive(false);
            VinietAnimator.SetBool("IsViniet", false);
                
            }
        }
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (Pressed == true)
            {
                Pressed = false;
                Time.timeScale = 1f;
            }
            else
            {
                Pressed = true;
                Time.timeScale = 0.12f;
            }
        }
    }
    public void OnContinueButtonClick()
    {
        PanelSet.SetActive(false);
        VinietAnimator.SetBool("IsViniet", false);
        Pressed = false;
        Time.timeScale = 1f;
    }
    public void OnLobbyButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void OnRestartButtonClick()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y);
        Time.timeScale = 1f;
    }
}
