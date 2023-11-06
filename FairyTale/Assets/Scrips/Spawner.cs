using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
  

   public  void Spwnar()
    {
        GameObject obj = Instantiate(prefab, transform.position, transform.rotation);
        GameController.instance.AdicionarInimigosLista(obj);



    }
}
