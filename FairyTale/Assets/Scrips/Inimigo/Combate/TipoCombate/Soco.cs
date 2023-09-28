using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soco : MonoBehaviour, I_Combate_Inimigo
{
    float tempo = 3;


    public void Atacar(GameObject arma, Animator anim, Inimigo inimigo)
    {
        tempo = tempo - Time.deltaTime;
           
        
        anim.SetBool("Correr", false);
        anim.SetBool("Soco", true);

    }
  
}
