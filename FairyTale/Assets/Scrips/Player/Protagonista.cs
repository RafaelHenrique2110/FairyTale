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
    public int combo = 2;
    bool resetarCombo;
    public Animator anim;
    [SerializeField] VarPoderesPlayer poderes;
    [SerializeField] VarCombatePlayer combates;
    [SerializeField] VarMovimentacaoPlayer movimentacoes;
    [SerializeField] GameObject[] arma;
    [SerializeField] Dashed dashed;
    Player protagonista = new Player(limiteVida, limiteForca, limiteEscudo, limiteEstamina, limiteTimePoder);
    [SerializeField] bool ativado;
    bool travaMovimento;
    [SerializeField] GameObject trails;
    [SerializeField] GameObject glow;



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
    bool ativarAtaque = true;
    private void Update()
    {
        if (ativado)
        {
            DetectarInimigoProximo();
            if (Input.GetKeyDown("1"))
            {
                itemSelecionado = 1;
                protagonista.CombateCorpoACorpo();
                GameController.instance.SelecionarSlot(Color.green, (Color.white));
            }
            if (Input.GetKeyDown("2"))
            {
                itemSelecionado = 2;
                protagonista.CombateDistancia();
                GameController.instance.SelecionarSlot(Color.white, (Color.green));
            }
            if (travaMovimento == false && !Input.GetKey(KeyCode.Mouse0))
            {
                transform.position = protagonista.Move(transform, speed, anim);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                MirarRotate();
                TravarMovimento();
                

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
                    protagonista.Atacar(arma, anim);
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
            

            protagonista.UsarPoder(arma, anim);

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

        if (other.CompareTag("municão"))
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
            protagonista.TomarDano(20f);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "gato")
        {
            GameController.instance.ativarDialogo(false);
        }
    }
    public Player Player { get { return protagonista; } }


}
