using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorVerification : MonoBehaviour
{


    void OnCollisionStay(Collision collision) 
    {
        if (collision.collider.CompareTag("Piso"))
        {

            Destroy(gameObject);
        }
        else 
        {

            Destroy(gameObject, 2);
        }
      
            
        
             
    }
}

