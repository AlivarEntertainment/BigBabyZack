using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCont : MonoBehaviour
{
    public GameObject NavigationPan;
    
    public void OnNavigationButtonClikc()
    {
        NavigationPan.SetActive(true);
    }
    public void OnCloseButtonClick()
    {
        NavigationPan.SetActive(false);
    }
}
