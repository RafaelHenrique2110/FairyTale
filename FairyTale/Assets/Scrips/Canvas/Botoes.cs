using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Botoes : MonoBehaviour
{
   [SerializeField] Image nome;
    [SerializeField] TMP_Text descricao;
    [SerializeField] TMP_Text precoNivelBarra;
    int indexHabilidade;
    [SerializeField] List<AbilidadePlayerScriptObject> habilidadesDisponiveis;
    [SerializeField] AbilidadePlayerScriptObject so;
    int indexLita=0;
    [SerializeField] GameObject painel;
    [SerializeField] Barras barra_nivel;

    public void FecharPainel()
    {
        painel.SetActive(false);
    }
    public void AumentarNivelPlayer(int preco)
    {
        
        if(barra_nivel.Nivelvida < barra_nivel.LimiteNivelvida)
        {
            if (GameController.instance.GetMoedas()>= preco)
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
        precoNivelBarra.text = n.ToString()+".00 R$";
    }
    public void TrocarPoderPlayer()
    {

        GameController.instance.TrocarPoderPlayer(GameController.instance.poderes_player.poderes[indexHabilidade]);
        AtualizarBotaoHabilidades();
        FecharPainel();

    }
    public void TrocarCombatePlayer()
    {
        GameController.instance.TrocaCombateDistanciaPlayer(GameController.instance.combates_player.combates[indexHabilidade]);
        AtualizarBotaoHabilidades();
        FecharPainel();
        GameController.instance.AtualizarSlot("Ataque","Disparo");

    }
    public void TrocarDash()
    {
        GameController.instance.TrocarDash(GameController.instance.movimentacoes_player.movimentacoes[indexHabilidade]);
        AtualizarBotaoHabilidades();
        FecharPainel();
    }
    public void TrocarMovimentacao()
    {
        GameController.instance.TrocarMovimento( GameController.instance.movimentacoes_player.movimentacoes[indexHabilidade]);
        AtualizarBotaoHabilidades();
        FecharPainel();
    }
    public void AtualizarBotaoHabilidades()
    {
        if(indexLita< habilidadesDisponiveis.Count)
        {
            indexLita++;
            so = habilidadesDisponiveis[indexLita];
        }
       

    }
    public void DefinirBotaoHabilidades()
    {
        indexHabilidade = so.indexPoder;
        nome.sprite  = so.nomePoder;
        descricao.text= so.descricao;
        

    }
    public void CarrgarCena(string nomeCena)
    {
        GameController.instance.CarrgarCena(nomeCena);
    }


}
