using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] int quantidade;
    void Start()
    {
        Invoke("Spwnar", 0f);
    }

    void Spwnar()
    {
        GameObject obj = Instantiate(prefab, transform.position, transform.rotation);
        GameController.instance.AdicionarInimigosLista(obj);



    }
}
