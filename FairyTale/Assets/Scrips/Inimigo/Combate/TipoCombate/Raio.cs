using UnityEngine;

public class Raio : MonoBehaviour, I_Combate_Inimigo
{
    bool executando = true;
    float tempo_disparo = 1;
    public void Atacar(GameObject arma, Animator anim, Inimigo inimigo)
    {

        anim.SetBool("Soco", false);
        tempo_disparo = tempo_disparo - Time.deltaTime;
        if (tempo_disparo <= 0)
        {
            Debug.Log("RAAAIOOO");
            if (anim != null)
            {
                GameController.instance.CriarMunicao("muniçãoInimigo", arma.transform);
            }
            tempo_disparo = 1;
        }


    }

}
