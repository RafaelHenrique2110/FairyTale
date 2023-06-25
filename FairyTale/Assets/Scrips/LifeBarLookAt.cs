using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// faz com que a barra de vida dos inimigos fique virada para a camera o tempo todo

public class LifeBarLookAt : MonoBehaviour
{    
    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
