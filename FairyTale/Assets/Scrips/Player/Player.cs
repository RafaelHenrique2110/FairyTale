using UnityEngine;


public class Player : MonoBehaviour
{
    private float vida = 0, forca = 0, escudo = 0, estamina = 0, limiteEstamina, timePoder, timePoder2, limiteTimePoder, limiteTimePoder2, limiteVida;

    Definocao_movimentacaoPlayer definir_movimento;
    Definocao_movimentacaoPlayer movimento_Dash = new Definocao_movimentacaoPlayer(new Sem_Dash());
    Definocao_movimentacaoPlayer movimento_Correr = new Definocao_movimentacaoPlayer(new Correr1());
    VarMovimentacaoPlayer movimentacoes;


    public Player(float limiteVida, float limiteForca, float limiteEscudo, float limiteEstamina, float limiteTimePoder, float limiteTimePoder2)
    {
        vida = limiteVida;
        forca = limiteForca;
        escudo = limiteEscudo;
        estamina = limiteEstamina;
        this.limiteEstamina = limiteEstamina;
        this.limiteTimePoder = limiteTimePoder;
        this.limiteTimePoder2 = limiteTimePoder2;
        this.limiteVida = limiteVida;


    }
    public void AtualizarPlayer(Player playerAtualizado)
    {

        // GameController.instance.DefinirPlayer(playerAtualizado);
        DefinirMaximoVida(playerAtualizado.LimmiteVida);
        DefinirVida(playerAtualizado.vida);
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
    public void DefinirMovimento(Definocao_movimentacaoPlayer correr)
    {
        movimento_Correr = correr;
    }
    public void AplicarMovimentacao(VarMovimentacaoPlayer movimentacoes)
    {
        this.movimentacoes = movimentacoes;
    }
    public void AbilitarMovimentacao()
    {
        movimento_Correr = movimentacoes.movimentacoes[2];
    }
    public void AlmentarTimePoder()
    {
        if (timePoder < limiteTimePoder)
        {
            timePoder = timePoder + Time.deltaTime;
            GameController.instance.AtualizarTimePoder(timePoder / limiteTimePoder);
        }
        if(timePoder >= limiteTimePoder)
        {
            DispausarPoder();
        }
      

    }
    public void AlmentarTimePoder2()
    {
        if (timePoder2 < limiteTimePoder2)
        {
            timePoder2 = timePoder2 + Time.deltaTime;
            GameController.instance.AtualizarTimePoder2(timePoder2 / limiteTimePoder2);
        }
        if (timePoder2 >= limiteTimePoder2)
        {
            DispausarPoder2();
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
    public void TomarDano(float dano)
    {

        if (vida > 0)
        {
            vida = GameController.instance.subitrair(vida, dano / escudo);
            GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
        }

    }
    public void Curar(float n)
    {
        if (vida < limiteVida)
        {
            vida = GameController.instance.Somar(vida, n);
            GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
        }

    }
    public void AumentaMaximoVida(float atribuicao)
    {
        limiteVida = GameController.instance.Somar(limiteVida, atribuicao);
        vida = limiteVida;
        GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
        Debug.Log(limiteVida);
    }
    public void ResetarVidaPlayer()
    {
        vida = limiteVida;
        GameController.instance.AtualizarVidaPlayer(vida / limiteVida);
    }
    public void DefinirMaximoVida(float atribuicao)
    {
        limiteVida = atribuicao;
        GameController.instance.AtualizarVidaPlayer(vida / limiteVida);

    }
    public void DefinirVida(float atribuicao)
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
   
    public void PausarPoder()
    {
        liberarPoder = false;
    }
    public void PausarPoder2()
    {
        liberarPoder2 = false;
    }
    public void DispausarPoder()
    {
        liberarPoder = true;
    }
    public void DispausarPoder2()
    {
        liberarPoder2 = true;
    }
    bool liberarPoder;
     bool liberarPoder2;

    public void DefinirTimePoder()
    {
        timePoder = 0;
        GameController.instance.AtualizarTimePoder((int)timePoder);
      
    }
    public void DefinirTimePoder2()
    {
        timePoder2 = 0;
        GameController.instance.AtualizarTimePoder2((int)timePoder2);

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
        if (!Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
        {
            dir.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            dir.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            dir.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            dir.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Correr();
        }
        else
        {
            Esperar();
            GameController.instance.GetAudioCorer().Stop();
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
    public float Vida { get { return vida; } }
    public float LimmiteVida { get { return limiteVida; } }
    public VarMovimentacaoPlayer Movimentacoes { get { return movimentacoes; } }
    public bool LiberarPoder()
    {
        return liberarPoder;
    }
    public bool LiberarPoder2()
    {
        return liberarPoder2;
    }






}

