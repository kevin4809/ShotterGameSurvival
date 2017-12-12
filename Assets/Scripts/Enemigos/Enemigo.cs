using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
	public Transform target; //Lo que los enemigos van a perseguir
	public NavMeshAgent agent; // navmesh del enemigo

	public float distance; // la distancia a la cual el enemigo te va  a detectar 

	void Start()
	{
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();//Busca el gameobject con el tag player y lo asigna como target
	}
		
	void Update()
	{

		if (Vector3.Distance (target.transform.position, transform.position) < distance) // si la distanica es menor al avalor asignado
		{
			agent.SetDestination (target.transform.position); // los nemigos se mueven asia el target por medio del nav mesh esto permite que esquiven los ostaculos que se encuentre en su camino
		}
	}

}

