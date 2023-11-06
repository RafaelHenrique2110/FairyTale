using UnityEngine;

public class Sem_Dash : MonoBehaviour, I_movimentacaoPlayer
{
    static Animation anin;
    public Vector3 Movimentacao(Transform dir, float speed, Animator anin)
    {

        return dir.position;
    }
}
