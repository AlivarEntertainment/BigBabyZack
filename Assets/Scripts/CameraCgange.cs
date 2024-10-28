using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCgange : MonoBehaviour
{
    public GameObject[] Cameras;
    void Start()
    {
        StartCoroutine("ChangeCamCor");
    }

    IEnumerator ChangeCamCor()
    {
        yield return new WaitForSeconds(2.2f);
        Cameras[0].SetActive(false);
        Cameras[1].SetActive(true);
    }
}
