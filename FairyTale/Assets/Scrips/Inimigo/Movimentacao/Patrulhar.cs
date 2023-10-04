using UnityEngine;

public class Patrulhar : MonoBehaviour, I_MovimentacaoInimigo
{
    int posiTarget = 0;
    int num = 0;
    public Vector3 MovimentacaoInimigo(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {

        anin.SetBool("Correr", false);
        anin.SetBool("Andar", true);
        speed = 5;
        Vector3 dir2 = target[posiTarget].position - dir.position;
        if (dir2.magnitude < 0.1)
        {
            num++;
            posiTarget = num % target.Length;
        }
        dir.rotation = Quaternion.LookRotation(dir2);
        dir.position += dir2.normalized * speed * Time.deltaTime;

        return dir.position;
    }

}
