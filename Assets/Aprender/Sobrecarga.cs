using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobrecarga : MonoBehaviour 
{

	public int suma(int numeroUno, int numeroDos)
	{
		return numeroUno + numeroDos;
	}

	public string suma(string letraUno, string letraDos)
	{
		return letraUno + letraDos;
	}
}
