using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyAttack : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public MeshRenderer mesh;
    bool attacking;
    public float rangeDist;
    [SerializeField] FlashImage flashImage = null;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
       float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
       
    
        if (distance <= rangeDist && !attacking){

                attacking = true;
            InvokeRepeating("Attack",3.0f,3.0f);
        }
        else if(distance > rangeDist && attacking )
        {
            attacking = false;
            CancelInvoke("Attack");
        }
        if (health == 0){
            Destroy(gameObject);
            ScoringSystem.theScore += 30;
        }
    }
    void Attack(){
        ScoringSystem.theScore -= 5;
        flashImage.StartFlash(.25f,0.5f,Color.red);
        //flashImg.GetComponent<FlashImg>.FlashOnce(.25f,.5f,newColor);
    }
/*
    void OnCollisionEnter(Collision collider){
        if (collider.gameObject.tag == "player"){
            InvokeRepeating("Attack",3.0f,3.0f);
        }
    }*/
    
    void OnMouseDown(){
        health -= 10;
        Debug.Log(health);
        StartCoroutine(TakeHit());
    }

    IEnumerator TakeHit(){
        mesh.enabled = false;
        yield return new WaitForSeconds(.1f);
        mesh.enabled = true;
    }
}
