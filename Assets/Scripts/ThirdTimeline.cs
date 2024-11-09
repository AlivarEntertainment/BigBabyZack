using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ThirdTimeline : MonoBehaviour
{
    [SerializeField]private Animator PressE;
     public int sceneNumber;
     public PlayableDirector playableDirector;
     public GameObject PlayerGO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D PlayerCol)
    {
        if(PlayerCol.gameObject.tag == "Player")
        {   
            PressE.SetBool("IsInFade", false);
            if(Input.GetKey(KeyCode.E))
            {   
                PlayerGO.SetActive(false);
                playableDirector.Play();
                StartCoroutine("TimelineCor3");
            }
        }
    }
     public IEnumerator TimelineCor3()
    {
        yield return new WaitForSeconds(4.2f);
        SceneManager.LoadScene(sceneNumber);
    }
}
