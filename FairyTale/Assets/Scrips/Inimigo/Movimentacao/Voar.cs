using UnityEngine;

public class Voar : MonoBehaviour, I_MovimentacaoInimigo
{

    Vector3 dir2 = new Vector3(0, 0, 0);
    Vector3 dir3;

    public Vector3 MovimentacaoInimigo(Transform[] targets, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {
        Vector3 dir3 = new Vector3(0, 5, 0);
        anin.SetBool("Andar", false);
        speed = 5;
       
        dir2.x = GameController.instance.player.transform.position.x - dir.position.x;
        dir2.z = GameController.instance.player.transform.position.z - dir.position.z;
        if (dir2.magnitude > 2)
        {
            dir.position += dir2.normalized * speed * Time.deltaTime;
        }
        
        if (dir.position.y < dir3.y)
        {

            dir.position += dir3.normalized * speed * Time.deltaTime;
        };
       
        if (dir2.magnitude > 0.1f)
        {
            Rotacionar(dir);

        }
        return dir.position;
    }
    void Rotacionar(Transform dir)
    {
        Vector3 dir3 = GameController.instance.player.transform.position - dir.position;
        dir3.y = 0;
        dir.rotation = Quaternion.LookRotation(dir3);
    }

}
