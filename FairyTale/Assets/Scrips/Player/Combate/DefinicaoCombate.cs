using UnityEngine;

public class DefinicaoCombate : MonoBehaviour
{
    I_Combate_Player i_combate_player;
    public DefinicaoCombate(I_Combate_Player i_combate)
    {
        this.i_combate_player = i_combate;
    }
    public void Atacar(GameObject[] arma, Animator anim)
    {
        i_combate_player.Atacar(arma, anim);
    }
}

