using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip SaludActiva;
	public AudioClip VenenoActivo;

	AudioSource reproductorAudio;
	
	void Start()
	{
		reproductorAudio = GetComponent<AudioSource>();	
	}
	void Update()
	{

	}
	public void Active()
	{
		reproductorAudio.PlayOneShot(SaludActiva);
	  	Debug.Log("Activando el Audio");
	}
	

	
}
