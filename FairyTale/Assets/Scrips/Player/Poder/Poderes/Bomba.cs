using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PoderesPlayer/ Spawnar", order = 1)]
public class Bomba : Poder_SO
{
    Transform target;
    [SerializeField] GameObject muni��o;

    public override void ExecutarPoder()
    {
        target = GameController.instance.armaPlaye.transform;
        GameController.instance.GetAudioMissel().Play();
        Instantiate(muni��o, target.transform.position, target.transform.rotation);
    }
}

