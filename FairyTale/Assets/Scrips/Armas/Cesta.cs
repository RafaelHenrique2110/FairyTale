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

    }
    public void Pegar()
    {
        state = stateCesta.Voltar;
    }
    void Ir()
    {
        transform.Translate(dirIr.normalized * 10 * Time.deltaTime);
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
            transform.rotation = targetVoltar.transform.rotation;
            //transform.parent = targetVoltar;
            Invoke("Tacar", tepoIda);
        }




    }


}

