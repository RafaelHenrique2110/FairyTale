using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mainMenu : MonoBehaviour
{
    public Image imagem; // Referência à imagem que deve aparecer

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExibirImagemTemporariamente()); // Inicia a rotina para exibir a imagem temporariamente
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

    IEnumerator ExibirImagemTemporariamente()
    {
        imagem.enabled = true; // Ativa a imagem
        yield return new WaitForSeconds(2f); // Espera 2 segundos
        imagem.enabled = false; // Desativa a imagem
    }

    public void SairDoJogo()
    {
        Application.Quit(); // Encerra o jogo em um build final
    }
}
