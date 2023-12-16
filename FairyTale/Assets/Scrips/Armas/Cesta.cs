using UnityEngine;

public enum stateCesta { IR, Voltar };
public class Cesta : MonoBehaviour
{
    [SerializeField] stateCesta state;
    [SerializeField] float tepoIda;
    [SerializeField] float tepoVolta;
    [SerializeField] Vector3 dirIr;
    Vector3 dirVoltar;
    [SerializeField] Transform targetVoltar;
    [SerializeField] Transform targetRotate;
    [SerializeField] GameObject corpoCesta;
    public void Update()
    {
       
    }
    public void Rotacionar()
    {
        Vector3 rotate = targetRotate.position - transform.position;
        transform.rotation= Quaternion.LookRotation(rotate);
    }
    public void Usar()
    {
        if (state == stateCesta.IR)
        {
            Ir();
        }
        if (state == stateCesta.Voltar)
        {
            Voltar();
        }
    }
    public void Tacar()
    {
        state = stateCesta.IR;
        transform.parent = null;
        AtivarCesta();

    }
    public void Pegar()
    {
        state = stateCesta.Voltar;
    }
    void Ir()
    {
        transform.Translate(dirIr.normalized * 10 * Time.deltaTime);
        //Rotacionar();
        DesativarCesta();
        Invoke("Pegar", tepoVolta);
    }
    void Voltar()
    {
        dirVoltar = targetVoltar.position - transform.position;
        if (dirVoltar.magnitude > 0.5)
        {
            transform.position += dirVoltar.normalized * 20 * Time.deltaTime;


        }
        if (dirVoltar.magnitude <= 0.5)
        {
            Vector3 rotate = targetRotate.position - transform.position;
            transform.rotation =Quaternion.LookRotation(rotate);
            //transform.parent = targetVoltar;
            Invoke("Tacar", tepoIda);
        }




    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            DesativarCesta();

            Invoke("AtivarCesta", 5);
        }
    }

    public void AtivarCesta()
    {
        corpoCesta.SetActive(true);
    }
    public void DesativarCesta()
    {
        corpoCesta.SetActive(false);
    }



}

