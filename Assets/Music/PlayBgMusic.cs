using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgMusic : MonoBehaviour
{
    public GameObject BgMusic;
    private AudioSource audioSource;
    public GameObject[] objects11;
    void Awake()
    {
        objects11 = GameObject.FindGameObjectsWithTag("Sound");
        if(objects11.Length == 0)
        {
            BgMusic = Instantiate(BgMusic);
            BgMusic.name = "BGMusic1";
            DontDestroyOnLoad(BgMusic.gameObject);
        }
        else
        {
            BgMusic = GameObject.Find("BGMusic1");
        }
    }

    // Update is called once per frame
    void Start()
    {
        audioSource = BgMusic.GetComponent<AudioSource>();
    }
}