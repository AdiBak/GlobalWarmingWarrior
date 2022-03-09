using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public Transform targetPos;
    public Transform oldPos;
  void Start() {
      oldPos.transform.position = transform.position;
  }
  void Update() {
  
  }
  public void StartDoor(){
      StartCoroutine(moveDoor());
  }
  public IEnumerator moveDoor() {
      transform.position = Vector3.MoveTowards(transform.position, targetPos.transform.position, 2.0f);
      yield return new WaitForSeconds(3.0f);
      transform.position = Vector3.MoveTowards(transform.position, oldPos.transform.position, 2.0f);
  }
        
}
