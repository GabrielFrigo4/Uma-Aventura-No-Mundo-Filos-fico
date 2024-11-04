using Bolt;
using Ludiq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] Filo;
    public int IdFilo;
    public Transform mão;
    public float VelocidadeFilo;
    public byte pitagorico;
    public string[] selecionadoresNomes;
    public Material[] materiais;
    public bool morreu;
    public string NomeCanvasMorreu;
    public GameObject CanvasMorreu;
    private Rigidbody2D rigidbody;
    private BoxCollider2D coll;

    private void Start()
    {
        GameObject.Find(selecionadoresNomes[0]).GetComponent<SpriteRenderer>().material = materiais[0];
        GameObject.Find(selecionadoresNomes[1]).GetComponent<SpriteRenderer>().material = materiais[0];
        GameObject.Find(selecionadoresNomes[IdFilo]).GetComponent<SpriteRenderer>().material = materiais[1];
        CanvasMorreu = GameObject.Find(NomeCanvasMorreu).GameObject();
        CanvasMorreu.SetActive(false);
        rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!morreu)
        {
            if (Input.GetButtonDown("Atirar") || Input.GetButtonDown("Atirar2"))
            {
                AtirarGelar();
            }

            if (Input.GetMouseButtonDown((int)MouseButton.Right))
            {
                switch (IdFilo)
                {
                    case 0:
                        IdFilo = 1;
                        GameObject.Find(selecionadoresNomes[1]).GetComponent<SpriteRenderer>().material = materiais[1];
                        GameObject.Find(selecionadoresNomes[0]).GetComponent<SpriteRenderer>().material = materiais[0];
                        break;
                    case 1:
                        IdFilo = 0;
                        GameObject.Find(selecionadoresNomes[1]).GetComponent<SpriteRenderer>().material = materiais[0];
                        GameObject.Find(selecionadoresNomes[0]).GetComponent<SpriteRenderer>().material = materiais[1];
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                IdFilo = 0;
                GameObject.Find(selecionadoresNomes[1]).GetComponent<SpriteRenderer>().material = materiais[0];
                GameObject.Find(selecionadoresNomes[0]).GetComponent<SpriteRenderer>().material = materiais[1];
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                IdFilo = 1;
                GameObject.Find(selecionadoresNomes[1]).GetComponent<SpriteRenderer>().material = materiais[1];
                GameObject.Find(selecionadoresNomes[0]).GetComponent<SpriteRenderer>().material = materiais[0];
            }
        }
        
    }

    void AtirarGelar()
    {
        GameObject filo = Instantiate(Filo[IdFilo], mão.position, transform.rotation) as GameObject;
        filo.GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadeFilo*transform.localScale.x, 0);
        filo.transform.localScale = new Vector3(transform.localScale.x,1,1);
        Destroy(filo,5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Plataforma":
                transform.SetParent(collision.transform);
                break;
            case "Inimigo":
                if(!collision.gameObject.GetComponent<Inimigos>().Congelado)
                Morreu();
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!morreu)
        switch (collision.gameObject.tag)
        {
            case "Inimigo":
                if (!collision.gameObject.GetComponent<Inimigos>().Congelado)
                Morreu();
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Plataforma":
                transform.SetParent(null);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "portal":
                collision.gameObject.GetComponent<Portal>().salvarScena();
                SceneManager.LoadScene(collision.gameObject.GetComponent<Portal>().scene);
                break;
        }
    }

    void Morreu()
    {
        if (!morreu)
        {
            CanvasMorreu.SetActive(true);
            morreu = true;
            Variables.Application.Set("score", 100);
            Variables.Object(gameObject).Set("Morreu", true);
            rigidbody.velocity = new Vector2(0,0);
            rigidbody.gravityScale = 0;
            coll.enabled = false;
            Object[] inimigos = FindObjectsOfType(typeof(Inimigos));
            for(int i = 0; i < inimigos.Length; i++)
            {
                inimigos[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                inimigos[i].GetComponent<Rigidbody2D>().gravityScale = 0;
                inimigos[i].GetComponent<Inimigos>().Parado = true;
            }
            Object[] plataforma = FindObjectsOfType(typeof(Plataforma));
            for (int i = 0; i < plataforma.Length; i++)
            {
                plataforma[i].GetComponent<Plataforma>().morreu = true;
            }
        }
    }
}
