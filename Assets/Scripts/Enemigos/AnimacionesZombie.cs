using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesZombie : MonoBehaviour 
{
	//animator
	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();// se coje el componente del animator
		anim.Play("isrunig");
	}
		
	void OnTriggerEnter (Collider other) //si el gameobject codision el el tag player
	{
		if (other.CompareTag ("Player")) { //se ejecutara la animacion de atacar
			anim.Play ("isattack");
		} else {
		}anim.Play ("isrunig");
	
	}

}