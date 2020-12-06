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

public class Enemy2 : Enemy
{
    public override void Move(){
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Speed);
    }
}
