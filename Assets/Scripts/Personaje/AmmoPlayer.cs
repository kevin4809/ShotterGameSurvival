using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPlayer : MonoBehaviour 
{
	DisparoRayCast ammnoActual; //script donde esta la municion del arma

	void Start()
	{
		ammnoActual = GetComponent<DisparoRayCast> (); //ammnoActual coje los componentes del scrip DisparoRayCast
	}

	void OnTriggerEnter(Collider other)
	{
		// si el jugador codiciona con un gameobject con el tag municion se le agregaran 4 cargadores 
		if(other.CompareTag("Municion"))
			{
			ammnoActual.numeroCargadores += 4;
			}
	}
}
