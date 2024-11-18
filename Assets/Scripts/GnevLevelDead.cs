using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GnevLevelDead : MonoBehaviour
{
    private int SceneToLoad;
    public float Seconds;
    void Start()
    {
        SceneToLoad = PlayerPrefs.GetInt("GnevLocation");
        StartCoroutine("ToGnevScene");
    }
    IEnumerator ToGnevScene()
    {
        yield return new WaitForSeconds(Seconds);
        SceneManager.LoadScene(SceneToLoad);
    }

}
