using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Definicao_Combate_Inimigo : MonoBehaviour
{
    I_Combate_Inimigo i_combate_player;
    public Definicao_Combate_Inimigo(I_Combate_Inimigo i_combate_inimigo)
    {
        this.i_combate_player = i_combate_inimigo;
    }
    public void Atacar(GameObject arma, Animator anim, Inimigo inimigo)
    {
        i_combate_player.Atacar(arma, anim, inimigo);
    }
    
   
}
