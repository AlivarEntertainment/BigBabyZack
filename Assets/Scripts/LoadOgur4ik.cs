using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
public class LoadOgur4ik : MonoBehaviour
{
    private int SceneToLoad;
    public Light2D LightSource;
    void Start()
    {
        SceneToLoad = PlayerPrefs.GetInt("OgurecLocation");
        StartCoroutine("GoBackToOgur4k");
        if(SceneToLoad == 29)
        {
            LightSource.GetComponent<Light2D>().color = Color.red;
        }
        else if(SceneToLoad == 33)
        {   
            LightSource.GetComponent<Light2D>().color =new  Color(0, 4, 0, 0.3f);
            
        }
    }

    public IEnumerator GoBackToOgur4k()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneToLoad);
    }
}
