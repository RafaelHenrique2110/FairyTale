using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    public Dialogo dialogo;

    public void ativaDialogo()
    {
        FindObjectOfType<ColtrolerDialogo>().ComecaDialogo(dialogo);
      GameController.instance.AtivarPlayer(false);
    }
}
