using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ComicsController : MonoBehaviour
{
    public Animator ComImageAnimator;
    public Image imageComics;
    public Sprite[] ComicsPages;
    public int CurrentPage = -1;
    public GameObject NextButton;
    public bool IsEpilog;
    public void Start()
    {
        Debug.Log("StartCom");
    }
    public void OnChangeButtonClick()
    {   
        if(CurrentPage == -1)
        {
            imageComics.enabled = true;
        }
        if(CurrentPage == 6 && IsEpilog == false)
        {
            NextButton.SetActive(false);
        }
        if(CurrentPage == 18 && IsEpilog == true)
        {
            SceneManager.LoadScene(40);
        }
        CurrentPage += 1;
        ComImageAnimator.SetTrigger("Change");
        imageComics.sprite = ComicsPages[CurrentPage];
        //StartCoroutine("ChangeSprite");
    }
  
}
