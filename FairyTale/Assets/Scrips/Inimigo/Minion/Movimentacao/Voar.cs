using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class  Voar : MonoBehaviour, I_MovimentacaoInimigo
{
    float distancia;
    bool sortear=true;
    float tempo = 1f;
    float limitempo=1f;
    Vector3 target= new Vector3(0, 0, 0);
    Vector3 calculoVetor = new Vector3(0, 0, 0);
    Transform tran;

    public Vector3 MovimentacaoInimigo(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {
       anin.SetBool("Andar", false);
       // tran.position = new Vector3(0, 30, 0);
        speed = 7;
        Vector3 dir2 = (target[0].position - dir.position);
        dir.position += dir2 * speed * Time.deltaTime;
        
        return dir.position;
    }
}
