using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    void Start(){
        DestroyAfterTime();
    }
    

    // 1. 시간이 지나면 사라지기
    public abstract void DestroyAfterTime();

    // 2. 아이템을 획득하면 적용
    public abstract void ApplyItem();

    public void DestroyThis(){
        Destroy(gameObject);
    }
}


// 효과 인터페이스
public interface IEffect{
    void GetOpaque();
}