using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inimigo : MonoBehaviour
{
    float vida, forca, escudo, tamanhoVida, tamanhoForca, tamanhoEscudo;
    public GameObject arma;
    public  Definicao_Combate_Inimigo definir_combate_basico;
    Definicao_Combate_Inimigo definir_combate_raio = new Definicao_Combate_Inimigo(new Raio());
    Definicao_Combate_Inimigo definir_combate_soco = new Definicao_Combate_Inimigo(new Soco());
    Definicao_Combate_Inimigo definir_combate_desabilitado = new Definicao_Combate_Inimigo(new CombateDesabilitado ());
    Definicao_Movimentacao_Inimigo definicao_movimentacao;
    Definicao_Movimentacao_Inimigo definir_movimento_patrulhar = new Definicao_Movimentacao_Inimigo(new Patrulhar());
    Definicao_Movimentacao_Inimigo definir_movimento_seguir = new Definicao_Movimentacao_Inimigo(new Seguir());
    Definicao_Movimentacao_Inimigo definir_movimento_Mirar= new Definicao_Movimentacao_Inimigo(new Mirar());
    Definicao_Movimentacao_Inimigo definir_movimento_Voar = new Definicao_Movimentacao_Inimigo(new Voar());
    float distancia;
   

    public Inimigo(float tamanhoVida, float tamanhoForca, float tamanhoEscudo)
    {
        forca = tamanhoForca;
        escudo = tamanhoEscudo;
        vida = tamanhoVida;
        this.tamanhoVida = tamanhoVida;


    }
    public void Patrulhar()
    {

        definicao_movimentacao = definir_movimento_patrulhar;
    }
    public void Voar()
    {

        definicao_movimentacao = definir_movimento_Voar;
    }
    public void Seguir()
    {
       definicao_movimentacao = definir_movimento_seguir;
    }
    public void AtualizarVida( Image sprite_vida)
    {
        Debug.Log("tamanhovIDA" + tamanhoVida);
        sprite_vida.fillAmount = vida /tamanhoVida;
    }
    public void Posicionar(Transform target)
    {
        definicao_movimentacao = new Definicao_Movimentacao_Inimigo(new Posicionar(target));
    }

    public void UsarArma(GameObject arma, Animator anim, Inimigo inimigo )
    {
        definir_combate_basico.Atacar(arma, anim, inimigo); 
    }
    public void PegarRaio()
    {
        definir_combate_basico = definir_combate_raio;
    }
    public Vector3 Mover(Transform[] target, Transform dir, float speed, Animator anin, Inimigo inimigo)
    {
       
        dir.position = definicao_movimentacao.Mover(target, dir, speed, anin, inimigo);
        distancia = Vector3.Distance(GameController.instance.PlayerTransform.position, dir.position);
        return dir.position;
    }
    public void Mirar()
    {
      
        definicao_movimentacao = definir_movimento_Mirar;
    }
    public  void Socar()
    {
     
        if (distancia <= 1)
        {
            Debug.Log("ATIVOUSOCOO");
            definir_combate_basico = definir_combate_soco;

        }
        if (distancia > 1 && distancia < 2)
        {
            definir_combate_basico = definir_combate_desabilitado;
        }
    }
    bool notificar = true;
    public void DetectarMovimento(GameObject[] sensores, Animator anim)
    {

       
        for (int i = 0; i < sensores.Length; i++)
        {
            if (sensores[i].GetComponent<Sensor>().detectou)
            {
                if (notificar)
                {
                    GameController.instance.assistente.Notificar();
                    notificar = false;
                }
               
                
                    UsarArma(arma, anim, this);
                
               

            }

        }
    }

    public void PerderVida(float dano, GameObject obj)
    {
        vida = GameController.instance.RemoverVida(dano, vida, obj);

    }
   
    public IEnumerator VoltarConciencia(Animator anim)
    {

        yield return new WaitForSeconds(1f);
        anim.SetBool("Dano", false);

    }
    public Definicao_Combate_Inimigo Definir_Combate_Desabilitado { get { return definir_combate_desabilitado; } }
    public Definicao_Combate_Inimigo Definir_Combate_Soco { get { return definir_combate_soco; } }
    public void Inpulso()
    {
     
        definicao_movimentacao = new Definicao_Movimentacao_Inimigo(new Inpulso());
       
    }
    public float Vida { get { return vida; } }
    




}
