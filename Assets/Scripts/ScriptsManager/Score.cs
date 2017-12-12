using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{

	public Text scoreText = null;
	public float score = 0;
	public Text oleadas = null;
	public float numeroOleadas = 0;
	public InputField playerName;
	public bool isActive = false;

    void Start()
	{
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> (); //aqui se busca el gameobjetc "ScoreText" y se coje los componentes del text
		oleadas = GameObject.Find("NumeroDeOleadas").GetComponent<Text>(); //aqui se busca el gameobjetc "NumeroDeOleadas" y se coje los componentes del text
	}

    void Update()
	{
		//aparece el puntaje en la pantalla esta en Unpdate para que se valla actualizando :D
		scoreText.text = "Score:  " + score;
		oleadas.text = "" + numeroOleadas;
	}

	public void initialenterned()
	{
		//para almacenar los puntajes en la liderboard
		GetComponent<ScoreBoard> ().CheckeandoLosScores(score, playerName.text);
		isActive = true;
	}

	public	void AddScore(int nuevoValor)
	{
		score += nuevoValor;
	} 

}
