using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaCanvas : MonoBehaviour
{
    [SerializeField]List<Botoes> botoes;

    public List<Botoes> GetBoestoes()
    {
        return botoes;
    }

}
