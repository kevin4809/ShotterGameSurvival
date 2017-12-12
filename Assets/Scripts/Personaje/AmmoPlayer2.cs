using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPlayer2 : MonoBehaviour
{
	DisparoPistola ammnoActual2;//script donde esta la municion del arma

	void Start()
	{
		ammnoActual2 = GetComponent<DisparoPistola> (); //ammnoActual coje los componentes del scrip DisparoRayCast
	}

	void OnTriggerEnter(Collider other)
	{
		// si el jugador codiciona con un gameobject con el tag municion se le agregaran 4 cargadores 
		if(other.CompareTag("Municion"))
		{
			ammnoActual2.numeroCargadores2 += 4;
		}
	}
}
