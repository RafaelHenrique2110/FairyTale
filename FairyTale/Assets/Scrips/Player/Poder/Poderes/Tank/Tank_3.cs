using UnityEngine;

public class Tank_3 : MonoBehaviour, I_Poder_Player
{
    float time = 3;
    public float Poder(GameObject arma, Animator anim, float n)
    {
        time = time - Time.deltaTime;
        if (time > 0)
        {
            GameController.instance.material_player.color = Color.red;
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
