using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBossScene : MonoBehaviour
{
   public float Seconds;
    void Start()
    {
        StartCoroutine("ToBossScene");
    }

    IEnumerator ToBossScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(12);
    }
}
