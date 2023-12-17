using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Botoes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image nome;
    [SerializeField] TMP_Text descricao;
    [SerializeField] TMP_Text precoNivelBarra;
    [SerializeField] Sprite novoSprite;
    [SerializeField] Button nexBotao;
    int indexHabilidade;
    int indexLita;
    [SerializeField] AbilidadePlayerScriptObject habilidade;
    [SerializeField] AbilidadePlayerScriptObject so;
    [SerializeField] GameObject painel;
    [SerializeField] Barras barra_nivel;
    [SerializeField] Sprite indentificadorPoder;
    [SerializeField] Sprite indentificadorPoder2;
    [SerializeField] GameObject painelDescricaoPoder;
    [SerializeField] Poder_SO novoPoder;
    [SerializeField] combate_So novoCombate;

    public void FecharPainel()
    {
        painel.SetActive(false);
        GameController.instance.AtivarPlayer(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("FOI");
        painelDescricaoPoder.SetActive(true);
        if (novoPoder != null)
        {
            painelDescricaoPoder.GetComponent<PaineLPoder>().SetPainel(novoPoder.titulo, novoPoder.descricao);
        }
        if(novoCombate != null)
        {
            painelDescricaoPoder.GetComponent<PaineLPoder>().SetPainel( novoCombate.titulo, novoCombate.descricao);
        }
        
    }
    public  void OnPointerExit(PointerEventData eventData)
    {
        painelDescricaoPoder.SetActive(false);
    }
   
    public void AumentarNivelPlayer(int preco)
    {

        if (barra_nivel.Nivelvida < barra_nivel.LimiteNivelvida)
        {
            if (GameController.instance.GetMoedas() >= preco)
            {

                GameController.instance.AumentarVidaPlayer(25);
                barra_nivel.AumentarNivelBarraVida();
                GameController.instance.GastarMoedas(preco);
                preco = preco * 2;
                AtualizarPrecoCompraNivelVida(preco);
                GameController.instance.Save();

            }

        }


    }
    void AtualizarPrecoCompraNivelVida(int n)
    {
        precoNivelBarra.text = n.ToString() + ".00 R$";
    }
    public void TrocarPoderPlayer(Poder_SO novoPoder)
    {
        GameController.instance.SetIndentificadorPoder(indentificadorPoder);
        GameController.instance.Protagonista.SetPoder(novoPoder);
        GetComponent<Image>().sprite = novoSprite;
        //GetComponent<Button>().interactable = false;
        if (nexBotao != null)
        {
            nexBotao.interactable = true;
        }
       

       // GameController.instance.TrocarPoderPlayer(GameController.instance.poderes_player.poderes[indexHabilidade]);
       // AtualizarBotaoHabilidades();
      //  FecharPainel();

    }
    public void TrocarPoderPlayer2(Poder_SO novoPoder)
    {
        GameController.instance.SetIndentificadorPoder2(indentificadorPoder2);
        GameController.instance.Protagonista.SetPoder2(novoPoder);
        GetComponent<Image>().sprite = novoSprite;
        //GetComponent<Button>().interactable = false;
        if (nexBotao != null)
        {
            nexBotao.interactable = true;
        }


        // GameController.instance.TrocarPoderPlayer(GameController.instance.poderes_player.poderes[indexHabilidade]);
        // AtualizarBotaoHabilidades();
        //  FecharPainel();

    }
    public void MelhorarForça(int dano)
    {
        Protagonista protagonista = GameController.instance.PlayerTransform.GetComponent<Protagonista>();
        GetComponent<Image>().sprite = novoSprite;
        protagonista.SetDano(dano);
    }
    public void TrocarCombatePlayer(combate_So novoCombate)
    {
        GameController.instance.Protagonista.SetCombate(novoCombate);
        GetComponent<Image>().sprite = novoSprite;
        //GetComponent<Button>().interactable = false;
        if (nexBotao != null)
        {
            nexBotao.interactable = true;
        }
        //GameController.instance.TrocaCombateDistanciaPlayer(GameController.instance.combates_player.combates[indexHabilidade]);
        //AtualizarBotaoHabilidades();
        //FecharPainel();
        //GameController.instance.AtualizarSlot("Ataque", "Disparo");

    }
    public void TrocarDash()
    {
        GameController.instance.TrocarDash(GameController.instance.movimentacoes_player.movimentacoes[indexHabilidade]);
         AtualizarBotaoHabilidades();
        FecharPainel();
    }
    public void TrocarMovimentacao()
    {
        GameController.instance.TrocarMovimento(GameController.instance.movimentacoes_player.movimentacoes[indexHabilidade]);
        AtualizarBotaoHabilidades();
        FecharPainel();
    }
    public void AtualizarBotaoHabilidades()
    {

        so = habilidade;
        GameController.instance.Save();

    }
    public void AtualizarIndexMelhoriaHabilidades(int indexLista)
    {
        so = habilidade;
        DefinirBotaoHabilidades();
    }
    public void DefinirBotaoHabilidades()
    {
        indexHabilidade = so.indexPoder;
        nome.sprite = so.nomePoder;
        descricao.text = so.descricao;


    }
    public void CarrgarCena(string nomeCena)
    {
        GameController.instance.CarrgarCena(nomeCena);
    }
    public int GetIndexBotao()
    {
        return indexLita;
    }


}
