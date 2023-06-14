using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover_Player : MonoBehaviour
{
    Transform dir;
    float speed;
    Animator anin;
    Vector3 move = Vector3.zero;
    public Mover_Player(Transform dir, float speed, Animator anin)
    {
        this.dir = dir;
        this.speed = speed;
        this.anin = anin;
    }
    public Vector3 MoverPlayer()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        move.x = horizontal;
        move.z = vertical;
       // Debug.Log(move);
        dir.position += move * speed * Time.deltaTime;
        ///dir.Translate(move * speed * Time.deltaTime);
        return dir.position;
    }

}
