using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] ItemPrefabs;

    void Start(){
        //SpawnRandom();
    }

    public void SpawnRandom(){
        GameObject itemPrefab = ItemPrefabs[Random.Range(0,ItemPrefabs.Length)];
        Points points = new Points();
        Vector2 pos = points[Random.Range(0,points.GetLength())].GetPos();

        SpawnItem(itemPrefab, pos);
        Invoke("SpawnRandom", 1.0f);
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
    public Point[] points = {
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

    public int GetLength(){
        return points.Length;
    }

}

// 위치 구조체
public struct Point{
    int x,y;

    public Point(int x, int y){
        this.x = x;
        this.y = y;
    }

    public Vector2 GetPos(){
        return new Vector2(this.x, this.y);
    }
}