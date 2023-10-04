using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Quest/Ir ate o portal", order = 1)]
public class Ir_ate_o_portal : So_Quest
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
    public void Alterar()
    {

    }
}
