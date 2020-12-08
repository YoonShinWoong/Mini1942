using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cover;
    public ItemManager itemManager;
    public SpawnManager spawnManager;

    public void OnClickStartBtn(){
        Cover.SetActive(false);
        itemManager.SpawnRandom();
        spawnManager.SpawnRandom();
    }
}
