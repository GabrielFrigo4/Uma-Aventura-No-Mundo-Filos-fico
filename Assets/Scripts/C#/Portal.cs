using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string scene;
    public void salvarScena()
    {
        PlayerPrefs.SetString("scene", scene);
    }
}
