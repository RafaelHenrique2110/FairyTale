using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmaBranca : MonoBehaviour
{
    [SerializeField] float minimum;
    [SerializeField] float maximum;
    [SerializeField] float t;
    [SerializeField] float speed;
    [SerializeField] bool ativar= false;
    [SerializeField] int dano;
    [SerializeField] Quaternion rotate;
    [SerializeField] GameObject obj;
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
          
           
        }
        if (ativar)
        {
            t = t + 1 * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, Mathf.Lerp(minimum, maximum, t), 0);
        }
        if (transform.rotation.y>= 1)
        {
            ativar = false;
            obj.SetActive(false);
            transform.rotation = rotate;
            t = 0;
           
        }
    }
    public void Usar()
    {
        obj.SetActive(true);
        ativar = true;
    }
           
    public float Dano { get { return dano; } }
}
