using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Bomba : MonoBehaviour, I_Poder_Player
 {
    public float Poder(GameObject arma, Animator anim, float n)
    {
       GameController.instance.CriarMunicao("bomba", arma.transform);
        GameController.instance.Player.PausarPoder();
        return 1f;
    }
 }

