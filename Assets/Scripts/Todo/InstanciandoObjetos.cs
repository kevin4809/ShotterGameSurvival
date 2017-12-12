using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciandoObjetos : MonoBehaviour
{




    public Transform prefab;
    public Rigidbody proyectile;
    public int velocidadProyectil;
    public Transform ignorarDos;
    public Transform personaje;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1.0F)
        {

            Rigidbody clone;
			clone = Instantiate(proyectile, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(new Vector3(0,0,1)* velocidadProyectil);
            Physics.IgnoreCollision(clone.GetComponent<Collider>(), GetComponent<Collider>());
            
            
        }


    }



  

}
