using UnityEngine;
using static Cinemachine.CinemachineTriggerAction.ActionSettings;

public class Protagonista : MonoBehaviour
{

    static int limiteVida = 100;
    static int limiteForca = 0;
    static int limiteEscudo = 1;
    static int limiteEstamina = 10;
    static int limiteTimePoder = 20;
    static int limiteTimePoder2 = 20;
    public int limiteCombo = 3;
    [SerializeField] float RaioComfonto;
    float speed = 0;
    public int combo = 2;
    bool resetarCombo;
    public Animator anim;
    [SerializeField] VarMovimentacaoPlayer movimentacoes;
    public GameObject[] arma;
    [SerializeField] Dashed dashed;
    Player protagonista = new Player(limiteVida, limiteForca, limiteEscudo, limiteEstamina, limiteTimePoder, limiteTimePoder2);
    [SerializeField] bool ativado;
    bool travaMovimento;
     public GameObject trails;
    [SerializeField] GameObject glow;
    [SerializeField] Poder_SO poder;
    [SerializeField] Poder_SO poder2;
    [SerializeField] combate_So combate;
    [SerializeField] int dano;
    [SerializeField] GameObject escudo;
    [SerializeField] GameObject vfxCura;
    public GameObject armatarget;




    private void Start()
    {
        
        protagonista.AplicarMovimentacao(movimentacoes);
        protagonista.Esperar();
      GameController.instance.DefinirProgresso();

        // protagonista.DesabilitarDash();
        // protagonista.AbilitarMovimentacao();

    }
    int itemSelecionado;
    bool ativarAtaque = true;
    private void Update()
    {
        if (ativado)
        {
            //  DetectarInimigoProximo();
            //if (Input.GetKeyDown("1"))
            //{
            //    itemSelecionado = 1;
            //    GameController.instance.SelecionarSlot(Color.green, (Color.white));
            //}
            //if (Input.GetKeyDown("2"))
            //{
            //    itemSelecionado = 2;
            //    GameController.instance.SelecionarSlot(Color.white, (Color.green));
            //}
            if (travaMovimento == false && !Input.GetKey(KeyCode.Mouse0))
            {
                transform.position = protagonista.Move(transform, speed, anim);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                MirarRotate();
                TravarMovimento();
                Combater();


                if (combo > 0 && ativarAtaque)
                {
                    if (itemSelecionado != 2)
                    {
                        Invoke("DiminuirCombo", 0.5f);
                        ativarAtaque = false;
                    }
                    trails.SetActive(true);
                    glow.SetActive(true);
                    Invoke("DisabilitarEfeitoEspada", 1.5f);
                    Invoke("DistravarMovimento", 1f);


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
            // protagonista.UsarPoder(arma, anim);
            protagonista.AlmentarTimePoder();
             protagonista.AlmentarTimePoder2();
            if (Input.GetKeyDown("f"))
            {
                
                if (protagonista.LiberarPoder())
                {
                    protagonista.DefinirTimePoder();
                    // escudo = definir_poder.UsarPoder(GameController.instance.armaPlaye, anim, escudo);
                    if (poder != null)
                    {
                        ExecutarPoder();
                    }


                }

               

            }
            if (Input.GetKeyDown("q"))
            {

                if (protagonista.LiberarPoder2())
                {
                    protagonista.DefinirTimePoder2();
                    // escudo = definir_poder.UsarPoder(GameController.instance.armaPlaye, anim, escudo);
                    if (poder2 != null)
                    {
                        ExecutarPoder2();
                    }


                }



            }




        }
    }
    public void DisabilitarEfeitoEspada()
    {
        trails.SetActive(false);
        glow.SetActive(false);
    }
    public void DistravarMovimento()
    {
        travaMovimento = false;
    }
    public void TravarMovimento()
    {
        travaMovimento = true;
    }
    public void Dash()
    {
        dashed.Dash(transform.forward, 2);
    }
    void DetectarInimigoProximo()
    {
        for (int i = 0; i < GameController.instance.inimmigos.Count; i++)
        {
            float distancia = Vector3.Distance(GameController.instance.inimmigos[i].transform.position, transform.position);
            if (distancia <= 3)
            {
                GameController.instance.playerConfronto = true;
            }
            else if (distancia > 3)
            {
                GameController.instance.playerConfronto = false;
            }
        }
    }
    public void SetDano(int dano)
    {
       this.dano = dano;
    }
    public int GetDano()
    {
        return dano;
    }
    public void SetPoder(Poder_SO novoPoder)
    {
        poder= novoPoder;
    }
    public void SetCombate(combate_So novoCombate)
    {
        combate = novoCombate;
    }
    public void SetPoder2(Poder_SO novoPoder)
    {
        poder2 = novoPoder;
    }
    public void ExecutarPoder()
    {
        protagonista.PausarPoder();
       protagonista.DefinirTimePoder();
        poder.ExecutarPoder();
    }
    public void ExecutarPoder2()
    {
        protagonista.PausarPoder2();
        protagonista.DefinirTimePoder2();
        poder2.ExecutarPoder();
    }
    public void Combater()
    {
        combate.ExecutarCombate();
    }
    void DiminuirCombo()
    {
        combo = (int)GameController.instance.subitrair(combo, 1);
        ativarAtaque = true;

    }
    public void Ativar(bool definir)
    {
        ativado = definir;
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
    public void AtualizarConfigPlayer(Player player)
    {
        protagonista = player;
    }
    void MirarRotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // Verifica se o raio atingiu um objeto
        {
            Vector3 targetDirection = hit.point - transform.position;
            targetDirection.y = 0; // Mantém o vetor no plano horizontal
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Rotaciona suavemente o jogador para a nova rotação
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 400f);
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("municaoInimigo"))
        {
            protagonista.TomarDano(1f);
            GameController.instance.Save();

            Destroy(other.gameObject);
        }
        if (other.CompareTag("mao_inimigo"))
        {
            GameController.instance.Save();
            protagonista.TomarDano(1f);
            if (protagonista.Vida <= 0)
            {
                GameController.instance.GameOver();
            }
        }

        if (other.CompareTag("cesta"))
        {
            protagonista.TomarDano(10f);
            if (protagonista.Vida <= 0)
            {
                GameController.instance.GameOver();
            }
        }
        if (other.CompareTag("moedas"))
        {
            GameController.instance.ADDMoedas(1);
            Destroy(other.gameObject);
            GameController.instance.Save();
        }
        if (other.CompareTag("gato"))
        {
            GameController.instance.ativarDialogo(true);
           
        }
        if (other.CompareTag("Vida"))
        {
            if (protagonista.Vida < protagonista.LimmiteVida)
            {
                protagonista.Curar(8);
                Destroy(other.gameObject);
            }

        }
        if (other.CompareTag("terminarJogo"))
        {
            GameController.instance.Vitoria();
        }
        if (other.CompareTag("mataPlayer"))
        {
            GameController.instance.GameOver();
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Chapeleiro" && Input.GetKey("e"))
        {
            GameController.instance.AtivarAprimoramentosResistenciaPlayer();
            GameController.instance.AtivarPlayer(false);
        }
        else if (other.CompareTag("mudar_Combate") && Input.GetKey("e"))
        {
           // GameController.instance.AtualizarBotoesHabilidade();
            GameController.instance.AtivarAprimoramentosPoderesPlayer();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "gato")
        {
            GameController.instance.ativarDialogo(false);
        }
    }
    public Player Player { get { return protagonista; } }
    public Poder_SO GetPoder()
    {
        return poder;
    }
    public Poder_SO GetPoder2()
    {
        return poder2;
    }

    public combate_So GetCombate() => combate;
    public Animator GetAnimaitor() => anim;
    public GameObject GetEscudo() => escudo;
    public GameObject VfxCura() => vfxCura;



}
