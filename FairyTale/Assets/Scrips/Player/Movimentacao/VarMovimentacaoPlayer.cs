using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarMovimentacaoPlayer : MonoBehaviour
{
    public List<Definocao_movimentacaoPlayer> movimentacoes = new List<Definocao_movimentacaoPlayer>(5);


    private void Start()
    {
      
        movimentacoes[0] = new Definocao_movimentacaoPlayer(new Esperar());
        movimentacoes[1] = new Definocao_movimentacaoPlayer(new Andar_Player());
        movimentacoes[2] = new Definocao_movimentacaoPlayer(new Correr1());
        movimentacoes[3] = new Definocao_movimentacaoPlayer(new Dash());
        movimentacoes[4] = new Definocao_movimentacaoPlayer(new Sem_Dash());
        movimentacoes[5] = new Definocao_movimentacaoPlayer(new Correr2());

        
    }
}
