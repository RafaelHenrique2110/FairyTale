using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Definicao_Quest : MonoBehaviour
{
    I_Quest i_quest;
    public Definicao_Quest (I_Quest i_quest)
    {
        this.i_quest = i_quest;
    }
    public void ExecutarQuest()
    {
        i_quest.ExecutarQuest();
        i_quest.AtualizarQuest();
    }
   public  void AlterarQuest()
    {
        i_quest.Alterar();
    }

}
