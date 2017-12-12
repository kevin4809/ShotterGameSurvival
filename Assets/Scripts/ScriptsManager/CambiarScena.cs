using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarScena : MonoBehaviour 
{
	public GameObject canvas; //canavas opciones donde estan las opciones de sonido y los controles
	private bool activarCanvas = false;//boleano del canvas opciones 
	public GameObject canvas2;//canvas dos menu
	private bool activarCanvas2 = false;//boleano canvas menu
	public GameObject pantallaPrincipal;//primer cavas es decir donde esta la barra de vida del jugador y la estamina
	private bool activarCanvasMenuP = true;//boleano canvas principal

	public bool CanvasTutorial; //boleano canvas tutorial
	public GameObject canvasTutorial; //canvas donde aparecen los botones


	void Start()
	{
		CanvasTutorial = true; //caundo inicien el juego aparecera en la pantalla el canvas Tutorial
		StartCoroutine (ActivarCanvasTutorial ()); //activa la un acorrutina
	}
	public void ActivarScena (string CagarJuego)
	{
		switch (CagarJuego) 
		{
		case"Juego":
			SceneManager.LoadScene ("Juego"); //si jugador preciona boton juego 
			break;

		case"Opciones":
			activarCanvas = true; //si se preciona el boton Opciones se abilita el canvas de opviones
			break;

		case"Retur":
			activarCanvas = false; // se desactiva el canvas de obciones
			break;
		case"Menu": 
			activarCanvas2 = true;   // se abre el menu
			activarCanvasMenuP = false;
			Pausarjuego (); // se pausa el juego
			break;

		case"Exit":
			SceneManager.LoadScene ("Menu"); // salimos al menu principal
			Pausarjuego (); // se pausa el juego
			break;

		case"Back":
			Pausarjuego (); //se pausa el jeugo 
			activarCanvas2 = false; // se desactiva el canvas2
			activarCanvasMenuP = true; //se activa el canvasMenup
			activarCanvas = false;//se desactiva el canvas 
			break;
		case"Controls":
			CanvasTutorial = true; //activa el canvas donde van las instruciones del juego
			break;
		case"Regresar":
			CanvasTutorial = false; //descativa el canvas donde van las intruciones del juego
			break;

		case"Salir":
			Application.Quit (); // sale del juego
			break;

		case"Exit2":
			SceneManager.LoadScene ("Menu"); //regresa a la scena del menu
			break;
		}


	}


	IEnumerator ActivarCanvasTutorial()
	{
		//al iniciar el juego el canvas tuturia aparece y se ejecuta esta coroutine 
		//despues de que pasan 4 segundos en canvas tutoria regresa a estar negativo lo que ase que se desactive
		yield return new WaitForSeconds (4);
		CanvasTutorial = false;
	}



	public void Pausarjuego()
	{
		//pausa el juego 
		if (Time.timeScale == 1.0F)
		{
			Time.timeScale = 0.0F;
		}
		else
		{
			Time.timeScale = 1.0F;
		}

	}

	void Update()
	{
		//si el bool canvastutoria es verdadero se activara el canvastutorial
		//si el bool canvastutoria es falso el canvastutoria estara desactivado
		if (CanvasTutorial == true) 
		{
			canvasTutorial.gameObject.SetActive (true);
		}
		if (CanvasTutorial == false) 
		{
			canvasTutorial.gameObject.SetActive (false);
		}
			
		//si bool activarcanvas es verdadero se activara el canvas de opciones
		//sio bool acrivarcanvas es falso el canvasopciones estara desactivado
		if (activarCanvas == true) {
			canvas.gameObject.SetActive (true);
		} 
		if (activarCanvas == false) {
			canvas.gameObject.SetActive (false);
		}

		//si el bool activarCanvas2 es verdadero se activara el canvas menu 
		//si el bool activarCanvas2 es falso el canvasmenu estara desactivado
		if (activarCanvas2 == true) {
			canvas2.gameObject.SetActive (true);
		}
		if (activarCanvas2 == false) {
			canvas2.gameObject.SetActive (false);
		}

		//si el bool activarCanvasMenup es verdadero se activara el canvasprincipal
		//si el bool acrivarCanvasMenup es falso el canvasprencipal estara desactivado
		if (activarCanvasMenuP == true) {
			pantallaPrincipal.gameObject.SetActive (true);
		}
		if (activarCanvasMenuP == false) {
			pantallaPrincipal.gameObject.SetActive (false);
		}
			
	}
}
