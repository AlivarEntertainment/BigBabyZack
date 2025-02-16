using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDootByStone : MonoBehaviour
{
    public Change changeToBoss;
    public GameObject[] Doors;
    public void OnTriggerEnter2D(Collider2D Stone)
    {
        if(Stone.gameObject.tag == "Player" || Stone.gameObject.tag == "Boulder")
        {
            changeToBoss.enabled = true;
            Doors[0].SetActive(false);
            Doors[1].SetActive(true);
        }
    }
}
