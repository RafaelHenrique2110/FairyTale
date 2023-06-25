using Unity.VisualScripting;
using UnityEngine;

public class InfoGame : MonoBehaviour
{
   [SerializeField] float limiteVidaPlayer;
   Player player;
   [SerializeField] int moedas;
    [SerializeField]  float barrasMelhoriasPlayer;
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
   public  Player GetPlayerSalvo()
    {
        return player;
    }
    public int GetMoedasSalvas()
    {
        return moedas;
    }
    public float GetLojaSalva()
    {
        return barrasMelhoriasPlayer;
    }
}
