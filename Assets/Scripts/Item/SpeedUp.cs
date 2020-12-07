using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Item, IEffect
{
    // 아이템 획득시 사라지기
    public override void DestroyAfterTime(){
        Invoke("DestroyThis", 3.0f);
        Invoke("GetOpaque", 1.5f);
    }

    // 아이템 획득 적용
    void OnCollisionEnter2D(Collision2D coll){
        // 플레이어랑 부딪힐 경우
        if(coll.gameObject.CompareTag("Player")){
            ApplyItem();
        }
    }

    public override void ApplyItem(){
        GameObject player = GameObject.Find("Player"); // 플레이어 찾아오기
        PlayerController playerController = player.GetComponent<PlayerController>(); // 플레이어 컨트롤러 속성
        playerController.speed *= 1.1f; // 1.1배

        DestroyThis(); // 사라지기
    }

    // 투명해지기
    public void GetOpaque(){
        Color32 color =  GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 60); // rgba
    }
    
}
