using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Corpo_A_Corpo1 : MonoBehaviour, I_Combate_Player
{
    int tempo = 10;
    string[] animacao = new string[2];
    GameObject armaobj;


    public void Atacar(GameObject [] arma, Animator anim)
    {
       
        armaobj = arma[1];
        animacao[1] = "Combate_Lado_Normal";
        anim.SetBool("Correr", false);
        anim.SetBool("Andar", false);

        armaobj.GetComponent<ArmaBranca>().Usar();
        if (GameController.instance.ativar_time_animacao==false)
        {
            GameController.instance.PlayerTransform.GetComponent<Protagonista>().Dash();
            int index = Random.Range(0, 2);
            anim.SetBool(animacao[1], true);
            GameController.instance.FinalizarAnimacao(0.3f, animacao[1] );
        }
       
      
    }
    //IEnumerator UsarArma()
    //{
        
    //    armaobj.GetComponent<ArmaBranca>().Usar();
    //    yield return new WaitForSeconds(10f);
    //}
    
   
}