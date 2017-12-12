using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBalasArmas : MonoBehaviour 
{

	public Canvas canvasRifleDeAsalto;
	bool canvasRifle;

	public Canvas canvasPistola;
	bool canvaspistola;

	SelecionArma selecionarArma;

	void Start()
	{
		canvasRifleDeAsalto = GameObject.FindGameObjectWithTag ("CanvasRifle").GetComponent<Canvas> ();
		canvasPistola = GameObject.FindGameObjectWithTag ("CanvasPistola").GetComponent<Canvas> ();
		selecionarArma = GetComponent<SelecionArma> ();
	}

	void Update()
	{
		if (selecionarArma.selectedWeapon == 0) 
		{
			canvasRifle = true;
			canvaspistola = false;
		}
		if (selecionarArma.selectedWeapon == 1) 
		{
			canvaspistola = true;
			canvasRifle = false;
		}

		if (canvasRifle == true) {
			canvasRifleDeAsalto.gameObject.SetActive (true);
		} else 
		{
			canvasRifleDeAsalto.gameObject.SetActive (false);
		}
		if (canvaspistola == true) {
			canvasPistola.gameObject.SetActive (true);
		} else 
		{
			canvasPistola.gameObject.SetActive(false);
		}
	}
		

}
