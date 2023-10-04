using System.Collections.Generic;
using UnityEngine;

public class VarCombatePlayer : MonoBehaviour
{
    public List<DefinicaoCombate> combates = new List<DefinicaoCombate>(5);


    private void Start()
    {
        combates[0] = new DefinicaoCombate(new Distancia_Desabilitado());
        combates[1] = new DefinicaoCombate(new Corpo_A_Corpo1());
        combates[2] = new DefinicaoCombate(new Distancia1());
        combates[3] = new DefinicaoCombate(new Distancia2());
        combates[4] = new DefinicaoCombate(new Distancia3());
        combates[5] = new DefinicaoCombate(new Corpo_A_Corpo2());

    }
}
