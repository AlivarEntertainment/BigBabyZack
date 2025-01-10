using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuicTimeEvent : MonoBehaviour
{   
    public enum ButtonToPress
    {
        D,
        A,
        Space,
        W
    }
    public bool Pressed;
    public ButtonToPress buttonToPress;
    public float TimeToPress;
    public int pressTimes;
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
        if(buttonToPress == ButtonToPress.D)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
            
            Debug.Log("Pressed");
            pressTimes -=1;
            }
        }
        if(buttonToPress == ButtonToPress.Space)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
            
            Debug.Log("Pressed");
            pressTimes -=1;
            }
        }
       if(pressTimes <= 0)
       {
            Pressed = true;
       }
    }
    IEnumerator FailCor()
    {
        yield return new WaitForSeconds(TimeToPress);
        if(Pressed == false)
        {
            Application.Quit();
            Time.timeScale = 0;
        }
    }
}
