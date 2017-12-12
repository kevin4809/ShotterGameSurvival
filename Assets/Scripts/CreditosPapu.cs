using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditosPapu : MonoBehaviour 
{

	public GameObject canvas;
	public GameObject Principal;
	public GameObject opciones;

	void Start()
	{
		canvas.gameObject.SetActive (false);
		Principal.gameObject.SetActive (true);
		opciones.gameObject.SetActive (false);
	}
	public void Creditos(string Activar)
	{
		switch (Activar) 
		{
		case"Creditos":
			canvas.gameObject.SetActive (true);
			Principal.gameObject.SetActive (false);
			opciones.gameObject.SetActive (false);
			break;

		case"Regresar":
			canvas.gameObject.SetActive (false);
			opciones.gameObject.SetActive (false);
			Principal.gameObject.SetActive (true);
			break;

		case"Opciones":
			opciones.gameObject.SetActive (true);
			break;

		case"Regresar2":
			opciones.gameObject.SetActive (false);
			break;

		case"Juego":
			SceneManager.LoadScene ("Juego");
			break;

		case"Exit":
			Application.Quit ();
			break;
		}

	}
}
