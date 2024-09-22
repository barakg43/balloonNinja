using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBottonSct : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
            Application.Quit();

    }
}

