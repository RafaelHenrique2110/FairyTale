using UnityEngine;

public class Distancia1 : MonoBehaviour, I_Combate_Player
{

    public void Atacar(GameObject[] arma, Animator anim)
    {
        GameController.instance.CriarMunicao("magia1", arma[0].transform);


    }
}
