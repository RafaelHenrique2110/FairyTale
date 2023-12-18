using UnityEngine;

public class InfoGame : MonoBehaviour
{
    [SerializeField] float limiteVidaPlayer;
    Player player;
    [SerializeField] int moedas;
    [SerializeField] float barrasMelhoriasPlayer;
    [SerializeField] int nivelBotaoDistancia;
    [SerializeField] int nivelBotaoGuerreiro;
    private static InfoGame instance;
    [SerializeField] Poder_SO poder1;
    [SerializeField] Poder_SO poder2;
    [SerializeField] combate_So combate;

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
        player = new Player(limiteVidaPlayer, 0, 0, 0, 0,0);

    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    public Poder_SO GetPoder1() => poder1;
   public Poder_SO GetPoder2() => poder2;

    public combate_So GetCombate() => combate;

    public void SavePoder1(Poder_SO poder)
    {
        poder1 = poder;
    }
    public void SavePoder2(Poder_SO poder)
    {
        poder2 = poder;
    }
    public void SaveCombate(combate_So combate)
    {
       this.combate = combate;
    }
    public void SavePlayer(Player player)
    {

        this.player = player;
    }
    public void SaveMoedas(int moedas)
    {
        this.moedas = moedas;
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
    public Player GetPlayerSalvo()
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
