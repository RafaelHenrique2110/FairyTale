using UnityEngine;

public class Seguir : MonoBehaviour, I_MovimentacaoInimigo
{
    float distancia;
    bool sortear = true;
    float tempo = 1f;
    float limitempo = 1f;
    Vector3 raio;

    public Vector3 MovimentacaoInimigo(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {

        tempo -= 1 * Time.deltaTime;

        if (tempo <= 0)
        {
            tempo = limitempo;
            sortear = true;

        }
        if (sortear)
        {
            sortear = false;
            raio = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));

        }
        anin.SetBool("Andar", false);
        speed = 7;
        Vector3 dir2 = (GameController.instance.player.transform.position - dir.position) - raio;
        Vector3 dir3 = (GameController.instance.player.transform.position - dir.position);
        distancia = Vector3.Distance(GameController.instance.PlayerTransform.position - raio, dir.position);
        dir.rotation = Quaternion.LookRotation(dir3);
        if (distancia > 5)
        {
            anin.SetBool("Correr", true);
            anin.SetBool("Soco", false);
            dir.position += (dir2.normalized) * speed * Time.deltaTime;
        }

        else
        {
            anin.SetBool("Correr", false);

        }
        return dir.position;
    }
}
