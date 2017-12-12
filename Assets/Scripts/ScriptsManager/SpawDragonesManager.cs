using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawDragonesManager : MonoBehaviour 
{

	public GameObject enemy;// el enemigo que bamos a instanciar
	public GameObject enemy2;// el enemigo que bamos a instanciar
	public GameObject enemy3;// el enemigo que bamos a instanciar
	public GameObject enemy4;// el enemigo que bamos a instanciar
	public Transform[] spawPoints; // puntos de Spawn
	public int n;


	private float enfriamiento;
	//tiempo actual del spawn
	public Score aumentarEnemigos;
	public float tiempoActualSpawDragones;
	//tiempo del spaw por niveles 
	public float timeSpawLevel6;
	public float timeSpawLevel7;
	public float timeSpawLevel8;
	public float timeSpawLevel9;
	public float timeSpawLevel10;


	void Start()
	{
		aumentarEnemigos = GameObject.Find("ScoreManager").GetComponent<Score>(); //se busca el gameobeject ScoreManager y se coje sus componentes
	}


	void Update()
	{ //siclo de tiempo de sawn 
		//para que se inicie el siclo el puntaje del juego deve de ser mayor a 300
		if (enfriamiento < 0 && aumentarEnemigos.score >= 300) 
		{
			ElegirEnemigo ();

			enfriamiento = tiempoActualSpawDragones;
		}

		enfriamiento -= Time.deltaTime;

		//tiempo de spawn de todos lo niveles 
		if (aumentarEnemigos.score >= 650) 
		{
			tiempoActualSpawDragones = timeSpawLevel6; 
		}
		if (aumentarEnemigos.score >= 800) 
		{
			tiempoActualSpawDragones = timeSpawLevel7;
		}
		if (aumentarEnemigos.score >= 1000) 
		{
			tiempoActualSpawDragones = timeSpawLevel8;
		}
		if (aumentarEnemigos.score >= 1300) 
		{
			tiempoActualSpawDragones = timeSpawLevel9;
		}
		if (aumentarEnemigos.score >= 1800) 
		{
			tiempoActualSpawDragones = timeSpawLevel10;
		}
	}
		


	//elige un enemigo a alzar entre los 5 que hay y lo spawnea 
	void ElegirEnemigo()
	{
		n = Random.Range (1, 5);
		Spawn ();
	}


	//spawn de los enemigos
	void Spawn()
	{
		//si el numero generado al azar es 1 se instansiara el 1 tipo de dragon 
		if (n == 1) 
		{
			int spawnPointIndex = Random.Range (0, spawPoints.Length);

			Instantiate (enemy, spawPoints [spawnPointIndex].position, spawPoints [spawnPointIndex].rotation);
		}
		//si el numero generado al azar es 2 se instansiara el 2 tipo de dragon 
		if (n == 2) 
		{
			int spawnPointIndex = Random.Range (0, spawPoints.Length);

			Instantiate (enemy2, spawPoints [spawnPointIndex].position, spawPoints [spawnPointIndex].rotation);
		}

		//si el numero generado al azar es 3 se instansiara el 3 tipo de dragon 
		if (n == 3) 
		{
			int spawnPointIndex = Random.Range (0, spawPoints.Length);

			Instantiate (enemy3, spawPoints [spawnPointIndex].position, spawPoints [spawnPointIndex].rotation);
		}

		//si el numero generado al azar es 4 se instansiara el 4 tipo de dragon 
		if (n == 4) 
		{
			int spawnPointIndex = Random.Range (0, spawPoints.Length);

			Instantiate (enemy4, spawPoints [spawnPointIndex].position, spawPoints [spawnPointIndex].rotation);
		}


	}
}
