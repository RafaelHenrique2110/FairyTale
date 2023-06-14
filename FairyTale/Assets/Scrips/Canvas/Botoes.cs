using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Botoes : MonoBehaviour
{
   [SerializeField] TMP_Text nome;
    int indexHabilidade;
    [SerializeField] List<AbilidadePlayerScriptObject> habilidadesDisponiveis;
    [SerializeField] AbilidadePlayerScriptObject so;
    int indexLita=0;
    [SerializeField] GameObject painel;

    public void FecharPainel()
    {
        painel.SetActive(false);
    }
    public void AumentarNivelPlayer(Barras barra_nivel)
    {
        if(barra_nivel.Nivelvida < barra_nivel.LimiteNivelvida)
        {
            GameController.instance.AumentarVidaPlayer(25);
        }
       
       
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
        nome.text = so.nomePoder;
      

    }
    public void CarrgarCena(string nomeCena)
    {
        GameController.instance.CarrgarCena(nomeCena);
    }


}
