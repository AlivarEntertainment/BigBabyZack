using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerSpawnerDifWays : MonoBehaviour
{
    public Transform[] SpawnersTrans;
    public int SpawnerId;
    public GameObject ZackObject;
    public bool IsSecond;
    public Animator FadeAnimator;
    public void Start()
    {
        if(IsSecond == true)
        {
            SpawnerId = PlayerPrefs.GetInt("Spawner");
            ZackObject.transform.position = SpawnersTrans[SpawnerId].position;
            PlayerPrefs.DeleteKey("Spawner");
        }
    }
    public void OnTriggerEnter2D(Collider2D Zack)
    {
        if(Zack.gameObject.tag == "Player" && IsSecond == false)
        {   
            PlayerPrefs.SetInt("Spawner", SpawnerId);
            StartCoroutine("FadeEndCor");
            FadeAnimator.SetTrigger("EndLevel");

        }
    }
    IEnumerator FadeEndCor()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(20);
    }
}
