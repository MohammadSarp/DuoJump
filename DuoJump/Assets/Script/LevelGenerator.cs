using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject boxPrefabThin;
    public GameObject boxWidePrefab;
    public int numberOfPlatforms;

    void Start()
    {
        Vector3 spawnPos = new Vector3();
        
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPos.x += Random.Range(10f, 20f);
            spawnPos.y = -3f;
            spawnPos.z = 10f;
            int randomNumber = Random.Range(0, 3);
            if(randomNumber == 0){
                Instantiate(boxPrefabThin, spawnPos, Quaternion.identity);
            } else if(randomNumber == 1) {
                Instantiate(boxWidePrefab, spawnPos, Quaternion.identity);
            } else if (randomNumber == 2){
                Instantiate(boxPrefab, spawnPos, Quaternion.identity);
            }
        }        
    }

}
