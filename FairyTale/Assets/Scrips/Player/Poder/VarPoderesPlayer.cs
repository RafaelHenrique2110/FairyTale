using System.Collections.Generic;
using UnityEngine;

public class VarPoderesPlayer : MonoBehaviour
{
    public List<Definicao_Poder_Player> poderes = new List<Definicao_Poder_Player>(5);


    private void Start()
    {
        poderes[0] = new Definicao_Poder_Player(new Sem_Poder());
        poderes[1] = new Definicao_Poder_Player(new Bomba());
        poderes[2] = new Definicao_Poder_Player(new Tank_1());
        poderes[3] = new Definicao_Poder_Player(new Tank_2());
        poderes[4] = new Definicao_Poder_Player(new Tank_3());
        poderes[5] = new Definicao_Poder_Player(new Tank_4());
    }
}
