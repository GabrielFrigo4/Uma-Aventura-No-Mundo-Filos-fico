using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC : MonoBehaviour
{
    public byte fps;
    public bool TmenuFjogo;
    public AudioClip somMenu, somJogo;
    private AudioSource audioConf;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;
        audioConf = GetComponent<AudioSource>();
        if (TmenuFjogo)
        {
            audioConf.clip = somMenu;
            audioConf.Play();
        }
        if (!TmenuFjogo)
        {
            audioConf.clip = somJogo;
            audioConf.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioConf.volume = PlayerPrefs.GetFloat("somJogo");
    }
}
