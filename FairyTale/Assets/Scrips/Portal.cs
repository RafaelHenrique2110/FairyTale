using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] string scena;
    public void ProximaCena(string Scena)
    {
        SceneManager.LoadScene(Scena); // Carrega a próxima cena
    }
    private void OnTriggerEnter(Collider other)
    {
        ProximaCena(scena);
    }
}
