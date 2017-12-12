using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionArma : MonoBehaviour 
{
	public int selectedWeapon = 0;

	void Start () 
	{
		SelectWeapon ();
	}

	void Update () 
	{
		int previosuSelectedWeapon = selectedWeapon;

		if (Input.GetAxis ("Mouse ScrollWheel") > 0f) 
		{
			if (selectedWeapon >= transform.childCount - 1)
				selectedWeapon = 0;
			else
				selectedWeapon++;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0f) 
		{
			if (selectedWeapon <= 0)
				selectedWeapon = transform.childCount - 1;
			else
				selectedWeapon--;
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedWeapon = 0;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			selectedWeapon = 1;
		}
		if (previosuSelectedWeapon != selectedWeapon) 
		{
			SelectWeapon ();
		}
	}
	void SelectWeapon()
	{
		int i = 0;
		foreach (Transform Weapon in transform)
		{
			if (i == selectedWeapon) 
			{
				Weapon.gameObject.SetActive (true);
			} else 
			{
				Weapon.gameObject.SetActive (false);
			}
			i++;
		}
	}
}
