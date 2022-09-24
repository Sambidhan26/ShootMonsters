using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public Transform[] spawnPoint;

    private int randPrefab;
    private int randSpawn;
    public static int score;
    //private float randPosition;

    GameObject target;
    
    Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");

        score = 0;
        InvokeRepeating("Spawn", 0f, 1.0f);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        randPrefab = Random.Range(0, monsterPrefabs.Length);
        randSpawn = Random.Range(0, spawnPoint.Length);

        spawnPosition = Random.insideUnitCircle * 3;

        //Instantiate(monsterPrefabs[monsterPrefabs.Length], spawnPosition, Quaternion.identity);
        //for(int i=0; i < monsterPrefabs.Length; i++)

        if (target != null)
        {
            //Instantiate(monsterPrefabs);
            Instantiate(monsterPrefabs[randPrefab], spawnPosition * randSpawn, Quaternion.identity);

            score += 1;
            //Instantiate(monsterPrefabs[randPrefab], spawnPosition, Quaternion.identity);
        }

        
    }
}
