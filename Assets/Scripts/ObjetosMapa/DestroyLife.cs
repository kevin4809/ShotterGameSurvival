using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLife : MonoBehaviour 
{
	public BoxCollider colliderVida; // box collider del gameobject
	public MeshRenderer render; // meshrender del gameobject
	AudioSource a; //audiosource del gameobject


	void Start()
	{
		colliderVida = GetComponent<BoxCollider> (); // collidervida coje los componentes de BoxCollider
		render = GetComponent<MeshRenderer> (); // render coje los componentes de Meshrenderer
		a = GetComponent<AudioSource> (); //a coje los componentes del AudioSource
	}

	void OnTriggerEnter (Collider other)
	{
		//si el cameobject codiciona con el gameobject con el tag player se desactiva el boxcollider y el meshrender, se activa un sonido y se ejecuta una couroutine
		if(other.CompareTag("Player"))
			{
			colliderVida.enabled = false;
			render.enabled = false;
			a.Play ();
			StartCoroutine (SpawnVida ());
			}
	}
		
	IEnumerator SpawnVida()
	{
		//despues de 60 segundos el collider el meshrender se vuelven a activar 
		yield return new WaitForSeconds (60);
		colliderVida.enabled = true;
		render.enabled = true;
	}
}
