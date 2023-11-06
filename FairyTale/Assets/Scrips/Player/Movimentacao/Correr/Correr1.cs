using UnityEngine;

public class Correr1 : MonoBehaviour, I_movimentacaoPlayer
{


    public Vector3 Movimentacao(Transform dir, float speed, Animator anin)
    {
        anin.SetBool("Correr", true);
        anin.SetBool("Andar", false);
        speed = 5;
        Mover_Player mover = new Mover_Player(dir, speed, anin);
        dir.position = mover.MoverPlayer();

        return dir.position;
    }
}
