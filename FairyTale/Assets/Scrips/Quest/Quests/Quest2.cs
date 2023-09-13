using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2 : MonoBehaviour, I_Quest
{
    string titulo_quest = "Vá para o portal! ";
    string requisitos_quest;
    public void DefinirExecucaoQuest()
    {
        GameController.instance.AtivarPortal();
    }
    public void AtualizarQuest()
    {
        GameController.instance.AtualizarCanvasQuest(requisitos_quest, titulo_quest);
    }
    public void Alterar()
    {
       
    }
}
