using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargadorScene : MonoBehaviour {
	void Start () {
		
	}

    void Update()
    {
    }
		public void cargadorScene(string nombreEscena)
            {
            SceneManager . LoadScene(nombreEscena);
        }
   
}
