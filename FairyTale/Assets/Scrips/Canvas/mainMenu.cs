using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mainMenu : MonoBehaviour
{
    public Image imagem; // Referência à imagem que deve aparecer

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProximaCena()
    {
        int proximaCenaIndex = SceneManager.GetActiveScene().buildIndex + 1; // Obtém o índice da próxima cena na ordem definida na build do jogo
        SceneManager.LoadScene(proximaCenaIndex); // Carrega a próxima cena
    }


    public void SairDoJogo()
    {
        Application.Quit(); // Encerra o jogo em um build final
    }
}
