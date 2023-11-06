using UnityEngine;

public interface I_MovimentacaoInimigo
{
    public Vector3 MovimentacaoInimigo(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo);
}
