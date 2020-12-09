using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float health = 50.0f;

    // 속성으로 선언(쉽게 변경 안되게 하기)
    public float Health{
        get { return health; }
    }

    void TakeDamage(float value){
        health -= value;
        Debug.Log("Player 체력 : " + health);

        if(health <= 0){
            Die();
            ExitGame(); // 종료
        }
    }

    // 종료함수
        public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit() // 어플리케이션 종료
    #endif
    }

    void Die(){
        Destroy(gameObject); // 자기 자신 소멸
    }

    void OnCollisionEnter2D(Collision2D coll){
        // 충돌한 객체가 Enemy일 경우를 구분
        if( coll.gameObject.CompareTag("Enemy")){
            TakeDamage(10);
            EventManager.RunPlayerHurtEvent();   
            Destroy(coll.gameObject);
        }

        // 충돌한 객체가 Coin일 경우
        else if( coll.gameObject.CompareTag("Coin")){
            EventManager.RunPlayerGetCoinEvent();
        }
    }

}
