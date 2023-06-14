using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpo_A_Corpo2 : MonoBehaviour, I_Combate_Player
{
    int tempo = 10;
    string[] animacao = new string[2];
   
    public void Atacar(GameObject []arma, Animator anim)
    {
        arma[1].GetComponent<ArmaBranca>().Usar();
        animacao[0] = "Combate_Cima";
        animacao[1] = "Combate_Lado_Rapido";
        anim.SetBool("Correr", false);
        anim.SetBool("Andar", false);

        if (GameController.instance.ativar_time_animacao == false)
        {
            int index = Random.Range(0, 2);
            anim.SetBool(animacao[1], true);
            GameController.instance.FinalizarAnimacao(0.5f, animacao[1]);
        }

        Debug.Log("corpoa a corpo 2");
    }
}
