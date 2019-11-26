using UnityEngine;
using System;
using System.Collections;

public class Explosion : MonoBehaviour
{

    void Start()
    {
        Invoke("Destroy", 1);
        
    }

    void  Destroy()
    {
        gameObject.SetActive(false);
    }

}
