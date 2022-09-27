using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPersonagem : MonoBehaviour {

    public GameObject Personagem;
    
    void Update(){
       float y = Personagem.transform.position.y;
       if (Personagem.transform.position.y < 0.5f)
       {
            y = 0.5f;           
       }
       transform.position = new Vector3(0, y, -10);
   }
}