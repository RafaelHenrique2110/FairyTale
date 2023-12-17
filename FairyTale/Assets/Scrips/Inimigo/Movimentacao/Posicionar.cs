using UnityEngine;

public class Posicionar : MonoBehaviour, I_MovimentacaoInimigo
{

    int posiTarget = 0;
    int num = 0;
    float distancia;
    Transform target;
    Vector3 raio;
    public Posicionar(Transform target)
    {
        this.target = target;
    }

    public Vector3 MovimentacaoInimigo(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {
        speed = 7;
        Vector3 dir2 = (GameController.instance.player.transform.position - dir.position);
        Vector3 dir3 = (GameController.instance.player.transform.position - dir.position);
        distancia = Vector3.Distance(GameController.instance.PlayerTransform.position - raio, dir.position);
        dir.rotation = Quaternion.LookRotation(dir3);
        if (distancia > 1)
        {
            anin.SetBool("Correr", true);
            anin.SetBool("Soco", false);
            dir.position += (dir2.normalized) * speed * Time.deltaTime;
        }
        else
        {
            Debug.Log("Posicionar");

            Debug.Log("ATIVARmIRA");
            inimigo.Mirar();
            anin.SetBool("Correr", false);
        }
      
      

        return dir.position;
    }
}
