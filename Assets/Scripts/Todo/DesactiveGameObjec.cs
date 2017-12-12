using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveGameObjec : MonoBehaviour {

	public GameObject GO;
	public AudioManager reproductorAudio;


  void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
              desaparecer();
			reproductorAudio.Active ();

        }
	}

	void desaparecer()
	{

			gameObject.SetActive (false);
		
	}
}
