using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPunch : MonoBehaviour
{
    bool CanGoUp;
    public void Start()
    {
        StartCoroutine("ReturnSpeed");
    }
    public void Update()
    {
        if(CanGoUp == true)
        {
              Time.timeScale += Time.deltaTime * 6;
            
        }
        if(Time.timeScale >= 1)
        {
            CanGoUp = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0.2f;
            StartCoroutine("SpeedCor");
        }
    }
    IEnumerator SpeedCor()
    {
        yield return new WaitForSeconds(0.3f);
        CanGoUp = true;
       
    }
    IEnumerator ReturnSpeed()
    {
        yield return new WaitForSeconds(8f);
        Time.timeScale = 1f;
    }
}
