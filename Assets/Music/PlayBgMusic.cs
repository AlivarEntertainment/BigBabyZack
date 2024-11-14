using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayBgMusic : MonoBehaviour
{
    public GameObject BgMusic;
    private AudioSource audioSource;
    public GameObject[] objects11;
    [SerializeField]public bool IsGnevMusic;
    void Awake()
    {   
        objects11 = GameObject.FindGameObjectsWithTag("Sound");
        int y = SceneManager.GetActiveScene().buildIndex;
        if (objects11.Length == 0 && y != 2)
        {
            Debug.Log(y);
            BgMusic = Instantiate(BgMusic);
            BgMusic.name = "BGMusic1";
            DontDestroyOnLoad(BgMusic.gameObject);
        }
        else if (y != 2)
        {
           BgMusic = GameObject.Find("BGMusic1");
        }
        else if(y == 2){
            audioSource.clip = null;
        }
    }

    // Update is called once per frame
    void Start()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(y);
        if (y != 2)
        {
            audioSource = BgMusic.GetComponent<AudioSource>();
            
        }
        else if (y == 2)
        {
            audioSource.clip = null;
        }

    }
}
