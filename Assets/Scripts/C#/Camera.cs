using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Player playerScript;
    public GameObject cameraJogo;
    public Transform A, B;

    void Start()
    {
        playerScript = FindObjectOfType(typeof(Player)) as Player;
        cameraJogo.transform.position = new Vector3(playerScript.transform.position.x, playerScript.transform.position.y, cameraJogo.transform.position.z);
        if (cameraJogo.transform.position.x < A.position.x) { cameraJogo.transform.position = new Vector3(A.position.x, cameraJogo.transform.position.y, cameraJogo.transform.position.z); }
        if (cameraJogo.transform.position.y < A.position.y) { cameraJogo.transform.position = new Vector3(cameraJogo.transform.position.x, A.position.y, cameraJogo.transform.position.z); }
        if (cameraJogo.transform.position.x > B.position.x) { cameraJogo.transform.position = new Vector3(B.position.x, cameraJogo.transform.position.y, cameraJogo.transform.position.z); }
        if (cameraJogo.transform.position.y > B.position.y) { cameraJogo.transform.position = new Vector3(cameraJogo.transform.position.x, B.position.y, cameraJogo.transform.position.z); }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.transform.position.x > A.position.x && playerScript.transform.position.x < B.position.x)
        {
            cameraJogo.transform.position = new Vector3(playerScript.transform.position.x, cameraJogo.transform.position.y, cameraJogo.transform.position.z);
        }

        if (playerScript.transform.position.y > A.position.y && playerScript.transform.position.y < B.position.y)
        {
            cameraJogo.transform.position = new Vector3(cameraJogo.transform.position.x, playerScript.transform.position.y, cameraJogo.transform.position.z);
        }
    }
}
