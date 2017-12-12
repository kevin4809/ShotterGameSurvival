using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerCriatura : MonoBehaviour 
{

	public GameObject Criatura; //gameobject que se va a instanciar
	public Transform[] spawPoints; //puntos de sapwn
	public Score aumentarEnemigos; //puntaje del jugador 


	private float enfriamiento; 
	//tiempo actual del spawn
	public float TiempoActualSpawZombies;
	//tiempo del spaw por niveles 
	public float timeSpawLevel5;
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
	{
		//siclo de tiempo de sawn 
		//para que se inicie el siclo el puntaje del juego deve de ser mayor a 200
		if (enfriamiento < 0 && aumentarEnemigos.score >= 200) 
		{
			Spawn ();

			enfriamiento = TiempoActualSpawZombies;
		}

		enfriamiento -= Time.deltaTime;

		//tiempo de spawn de todos lo niveles 
		if (aumentarEnemigos.score >= 300) 
		{
			TiempoActualSpawZombies = timeSpawLevel5;
		}
		if (aumentarEnemigos.score >= 650) 
		{
			TiempoActualSpawZombies = timeSpawLevel6;
		}
		if (aumentarEnemigos.score >= 800) 
		{
			TiempoActualSpawZombies = timeSpawLevel7;
		}
		if (aumentarEnemigos.score >= 1000) 
		{
			TiempoActualSpawZombies = timeSpawLevel8;
		}
		if (aumentarEnemigos.score >= 1300) 
		{
			TiempoActualSpawZombies = timeSpawLevel9;
		}
		if (aumentarEnemigos.score >= 1800) 
		{
			TiempoActualSpawZombies = timeSpawLevel10;
		}

	}

	void Spawn()
	{
		//se instancia el gameobject en los puntos de spaw definidos 
		int spawnPointIndex = Random.Range (0, spawPoints.Length);

		Instantiate (Criatura, spawPoints [spawnPointIndex].position, spawPoints [spawnPointIndex].rotation);
	}
}
