using UnityEngine;

public class Distancia3 : MonoBehaviour, I_Combate_Player
{

    public void Atacar(GameObject[] arma, Animator anim)
    {
        GameController.instance.CriarMunicao("magia3", arma[0].transform);


    }
}

