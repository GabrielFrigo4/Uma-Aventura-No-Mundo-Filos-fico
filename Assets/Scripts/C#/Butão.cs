using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Bolt;

public class Butão : MonoBehaviour
{
    public int canva;
    public GameObject menu, opçoes, resumo;
    public Sprite Max, Min;
    public bool Dica = true;
    public GameObject zerar;
    private GameObject dica, but;

    public void Start()
    {
        dica = GameObject.Find("DicaBar");
        but = GameObject.Find("MaxMin");
        if (GameObject.Find("Dica") != null)
        {
            AtualizarMaxMin();
        }

        if(zerar != null)
        if(PlayerPrefs.GetString("scene") != "")
        {
            Variables.Object(zerar).Set("zerar", true);
        }
        else
        {
            Variables.Object(zerar).Set("zerar", false);
        }
    }

    public void Jogar()
    {
        print(PlayerPrefs.GetString("scene"));
        switch (PlayerPrefs.GetString("scene"))
        {
            case "":
                SceneManager.LoadScene("Tutorial");
                break;
            case "Fase1":
                SceneManager.LoadScene("Fase1");
                break;
            case "Fase2":
                SceneManager.LoadScene("Fase2");
                break;
            case "Fase3":
                SceneManager.LoadScene("Fase3");
                break;
            case "Creditos":
                SceneManager.LoadScene("Creditos");
                break;
        }
    }

    public void Resumo()
    {
        canva = 3;
        Atualizar();
    }

    public void Opções()
    {
        canva = 2;
        Atualizar();
    }

    public void Voltar()
    {
        canva = 1;
        Atualizar();
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Reiniciar()
    {
        Scene scene = SceneManager.GetActiveScene();
        Application.LoadLevel(scene.name);
    }

    public void Zerar()
    {
        PlayerPrefs.DeleteKey("scene");
        Variables.Object(zerar).Set("zerar", false);
    }

    private void Atualizar()
    {
            switch (canva)
            {
                case 1:
                    menu.SetActive(true);
                    opçoes.SetActive(false);
                    resumo.SetActive(false);
                    break;
                case 2:
                    menu.SetActive(false);
                    opçoes.SetActive(true);
                    resumo.SetActive(false);
                    break;
                case 3:
                    menu.SetActive(false);
                    opçoes.SetActive(false);
                    resumo.SetActive(true);
                    break;
            }
    }

    public void MaxMin()
    {
        Dica = !Dica;
        AtualizarMaxMin();
    }
    void AtualizarMaxMin()
    {
        dica.SetActive(Dica);
        if (Dica)
        {
            but.GetComponent<Image>().sprite = Min;
        }
        else
        {
            but.GetComponent<Image>().sprite = Max;
        }
    }

    public void MenuVolt()
    {
        SceneManager.LoadScene("Menu");
    }
}
