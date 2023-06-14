using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float tempoDeVida;
    [SerializeField] float dano;
    private void Start()
    {
        Destroy(this.gameObject, tempoDeVida);
    }
    void Update()
    {
        GameController.instance.MoverProjetil(transform, speed);
    }
    public float Dano { get { return dano; } }

}
