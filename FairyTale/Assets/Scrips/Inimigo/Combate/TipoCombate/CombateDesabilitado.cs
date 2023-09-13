using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateDesabilitado : MonoBehaviour, I_Combate_Inimigo
{
    bool  executando=true;
    public void Atacar(GameObject arma, Animator anim, Inimigo inimigo)
    {
       
        anim.SetBool("Soco", false);
       // anim.SetBool("Dano", true);

    }
    public void Sair()
    {
        executando = false;
    }
  
}
