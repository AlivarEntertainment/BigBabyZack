using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{   
    public GameObject[] block;
    public Transform[] BlockStartPos;
    public Animator CrishkaAnim;
    public void OnMouseDown()
    {   
        CrishkaAnim.SetTrigger("crishka");
        for(int i = 0; i <= block.Length; i++)
        {
            block[i].transform.position = BlockStartPos[i].position;
        }
    }
}
