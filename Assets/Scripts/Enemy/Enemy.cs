using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// unity 에서 객체 생성법
// 1. 스크립트에 게임오브젝트에 부착
// 2. 생성자 통한 객체 생성

/*
    피격 과정
    1. Enemy Bullet 충돌
        - collider 를 양쪽에 추가(RigidBody)
    2) 충돌 시 적군 체력 감소
        - OnCollisionEnter2D 메서드 통해서 처리(충돌 스크립트로 가져오기)
        - OnCollisionStay2D(충돌 내내), OnCollisionExit2D(충돌 종료시)
    3) 충돌 후 총알 소멸

*/

public class Enemy : MonoBehaviour
{
    private float health = 50.0f;
    public float Speed = 1000f; // 퍼블릭은 변수명 대문자

    // 속성으로 선언(쉽게 변경 안되게 하기)
    public float Health{
        get { return health; }
    }

    // 정량 체력감소
    void TakeDamage(int value){
        health -= value;
        Debug.Log("Enemy 체력 : " + health);

        if(health <= 0){
            Die();
        }
    }

    // 비율 체력감소
    void TakeDamage(float value){
        health -= (health * value);
    }

    void Die(){
        Destroy(gameObject); // 자기 자신 소멸
    }

    void OnCollisionEnter2D(Collision2D coll){
        // 총알 충돌시
        if(coll.gameObject.CompareTag("Bullet")){
            TakeDamage(10);
            
            // 총알 소멸시키기(나랑 충돌한 거 없애기)
            coll.gameObject.SetActive(false); // 어차피 2초 후 destroy 되므로(안보이게만)
        }
        
    }

    public virtual void Move(){
        
    }
}
