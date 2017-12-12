using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour 
{
	public Score puntaje;
	public VidaJugador vida;
	public DisparoRayCast numeroBalas;

	void Start()
	{
		puntaje = GameObject.Find ("ScoreManager").GetComponent<Score> ();
		vida = GameObject.Find ("Player").GetComponent<VidaJugador> ();
		numeroBalas = GameObject.Find ("RifleDeAsalto").GetComponent<DisparoRayCast> ();
	}

	public void Guardar(string save)
	{
		switch (save) 
		{
		case"Guardar":
			PlayerPrefs.SetInt ("numeroBalas", numeroBalas.currentAmno);
			PlayerPrefs.SetFloat ("numeroCargadores", numeroBalas.numeroCargadores);
			PlayerPrefs.SetInt ("vida", vida.vidaJugador);
			PlayerPrefs.SetFloat ("prueba", puntaje.score);
			Debug.Log ("Guardeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
			break;

		case"Cargar":
			puntaje.score = PlayerPrefs.GetFloat ("prueba");
			vida.vidaJugador = PlayerPrefs.GetInt ("vida");
			numeroBalas.currentAmno = PlayerPrefs.GetInt ("numeroBalas");
			numeroBalas.numeroCargadores = PlayerPrefs.GetFloat ("numeroCargadores");
			Debug.Log ("guardeeeeeeeeeeeeeeeeeeeeeeeee");
			break;
		}
	}
}
	
