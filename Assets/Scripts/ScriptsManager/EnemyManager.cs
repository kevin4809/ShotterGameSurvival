using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{

	public GameObject Zombie; //gameobject el cual sera instanciado
	public Transform[] spawPoints; //puntos de spawn
	public Score aumentarEnemigos; //score 


	private float enfriamiento;
	//tiempo actual del spawn
	public float TiempoActualSpawZombies;
	//tiempo del spaw por niveles 
	public float timeSpawLevel2;
	public float timeSpawLevel3;
	public float timeSpawLevel4;
	public float timeSpawLevel5;
	public float timeSpawLevel6;
	public float timeSpawLevel7;
	public float timeSpawLevel8;
	public float timeSpawLevel9;
	public float timeSpawLevel10;


	void Start()
	{
		aumentarEnemigos = GameObject.Find("ScoreManager").GetComponent<Score>(); //se busca el gameobeject ScoreManager y se coje sus componentes
		aumentarEnemigos.numeroOleadas = 1; // el contador de oleadas empieza en 1
	}
		
	void Update()
	{
		//siclo de tiempo de sawn 
		if (enfriamiento < 0) 
		{
			Spawn ();

			enfriamiento = TiempoActualSpawZombies;
		}

		enfriamiento -= Time.deltaTime;

		//tiempo de spawn de todos lo niveles 
		if (aumentarEnemigos.score >= 50) 
		{
			TiempoActualSpawZombies = timeSpawLevel2;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 2;
		}
		if (aumentarEnemigos.score >= 100) 
		{
			TiempoActualSpawZombies = timeSpawLevel3;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 3;
		}
		if (aumentarEnemigos.score >= 150) 
		{
			TiempoActualSpawZombies = timeSpawLevel4;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 4;
		}
		if (aumentarEnemigos.score >= 250) 
		{
			TiempoActualSpawZombies = timeSpawLevel5;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 5;
		}
		if (aumentarEnemigos.score >= 400) 
		{
			TiempoActualSpawZombies = timeSpawLevel6;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 6;
		}
		if (aumentarEnemigos.score >= 650) 
		{
			TiempoActualSpawZombies = timeSpawLevel7;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 7;
		}
		if (aumentarEnemigos.score >= 1000) 
		{
			TiempoActualSpawZombies = timeSpawLevel8;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 8;
		}
		if (aumentarEnemigos.score >= 1400) 
		{
			TiempoActualSpawZombies = timeSpawLevel9;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 9;
		}
		if (aumentarEnemigos.score >= 1800) 
		{
			TiempoActualSpawZombies = timeSpawLevel10;
			//actualizacion de oleada 
			aumentarEnemigos.numeroOleadas = 10;
		}

	}
	//se instancia el gameobject en los puntos de spaw definidos 
	void Spawn()
	{
		int spawnPointIndex = Random.Range (0, spawPoints.Length);

		Instantiate (Zombie, spawPoints [spawnPointIndex].position, spawPoints [spawnPointIndex].rotation);
	}
}
