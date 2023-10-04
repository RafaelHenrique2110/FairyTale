using System.Collections.Generic;
using UnityEngine;

public class Assistente : MonoBehaviour
{
    private List<I_Observer> _observadores = new List<I_Observer>();

    public void AdicionarObservador(I_Observer observador)
    {
        _observadores.Add(observador);
    }

    public void RemoverObservador(I_Observer observador)
    {
        _observadores.Remove(observador);
    }

    public void Notificar()
    {
        for (int i = 0; i < _observadores.Count; i++)
        {

            _observadores[i].Notificar();
        }
    }
}
