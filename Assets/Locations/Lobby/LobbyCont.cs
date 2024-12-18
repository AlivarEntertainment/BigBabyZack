using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCont : MonoBehaviour
{
    public GameObject NavigationPan;
    public Animator FadeAnim;
    
    public void OnNavigationButtonClikc()
    {
        NavigationPan.SetActive(true);
        FadeAnim.SetTrigger("ChangeNav");
    }
    public void OnCloseButtonClick()
    {
        NavigationPan.SetActive(false);
        FadeAnim.SetTrigger("ChangeNav");
    }
}
