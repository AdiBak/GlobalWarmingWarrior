using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    public GameObject explosionPref; // an explosion prefab, I put one in inspector slot
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "player"){
            GetComponent<Renderer>().enabled = false;
            explosionPref.SetActive(true); //active explosion
            other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * 3000); // not working....????
            Invoke("DestroyLandMine",2); // remove landmine after explosion
        }
    }

    void DestroyLandMine(){
        Destroy(gameObject);
    }
}
