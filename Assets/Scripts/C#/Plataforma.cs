using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform plataforma, A, B;
    public float vel;
    public int Temp, TempRam;
    public Vector3 destino;
    public bool morreu;

    void Start()
    {
        plataforma.position = A.position;
        destino = B.position;
        TempRam = Temp;
    }


    void FixedUpdate()
    {
        if (!morreu)
        {
            plataforma.position = Vector3.MoveTowards(plataforma.position, destino, vel*Time.deltaTime);
            if(plataforma.position == destino && TempRam == 0)
            {
                if(A.position == destino)
                {
                    destino = B.position;
                }
                else if (B.position == destino)
                {
                    destino = A.position;
                }
                TempRam = Temp;
            }
            else if (plataforma.position == destino)
            {
                TempRam--;
            }
        }

    }
}
