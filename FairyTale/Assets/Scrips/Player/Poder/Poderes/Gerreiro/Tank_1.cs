using UnityEngine;
using System;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PoderesPlayer/Tank_1", order = 1)]
public class Tank_1 : Poder_SO
{
    [SerializeField] float limiteTime;
    [SerializeField] float valEscudo;
    [SerializeField] Color colorEscudo;
    [SerializeField] Color colorSemEscudo;
    public override void ExecutarPoder()
    {
      
       GameController.instance.Protagonista.GetEscudo().SetActive(true);
        GameController.instance.material_player.color = colorEscudo;
        GameController.instance.Player.AumentaEscudo(valEscudo);
        GameController.instance.AtivarRemoverEfeitoPoder(limiteTime);

    }
    public override void RemoverEfeitoPoder()
    {
        // GameController.instance.Player.PausarPoder();
        GameController.instance.material_player.color = colorSemEscudo;
        GameController.instance.Player.AumentaEscudo(valEscudo);
        GameController.instance.Protagonista.GetEscudo().SetActive(false);
    }

}
