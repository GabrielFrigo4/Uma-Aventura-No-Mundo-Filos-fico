using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filo : MonoBehaviour
{
    public GameObject animação;
    public bool TGeloFFogo;
    private AudioSource som;

    private void Start()
    {
        som = GetComponent<AudioSource>();
        som.volume = PlayerPrefs.GetFloat("somJogo");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Inimigo")
        {
            collision.gameObject.GetComponent<Inimigos>().tempEstado(TGeloFFogo);
            Quebrou();
        }
        if (collision.tag == "Motor")
        {
            collision.gameObject.GetComponent<Motor>().tempEstado(TGeloFFogo);
            Quebrou();
        }
        if (collision.tag != "Player")
        {
            Quebrou();
        }
    }

    void Quebrou()
    {
        GameObject fif = Instantiate(animação,transform.position, transform.rotation);
        fif.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("somJogo");
        Destroy(this.gameObject);
    }

    void Atingio()
    {

    }
}
