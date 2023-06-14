using UnityEngine;

public class Distancia2 : MonoBehaviour, I_Combate_Player
{

    public void Atacar(GameObject[] arma, Animator anim)
    {
        GameController.instance.CriarMunicao("magia2", arma[0].transform);


    }
}
