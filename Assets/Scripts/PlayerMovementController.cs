using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float rayCastDist;
    private Rigidbody rigidbody;
    public bool hasKey1 = false;
    public bool hasKey2 = false;
    public bool hasKey3 = false;

    public static bool isFight = false;
    public GameObject door;
    public GameObject door2;
    public GameObject glassDoor;
    public GameObject particleSys;
    private bool canExtinguish = false;
    public static bool missionComp = false;
    public GameObject needpoints;
    private void Start(){
        rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update(){
        Jump();
        if (Input.GetKeyDown(KeyCode.E) && canExtinguish){
            particleSys.SetActive(false);
            missionComp = true;
        }
    }

    private void FixedUpdate(){
        Move();
    }

    private void Move(){
        float hAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, yAxis) * speed;
        Vector3 newPos = rigidbody.position + rigidbody.transform.TransformDirection(movement);

        rigidbody.MovePosition(newPos);
    }

    private void Jump(){
       if (Input.GetKeyDown(KeyCode.Space)){
           if (IsGrounded()){
                rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
           }
       } 
    }

    private bool IsGrounded(){
        return (Physics.Raycast(transform.position, Vector3.down, rayCastDist));
    }

    void OnCollisionEnter(Collision other){
        /*if (other.gameObject.tag == "car"){
            transform.parent = other.gameObject.transform;
        }*/
        switch(other.gameObject.tag){
            case "car":
                transform.parent = other.gameObject.transform;
                break;
            case "pend":
                ScoringSystem.theScore -= 5;
                break;
            case "key":
                if (ScoringSystem.theScore >= 200){
                    hasKey1 = true;
                    Destroy(other.gameObject);
                } else {
                    needpoints.gameObject.SetActive(true);
                    StartCoroutine("hideNP");
                }
                break;
            case "key2":
                if (ScoringSystem.theScore >= 325){
                    hasKey2 = true;
                    Destroy(other.gameObject);
                } else{
                    StartCoroutine("hideNP");
                }
                break;
            case "key3":
                if (AIFollow2.killCt > 7){
                    hasKey3 = true;
                    Destroy(other.gameObject);
                }
                break;
            case "food":
                Destroy(other.gameObject);
                ScoringSystem.theScore += 10;
                break;
            case "water":
                Destroy(other.gameObject);
                ScoringSystem.theScore += 10;
                break;
            
        }
        if (other.gameObject.tag == "fight"){
            isFight = true;
            //Debug.Log(isFight);
        } else {
            isFight = false;
            //Debug.Log(isFight);
        }
        
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "car"){
            transform.parent = null;
        } 
    }
        
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "gate"){
            if (hasKey1)
                door.GetComponent<OpenDoors>().StartDoor();
        } else if (other.gameObject.tag == "gate2"){
            if (hasKey2)
                door2.GetComponent<OpenDoors>().StartDoor();
        } else if (other.gameObject.tag == "glassgate"){
            if (hasKey3){
                //glassDoor.GetComponent<OpenDoors>().StartDoor();
                Destroy(other.gameObject);
                canExtinguish = true;
            }
        }
    }

    IEnumerator hideNP(){
        yield return new WaitForSeconds(3);
        needpoints.gameObject.SetActive(false);
    }
    /*IEnumerator GateActions(){
        door.GetComponent<OpenDoors>().OpenDoor();
    }*/
}
