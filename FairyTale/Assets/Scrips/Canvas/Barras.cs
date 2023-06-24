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
    public float NivelVida { get { return nivelVida; } }
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
        }
    }
   void Atualizar(Barras barra)
    {
        this.nivelVida = barra.Nivelvida;
    }
    void AtualizarNivelBarraVida(float nivel)
    {
        txt_nivel_vida_playe.text = "Nivel " + nivelVida;
        barra_nivel_vida_playe.fillAmount = nivel/limiteNivelVida;
    }
    public float Nivelvida { get { return nivelVida; } }
    public float LimiteNivelvida { get { return limiteNivelVida; } }
}
