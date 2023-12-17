using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PoderesPlayer/Addvida", order = 1)]

public class AddVida: Poder_SO
{
   [SerializeField] float vida;
    [SerializeField] Sprite indentificadorPoder;
    [SerializeField] float limiteTime;

    public override void ExecutarPoder()
    {

       GameObject vfxcura= Instantiate(GameController.instance.Protagonista.VfxCura(), GameController.instance.Protagonista.transform.position, GameController.instance.Protagonista.transform.rotation);
        GameController.instance.Player.Curar(vida);
       // GameController.instance.AtivarRemoverEfeitoPoder(limiteTime);
        Destroy(vfxcura, limiteTime);


    }
    public override void RemoverEfeitoPoder()
    {
       // GameController.instance.Protagonista.VfxCura().SetActive(false);
    }
}
