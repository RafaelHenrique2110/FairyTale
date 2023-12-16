using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        Invoke("Spwnar", 0);
    }
    public void Spwnar()
    {
        GameObject obj = Instantiate(prefab, transform.position, transform.rotation);
        GameController.instance.AdicionarInimigosLista(obj);
        Invoke("Spwnar", 7);
    }

}
