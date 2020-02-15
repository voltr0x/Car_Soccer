using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    private int enemyCount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Generate a random spawn position for obstacles & enemies
    private Vector3 GenerateSpawnPos()
    {
        float spawnX = Random.Range(-12, 12);
        float spawnZ = Random.Range(10, 20);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);

        return randomPos;
    }
}
