using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComicsController : MonoBehaviour
{
    public Animator ComImageAnimator;
    public Image imageComics;
    public Sprite[] ComicsPages;
    public int CurrentPage = -1;

    public void OnChangeButtonClick()
    {
        CurrentPage += 1;
        ComImageAnimator.SetTrigger("Change");
        StartCoroutine("ChangeSprite");
    }
    IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(0.4f);
        imageComics.sprite = ComicsPages[CurrentPage];
    }
}
