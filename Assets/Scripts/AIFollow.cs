using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollow : MonoBehaviour
{
    public Transform player;
    private float speed = 10f;
    bool canFollow = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  if (canFollow)
       //{
        if (player.transform.position.x > 330 && player.transform.position.z < -30)
        {
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gate")
        {
           // canFollow = false;
            // gameObject.SetActive(false);
            //Destroy(gameObject);
            speed = 0f;
        }
    }

}




