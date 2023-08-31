using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chapeuzinho : MonoBehaviour
{
    static float tamanhoVida = 500, tamanhoForca = 200, tamanhoEscudo = 50;
    public float speed = 0;
    public GameObject[] sensores;
    public Transform[] target;
    public Transform Posicionamento;
    [SerializeField] Image sprite_vida;
    [SerializeField] GameObject arma;
    [SerializeField] Animator anin;
    [SerializeField] List<GameObject> inventario;
    Inimigo ChapeuzunhoV = new Inimigo(tamanhoVida, tamanhoForca, tamanhoEscudo);

    private void Start()
    {
        // ChapeuzunhoV.Seguir();
        ChapeuzunhoV.Voar();
    }
    void FixedUpdate()
    {
      
        ChapeuzunhoV.DetectarMovimento(sensores, anin);
        transform.position = ChapeuzunhoV.Mover(target, transform, speed, anin, ChapeuzunhoV);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("municão"))
        {
            if (ChapeuzunhoV.Vida <= 0)
            {
                DroparIten(inventario);
            }
            anin.SetBool("Dano", true);
            ChapeuzunhoV.PerderVida(other.GetComponent<Municao>().Dano, this.gameObject);
            ChapeuzunhoV.AtualizarVida(sprite_vida);
            Destroy(other.gameObject);
            StartCoroutine(ChapeuzunhoV.VoltarConciencia(anin));

        }
        if (other.CompareTag("Espada") && GameController.instance.CombateCorpoPlayer())
        {
            if (ChapeuzunhoV.Vida <= 0)
            {
                DroparIten(inventario);
            }
            ChapeuzunhoV.definir_combate_basico = ChapeuzunhoV.Definir_Combate_Desabilitado;
            anin.SetBool("Dano", true);
            anin.SetBool("Soco", false);
            ChapeuzunhoV.PerderVida(other.GetComponent<ArmaBranca>().Dano, this.gameObject);
            ChapeuzunhoV.AtualizarVida(sprite_vida);
            StartCoroutine(ChapeuzunhoV.VoltarConciencia(anin));

        }

    }
    public void DroparIten(List<GameObject> inventario)
    {

        for (int i = 0; i < inventario.Count; i++)
        {
            Instantiate(inventario[i].gameObject, transform.position, transform.rotation);
        }
    }

    public Inimigo Chapeuzinhov { get { return ChapeuzunhoV; } }
}
