using System.Collections.Generic;
using UnityEngine;

public class ListaCanvas : MonoBehaviour
{
    [SerializeField] List<Botoes> botoes;

    public List<Botoes> GetBoestoes()
    {
        return botoes;
    }
    public List<Botoes> GetListaBotoes()
    {
        return botoes;
    }

}
