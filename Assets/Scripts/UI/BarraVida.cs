using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour 
{

	public Slider barraVida;
	DestroyEnemy vidaEnemigo;

	void Start()
	{
		vidaEnemigo = GameObject.Find ("Reptile").GetComponent<DestroyEnemy> ();
	}

	void Update()
	{
		barraVida.value = vidaEnemigo.vida;
	}
}
