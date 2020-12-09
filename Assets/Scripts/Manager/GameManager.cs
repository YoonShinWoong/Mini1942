using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    
    /* 
        * 게임데이터 저장
        1. PlayerPrefabss - 간단한 숫자 - 문자열 등을 저장할 때 사용
            - SetInt, GetInt

        2. UserData 객체 저장


    */

    public GameObject Cover;
    public ItemManager itemManager;
    public SpawnManager spawnManager;

    public static int score = 0;
    UserData userData;
    int hp = 5;
    public Text ScoreText;
    public Text BestScoreText;
    public Text HealthText;

    void Start(){
        EventManager.EnemyDieEvent += OnEnemyDie;
        EventManager.PlayerHurtEvent += OnPlayerHurt;
        EventManager.PlayerGetCoinEvent += OnPlayerGetCoin; 

        // bestScore 불러오기
        LoadUserData();
        BestScoreText.text = System.String.Format("Best Score : {0}", userData.BestScore);
    }

    public void OnClickStartBtn(){
        Cover.SetActive(false);
        StartCoroutine(itemManager.SpawnRandom());
        StartCoroutine(spawnManager.SpawnRandom());

        
        ScoreText.text = System.String.Format("Score : {0}", score);
        HealthText.text = System.String.Format("HP : {0}", hp);
    }

    // 적군 사망 시 점수 상승
    public void OnEnemyDie(){
        score += 1;
        ScoreText.text = System.String.Format("Score : {0}", score);

        // 만약 현재 점수가 더 크면 
        if (score > userData.BestScore){
            userData.BestScore= score;
            BestScoreText.text = System.String.Format("Best Score : {0}", userData.BestScore);

            SaveUserData();
        }
    }

    public void OnPlayerGetCoin(){
        score += 1;
        ScoreText.text = System.String.Format("Score : {0}", score);

        // 만약 현재 점수가 더 크면 
        if (score > userData.BestScore){
            userData.BestScore= score;
            BestScoreText.text = System.String.Format("Best Score : {0}", userData.BestScore);

            SaveUserData();
        }
    }

    // 플레이어 감점시 점수 하락
    public void OnPlayerHurt(){
        hp -= 1;
        HealthText.text = System.String.Format("HP : {0}", hp);
    }

    // UserData 처리 함수
    void SaveUserData(){
        // Application.persistenceDataPath;
        FileStream fs = new FileStream(Application.persistentDataPath + "/userData.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, userData);
        fs.Close();
    }

    void LoadUserData(){
        // 파일 예외 처리
        try{
            FileStream fs = new FileStream(Application.persistentDataPath + "/userData.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            userData = (UserData)bf.Deserialize(fs);
        }catch(System.Exception e){
            Debug.Log(e.Message);
            userData = new UserData();
        }
    }
}


[System.Serializable]
class UserData{
    public int BestScore;
}