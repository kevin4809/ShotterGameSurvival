using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour 
{

	public int vidaJugador = 1000; //vida del jugador
	public int valorCura; //el total de vida que se va a curar el jugador cuando coja una cura 
    Slider mainSlider; //barra de vida
	public int daño = 100; // daño que recive de los enemigos

	Canvas canvasGameOver; //cuando el jugador muere aparece este canvas
	bool isCanvasGameOver; //bool para saber si el jugador esta muerto o no

	Camera camaraGameOver; //camara que se instanciara despues de que el jugador muera
	bool iscamera; //bool para saber si el jugador esta muerto o no

	void Start()
	{
		camaraGameOver = GameObject.Find("CameraGameOver").GetComponent<Camera> ();//se busca el gameobject cameraGameover despues de encontrarlo camaraGameOver coje los componetes de camara
		isCanvasGameOver = false; //el bool comienza en falso 
		iscamera = false; //el bool cienza en falso
		canvasGameOver = GameObject.Find("CanvasGameOver").GetComponent<Canvas> (); //se busca el gameobject canvasGammeOver y se coje sus componentes 
		mainSlider = GameObject.FindGameObjectWithTag ("SliderVida").GetComponent<Slider> (); // se busca el gameobject SliderVida y se cojen sus componentes 
	}

	void OnTriggerEnter(Collider other) 
	{
		//si el jugador codiciona con gameobjects con el tag enemy y enemy2 recivira daño
		//si el jugador codiciona con gameobjects con el tag vida se curara un valor determinado
		//el mainsalider.value esta abajo de todos para que se valla actualizando la barra de vida 
		if (other.CompareTag ("Enemy")) {
			vidaJugador -= daño;
			mainSlider.value = vidaJugador;
		} else if (other.CompareTag ("Vida") && vidaJugador < 1000) {
			vidaJugador += valorCura;
			mainSlider.value = vidaJugador;
		} else if (other.CompareTag ("Enemy2")) 
		{
			vidaJugador -= 200;
			mainSlider.value = vidaJugador;
		}
	}
		
	void Update()
	{
		// si la vida de el jugador esta por debajo o es igual a 0 se activan los boleanos iscanvasGameOver y isCamera ademas de esto se destruye el gameobject
		if (vidaJugador <= 0) 
		{
			isCanvasGameOver = true;
			iscamera = true;
			Destroy(gameObject);
		}
		//si iscanvasGameOver es positivo se activara el canvas de GameOver
		//si iscanvasGameOver es negativo el canvas estara desacrivado
		if (isCanvasGameOver == true) 
		{
			canvasGameOver.gameObject.SetActive (true);
		}
		if (isCanvasGameOver == false) 
		{
			canvasGameOver.gameObject.SetActive (false);
		}

		//si iscamera es positivo se activara la camara 
		//si iscamera es negativo la camara permanesera desactivada 
		if (iscamera == true) 
		{
			camaraGameOver.gameObject.SetActive (true);
		}
		if (iscamera == false) 
		{
			camaraGameOver.gameObject.SetActive (false);
		}
	}

}