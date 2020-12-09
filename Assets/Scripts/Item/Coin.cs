using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item, IEffect
{

    // 아이템 획득시 사라지기
    public override void DestroyAfterTime(){
        Invoke("DestroyThis", 5.0f); // 5초 후 사라짐
        Invoke("GetOpaque", 3.0f); // 3초 후 깜빡
    }

    // 아이템 획득 적용
    void OnCollisionEnter2D(Collision2D coll){
        // 플레이어랑 부딪힐 경우
        if(coll.gameObject.CompareTag("Player")){
            ApplyItem();
        }
    }
    public override void ApplyItem(){
        
        DestroyThis(); // 획득 시 사라지기
    }

    // 투명해지기
    public void GetOpaque(){
        Color32 color =  GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 60); // rgba
    }
    
}
