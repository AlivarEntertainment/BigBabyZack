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
        yield return new WaitForSeconds(Seconds);
        SceneManager.LoadScene(14);
    }
}
