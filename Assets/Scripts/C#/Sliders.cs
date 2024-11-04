using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public GameObject resumoTexto, MusicaSlider, SomSlider;

    public void Start()
    {
        if(PlayerPrefs.GetInt("iniciou") == 0)
        {
            PlayerPrefs.SetFloat("somMusica", MusicaSlider.GetComponent<Slider>().value);
            PlayerPrefs.SetFloat("somJogo", SomSlider.GetComponent<Slider>().value);
            PlayerPrefs.SetInt("iniciou",1);
        }
        else
        {
            MusicaSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("somMusica");
            SomSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("somJogo");
        }
    }

    // Update is called once per frame
    public void resumoPosição(float i)
    {
        resumoTexto.transform.position = new Vector3(resumoTexto.transform.position.x, -5+10*i, 0);
    }

    public void somMusica(float i)
    {
        PlayerPrefs.SetFloat("somMusica", i);
    }

    public void somJogo(float i)
    {
        PlayerPrefs.SetFloat("somJogo", i);
    }
}
