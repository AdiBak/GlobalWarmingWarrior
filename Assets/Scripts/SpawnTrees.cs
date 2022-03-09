using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
   public GameObject tree;
    private bool isTouchingGrass = false;
    void Start(){

    }
    //Vector3 playerPos = transform.position;
    //Vector3 playerDirection = transform.forward;
    float spawnDistance = 5;
    int numTrees = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTouchingGrass /*&& numTrees <= 3*/){
            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.forward;
            Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
            Debug.Log(spawnPos);
            Instantiate(tree, spawnPos, Quaternion.identity);
            ScoringSystem.theScore += 20;
           // numTrees++;
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "grass"){
            isTouchingGrass = true;
        } else {
            isTouchingGrass = false;
        }
    }
     //var prefab : Transform;
 
    /*void Update(){
        if(Input.GetMouseButtonUp(0)){
            Ray ray = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
    
            if (Physics.Raycast(ray, hit,Mathf.Infinity)){
    
                if(hit.collider.tag == "Grass"){
                    Vector3 placePos = hit.point;
                    placePos.y += .5;
                    placePos.x = Mathf.Round(placePos.x);
                    placePos.z = Mathf.Round(placePos.z);
                        Instantiate (tree, placePos, Quaternion.identity);
                }
            }
        }
    }

   */
}
