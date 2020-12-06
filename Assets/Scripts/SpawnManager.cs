using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPrefab1;
    public GameObject EnemyPrefab2;

    void Start(){
        SpawnEnemy(EnemyPrefab1, new Vector3(-1, 2, 0 ));
        SpawnEnemy(EnemyPrefab2, new Vector3(1, 2, 0 ));

        // for(int i = 0 ; i < 5 ; i++){
        //     for(int j = 0; j < 5; j++){
        //         if( j % 2 == 0){
        //             SpawnEnemy(EnemyPrefab1, new Vector3(i,j,0));
        //         }
        //         else{
        //             SpawnEnemy(EnemyPrefab2, new Vector3(i,j,0));
        //         }
        //     }
        // }
    }

    void SpawnEnemy(GameObject prefab, Vector3 position){
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = position;
        enemy.GetComponent<Enemy>().Move(); // override
    }
}
