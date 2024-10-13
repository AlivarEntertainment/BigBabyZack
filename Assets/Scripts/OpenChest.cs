using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject sword;
    public Animator animatorChest;

    public void OnTriggerStay2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player")
        {
           if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(OpneChestCor());
                animatorChest.SetTrigger("Open");
            }
        }
    }
    public IEnumerator OpneChestCor()
    {
        yield return new WaitForSeconds(0.7f);
        sword.SetActive(true);
    }
}
