using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Quest/Fale com o Chapeleiro", order = 1)]
public class FalarComChapeleiro : So_Quest
{
    [SerializeField] string titulo_quest = "Titulo ";
    [SerializeField] string requisitos_quest;
    public override void ExecuteQuest()
    {
        AtualizarQuest();
    }
    public override void AtualizarQuest()
    {
        GameController.instance.AtualizarCanvasQuest(requisitos_quest, titulo_quest);
    }

}
