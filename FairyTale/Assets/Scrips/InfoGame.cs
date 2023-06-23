using Unity.VisualScripting;
using UnityEngine;

public class InfoGame : MonoBehaviour
{
   [SerializeField] float limiteVidaPlayer;
    Player player;


    private void Awake()
    {
       
        DontDestroyOnLoad(gameObject);
        player = new Player(limiteVidaPlayer, 0, 0, 0, 0);

    }
   
    public void SavePlayer(Player player)
    {
       
        this.player = player;
    }
   public  Player GetPlayerAtualizado()
    {
        return player;
    }
}
