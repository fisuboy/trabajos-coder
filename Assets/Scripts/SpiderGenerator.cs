using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderGenerator : MonoBehaviour
{
    enum EnemyTypes { Small = 1, Big, Jump };
    [SerializeField] private EnemyTypes type;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case EnemyTypes.Small:
                InvokeRepeating("SpawnEnemy", (startDelay + 3f), (spawnInterval + 3f));
                transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                break;
            case EnemyTypes.Big:
                InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
                break;
            case EnemyTypes.Jump:
                InvokeRepeating("SpawnEnemy", (startDelay - 1f), (spawnInterval - 1f));
                break;
            default:
                Debug.Log("<color=#FF0000>ERROR AL ELEGIR NIVEL</color>");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, Vector3.forward, enemyPrefab.transform.rotation);
    }

}