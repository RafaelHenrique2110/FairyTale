using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    private float vida = 0, forca = 0, escudo =0, estamina = 0, limiteEstamina, timePoder, limiteTimePoder, limiteVida;
    
    Definocao_movimentacaoPlayer definir_movimento;
    Definocao_movimentacaoPlayer movimento_Dash = new Definocao_movimentacaoPlayer(new Sem_Dash());
    Definocao_movimentacaoPlayer movimento_Correr= new Definocao_movimentacaoPlayer(new Correr1());
    DefinicaoCombate definir_combate_corpo_a_corpo;
    DefinicaoCombate definir_combate_distancia;
    DefinicaoCombate definir_combate;
    DefinicaoCombate combate_espada= new DefinicaoCombate(new Corpo_A_Corpo1());
    VarPoderesPlayer poderes;
    VarCombatePlayer combates;
    VarMovimentacaoPlayer movimentacoes;
    Definicao_Poder_Player definir_poder;
    Definicao_Poder_Player sem_poder = new Definicao_Poder_Player(new Sem_Poder());
 
   
    public Player(float limiteVida, float limiteForca, float limiteEscudo, float limiteEstamina, float limiteTimePoder)
    {
        vida = limiteVida;
        forca = limiteForca;
        escudo = limiteEscudo;
        estamina = limiteEstamina;
        this.limiteEstamina = limiteEstamina;
        this.limiteTimePoder = limiteTimePoder;
        this.limiteVida = limiteVida;
       
     
    }
    public  void AtualizarPlayer(Player playerAtualizado)
    {
        
       // GameController.instance.DefinirPlayer(playerAtualizado);
        DefinirMaximoVida(playerAtualizado.LimmiteVida);
        DefinirVida(playerAtualizado.vida);
       definir_combate_distancia = playerAtualizado.DefiniCombateDistancia;
        definir_poder = playerAtualizado.DefiniPoder;
    }

    public void Esperar()
    {
        GanharEstamina();
        definir_movimento = movimentacoes.movimentacoes[0];
    }
    public void Correr()
    {
        definir_movimento = movimento_Correr; 
    }
    public void DefinirMovimento( Definocao_movimentacaoPlayer correr)
    {
        movimento_Correr= correr;
    }
    public void AplicarMovimentacao(VarMovimentacaoPlayer movimentacoes)
    {
        this.movimentacoes = movimentacoes;
    }
    public void AbilitarMovimentacao()
    {
        movimento_Correr= movimentacoes.movimentacoes[2];
    }
    public void DiminurTimePoder()
    {
        if (timePoder > 0)
        {
            timePoder = timePoder - Time.deltaTime;
            GameController.instance.AtualizarTimePoder((int)timePoder);
        }

    }
    void PerderEstamina(float perda)
    {
        if (estamina > 0)
        {
            estamina = estamina - perda * Time.deltaTime;
            GameController.instance.AtualizarEstaminaPlayer(estamina / limiteEstamina);
        }
    }
    public  void TomarDano(float dano)
    {
        
        if (vida > 0)
        {
            vida = GameController.instance.subitrair(vida, dano/escudo);
            GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
        }
        
    }
    public void Curar(float n)
    {
        vida = GameController.instance.Somar(vida,n);
        GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
    }
    public void AumentaMaximoVida(float atribuicao)
    {
        limiteVida = GameController.instance.Somar(limiteVida,atribuicao);
        vida = limiteVida;
        GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
        Debug.Log(limiteVida);
    }
    public void DefinirMaximoVida(float atribuicao)
    {
        limiteVida = atribuicao;
        GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
      
    }
     void DefinirVida(float atribuicao)
    {
        this.vida = atribuicao;
        GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
    }

    public void AumentaEscudo(float atribuicao)
    {
        escudo = GameController.instance.Somar(escudo, atribuicao);
    }
    void PerderEstaminaEstantanio(float perda)
    {
        if (estamina > 0)
        {
            estamina = GameController.instance.subitrair(estamina, perda);
            GameController.instance.AtualizarEstaminaPlayer(estamina / limiteEstamina);

        }

    }
    void GanharEstamina()
    {
        if (estamina < limiteEstamina)
        {

            estamina = estamina + Time.deltaTime;
            GameController.instance.AtualizarEstaminaPlayer(estamina / limiteEstamina);

        }
    }
    public void AplicarCombate(VarCombatePlayer combates)
    {
        this.combates = combates; 
    }
    public void CombateCorpoACorpo()
    {
        definir_combate_corpo_a_corpo = combate_espada;
        definir_combate = definir_combate_corpo_a_corpo;
    }
    public void CombateDistancia()
    {
        definir_combate = definir_combate_distancia;

    }
    public void DesabilitarCombateDistancia()
    {
        definir_combate_distancia = combates.combates[0];
    }
    public void DefinirCombateDistancia(DefinicaoCombate combate)
    {
       definir_combate_distancia = combate;
        CombateDistancia();

    }
    public void AplicarPoder(VarPoderesPlayer poderes)
    {
       this.poderes = poderes;
       
    }
    public void DesabilitarPoder()
    {
        definir_poder = sem_poder;
    }
    public void PegarEscudo()
    {
        GameController.instance.TrocarPoderPlayer(GameController.instance.poderes_player.poderes[2]);

    }
    public void DefinirPoder(Definicao_Poder_Player poder)
    {
        definir_poder = poder;
    }

    public void Atacar(GameObject [] arma, Animator anim)
    {
      
       
           
            definir_combate.Atacar(arma, anim);
        
        

    }
  
    public void PausarPoder()
    {
        liberarPoder = false;
    }
    public void DispausarPoder()
    {
        liberarPoder = true;
    }
    bool liberarPoder;
    public void UsarPoder(GameObject[] arma, Animator anim)
    {
        
        DiminurTimePoder();
       
        if (Input.GetKeyDown("f") && timePoder <= 0) 
        {        
           // if (definir_poder!=sem_poder)
           // {
                DispausarPoder();
                Debug.Log("aaoaooaoa");
                timePoder = limiteTimePoder;
          //  }
           
  
        }
        if (liberarPoder)
        {
           escudo = definir_poder.UsarPoder(GameController.instance.armaPlaye, anim, escudo);
        }
    }
    public void UsarDash()
    {
        
       // PerderEstaminaEstantanio(5);
        definir_movimento = movimento_Dash;
    }
    public void DefinirDash(Definocao_movimentacaoPlayer dash)
    {
        movimento_Dash = dash;
    }
    public void DesabilitarDash()
    {
        movimento_Dash = movimentacoes.movimentacoes[4];
    }
    public Vector3 Move(Transform dir, float speed, Animator anin)
    {
        //Debug.Log("limite" + limiteVida);
        if (Input.GetKey(KeyCode.W))
        {
            dir.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.rotation = Quaternion.Euler(0,180 , 0);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Correr();
        }
        else
        {
            Esperar();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (estamina > 0)
            {
                UsarDash();
            }
        }

        dir.position = definir_movimento.Mover(dir, speed, anin);
        return dir.position;
    }
    public DefinicaoCombate DefiniCombate { get { return definir_combate; } }
    public Definicao_Poder_Player DefiniPoder { get { return definir_poder; } }
    public DefinicaoCombate DefiniCombateDistancia { get { return definir_combate_distancia; } }
    public Definicao_Poder_Player Definir_Poder { get { return definir_poder; } }
    public float Vida { get { return vida; } }
    public float LimmiteVida { get { return limiteVida; } }
    public VarPoderesPlayer Poderes { get { return poderes; } }
    public VarCombatePlayer Combates { get { return combates; } }
    public VarMovimentacaoPlayer Movimentacoes { get { return movimentacoes; } }




}

