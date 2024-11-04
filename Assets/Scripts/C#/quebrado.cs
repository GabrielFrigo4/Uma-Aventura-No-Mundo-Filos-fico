using MiscUtil.Xml.Linq.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quebrado : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Rigidbody2D>().constraints -= RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
