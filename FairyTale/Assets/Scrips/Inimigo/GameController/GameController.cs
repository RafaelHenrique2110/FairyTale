using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject player;
    public GameObject aprimoramentos_resistencia_player;
    public GameObject aprimoramentos_poderes_player;
    public bool playerConfronto;
    [SerializeField] Image sprite_estamina;
    [SerializeField] Image sprite_vida;
    [SerializeField] Text txt_timePoder;
    [SerializeField] Text txt_timePoder2;
    [SerializeField] Image fillPoder;
    [SerializeField] Image fillPoder2;
    [SerializeField] TMP_Text txt_vida;
    [SerializeField] Text txt_requisitos_quest;
    [SerializeField] Text txt_titulo_quest;
    [SerializeField] float sensibilidadeMouse = 0;
    [SerializeField] ListaCanvas canvas;
    [SerializeField] int moedas;
    [SerializeField] TMP_Text txt_moedas;
    [SerializeField] GameObject painel_gameOver;
    [SerializeField] GameObject painel_vitoria;
    List<MinionsDistancia> Observadores;
    public VarMovimentacaoPlayer movimentacoes_player;
    [SerializeField] So_Quest Quest;
    [SerializeField] GameObject Portal;
    public Assistente assistente;

    public TMP_Text txtSlot1;
    public TMP_Text txtSlot2;
    [SerializeField] Image slot1;
    [SerializeField] Image slot2;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject ObjInfoGame;

    [SerializeField] GameObject BtnDialogo;
    [SerializeField] AudioSource audio_Correr;
    [SerializeField] Chapeuzinho chapeuzinho;
    [SerializeField] GameObject portalFinal;
   [SerializeField] bool removerEfeitoplayer;
    [SerializeField] float timeRemoverEfeitoPLAYER;
    [SerializeField] Image indentificadorPoder;
    [SerializeField] Image indentificadorPoder2;
    private void Start()
    {
        assistente = new Assistente();
        instance = this;
        if (indentificadorPoder == null)
        {
            indentificadorPoder = GameObject.Find("INDENTIFICADOR").GetComponent<Image>();
        }
        if(indentificadorPoder2 == null)
        {
            indentificadorPoder2 = GameObject.Find("INDENTIFICADOR2").GetComponent<Image>();
        }
        AdiquirirMovimentacaoPlayer();
        AplicarQuest(Quest);
        AtualizarQuest();
        DefinirProgresso();
       


    }
    private void Update()
    {
        if (ativar_time_animacao)
        {
            TocarTimeAnimacao(player.GetComponent<Protagonista>().anim, animacao_combate_player);
        }
        ExecutarQuest();
        if (removerEfeitoplayer)
        {
            RemoverEfeitoPlayer();
        }

    }

    //////FUN�OES Player///////
    public void AtualizarTimePoder(float n)
    {
        txt_timePoder.text = "" + n;
        fillPoder.fillAmount = n;

    }
    public void AtualizarTimePoder2(float n)
    {

        fillPoder2.fillAmount = n;

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
    public Protagonista Protagonista { get { return player.GetComponent<Protagonista>(); } }

    public void AumentarVidaPlayer(float atribuicao)
    {
        Player.AumentaMaximoVida(atribuicao);
        Save();

    }
    void ResetarVidaPlayer()
    {
        Player.ResetarVidaPlayer();
    }

    public void TrocarMovimento(Definocao_movimentacaoPlayer correr)
    {
        Player.DefinirMovimento(correr);
    }
    public void AlterarValorQuest()
    {
        Quest.AlterarQuest();
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
    public void SetIndentificadorPoder(Sprite sprite)
    {
       indentificadorPoder.sprite = sprite;
    }
    public void SetIndentificadorPoder2(Sprite sprite)
    {
        indentificadorPoder2.sprite = sprite;
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
    public void AtivarRemoverEfeitoPoder(float tempo)
    {
        timeRemoverEfeitoPLAYER = tempo;
        removerEfeitoplayer = true;
    }
    public void RemoverEfeitoPlayer()
    {

        timeRemoverEfeitoPLAYER -= Time.deltaTime;
        if(timeRemoverEfeitoPLAYER <= 0)
        {
            Protagonista.GetPoder().RemoverEfeitoPoder();
            removerEfeitoplayer = false;
        }
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
            case "muniçãoInimigo": municao = Instantiate(municoes[4], arma.position, arma.rotation); break;
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
            vida = subitrair(vida, dano);

        }
        else
        {
           // AlterarValorQuest();
            inimmigos.Remove(obj);
            
           

        }
        return vida;
    }


    public void FinalizarAnimacao(float time, string animacao)
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
    public void AplicarQuest(So_Quest quest)
    {
        Quest = quest;
    }
    public void ExecutarQuest()
    {
        Quest.ExecuteQuest();

    }
    public void AtualizarQuest()
    {
        Quest.AtualizarQuest();
    }
    public void AtualizarCanvasQuest(string txt1, string txt2)
    {
        txt_requisitos_quest.text = txt1;
        txt_titulo_quest.text = txt2;
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
        for (int i = 0; i < canvas.GetBoestoes().Count; i++)
        {
            canvas.GetBoestoes()[i].DefinirBotaoHabilidades();
        }
    }
    public void ADDMoedas(int quantidades)
    {
        moedas += quantidades;
        AtualizarHudMoedas();
    }
    public void GastarMoedas(int valor)
    {
        moedas -= valor;
        AtualizarHudMoedas();
    }
    public void AtualizarHudMoedas()
    {
        txt_moedas.text = moedas.ToString();

    }
    public void AtualizarMoedas(int moedaSalva)
    {
        moedas = moedaSalva;
        GameController.instance.AtualizarHudMoedas();
    }
    public void CarrgarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    public void GameOver()
    {
        painel_gameOver.SetActive(true);
        ResetarVidaPlayer();

    }
    public void Vitoria()
    {
        painel_vitoria.SetActive(true);


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
    public void AbilitarHud()
    {
        hud.gameObject.SetActive(true);
    }
    public void AtivarPlayer(bool definir)
    {
        player.GetComponent<Protagonista>().Ativar(definir);
    }
    void AtualizarLoja(Barras barra)
    {

          hud.GetComponent<Barras>().Equals( hud.GetComponent<Barras>());

    }
    public void AtualizarMelhoriaHabilidades(int indexMeloriaGerreiro, int indexMeloriaDistancia)
    {
         canvas.GetComponent<ListaCanvas>().GetBoestoes()[0].GetComponent<Botoes>().AtualizarIndexMelhoriaHabilidades(indexMeloriaGerreiro);
        canvas.GetComponent<ListaCanvas>().GetBoestoes()[1].GetComponent<Botoes>().AtualizarIndexMelhoriaHabilidades(indexMeloriaDistancia);
    }
    public void DefinirProgresso()
    {
        ObjInfoGame = GameObject.Find("InfoGame");
        InfoGame infoGame = ObjInfoGame.GetComponent<InfoGame>();
        //player.GetOrAddComponent<Protagonista>().Player.DefinirMaximoVida(infoGame.limiteVidaPlayer);
        if (infoGame.GetPoder1()!= null)
        {
            Protagonista.SetPoder(infoGame.GetPoder1());
            SetIndentificadorPoder(infoGame.GetPoder1().GetIndentificadorPoder());
        }
        if (infoGame.GetPoder2() != null)
        {
            Protagonista.SetPoder2(infoGame.GetPoder2());
            SetIndentificadorPoder2(infoGame.GetPoder2().GetIndentificadorPoder());
        }
        if (infoGame.GetCombate() != null)
        {
            Protagonista.SetCombate(infoGame.GetCombate());
        }  
       Player.AtualizarPlayer(infoGame.GetPlayerSalvo());
        AtualizarMoedas(infoGame.GetMoedasSalvas());
        hud.GetComponent<Barras>().Atualizar(infoGame.GetLojaSalva());
        if (SceneManager.GetActiveScene().name == "Fase1")
        {
            AtualizarMelhoriaHabilidades(infoGame.GetNivelAprimoramentosGerreiro(), infoGame.GetNivelAprimoramentosDistamcia());
        }


    }
    public void AtivarPortalFinal()
    {
        portalFinal.SetActive(true);
    }
    public void Save()
    {
        ObjInfoGame.GetComponent<InfoGame>().SavePlayer(Player);
        ObjInfoGame.GetComponent<InfoGame>().SaveMoedas(moedas);
       ObjInfoGame.GetComponent<InfoGame>().SaveLoja(hud.GetComponent<Barras>().Nivelvida);
        ObjInfoGame.GetComponent<InfoGame>().SavePoder1(Protagonista.GetPoder());
        ObjInfoGame.GetComponent<InfoGame>().SavePoder2(Protagonista.GetPoder2());
        ObjInfoGame.GetComponent<InfoGame>().SaveCombate(Protagonista.GetCombate());
        if (SceneManager.GetActiveScene().name == "Fase1")
        {
            ObjInfoGame.GetComponent<InfoGame>().SaveNivelAprimoramentos(canvas.GetComponent<ListaCanvas>().GetBoestoes()[0].GetComponent<Botoes>().GetIndexBotao(), canvas.GetComponent<ListaCanvas>().GetBoestoes()[1].GetComponent<Botoes>().GetIndexBotao());
        }
    }

    public int GetMoedas()
    {
        return moedas;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public void ativarDialogo(bool ativo)
    {
        BtnDialogo.SetActive(ativo);
    }
    public AudioSource GetAudioCorer() => audio_Correr;
    public Chapeuzinho GetChapeuzinho() => chapeuzinho;
}
