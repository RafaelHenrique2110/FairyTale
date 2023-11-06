using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] string scena;
    public void ProximaCena(string Scena)
    {
        SceneManager.LoadScene(Scena); // Carrega a próxima cena
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ProximaCena(scena);
        }
       
    }
}
   
