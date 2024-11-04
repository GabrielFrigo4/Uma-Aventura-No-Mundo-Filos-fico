using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public bool Congelado = true, fuma = false;
    public byte velRot = 1, temFuma = 1, tempClamp = 1;
    public Material[] materiais;
    public SpriteRenderer[] render;
    public Transform[] trans;
    public GameObject fumaça;
    private byte time, max;
    public string scene;

    void Start()
    {
        if (!Congelado)
        {
            render[0].material = materiais[0];
            render[1].material = materiais[0];
            render[2].material = materiais[0];
        }
        else if (Congelado)
        {
            render[0].material = materiais[1];
            render[1].material = materiais[1];
            render[2].material = materiais[1];
        }
    }


    void Update()
    {
        if (!Congelado)
        {
            trans[0].Rotate(0, 0, velRot * Time.deltaTime);
            if (!fuma) { fuma = true; StartCoroutine("Fumaça"); }
            if(render[3].color.a < 1)
            {
                render[3].color = new Color(1, 1, 1, render[3].color.a + 0.005f);
            }
            else
            {
                SceneManager.LoadScene(scene);
            }
        }
    }

    public void tempEstado(bool Est)
    {
        if (!Est)
        {
            Congelado = false;
            descongelar();
        }
    }

    void descongelar()
    {
        render[0].material = materiais[0];
        render[1].material = materiais[0];
        render[2].material = materiais[0];
    }

    IEnumerator Fumaça()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject Fum = Instantiate(fumaça, trans[1]);
        Destroy(Fum, temFuma);
        StartCoroutine("Fumaça");
    }
}
