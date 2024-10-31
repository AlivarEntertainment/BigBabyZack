using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCgange : MonoBehaviour
{
    public GameObject[] Cameras;
    public GameObject EnemiesGO;
    void Start()
    {
        StartCoroutine("ChangeCamCor");
        StartCoroutine("EnemieActive");
    }

    IEnumerator ChangeCamCor()
    {
        yield return new WaitForSeconds(2.1f);
        Cameras[0].SetActive(false);
        Cameras[1].SetActive(true);
        
    }
    IEnumerator EnemieActive()
    {
        yield return new WaitForSeconds(4f);
        EnemiesGO.SetActive(true);
    }
}
