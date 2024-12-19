using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]public Scene Tonnel;
    public int Comics;
    public GameObject ResetPan;
    public void Start()
    {
        Debug.Log("!");
    }
    public void OnStartGameButtonClick()
    {
        SceneManager.LoadScene(18);
    }
    public void OnComics()
    {
        SceneManager.LoadScene(Comics);
    }
    public void OnActiveRestart()
    {
        ResetPan.SetActive(true);
    }
    public void OnDeactRestart()
    {
        ResetPan.SetActive(false);
    }
    public void OnRestartButtonClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
