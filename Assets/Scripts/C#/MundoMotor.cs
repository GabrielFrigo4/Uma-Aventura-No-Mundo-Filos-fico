using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MundoMotor : MonoBehaviour
{
    public Vector3 pos;
    public Transform A;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            A.position = pos;
        }
    }
}
