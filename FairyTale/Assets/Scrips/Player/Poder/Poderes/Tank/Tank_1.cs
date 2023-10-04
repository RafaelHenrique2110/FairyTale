using UnityEngine;

public class Tank_1 : MonoBehaviour, I_Poder_Player
{
    float time = 3;
    public float Poder(GameObject arma, Animator anim, float n)
    {
        Debug.Log(time);
        time = time - Time.deltaTime;
        if (time > 0)
        {
            GameController.instance.material_player.color = Color.blue;
            return n = 20;
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
