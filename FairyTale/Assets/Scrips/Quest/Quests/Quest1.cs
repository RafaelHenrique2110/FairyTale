using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : TipoQuste, I_Quest
{
    int inimigos_Mortos =0, inimigos_para_matar = 10;
    string titulo_quest = "Elimine os  Inimigos! ";
    string requisitos_quest;
   
   public  void DefinirExecucaoQuest()
   {
        requisitos_quest= inimigos_Mortos+ "/" + inimigos_para_matar;
       
        if(inimigos_Mortos>=inimigos_para_matar)
        {
            GameController.instance.AplicarQuest(new Definicao_Quest(new Quest2()));
        }
        
        //Debug.Log("INIMIGOS MORTOS "+inimigos_Mortos);
   }
    public override void ExecuraQuest()
    {
        DefinirExecucaoQuest();
    }
    public void AtualizarQuest()
   {
        GameController.instance.AtualizarCanvasQuest(requisitos_quest, titulo_quest);
   }
    public  void Alterar()
    {
        inimigos_Mortos++;
        AtualizarQuest();
    }

}
