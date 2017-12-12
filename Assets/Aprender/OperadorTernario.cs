using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperadorTernario : MonoBehaviour 
{
	
	void Start()
	{
		int health = 10;
		string message;

		message = health > 0 ? "player esta vivo" : "player esta muerto";
	
		message = health > 0 ? "Player esta vivo" : health == 0 ? "player es raro" : "Player esta muerto";


		if (health < 0) {
			Debug.Log ("Player esta vivo");
		} else
			Debug.Log ("Player esta muerto");
	}

	void Update()
	{
		int x = Static.enemycount;
		Debug.Log ("Cuanto vale x: " + x);

		int suma = Static.Add (50, 30);
		Debug.Log ("El resultado de la suma es: " + suma);


		Sobrecarga mysuma = new Sobrecarga ();
		int resultadoint = mysuma.suma (50, 80);
		string resultadosuma = mysuma.suma ("hola", "grupo");
		Debug.Log (resultadoint);
		Debug.Log (resultadosuma);
	}
}
