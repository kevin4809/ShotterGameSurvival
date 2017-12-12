using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox2 : MonoBehaviour 
{
	public BoxCollider colliderBox; //collider del gameobject
	AudioSource audioS; //audiosource del gameobject

	void Start()
	{
		audioS = GetComponent<AudioSource> ();	//audioS coje los componentes del AudioSource
	}
	void OnTriggerEnter(Collider other)
	{
		//si el cameobject codiciona con el gameobject con el tag player se desactiva el boxcollider y se activa un sonido ademas de esto se ejecuta una couroutine
		if (other.CompareTag ("Player")) 
		{
			colliderBox.enabled = false;
			audioS.Play ();
			StartCoroutine (Spawn ());
		}
	}

	IEnumerator Spawn()
	{
		//despues de que pasen 60 segundos el boxcollider se vuelve a activar
		yield return new WaitForSeconds (60);
		colliderBox.enabled = true;

	}
}
