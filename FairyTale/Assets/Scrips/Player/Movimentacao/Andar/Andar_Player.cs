using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Andar_Player : MonoBehaviour, I_movimentacaoPlayer
{

    static Animation anin;

    public Vector3 Movimentacao(Transform dir, float speed, Animator anin)
    {
        anin.SetBool("Andar", true);
        anin.SetBool("Correr", false);
        speed = 5;
        Debug.Log("Andar_Player");
        Mover_Player mover = new Mover_Player(dir, speed, anin);
        dir.position = mover.MoverPlayer();
        return dir.position;

    }

}
