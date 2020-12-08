using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] EnemyPrefabs;

    void Start(){
        //SpawnRandom();
    }

    public void SpawnRandom(){
        GameObject enemyPrefab = EnemyPrefabs[Random.Range(0,EnemyPrefabs.Length)];
        Points points = new Points();
        Vector2 pos = points[Random.Range(0,points.GetLength())].GetPos();

        SpawnEnemy(enemyPrefab, pos);
        Invoke("SpawnRandom", 1.0f);
    }

    void SpawnEnemy(GameObject prefab, Vector3 position){
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = position;
        enemy.GetComponent<Enemy>().Move(); // override
    }
}
