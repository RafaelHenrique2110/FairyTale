using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionsCorpoACorpo : MonoBehaviour, I_Observer
{
    static float tamanhoVida = 20, tamanhoForca = 100, tamanhoEscudo = 20;
    public float speed = 0;
    public GameObject[] sensores;
    public Transform[] target;
    public Transform Posicionamento;
    [SerializeField] Image sprite_vida;
    [SerializeField] GameObject arma;
    [SerializeField] Rigidbody r;
    [SerializeField] Animator anin;
    [SerializeField] List<GameObject> inventario;
    [SerializeField] Dashed dashed;
    Inimigo minion = new Inimigo(tamanhoVida, tamanhoForca, tamanhoEscudo);
    void Start()
    {

        GameController.instance.assistente.AdicionarObservador(this);

        minion.Seguir();


    }
    void FixedUpdate()
    {
        minion.Socar();
        minion.UsarArma(arma,anin, minion);
        transform.position = minion.Mover(target, transform, speed, anin, minion);
    }


    public void Notificar()
    {

        minion.Seguir();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("municaoPlayer"))
        {
           
            dashed.Dash(other.transform.forward, 5);
            anin.SetBool("Dano", true);
            minion.PerderVida(other.GetComponent<Municao>().Dano, this.gameObject);
            minion.AtualizarVida(sprite_vida);
            Destroy(other.gameObject);
            StartCoroutine(minion.VoltarConciencia(anin));
            if (minion.Vida <= 0)
            {
                DroparIten(inventario);
                minion.Matar(this.gameObject);
            }

        }
        if (other.CompareTag("Espada") && GameController.instance.CombateCorpoPlayer())
        {
           
            dashed.Dash(other.transform.forward, 5);
            minion.definir_combate_basico = minion.Definir_Combate_Desabilitado;
            anin.SetBool("Dano", true);
            anin.SetBool("Soco", false);
            minion.PerderVida(other.GetComponent<ArmaBranca>().Dano, this.gameObject);
            minion.AtualizarVida(sprite_vida);
            StartCoroutine(minion.VoltarConciencia(anin));
            if (minion.Vida <= 0)
            {
                DroparIten(inventario);
                minion.Matar(this.gameObject);
            }

        }

    }
    public void DroparIten(List<GameObject> inventario)
    {

        for (int i = 0; i < inventario.Count; i++)
        {
            Instantiate(inventario[i].gameObject, transform.position, transform.rotation);
        }
    }

    public Inimigo Minion { get { return minion; } }

}
