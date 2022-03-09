 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class EnemyManager : MonoBehaviour
 {
     [SerializeField]
     private GameObject enemyPrefab;
     private int spawnIndex;
     private Transform[] spawnpoints;
     private Vector3 spawnPos;
     private int count;
     private int enemyCount;
     public GameObject FinalPath;
     
     void Start(){
         count = transform.childCount;
         enemyCount = count;
         spawnpoints = new Transform[count];
         for(int i = 0; i < count; i++){
             spawnpoints[i] = transform.GetChild(i);
         }
         //if (enemyCount > 0){
            InvokeRepeating("spawnEnemys", 1, 3);
           // enemyCount--;
           // Debug.Log(enemyCount);
         //}
     }
     
     void spawnEnemys(){
         spawnIndex = Random.Range(0, count);
         if (PlayerMovementController.isFight){
             if (enemyCount > 0){
                Instantiate(enemyPrefab, spawnpoints[spawnIndex].position, enemyPrefab.transform.rotation);
                enemyCount--;
                Debug.Log(enemyCount);
             } else {
                FinalPath.transform.position = new Vector3(FinalPath.transform.position.x, 1, FinalPath.transform.position.z);
             }
         }
     }
 }