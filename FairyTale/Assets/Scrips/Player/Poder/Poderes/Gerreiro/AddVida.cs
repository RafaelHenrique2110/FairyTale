using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PoderesPlayer/Addvida", order = 1)]

public class AddVida: Poder_SO
{
   [SerializeField] float vida;
    [SerializeField] float limiteTime;

    public override void ExecutarPoder()
    {
        GameController.instance.GetAudioTecarregarVida().Play();
       GameObject vfxcura= Instantiate(GameController.instance.Protagonista.VfxCura(), GameController.instance.Protagonista.transform.position, GameController.instance.Protagonista.transform.rotation);
        vfxcura.transform.parent = GameController.instance.Protagonista.transform;
        GameController.instance.Player.Curar(vida);
       // GameController.instance.AtivarRemoverEfeitoPoder(limiteTime);
        Destroy(vfxcura, limiteTime);



    }
    public override void RemoverEfeitoPoder()
    {
       // GameController.instance.Protagonista.VfxCura().SetActive(false);
    }
}
