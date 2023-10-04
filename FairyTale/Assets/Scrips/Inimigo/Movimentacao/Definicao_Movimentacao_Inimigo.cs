using UnityEngine;

public class Definicao_Movimentacao_Inimigo : MonoBehaviour
{
    I_MovimentacaoInimigo i_movimentacaoInimigo;
    public Definicao_Movimentacao_Inimigo(I_MovimentacaoInimigo i_movimentacaoInimigo)
    {
        this.i_movimentacaoInimigo = i_movimentacaoInimigo;
    }
    public Vector3 Mover(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {
        return dir.position = i_movimentacaoInimigo.MovimentacaoInimigo(target, dir, speed, anin, inimigo);
    }
}
