using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ModoDios : MonoBehaviour 
{

	public DestroyEnemy SubirVelosidad; // scrip destruir enemigo
	public NavMeshAgent agent; // navmesh enemigo
	public int velocidad; // velocidad a la que se va a mover 
	public int vida; // vida a la cual le va a aumentar la velosidad al enemigo

	void Start()
	{
		SubirVelosidad = GetComponent<DestroyEnemy> (); //subirVelosidad coje el componente del script DestroyEnemy
		agent = GetComponent<NavMeshAgent> (); // aget coje el componente del navmesh del enemigo
	}

	void Update()
	{
		// si la vida del enemigo es menor o igual a el valor asignado su velosidad aumentara 
		if (SubirVelosidad.vida <= vida)  
		{
			agent.speed = velocidad; 
		}
		// si la vida del enemigo es 0 la velosidad se reducira al 0
		if (SubirVelosidad.vida <= 0) 
		{
			agent.speed = 0;
		}
	}
}
