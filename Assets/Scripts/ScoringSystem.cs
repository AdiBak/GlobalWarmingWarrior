using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreTxt;
    public static int theScore;
    
    void Update(){
        scoreTxt.GetComponent<Text>().text = "SCORE: " + theScore;
    }
}
