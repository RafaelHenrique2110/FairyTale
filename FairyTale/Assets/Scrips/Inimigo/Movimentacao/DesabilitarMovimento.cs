using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesabilitarMovimento : MonoBehaviour, I_MovimentacaoInimigo
{
    public Vector3 MovimentacaoInimigo(Transform[] targets, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {

        return dir.position;
    }
}
