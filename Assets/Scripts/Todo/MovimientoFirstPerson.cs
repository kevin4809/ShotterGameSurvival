using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MovimientoFirstPerson : MonoBehaviour 
{

    public Camera fpsCamera;
    public int MovientoVertical;
    public int MovimientoHorizontal;
    //variable tipo bool con la cual podremos activar y desactivar el puntero
    public bool cursor;

    float h; //donde se almazenara la informacion del movimiento horizontal
    float v; //donde se almazenara la informacion del movimiento vertical

	public int estamina;
    Slider sliderEstamina;
    float contador;

	public Vector3 posJugador;

	void Start()
	{
		sliderEstamina = GameObject.FindGameObjectWithTag ("SliderStamina").GetComponent<Slider> ();
	}
    void Update () 
	{ // aqui desactivamos el puntero


        if (cursor == false)
        {
            Cursor.visible = false;
        }


		h = MovimientoHorizontal * Input.GetAxis ("Mouse X");
        v = MovientoVertical * Input.GetAxis("Mouse Y");    //este se encarga del movimiento de la camara con el mouse
		if(Time.timeScale==1.0)
		{
			transform.Rotate (0, h, 0);
			fpsCamera.transform.Rotate(-v, 0, 0);

		}

		if (Input.GetKey (KeyCode.W)&&Time.timeScale==1.0)  //si el usuario preciona "w" el jugador se movera hacia delante 
		{
			transform.Translate (0, 0, 0.3f);
			if (Input.GetKey(KeyCode.LeftShift)&&Time.timeScale==1.0 && estamina >= 0) 
			{
				estamina -= 20;
				sliderEstamina.value = estamina;
				transform.Translate (0, 0, 0.5f);

			}else if (Input.GetKey (KeyCode.Space)&&Time.timeScale==1.0) //si el usuario preciona "Space" el jugador saltara
            {
				transform.Translate (0, 0.07f, 0);
			}
		} else if (Input.GetKey (KeyCode.S)&&Time.timeScale==1.0) //si el usuario preciona "S" el jugador se movera hacia atras
        {
			transform.Translate (0, 0, -0.3f);
			if(Input.GetKey (KeyCode.Space)&&Time.timeScale==1.0) //si el usuario preciona "Space" el jugador saltara
            {
				transform.Translate (0, 0.07f, 0);
			}
		}
		else if (Input.GetKey (KeyCode.A)&&Time.timeScale==1.0) //si el jugador preciona "A" el juagador se movera hacia la izquierda 
		{
			transform.Translate (-0.3f, 0, 0);
			if(Input.GetKey (KeyCode.Space)&&Time.timeScale==1.0) //si el usuario preciona "Space" el jugador saltara
            {
				transform.Translate (0, 0.07f, 0);
			}
		} else if (Input.GetKey (KeyCode.D)&&Time.timeScale==1.0) //si el usuario preciona "D" el jugador se movera hacia la derc
		{
			transform.Translate (0.3f, 0, 0);
			if(Input.GetKey (KeyCode.Space)&&Time.timeScale==1.0)  //si el usuario preciona "Space" el jugador saltara
            {
				transform.Translate (0, 0.07f, 0);
			}
		}else if(Input.GetKey (KeyCode.Space)&&Time.timeScale==1.0) //si el usuario preciona "Space" el jugador saltara
        {
			transform.Translate (0, 0.07f, 0);
		}  
	
		if (estamina <= 0) 
		{
			StartCoroutine (RestaurarEstamina ());
            contador = 0;
		}
   }
		
	IEnumerator RestaurarEstamina()
	{
		yield return new WaitForSeconds (5);
        RestaurarStamina();
        sliderEstamina.value = estamina;
	}

    void RestaurarStamina()
    {
        if (contador <= 40)
        {
            estamina += 100;
            sliderEstamina.value = estamina;
        }
        contador++;
    }
}
