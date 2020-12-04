using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 총알이 사라지게 하기
    // Invoke 시간 카운트, Destroy 삭제하기
    void Start()
    {
        Invoke("DestroySelf", 2.0f);
    }

    void DestroySelf(){
        Destroy(gameObject);
    }
}
