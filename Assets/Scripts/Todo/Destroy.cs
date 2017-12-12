using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public int vida = 100;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Balas"))
        {
            vida -= 50;

        }
        if (vida == 0)
        {
            Destroy(gameObject);
        }



    }
}
