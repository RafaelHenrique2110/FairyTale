using UnityEngine;

public class Sensor : MonoBehaviour
{

    [SerializeField] float tamanhoDeteccao = 100;
    RaycastHit hit;
    public string detectr = "Colocar Nome";
    Ray ray;
    public bool detectou;


    private void FixedUpdate()
    {
        RayCastR();
    }
    void RayCastR()
    {

        Ray ray = new Ray(transform.position, transform.forward); ;
        if (Physics.Raycast(ray, out hit, tamanhoDeteccao))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider.CompareTag(detectr))
            {
                detectou = true;


            }

        }
        else
        {
            detectou = false;
        }

    }
}
