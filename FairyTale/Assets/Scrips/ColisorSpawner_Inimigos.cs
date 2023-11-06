using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorSpawner_Inimigos : MonoBehaviour
{
    [SerializeField] List<Spawner> spawners;



    public void AtivarSpawners()
    {
        for(int i = 0; i < spawners.Count; i++)
        {
            spawners[i].Spwnar();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AtivarSpawners();
            Destroy(this.gameObject);
        }
       
    }
}
