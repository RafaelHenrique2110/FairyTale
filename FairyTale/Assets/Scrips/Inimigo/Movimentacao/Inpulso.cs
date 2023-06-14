using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inpulso : MonoBehaviour, I_MovimentacaoInimigo
{
    float tempo = 3;
    public Vector3 MovimentacaoInimigo(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {
       
        speed = -3f;
        Vector3 v = new Vector3(0, 0, 1);
        Vector3 v2 = dir.position - v;
        dir.Translate(v2 * speed* Time.deltaTime);
           
        
        
        return dir.position;
    }
}
