using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool ativar_time_animacao;
    public Material material_player;
    string animacao_combate_player;
    float time_animacao;
    public GameObject[] municoes;
    public List<GameObject> inimmigos;
    public List<AbilidadePlayerScriptObject> poderesPlayer;
    public GameObject armaPlaye;
    public  GameObject player;
    public GameObject aprimoramentos_resistencia_player;
    public GameObject aprimoramentos_poderes_player;
    public bool playerConfronto;
    [SerializeField] Image sprite_estamina;
    [SerializeField] Image sprite_vida;
    [SerializeField] Text txt_timePoder;
    [SerializeField] Text txt_vida;
    [SerializeField] Text txt_requisitos_quest;
    [SerializeField] Text txt_titulo_quest;
    [SerializeField] float sensibilidadeMouse = 0;
    [SerializeField]ListaCanvas canvas;
    [SerializeField] int moedas;
    [SerializeField] TMP_Text txt_moedas;
    [SerializeField] GameObject painel_gameOver;
    List<MinionsDistancia> Observadores;
    public VarPoderesPlayer poderes_player;
    public VarCombatePlayer combates_player;
    public VarMovimentacaoPlayer  movimentacoes_player;
    Definicao_Quest defirQuest;
    [SerializeField] GameObject Portal;
    public Assistente assistente;

    public TMP_Text txtSlot1;
    public TMP_Text txtSlot2;
    [SerializeField] Image slot1;
    [SerializeField] Image slot2;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject ObjInfoGame;
     
    private void Start()
    {
        assistente = new Assistente();
        instance = this;

        AdiquirirPoderesPlayer();
        AdiquirirCombatesPlayer();
        AdiquirirMovimentacaoPlayer();
        AplicarQuest(new Definicao_Quest(new Quest1()));
         DefinirProgresso();

    }
    private void Update()
    {
        if (ativar_time_animacao)
        {
            TocarTimeAnimacao(player.GetComponent<Protagonista>().anim, animacao_combate_player);
        }
        ExecutarQuest();
       
    }
    
    //////FUN�OES Player///////
    public void AtualizarTimePoder(int n)
    {
        txt_timePoder.text = "" + n;
    }
    public void AtualizarEstaminaPlayer(float n)
    {

        sprite_estamina.fillAmount = n;
    }
    public void AtualizarVidaPlayer(float n)
    {
        txt_vida.text = (int)Player.Vida + "/" + (int)Player.LimmiteVida;
        sprite_vida.fillAmount = n;
    }

    public Player Player { get { return player.GetComponent<Protagonista>().Player; } }
    public Transform PlayerTransform { get { return player.transform; } }

    public void AumentarVidaPlayer(float atribuicao)
    {
        Player.AumentaMaximoVida(atribuicao);
        Save();
       
    }
    
    public void TrocarPoderPlayer(Definicao_Poder_Player poder)
    {
       Player.DefinirPoder(poder);
    }
    public void TrocaCombateDistanciaPlayer(DefinicaoCombate combate)
    {
        Player.DefinirCombateDistancia(combate);
    }
    public void TrocarMovimento( Definocao_movimentacaoPlayer correr)
    {
        Player.DefinirMovimento( correr);
    }

    public void AdiquirirPoderesPlayer()
    {
        poderes_player = Player.Poderes;
    }
    public void AdiquirirCombatesPlayer()
    {
        combates_player = Player.Combates;
    }
    public void AdiquirirMovimentacaoPlayer()
    {
        movimentacoes_player = Player.Movimentacoes;
    }
    public void TrocarDash(Definocao_movimentacaoPlayer dash)
    {
        Player.DefinirDash(dash);
    }
   public void DefinirPlayer(Player novaConfig)
    {
       player.GetComponent<Protagonista>().AtualizarConfigPlayer(novaConfig);
    }
    public bool CombateCorpoPlayer()
    {

        if (animacao_combate_player == "Combate_Cima" || animacao_combate_player == "Combate_Lado_Normal" || animacao_combate_player == "Combate_Lado_Rapido")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void AtivarAprimoramentosResistenciaPlayer()
    {
        aprimoramentos_resistencia_player.SetActive(true);
    }
    public void AtivarAprimoramentosPoderesPlayer()
    {
       aprimoramentos_poderes_player.SetActive(true);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////FUN�OES Mouse /////////

    float mouse = 0;
    public void RotacaoMouse(Transform rotate)
    {
        mouse += Input.GetAxis("Mouse X");
        rotate.rotation = Quaternion.Euler(0, mouse * sensibilidadeMouse, 0);
    }
   
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////FUN�OES GLOBAIS///////
    public void MoverProjetil(Transform dir, float speed)
    {

        dir.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public GameObject CriarMunicao(string nomemunicao, Transform arma)
    {
        GameObject municao = null;

        switch (nomemunicao)
        {
            case "magia1": municao = Instantiate(municoes[0], arma.position, arma.rotation); break;
            case "bomba": municao = Instantiate(municoes[4], arma.position, arma.rotation); break;
            case "magia2": municao = Instantiate(municoes[1], arma.position, arma.rotation); break;
            case "magia3": municao = Instantiate(municoes[2], arma.position, arma.rotation); break;


        }
        return municao;
    }
    

    public float subitrair(float n1, float n2)
    {
        float calculo = n1 - n2;
        return calculo;

    }
    public float Somar(float n1, float n2)
    {
        float calculo = n1 + n2;
        return calculo;

    }
    public float RemoverVida(float dano, float vida, GameObject obj)
    {
        if (vida > 0)
        {
            vida =  subitrair(vida, dano);
            
        }
        else
        {
            AlterarValorQuest();
            inimmigos.Remove(obj);
            Matar(obj);
            
        }
        return vida;
    }
    public void Matar(GameObject obj)
    {
        Destroy(obj);
    }
  
    public void FinalizarAnimacao( float time, string animacao)
    {
        ativar_time_animacao = true;
        animacao_combate_player = animacao;
        time_animacao = time;
    }

    void TocarTimeAnimacao(Animator anim, string nome)
    {
        if (time_animacao > 0)
        {
            time_animacao = time_animacao - Time.deltaTime;
        }
        if (time_animacao <= 0)
        {
            ativar_time_animacao = false;
            anim.SetBool(nome, false);
            animacao_combate_player = "";


        }

    }
    public void AdicionarInimigosLista(GameObject inimigo)
    {
        inimmigos.Add(inimigo);
    }
    public void AplicarQuest(Definicao_Quest quest)
    {
        defirQuest= quest;
    }
    public void AlterarValorQuest()
    {
        defirQuest.AlterarQuest();
    }
    public void ExecutarQuest()
    {
        defirQuest.ExecutarQuest();

    }
    public  void AtualizarCanvasQuest(string txt1, string txt2)
    {
        txt_requisitos_quest.text= txt1;
        txt_titulo_quest.text= txt2;
    }
    public void AtivarPortal()
    {
        Portal.gameObject.SetActive(true);
    }
   
    public void AdicionarObserver(MinionsDistancia observer)
    {
        Observadores.Add(observer);
    }
    public void AtualizarBotoesHabilidade()
    {
        for(int i = 0; i < canvas.GetBoestoes().Count; i++)
        {
            canvas.GetBoestoes()[i].DefinirBotaoHabilidades();
        }
    }
    public void ADDMoedas(int quantidades)
    {
        moedas += quantidades;
        AtualizarMoedas();
    }
    public void GastarMoedas(int valor)
    {
        moedas -= valor;
        AtualizarMoedas();
    } 
    public void AtualizarMoedas()
    {
       txt_moedas.text = moedas.ToString();
        
    }
    public void CarrgarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    public void GameOver()
    {
        painel_gameOver.SetActive(true);

    }
    public void AtualizarSlot(string slot1, string slot2)
    {
        txtSlot1.text = slot1;
        txtSlot2.text = slot2;
    }
    public void SelecionarSlot(Color Corslota1, Color Corsloat2)
    {
        slot1.color = Corslota1;
        slot2.color = Corsloat2;
    }
    public void AbilitarHud(){
        hud.gameObject.SetActive(true);
    }
   public void AtivarPlayer(bool definir){
          player.GetComponent<Protagonista>().Ativar(definir);
   }
   public void DefinirProgresso()
    {
        ObjInfoGame = GameObject.Find("InfoGame");
        InfoGame infoGame= ObjInfoGame.GetComponent<InfoGame>();
        //player.GetOrAddComponent<Protagonista>().Player.DefinirMaximoVida(infoGame.limiteVidaPlayer);
        Player.AtualizarPlayer(infoGame.GetPlayerAtualizado());

   }
    public void Save()
    {
        ObjInfoGame.GetComponent<InfoGame>().SavePlayer(Player);
    }
    public int GetMoedas()
    {
        return moedas;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

