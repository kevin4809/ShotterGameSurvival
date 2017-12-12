using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAudioSource : MonoBehaviour {



    public int  TotalSalud=100;



    void OnTriggerEnter (Collider other)
    {

        if (other.CompareTag("Player"))
        {
         
            TotalSalud += 100;
            Debug.Log("Total salud: "+TotalSalud);
        }

        
        	
	}

}
