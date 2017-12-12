using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAmmo : MonoBehaviour 
{
	public MeshRenderer meshrender; // mesh render del gameobject
	public BoxCollider colliderBox; // box collider del gameobject 

	void OnTriggerEnter(Collider other)
	{
		//si el gameobject codiciona con el gameobject con el tag player se desactivara el meshrender y el collider ademas de esto se ejecutara una coroutina
		if (other.CompareTag ("Player")) 
		{
			meshrender.enabled = false;
			colliderBox.enabled = false;
			StartCoroutine(Spawn());
		}
	}

	IEnumerator Spawn()
	{
		//despues de que pasen 60 segundos el meshrender y el boxcillider se volveran a activar
		yield return new WaitForSeconds (60);
		meshrender.enabled = true;
		colliderBox.enabled = true;
	}
}
