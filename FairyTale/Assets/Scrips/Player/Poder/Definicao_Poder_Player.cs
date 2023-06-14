using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Definicao_Poder_Player : MonoBehaviour
{
    I_Poder_Player i_poder_player;

    public Definicao_Poder_Player(I_Poder_Player i_poder_player)
    {
        this.i_poder_player = i_poder_player;
    }
    public float UsarPoder(GameObject arma, Animator anin, float n)
    {
       n= i_poder_player.Poder( arma, anin,n);
        return n;
    }
}
