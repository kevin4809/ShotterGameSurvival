using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//traer librerias

public class EnemyAndHeal : MonoBehaviour
{


    public int TotalSalud = 1000;
    public Slider mainSlider;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Heal"))
        {
            TotalSalud += 100;
            Debug.Log("Total salud: " + TotalSalud);
            mainSlider.value = TotalSalud;
        }
        else
        if (other.CompareTag("Enemy"))
        {
            TotalSalud -= 100;
                Debug.Log("Total salud: " + TotalSalud);
            mainSlider.value = TotalSalud;

        }
        if (TotalSalud == 0)
            {
            gameObject.SetActive(false);
        }

    }
}

    
