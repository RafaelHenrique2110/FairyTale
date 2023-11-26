using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CombatePlayer/ Spawnar", order = 1)]
public class Spawnar : combate_So
{
     Transform target;
    [SerializeField] GameObject muni��o;
    
    public override void ExecutarCombate()
    {
        target = GameController.instance.armaPlaye.transform;
        Instantiate(muni��o,target.transform.position,target.transform.rotation);
    }
}
