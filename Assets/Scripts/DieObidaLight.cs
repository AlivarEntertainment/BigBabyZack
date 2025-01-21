using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DieObidaLight : MonoBehaviour
{   
    public bool CutScene;
    private int SceneToLoad;
    public void Start()
    {   
        if(CutScene == true)
        {
            StartCoroutine("GoBackToObida");
        }
        SceneToLoad = PlayerPrefs.GetInt("ObidaLocation");
    }
    public void OnTriggerEnter2D(Collider2D playerCol)
    {
        if(playerCol.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("ObidaLocation", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(25);
        }
    }
    public IEnumerator GoBackToObida()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneToLoad);
    }
}
