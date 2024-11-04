using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuVolt : MonoBehaviour
{
    private AudioSource MusicaTriste;

    private void Start()
    {
        MusicaTriste = GetComponent<AudioSource>();
        MusicaTriste.volume = PlayerPrefs.GetFloat("somMusica");
    }

    public void MenuVolt()
    {
        SceneManager.LoadScene("Menu");
    }
}
