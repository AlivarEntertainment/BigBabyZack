using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuicTimeEvent : MonoBehaviour
{
    public bool Pressed;
    public void Start()
    {
        StartCoroutine("FailCor");
    }
    public void Update()
    {   
        if(Time.timeScale >= 0.2f && Pressed == false)
        {
            Time.timeScale -= Time.deltaTime * 4f;
        }
        else if(Pressed == true && Time.timeScale <= 1)
        {
            Time.timeScale += Time.deltaTime * 8;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Pressed = true;
            Debug.Log("Pressed");
        }
       
    }
    IEnumerator FailCor()
    {
        yield return new WaitForSeconds(0.7f);
        if(Pressed == false)
        {
            Application.Quit();
            Time.timeScale = 0;
        }
    }
}
