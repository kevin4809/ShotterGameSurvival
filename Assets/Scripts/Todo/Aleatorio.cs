using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aleatorio : MonoBehaviour
{
    float Nextime = 0;
    int Counter = 10;
    public int Timer;

    public float HorizontalSpacing = 2f;
    public float VerticalSpacing = 1f;
	// Use this for initialization
	void Start () {

		Debug.Log ("Hola SMith");

		
	}
	
	// Update is called once per frame
	void Update () {
		if(Counter > 0 && Time.fixedTime > Nextime)
        {
            Nextime = Time.fixedTime + Timer;
            for (int j = 10; j > 0; j--)
            {
                int randomNumer = Random.Range(1, 10);
                for (int i = 0; i < randomNumer; i++)
                {
                    GameObject box =
                         GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = new Vector3(Counter*HorizontalSpacing,
                    i * VerticalSpacing, j * HorizontalSpacing);
                       
                }
            }
            Counter--;
        }
	}
}
