using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
public class PaineLPoder : MonoBehaviour
{
    [SerializeField] TMP_Text tituloTipoPoder;
    [SerializeField] TMP_Text descricaoTipoPoder;

    public void SetPainel(string titulo, string texto)
    {
       tituloTipoPoder.text = titulo;
        descricaoTipoPoder.text = texto;
    }
}
