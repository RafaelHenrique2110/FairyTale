using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Corpo_A_Corpo1 : MonoBehaviour, I_Combate_Player
{
    int tempo = 10;
    string[] animacao = new string[2];
   
   
    public void Atacar(GameObject [] arma, Animator anim)
    {
        arma[1].GetComponent<ArmaBranca>().Usar();
       animacao[1] = "Combate_Lado_Normal";
        anim.SetBool("Correr", false);
        anim.SetBool("Andar", false);
       
        if (GameController.instance.ativar_time_animacao==false)
        {
            int index = Random.Range(0, 2);
            anim.SetBool(animacao[1], true);
            GameController.instance.FinalizarAnimacao(1f, animacao[1] );
        }
       
        Debug.Log("corpoa a corpo 2");
    }
    
   
}