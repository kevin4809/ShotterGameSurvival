using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionDaño : MonoBehaviour 
{
	public GameObject canvasDaño; //canvas con panel rojo 
	public bool isdamage; //boo para saber si se le esta aciendo daño a jugador
	Animator anim; //animator con el cual vamos controlar el tono de rojo del panel

	void Start()
	{
		anim = GameObject.Find ("PanelDaño").GetComponent<Animator> (); //se busca el gameobject paneldaño y anim coje los componetes del animator
		isdamage = false; // el daño comienza en falso
	}
		

	void OnTriggerEnter(Collider other)
	{
		//si el jugador codiciona con los emenigos los cuales tienen el tag enemy y enemy2 se hactivara el bool isdamage y la animacion que controla en tono de rojo
		//se ejecuta una coroutine 
		if(other.gameObject.CompareTag("Enemy"))
			{
			anim.Play ("CanvasDaño");
			isdamage = true;
			StartCoroutine (EsperaCanvasDaño ());
			}
		if(other.gameObject.CompareTag("Enemy2")) 
		{
			anim.Play ("CanvasDaño");
			isdamage = true;
			StartCoroutine (EsperaCanvasDaño ());
		}
	}

	//despues de que pasan 0.8f el bool vuelve a falso por ende la pantalla regresa a la normalidad 
	IEnumerator EsperaCanvasDaño()
	{
		yield return new WaitForSeconds (0.8f);
		isdamage = false;
	}

	//si bool isdamaje es verdadero se activa el canvaz rojo lo cual da un efecto de daño
	//si bool isdamaje es falso la pantalla continua normal
	void Update()
	{
		if (isdamage == true) 
		{
			canvasDaño.gameObject.SetActive (true);

		} else if (isdamage == false) 
		{
			canvasDaño.gameObject.SetActive (false);
		}
	}
}
