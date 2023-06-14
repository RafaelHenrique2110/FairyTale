using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esperar : MonoBehaviour, I_movimentacaoPlayer
{
    public Vector3 Movimentacao(Transform dir, float speed, Animator anin)
    {
        anin.SetBool("Correr", false);
        anin.SetBool("Andar", false);
        return dir.position;
    }
}

