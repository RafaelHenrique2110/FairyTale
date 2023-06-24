using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Barras : MonoBehaviour
{
    [SerializeField] float nivelVida; 
    [SerializeField] float limiteNivelVida;
    [SerializeField] Text txt_nivel_vida_playe;
    [SerializeField] Image barra_nivel_vida_playe;
    private void Start()
    {
        AtualizarNivelBarraVida(nivelVida);
    }
    public void AumentarNivelBarraVida()
    {
        if(nivelVida< limiteNivelVida)
        {
            nivelVida++;
            AtualizarNivelBarraVida(nivelVida);
            GameController.instance.Save();
        }
    }
   public void Atualizar(float barra)
    {
        this.nivelVida = barra;
        AtualizarNivelBarraVida(nivelVida);
    }
    void AtualizarNivelBarraVida(float nivel)
    {
        txt_nivel_vida_playe.text = "Nivel " + nivelVida;
        barra_nivel_vida_playe.fillAmount = nivel/limiteNivelVida;
    }
    public float Nivelvida { get { return nivelVida; } }
    public float LimiteNivelvida { get { return limiteNivelVida; } }
}
