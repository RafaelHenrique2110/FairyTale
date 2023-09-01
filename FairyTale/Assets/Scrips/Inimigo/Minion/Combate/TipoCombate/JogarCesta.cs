using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogarCesta : MonoBehaviour, I_Combate_Inimigo
{
    
    public void Atacar(GameObject arma, Animator anim, Inimigo inimigo)
    {


        jogarCesta(arma);

    }
   void jogarCesta(GameObject cesta)
    {
        cesta.GetComponent<Cesta>().Usar();
        
    }
  
}
