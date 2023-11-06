using UnityEngine;

public class Dash : MonoBehaviour, I_movimentacaoPlayer
{
    static Animation anin;
    public Vector3 Movimentacao(Transform dir, float speed, Animator anin)
    {

        speed = 16;
        Mover_Player mover = new Mover_Player(dir, speed, anin);
        dir.position = mover.MoverPlayer();
        return dir.position;
    }
}