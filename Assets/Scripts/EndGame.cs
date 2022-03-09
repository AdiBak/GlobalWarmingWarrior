using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{
    //public GameObject[] agoAllGameObjects;
    public GameObject player;
    public GameObject thanks;
    // Start is called before the first frame update
    void Start()
    {
        //thanks.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovementController.missionComp){
            Invoke("lastStage",3.0f);
            
          //  player.transform.position = new Vector3()
           /*GameObject text = new GameObject();
            TextMesh t = text.AddComponent<TextMesh>();
            t.text = @"I hope you liked my game! 
                        Thanks for playing!";
            t.fontSize = 30;
            t.color = Color.black;
            //t.transform.localEulerAngles += new Vector3(90, 0, 0);
            t.transform.localPosition = new Vector3(-70, 280, 250);*/
            
        }
    }
    void lastStage(){
      /*  for(int iGO = 0; iGO < agoAllGameObjects.Length; iGO++)
            {
                if (agoAllGameObjects[iGO] != null){
                    if(agoAllGameObjects[iGO].name != "Player" && agoAllGameObjects[iGO].name != "Camera" && agoAllGameObjects[iGO].name != "OffLightsTxt" && agoAllGameObjects[iGO].name != "PlantTrees" && agoAllGameObjects[iGO].name != "Remember" && agoAllGameObjects[iGO].name != "Please"){
                        Destroy(agoAllGameObjects[iGO]);
                    }
                }

            }
        GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = gameObject.transform.position;
        plane.transform.localScale = new Vector3(30, 1, 30);*/
        GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = gameObject.transform.position;
        plane.transform.localScale = new Vector3(30, 1, 30);
        player.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y - 5, plane.transform.position.z);
        thanks.gameObject.SetActive(true);
    }
}
