using UnityEngine;

public class Posicionar : MonoBehaviour, I_MovimentacaoInimigo
{

    int posiTarget = 0;
    int num = 0;
    float distancia;
    Transform target;
    public Posicionar(Transform target)
    {
        this.target = target;
    }

    public Vector3 MovimentacaoInimigo(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {
        Debug.Log("Posicionar");
        anin.SetBool("Correr", true);
        anin.SetBool("Andar", false);
        speed = 5;
        Vector3 dir2 = this.target.position - dir.position;
        distancia = Vector3.Distance(this.target.position, dir.position);
        if (distancia >= 0.1)
        {

            dir.rotation = Quaternion.LookRotation(dir2);
            dir.position += dir2.normalized * speed * Time.deltaTime;
        }
        if (distancia < 2f)
        {
            Debug.Log("ATIVARmIRA");
            inimigo.Mirar();
            anin.SetBool("Correr", false);
        }

        return dir.position;
    }
}
