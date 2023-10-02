using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lobo : MonoBehaviour
{
    static float tamanhoVida = 50, tamanhoForca = 10, tamanhoEscudo = 5;
    public float speed = 0;
    public GameObject[] sensores;
    public Transform[] target;
    public Transform Posicionamento;
    [SerializeField] Image sprite_vida;
    [SerializeField] GameObject arma;
    [SerializeField] Rigidbody r;
    [SerializeField] Animator anin;
    [SerializeField] List<GameObject> inventario;
    [SerializeField] Chapeuzinho chapeuzinho;
    [SerializeField] Dashed dashed;
    Inimigo lobo = new Inimigo(tamanhoVida, tamanhoForca, tamanhoEscudo);
    void Start()
    {

        lobo.Seguir();


    }
    void FixedUpdate()
    {
        lobo.Socar();
        transform.position = lobo.Mover(target, transform, speed, anin, lobo);
       lobo.UsarArma(arma, GetAnimator, lobo);
    }


    public void Notificar()
    {

        lobo.Seguir();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("municão"))
        {
            
            anin.SetBool("Dano", true);
            lobo.PerderVida(other.GetComponent<Municao>().Dano, this.gameObject);
            lobo.AtualizarVida(sprite_vida);
            Destroy(other.gameObject);
            if (lobo.Vida <= 0)
            {
                chapeuzinho.Chapeuzinhov.Seguir();
                chapeuzinho.Chapeuzinhov.Socar();
                lobo.EntrarEmComa(gameObject);

            }
            if (lobo.Vida > 0)
            {
                StartCoroutine(lobo.VoltarConciencia(anin));
            }
            

        }
        if (other.CompareTag("Espada") && GameController.instance.CombateCorpoPlayer())
        {
            dashed.Dash(other.transform.forward, 5);
            lobo.definir_combate_basico = lobo.Definir_Combate_Desabilitado;
            anin.SetBool("Dano", true);
            anin.SetBool("Soco", false);
            lobo.PerderVida(other.GetComponent<ArmaBranca>().Dano, this.gameObject);
            Debug.Log(lobo.Vida);
            lobo.AtualizarVida(sprite_vida);
            if (lobo.Vida <= 0)
            {
                chapeuzinho.Chapeuzinhov.Seguir();
                chapeuzinho.Chapeuzinhov.Socar();
                chapeuzinho.HabilitarGravidade(true);
                lobo.EntrarEmComa(gameObject);
                StartCoroutine(lobo.VoltarDoComa(gameObject,50));
                StartCoroutine(NotificarChapeuzinho(11));
              


            }
            if (lobo.Vida > 0)
            {
                StartCoroutine(lobo.VoltarConciencia(anin));
            }

        }

    }
    public IEnumerator  NotificarChapeuzinho(float time)
    {
        yield return new WaitForSeconds(time);
        if(lobo.Vida <= 0)
        {
            chapeuzinho.Chapeuzinhov.Seguir();
            chapeuzinho.Chapeuzinhov.Socar();
            chapeuzinho.HabilitarGravidade(true);
        }
        else
        {
            chapeuzinho.HabilitarGravidade(false);
            chapeuzinho.Chapeuzinhov.Voar();
            chapeuzinho.Chapeuzinhov.PegarCesta();
        }
    }
    public void DroparIten(List<GameObject> inventario)
    {

        for (int i = 0; i < inventario.Count; i++)
        {
            Instantiate(inventario[i].gameObject, transform.position, transform.rotation);
        }
    }

    public Inimigo lOBO { get { return lobo; } }
    public Image GetSpriteVida { get { return sprite_vida; } }
    public Animator GetAnimator { get { return anin; } }

}
