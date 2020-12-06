using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* 1. 플레이어 객체 
    - SetActive 활성화(보여짐)
    - Transform 이동(위치 변경)
    */

    /* 2. 플레이어 객체 이동
    - Input.GetKey() : 키보드 값 입력 받는 메소드
    - Input.GetKeyDown() : 키보드 값 한번만 입력 받는 메소드
    - 오브젝트 생성, 속성가져오기(GetComponent<이름>)
    */

    public float speed = 0.02f;
    public float bulletSpeed = 300;
    public GameObject BulletPrefab; 
    public GameObject Gun;

    void Update()
    {
        // WASD : 이동
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(0,speed,0);
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Translate(-speed,0,0);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(0,-speed,0);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Translate(speed,0,0);
        }

        // Space : 총알 발사
        if (Input.GetKeyDown(KeyCode.Space)){
            for(int i =0 ; i<3; i++){
                GameObject bullet = Instantiate(BulletPrefab);

                Vector3 bulletStartPos = Gun.transform.position;
                bulletStartPos.y += i *0.3f;
                bullet.transform.position = bulletStartPos;

                bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
            }
        }

    }
}
