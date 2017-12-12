using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawReptilianoManager : MonoBehaviour 
{
	public GameObject reptiliano;
	Score spawReptiliano;
	public Transform[] spawPoints;
	int i;

	void Start()
	{
		i = 1;
		spawReptiliano = GameObject.Find ("ScoreManager").GetComponent<Score> ();
	}

	void Update()
	{
		if (spawReptiliano.score >= 2000 && i == 1) 
		{
			int spawnPointIndex = Random.Range (0, spawPoints.Length);

			Instantiate (reptiliano, spawPoints [spawnPointIndex].position, spawPoints [spawnPointIndex].rotation);
			i++;
		}
	}


}
