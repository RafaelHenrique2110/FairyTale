using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PoderesPlayer/ Spawnar", order = 1)]
public class Bomba : Poder_SO
{
    Transform target;
    [SerializeField] GameObject munição;

    public override void ExecutarPoder()
    {
        target = GameController.instance.armaPlaye.transform;
        Instantiate(munição, target.transform.position, target.transform.rotation);
    }
}

