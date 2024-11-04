using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public Material[] materiais;
    private Player playerScript;
    public bool Congelado, Parado;
    private SpriteRenderer render;
    private Rigidbody2D rigd;
    public float vel, Dist, forPulo;
    public LayerMask layerMask;
    public Transform pé;
    public LayerMask chão;
    private int temp = 0, random = 0;
    public int tempMove;
    private bool invertido = false;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType(typeof(Player)) as Player;
        render = GetComponent<SpriteRenderer>();
        rigd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Congelado && !Parado)
        {
            if (verPlayer(Dist) && playerScript.transform.position.x > transform.position.x)
            {
                rigd.velocity = new Vector2(vel, rigd.velocity.y);
                pular();
                if (invertido) { inverter(); invertido = false; }
            }
            else if (verPlayer(Dist) && playerScript.transform.position.x < transform.position.x)
            {
                rigd.velocity = new Vector2(-vel, rigd.velocity.y);
                pular();
                if (!invertido) { inverter(); invertido = true; }
            }
            else
            {
                rigd.velocity = new Vector2(0, rigd.velocity.y);
                movimentoRan(tempMove);
            }
        }
        



        if (!Congelado && render.material != materiais[0])
        {
            rigd.bodyType = RigidbodyType2D.Dynamic;
            render.material = materiais[0];
        }
        if (Congelado && render.material != materiais[1])
        {
            rigd.bodyType = RigidbodyType2D.Kinematic;
            rigd.velocity = new Vector3(0, 0, 0);
            render.material = materiais[1];
        }
    }

    bool verPlayer(float dist)
    {
        bool val = false;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerScript.transform.position, layerMask);
        Debug.DrawLine(transform.position, playerScript.transform.position, Color.blue);
        if(Vector3.Distance(transform.position, playerScript.transform.position) < dist)
        {
            if (hit.collider != null)
            {
                if(hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.tag != "Opaco")
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
        }
        

        return val;
    }

    void pular()
    {
        if (playerScript.transform.position.y > transform.position.y + 2.2f)
        {
            if (Physics2D.OverlapCircle(new Vector2(pé.position.x, pé.position.y), 0.05f, chão))
            {
                rigd.velocity = new Vector2(rigd.velocity.x, 0);
                rigd.AddForce(new Vector2(0, forPulo), ForceMode2D.Impulse);
            }
        }
    }

    void movimentoRan(int Temp)
    {
        if (temp > 0)
        {
            switch (random)
            {
                case -1:
                    rigd.velocity = new Vector2(-vel, rigd.velocity.y);
                    if (!invertido) { inverter(); invertido = true; }
                    temp--;
                    break;
                case 0:
                    rigd.velocity = new Vector2(0, rigd.velocity.y);
                    temp--;
                    break;
                case 1:
                    rigd.velocity = new Vector2(vel, rigd.velocity.y);
                    if (invertido) { inverter(); invertido = false; }
                    temp--;
                    break;
            }
        }
        else
        {
            random = Random.Range(-1,2);
            temp = Temp;
        }
    }

    public void tempEstado(bool Est)
    {
        Congelado = Est;
    }

    void inverter()
    {
        sbyte x = (sbyte)transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x,1,1);
    }
}
