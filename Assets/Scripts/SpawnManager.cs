using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Character enemyPrefab;
    public Character allyPrefab;
    public Mineral min1;
    Vector3 randomPos;
    float Radius;
    public static SpawnManager instance;
    

    private void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        Radius = 50.0f;
        enemyPrefab = GameManager.instance.enemyPrefab;
        allyPrefab = GameManager.instance.allyPrefab;
        min1 = GameManager.instance.min1;        
    }

    public void SpawnEnemy() 
    {
        randomPos = Random.insideUnitSphere * Radius;
        randomPos = new Vector3(randomPos.x, 0, randomPos.z);
        Character enemy = Instantiate(enemyPrefab);
        enemy.transform.position = randomPos;        
    }

    public void SpawnAlly(Vector3 playerPosition)
    {
        randomPos = Random.insideUnitSphere * 10f;
        randomPos = new Vector3(randomPos.x, 0, randomPos.z);
        Character ally = Instantiate(allyPrefab);
        ally.transform.position = randomPos + playerPosition;
    }

    public void SpawnMineral()
    {
        randomPos = Random.insideUnitSphere * Radius;
        randomPos = new Vector3(randomPos.x, 0 , randomPos.z);
        Mineral mineral = Instantiate(min1);
        mineral.transform.position = randomPos;
    }
}
