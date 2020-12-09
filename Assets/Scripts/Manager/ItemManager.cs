using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] ItemPrefabs;

    void Start(){
        //SpawnRandom();
    }

    // Invoke는 단순 시간 대기, CorRoutine은 제어권 관리
    public IEnumerator SpawnRandom(){
        while(true){
            GameObject itemPrefab = ItemPrefabs[Random.Range(0,ItemPrefabs.Length)];
            Points points = new Points();
            Vector2 pos = points[Random.Range(0,points.GetCount())].GetPos();

            SpawnItem(itemPrefab, pos);

            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnItem(GameObject itemPrefab, Vector2 pos){
        GameObject item = Instantiate(itemPrefab);
        item.transform.position = pos;
    }
}
// 열거형 통해 값 명시
enum Items{
    Coin, SpeedUp, PowerUp, DeffenceUp, HealthUp
}

class Points{
    public static List<Point> points = new List<Point> {
        new Point(0,0),
        new Point(1,0),
        new Point(-1,0),
        new Point(-1,-2),
        new Point(-2,-1),
        new Point(0,1),
        new Point(2,0),
        new Point(0,2)
    };

    public Point this[int index]{
        get{
            return points[index];
        }
        set{
            points[index] = value;
        }
    }

    public int GetCount(){
        return points.Count;
    }

}

// 위치 구조체
public struct Point{
    float x,y;

    public Point(float x, float y){
        this.x = x;
        this.y = y;
    }

    public Vector2 GetPos(){
        return new Vector2(this.x, this.y);
    }
}