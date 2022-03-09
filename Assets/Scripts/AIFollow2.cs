using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollow2 : MonoBehaviour
{
    /*public GameObject player;
    private float speed = 10f;
    //bool canFollow = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  if (canFollow)
       //{
        //if (player.transform.position.x > 330 && player.transform.position.z < -30)
        //{
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
        //}
        //}
    }
/*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gate")
        {
           // canFollow = false;
            // gameObject.SetActive(false);
            //Destroy(gameObject);
            speed = 0f;
        }
    }*/

    //global variables
     private Transform target;
    private float speed = 5f;
    private Vector3 speedRot = Vector3.right * 50f;
    private FlashImage flashImage = null;
    public float rangeDist;
    bool attacking;
    public static int killCt;

    public GameObject yMark;
    
    public float moveForce;
    void Start () {
        target = GameObject.FindGameObjectWithTag("player").transform; // initializing stuff
        flashImage = GameObject.Find("FlashImage").GetComponent<FlashImage>();
    }
    
    void Update () {
        transform.Rotate (speedRot * Time.deltaTime); 
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // move toward player

        float distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
       
    
        if (distance <= rangeDist && !attacking){ // if in range, attack

            attacking = true;
            InvokeRepeating("AttackPlayer",3.0f,2.0f);
        }
        else if(distance > rangeDist && attacking )
        {
            attacking = false;
            CancelInvoke("AttackPlayer");
        }

        if (transform.position.y < yMark.transform.position.y){
            Destroy(gameObject);
            ScoringSystem.theScore += 30;
            killCt++;
            Debug.Log("kill" + killCt);
        }
    }

    void OnMouseDown(){ // NOT WORKING
        //gameObject.GetComponent<Rigidbody>().AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position).normalized * moveForce, ForceMode.Impulse);
        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * 700);
        gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * 3000);
    }

    void AttackPlayer(){
        ScoringSystem.theScore -= 5;
        flashImage.StartFlash(.5f,0.5f,Color.red); //flash screen red
    }

}




