using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameOver : MonoBehaviour 
{

	public Button restart;
	bool isRestart = false;
	public Button exit;
	bool isExit = false;
	public Button save;
	bool isSave = true;
	public InputField nick;
	bool isNick = true;

	Score isScore;


	void Start()
	{
		isScore = GameObject.Find ("ScoreManager").GetComponent<Score> ();
	}

	void Update()
	{

		if (isScore.isActive == true) 
		{
			isRestart = true;
			isExit = true;
			save.enabled = false;
			nick.enabled = false;
		}


		if (isRestart == true) 
		{
			restart.gameObject.SetActive (true);
		}
		if (isRestart == false) 
		{
			restart.gameObject.SetActive (false);
		}
		if (isExit == true) 
		{
			exit.gameObject.SetActive (true);
		}
		if (isRestart == false) 
		{
			exit.gameObject.SetActive (false);
		}
	}
}
