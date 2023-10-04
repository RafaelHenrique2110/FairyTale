using UnityEngine;

public class Mirar : MonoBehaviour, I_MovimentacaoInimigo
{
    public Vector3 MovimentacaoInimigo(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {

        Vector3 dir2 = GameController.instance.player.transform.position - dir.position;
        dir.rotation = Quaternion.LookRotation(dir2);
        return dir.position;
    }
}
