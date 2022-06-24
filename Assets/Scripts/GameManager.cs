using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Character enemyPrefab;
    public Character allyPrefab;
    public Mineral min1;
    public static GameManager instance;
    public Character player;
    public Transform cam;
    public Image mineralImg;
    public Image healthBarImg;
    private void Start()
    {
        for(int i =0; i<100; i++)
        {
            SpawnManager.instance.SpawnMineral();
        }
        SpawnManager.instance.InvokeRepeating("SpawnEnemy" , 2f , 3f);
        SpawnManager.instance.InvokeRepeating("SpawnMineral", 2f, 3f);
        
    }
    private void Update()
    {
       
    }
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
    }

}
