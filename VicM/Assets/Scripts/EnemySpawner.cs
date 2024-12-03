using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;

    [SerializeField]
    private int desiredEnemies = 5 ;
    private int numEnemies = 1 ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(numEnemies<=desiredEnemies)
        {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-9f, 9), Random.Range(-4f, 4f), 0), Quaternion.identity);
        numEnemies+=1;
        StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}