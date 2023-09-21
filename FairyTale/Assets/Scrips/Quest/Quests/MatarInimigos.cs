using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Quest/MatarInimigos", order = 1)]
public class MatarInimigos :  So_Quest
{
    [SerializeField] So_Quest proxQuest;
    [SerializeField] int inimigos_para_matar = 10;
    int inimigos_Mortos = 0;
    [SerializeField] string titulo_quest = "Titulo ";
    [SerializeField]string requisitos_quest;
   
   public  void DefinirExecucaoQuest()
   {
        requisitos_quest= inimigos_Mortos+ "/" + inimigos_para_matar;
       
        if(inimigos_Mortos>=inimigos_para_matar)
        {
            GameController.instance.AplicarQuest(proxQuest);
        }
        
       
   }
    public override void  ExecuteQuest()
    {
        Debug.Log("mate inimigos");
        DefinirExecucaoQuest();
    }
    public override void  AtualizarQuest()
   {
        GameController.instance.AtualizarCanvasQuest(requisitos_quest, titulo_quest);
   }
    public override void AlterarQuest()
    {
        inimigos_Mortos++;
        AtualizarQuest();
    }

}
