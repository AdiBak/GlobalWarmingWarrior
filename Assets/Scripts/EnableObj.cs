using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObj : MonoBehaviour
{    public int scoreThreshold;
    // Start is called before the first frame update
    // Use this for initialization
    void Start () {
         MeshRenderer m = GetComponent<MeshRenderer>();
         m.enabled = false;
         foreach (MeshRenderer r in GetComponentsInChildren<MeshRenderer>())
            r.enabled = false;
     }
     
     // Update is called once per frame
     void Update () {
         MeshRenderer m = GetComponent<MeshRenderer>();
         m.enabled = true;
         foreach (MeshRenderer r in GetComponentsInChildren<MeshRenderer>())
            r.enabled = false;
     }


}
