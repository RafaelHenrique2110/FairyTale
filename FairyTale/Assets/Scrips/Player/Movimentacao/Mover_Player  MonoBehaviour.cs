using Unity.VisualScripting;
using UnityEngine;


public class Mover_Player : MonoBehaviour
{
    Transform dir;
    float speed;
    Animator anin;
    Vector3 move = Vector3.zero;
    float vertical;
    float horizontal;
    public Mover_Player(Transform dir, float speed, Animator anin)
    {
        this.dir = dir;
        this.speed = speed;
        this.anin = anin;
    }
    public Vector3 MoverPlayer()
    {
         vertical = Input.GetAxis("Vertical");
         horizontal = Input.GetAxis("Horizontal");
        move.x = horizontal;
        move.z = vertical;
        // Debug.Log(move);
        dir.position += move * speed * Time.deltaTime;
        if (move.magnitude >= 0.1f)
        {
            if (!GameController.instance.GetAudioCorer().isPlaying)
            {
                GameController.instance.GetAudioCorer().Play();
            }
            
           
        }
       
        ///dir.Translate(move * speed * Time.deltaTime);
        return dir.position;
        
    }
    public float GetVertical() => vertical;
    public float GetHorizontal()=> horizontal;

}
