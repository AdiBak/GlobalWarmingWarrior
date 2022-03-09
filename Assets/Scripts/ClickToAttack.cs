using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class SceneTwoScript: MonoBehaviour {  
  // Start is called before the first frame update    
 // [SerializeField] FlashImage flashImage = null;
  void Start() {}  
  
  // Update is called once per frame    
  void Update() {  
    if (Input.GetMouseButtonDown(0)) {  
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
      RaycastHit hit;  
      if (Physics.Raycast(ray, out hit)) {  
  
        //Select stage    
        if (hit.transform.tag == "enemy") {  
           // hit.GetComponent<EnemyAttack>().health -= 10;
         // flashImage.StartFlash(.25f,0.5f,Color.red);
        }  
      }  
    }  
  }  
}  