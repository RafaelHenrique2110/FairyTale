using Unity.VisualScripting;
using UnityEngine;

public class InfoGame : MonoBehaviour
{
   [SerializeField] float limiteVidaPlayer;
   Player player;
   [SerializeField] int moedas;
    [SerializeField]  float barrasMelhoriasPlayer;
    [SerializeField] int nivelBotaoDistancia;
    [SerializeField] int nivelBotaoGuerreiro;
    private static InfoGame instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        player = new Player(limiteVidaPlayer, 0, 0, 0, 0);

    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    public void SavePlayer(Player player)
    {
       
        this.player = player;
    }
    public void SaveMoedas(int moedas)
    {
        this.moedas= moedas;
    }
    public void SaveLoja(float barrasMelhoriasPlayer)
    {
        this.barrasMelhoriasPlayer = barrasMelhoriasPlayer;
    }
    public void SaveNivelAprimoramentos(int botaoGuerreiro, int botaoDistancia)
    {
        this.nivelBotaoDistancia = botaoDistancia;
        this.nivelBotaoGuerreiro = botaoGuerreiro;
    }
    public  Player GetPlayerSalvo()
    {
        return player;
    }
    public int GetMoedasSalvas()
    {
        return moedas;
    }
    public int GetNivelAprimoramentosGerreiro()
    {
        return nivelBotaoGuerreiro;
    }
    public int GetNivelAprimoramentosDistamcia()
    {
        return nivelBotaoDistancia;
    }

    public float GetLojaSalva()
    {
        return barrasMelhoriasPlayer;
    }
}
