using UnityEngine;

public class Voar : MonoBehaviour, I_MovimentacaoInimigo
{

    Vector3 dir2 = new Vector3(0, 5, 0);
    public Vector3 MovimentacaoInimigo(Transform[] targets, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {
        anin.SetBool("Andar", false);
        speed = 5;
        Rotacionar(dir);
        if (dir.position.y < dir2.y)
        {
            dir.position += dir2.normalized * speed * Time.deltaTime;
        }
        return dir.position;
    }
    void Rotacionar(Transform dir)
    {
        Vector3 dir3 = (GameController.instance.player.transform.position - dir.position);
        dir.rotation = Quaternion.LookRotation(dir3);
    }

}
