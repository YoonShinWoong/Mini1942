using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action EnemyDieEvent;

    public static event Action PlayerHurtEvent;

    public static event Action PlayerGetCoinEvent;

    public static void RunEnemyDieEvent(){
        if(EnemyDieEvent != null){
            EnemyDieEvent();
        }
    }    

    public static void RunPlayerHurtEvent(){
        if(PlayerHurtEvent != null){
            PlayerHurtEvent();
        }
    }

    public static void RunPlayerGetCoinEvent(){
        if(PlayerGetCoinEvent != null){
            PlayerGetCoinEvent();
        }
    }
}
