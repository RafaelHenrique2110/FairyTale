using UnityEngine;

public class Definocao_movimentacaoPlayer : MonoBehaviour
{
    private I_movimentacaoPlayer I_movimentacao;
    public Definocao_movimentacaoPlayer(I_movimentacaoPlayer I_movimentacao)
    {
        this.I_movimentacao = I_movimentacao;
    }
    public Vector3 Mover(Transform dir, float speed, Animator anin)
    {
        dir.position = I_movimentacao.Movimentacao(dir, speed, anin);
        return dir.position;
    }
}
