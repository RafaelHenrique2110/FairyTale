using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CombatePlayer/ Bater", order = 1)]
public class Corpo_A_Corpo1 : combate_So
{
    int tempo = 10;
    string[] animacao = new string[2];
    GameObject armaobj;
    [SerializeField] int dano;

    public override void ExecutarCombate()
    {
        if (!GameController.instance.GetAudioEspadada().isPlaying)
        {
            GameController.instance.GetAudioEspadada().Play();
        }
       
        Protagonista protagonista = GameController.instance.PlayerTransform.GetComponent<Protagonista>();
        protagonista.Dash();
        armaobj = protagonista.arma[1];
        protagonista.trails.SetActive(true);
        animacao[1] = "Combate_Lado_Normal";
        protagonista.GetAnimaitor().SetBool("Correr", false);
        protagonista.GetAnimaitor().SetBool("Andar", false);
        armaobj.GetComponent<ArmaBranca>().SetDano(protagonista.GetDano());
        armaobj.GetComponent<ArmaBranca>().Usar();
        
        if (GameController.instance.ativar_time_animacao == false)
        {
           
            int index = Random.Range(0, 2);
            protagonista.GetAnimaitor().SetBool(animacao[1], true);
            GameController.instance.FinalizarAnimacao(0.1f, animacao[1]);
        }
    }

    //IEnumerator UsarArma()
    //{

    //    armaobj.GetComponent<ArmaBranca>().Usar();
    //    yield return new WaitForSeconds(10f);
    //}


}