using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MinionsDistancia : MonoBehaviour, I_Observer
{
    static int tamanhoVida = 1, tamanhoForca = 5, tamanhoEscudo = 5;
    public float speed = 0;
    public GameObject[] sensores;
    public Transform[] target;
    public Transform Posicionamento;
    [SerializeField] Image sprite_vida;
    [SerializeField] GameObject arma;
    [SerializeField] Rigidbody r;
    [SerializeField] Animator anin;
    [SerializeField] List<GameObject> inventario;
    Inimigo minion = new Inimigo(tamanhoVida, tamanhoForca, tamanhoEscudo);

    void Start()
    {

        GameController.instance.assistente.AdicionarObservador(this);
        minion.arma = arma;
        minion.Posicionar(Posicionamento);
        minion.PegarRaio();

    }
    void FixedUpdate()
    {

       minion.UsarArma(arma, anin, minion);
        transform.position = minion.Mover(target, transform, speed, anin, this.minion);
    }

    public void Notificar()
    {
        minion.Posicionar(Posicionamento);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("municaoPlayer"))
        {
            if (minion.Vida <= 0)
            {
                DroparIten(inventario);
                minion.Matar(this.gameObject);
            }
            anin.SetBool("Dano", true);
            minion.PerderVida(other.GetComponent<Municao>().Dano, this.gameObject);

            minion.AtualizarVida(sprite_vida);
            Destroy(other.gameObject);
            StartCoroutine(minion.VoltarConciencia(anin));

        }
        if (other.CompareTag("Espada") && GameController.instance.CombateCorpoPlayer())
        {
            if (minion.Vida <= 0)
            {
                DroparIten(inventario);
                minion.Matar(this.gameObject);


            }
            minion.definir_combate_basico = minion.Definir_Combate_Desabilitado;
            anin.SetBool("Dano", true);
            anin.SetBool("Soco", false);
            //ChapeuzunhoV.Inpulso();
            minion.PerderVida(other.GetComponent<ArmaBranca>().Dano, this.gameObject);
            minion.AtualizarVida(sprite_vida);
            StartCoroutine(minion.VoltarConciencia(anin));

        }


    }
    public void DroparIten(List<GameObject> inventario)
    {

        for (int i = 0; i < inventario.Count; i++)
        {
            Instantiate(inventario[i], transform.position, transform.rotation);

        }
    }
    public Inimigo Minion { get { return minion; } }



}
