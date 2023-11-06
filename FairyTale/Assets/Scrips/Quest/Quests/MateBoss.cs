using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Quest/MatarBoss", order = 1)]
public class MateBoss : So_Quest
{
    [SerializeField] So_Quest proxQuest;
    [SerializeField] string titulo_quest = "Titulo ";
    [SerializeField] string requisitos_quest;

    public void DefinirExecucaoQuest()
    {
      
        if (GameController.instance.GetChapeuzinho().Chapeuzinhov.Vida <= 0)
        {
            Debug.Log("VITORIAAAAAAAAAAAAAAAAA");
        }
    }
    public override void ExecuteQuest()
    {
       
        DefinirExecucaoQuest();
    }
    public override void AtualizarQuest()
    {
        GameController.instance.AtualizarCanvasQuest(requisitos_quest, titulo_quest);
    }
    public override void AlterarQuest()
    {
      
        AtualizarQuest();
    }

}
