using Unity.VisualScripting;
using UnityEngine;

public class InfoGame : MonoBehaviour
{
   [SerializeField] float limiteVidaPlayer;
   Player player;
   [SerializeField] int moedas;
    [SerializeField] Barras barrasMelhoriasPlayer;


    private void Awake()
    {
       
        DontDestroyOnLoad(gameObject);
        player = new Player(limiteVidaPlayer, 0, 0, 0, 0);

    }
    public void SavePlayer(Player player)
    {
       
        this.player = player;
    }
    public void SaveMoedas(int moedas)
    {
        this.moedas= moedas;
    }
    public void SaveLoja(Barras barrasMelhoriasPlayer)
    {
        this.barrasMelhoriasPlayer = barrasMelhoriasPlayer;
    }
   public  Player GetPlayerSalvo()
    {
        return player;
    }
    public int GetMoedasSalvas()
    {
        return moedas;
    }
    public Barras GetLojaSalva()
    {
        return barrasMelhoriasPlayer;
    }
}
