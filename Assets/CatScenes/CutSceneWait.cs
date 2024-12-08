using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutSceneWait : MonoBehaviour
{
    public float Seconds;
    public int Scene2;
    void Start()
    {
        StartCoroutine("WaitNChange");
    }

    IEnumerator WaitNChange()
    {
        yield return new WaitForSeconds(Seconds);
        SceneManager.LoadScene(Scene2);
    }
}
