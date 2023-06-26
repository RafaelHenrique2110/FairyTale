using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    public Dialogo dialogo;

    public void ativaDialogo()
    {
        FindObjectOfType<ColtrolerDialogo>().ComecaDialogo(dialogo);
    }
}
