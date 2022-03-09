using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLights : MonoBehaviour
{
     public Material blackMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider){
        if (collider.gameObject.tag == "player"){
            GetComponent<Renderer>().material = blackMat;
            ScoringSystem.theScore += 15;
        }
    }
}
