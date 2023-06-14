using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Protagonista : MonoBehaviour
{

    static int limiteVida = 100;
    static int limiteForca = 0;
    static int limiteEscudo = 1;
    static int limiteEstamina = 10;
    static int limiteTimePoder = 20;
    public int limiteCombo = 3;
    [SerializeField] float RaioComfonto;
    float speed = 0;
    public int combo=2;
    bool resetarCombo;
    public Animator anim;
    [SerializeField] VarPoderesPlayer poderes;
    [SerializeField] VarCombatePlayer combates;
    [SerializeField] VarMovimentacaoPlayer movimentacoes;
    [SerializeField] GameObject[] arma;
    Player protagonista = new Player(limiteVida, limiteForca, limiteEscudo, limiteEstamina, limiteTimePoder);
   
    private void Start()
    {
        protagonista.AplicarPoder(poderes);
        protagonista.AplicarCombate(combates);
        protagonista.AplicarMovimentacao(movimentacoes);
        protagonista.Esperar();
        protagonista.CombateCorpoACorpo();
        protagonista.DesabilitarPoder();
        protagonista.DesabilitarCombateDistancia();
       // protagonista.DesabilitarDash();
        // protagonista.AbilitarMovimentacao();
    }
    int itemSelecionado;
    bool ativarAtaque=true;
    private void Update()
    {
        DetectarInimigoProximo();
        if (Input.GetKeyDown("1"))
        {
            itemSelecionado = 1;
           protagonista.CombateCorpoACorpo();
        }
        if (Input.GetKeyDown("2"))
        {
            itemSelecionado = 2;
            protagonista.CombateDistancia();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(resetarCombo);
            if (combo > 0&& ativarAtaque)
            {
                if (itemSelecionado !=2)
                {
                    Invoke("DiminuirCombo", 0.2f);
                    ativarAtaque = false;
                }
                
                protagonista.Atacar(arma, anim);
               
                
            }
            if (combo <= 1f)
            {
                resetarCombo = true;
            }


        }
        if (resetarCombo)
        {
          ResetarCombo();
        }

        protagonista.UsarPoder(arma, anim);
        transform.position = protagonista.Move(transform, speed, anim);
    }
    void DetectarInimigoProximo()
    {
        for(int i = 0; i <  GameController.instance.inimmigos.Count; i++)
        {
            float distancia= Vector3.Distance(GameController.instance.inimmigos[i].transform.position, transform.position);
            if(distancia <= 3)
            {
              GameController.instance.playerConfronto = true;
            }
            else if (distancia > 3)
            {
                GameController.instance.playerConfronto = false;
            }
        }
    }
    void DiminuirCombo()
    {
        combo = (int)GameController.instance.subitrair(combo, 1);
        ativarAtaque = true;

    }
    float tempoResetCombo = 1f;
    void ResetarCombo()
    {
        tempoResetCombo -= Time.deltaTime;
        if (tempoResetCombo <= 0)
        {
            combo = limiteCombo;
            tempoResetCombo = 1;
            resetarCombo = false;

        }


    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("munic�o"))
        {
            protagonista.TomarDano(1f, this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("mao_inimigo"))
        {
           protagonista.TomarDano(1f, this.gameObject);
            if (protagonista.Vida <= 0)
            {
                GameController.instance.GameOver();
            }
        }
        if (other.CompareTag("moedas"))
        {
            GameController.instance.ADDMoedas(1);
            Destroy(other.gameObject);
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Chapeleiro" && Input.GetKey("e"))
        {
            GameController.instance.AtivarAprimoramentosResistenciaPlayer();
        }
        else if (other.CompareTag("mudar_Combate") && Input.GetKey("e"))
        {
           GameController.instance.AtualizarBotoesHabilidade();
           GameController.instance.AtivarAprimoramentosPoderesPlayer();

        }
    }
    public Player Player { get { return protagonista; } }
   

}
