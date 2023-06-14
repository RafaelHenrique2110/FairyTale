using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_4 : MonoBehaviour, I_Poder_Player
{
    float time = 6;
    public float Poder(GameObject arma, Animator anim, float n)
    {
        time = time - Time.deltaTime;
        if (time > 0)
        {
            GameController.instance.material_player.color = Color.black;
            return n = 100;
        }
        else
        {
            time = 3;
            GameController.instance.Player.PausarPoder();
            GameController.instance.material_player.color = Color.yellow;
            return n = 1;
        }

    }
}
