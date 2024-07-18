using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    private Stack<GameObject> stackStoreEnemySpawned;

    private void Start()
    {
        stackStoreEnemySpawned = new Stack<GameObject>();
    }
    private void Update()
    {
        
    }
    private void SpawnEnemy()
    {

    }
}
