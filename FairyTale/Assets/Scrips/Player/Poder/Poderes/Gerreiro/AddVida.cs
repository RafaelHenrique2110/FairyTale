using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PoderesPlayer/Addvida", order = 1)]

public class AddVida: Poder_SO
{
   [SerializeField] float vida;
    [SerializeField] Sprite indentificadorPoder;
    
    public override void ExecutarPoder()
    {
        GameController.instance.Player.Curar(vida);
       

    }
}
