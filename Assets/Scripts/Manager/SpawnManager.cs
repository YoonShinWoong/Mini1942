using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] EnemyPrefabs;

    void Start(){
        //SpawnRandom();
        EventManager.EnemyDieEvent += OnEnemyDie;
    }

    // CouRoutine 제어권 넘김
    // 즉 몇초 동안 대기
    public IEnumerator SpawnRandom(){
        while(true){

            GameObject enemyPrefab = EnemyPrefabs[Random.Range(0,EnemyPrefabs.Length)];
            Points points = new Points();
            Vector2 pos = points[Random.Range(0,points.GetCount())].GetPos();
            SpawnEnemy(enemyPrefab, pos);

            yield return new WaitForSeconds(1.2f);
        }
    }

    void SpawnEnemy(GameObject prefab, Vector3 position){
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = position;
        enemy.GetComponent<Enemy>().Move(); // override
    }


    void OnEnemyDie(){
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(-5.0f , 5.0f);
        Point point = new Point(x,y);

        Points.points.Add(point);
    }
}
