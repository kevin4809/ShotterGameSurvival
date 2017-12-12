using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAmno : MonoBehaviour
{
    public BoxCollider colliderBox; // collider de la caja
	public int totalMunicion; // el total de municion que le dara al jugador por cojer la caja 

	public DisparoRayCast aumentarMunicion; // script donde esta la municion total del arma 

	bool isenable; 

	void Start()
	{
		aumentarMunicion = GameObject.Find ("RifleDeAsalto").GetComponent<DisparoRayCast> (); // aumentarMunicion coje los componetes del script DisparoRaycast
		colliderBox = GetComponent<BoxCollider> (); // colliderbox coje los componentes del boxcollider del gameobject
	}

	void OnTriggerEnter (Collider other)
	{
		// si el gameobject ase codicion con el gameobject con el tag player se le desactiva el box collider aumenta la municion y se ejecuta una corutina
		if(other.CompareTag("Player"))
			{
			colliderBox.enabled = false;
			isenable = true;
			aumentarMunicion.numeroCargadores += totalMunicion; 
			StartCoroutine (Spawn ());
			}
	}

	IEnumerator Spawn()
	{
		//despues de que pasan 60 segundos se buelve a activar el box collider 
		yield return new WaitForSeconds (60);
		colliderBox.enabled = true;
		isenable = false;
	}
     

}
