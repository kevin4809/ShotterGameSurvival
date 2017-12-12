using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoPistola : MonoBehaviour {

	public float daño = 10f; // daño del arma
	public float rangoDisparo = 100f; // rango del disparo
	public ParticleSystem disparo; // particula que sale despues de aver disparado 
	public GameObject efectoImpacto; //efecto de impacto de la bala 
	public float velocidadDeDisparo = 15f; // velosidad del disparo
	private float nextimetofire = 0f; //tiempo de desparo
	public Camera fpscam; // camara del personaje 

	public int MaxAmno = 10; // maxima nunicion antes de recargar
	private int currentAmno; // municion actual 
	public float reloadTime = 5f; // tiempo de recarga del arma
	private bool isreloading = false; // bool para saber si esta recargando o no 

	public Animator anim; // animaciones arma

    AudioSource sound; //audio disparo 

    public float numeroCargadores2; // numero de cargadores disponibles 

    float i;
	float n;

    public Text textBalas = null; // text balas
    public Text textCargadores = null; // text cargadores 


    void Start()
	{
        sound = GetComponent<AudioSource>(); // sound coje los componentes del AudioSource

		// si al iniciar el juego la municion es == -1 entonses se recargara el arma 
		if(currentAmno == -1)     
			currentAmno = MaxAmno;
		
		anim = GetComponent<Animator> (); // anim coje los componentes de Animator

        textBalas = GameObject.Find("NumeroBalasP").GetComponent<Text>(); // se busca el gameobject NumeroBalasp y textBalas coje los componetes de Text
		textCargadores = GameObject.Find("NumeroCargadoresP").GetComponent<Text>(); // se busca el gameobject NumeroCargadoresP y textCargadores coje los componetes de Text

		//contadores 
        i = 1;
		n = 1;
		//para que aparescan el numero de balas y cargadores al iniciar el juego en el canvas 
        textBalas.text = "" + currentAmno;
        textCargadores.text = "/" + numeroCargadores2;

    }
    void Update ()
	{
		// si municon acutal es menor o igual a 0 y numero cargadores mallor o igual a 1 se ejucuta una couroutine 
		if (isreloading)
			return;
		if (currentAmno <= 0 && numeroCargadores2 >= 1) 
		{
			StartCoroutine (Reload());
			return;
		}

		//si se preciona el boton del mause y el valor actual de la municion es mayor a 0 entonces se ejecuta Shoot()
		if (Input.GetButtonDown("Fire1") && Time.time >= nextimetofire && currentAmno > 0)
		{
			nextimetofire = Time.time + 1f / velocidadDeDisparo;
			Shoot();
            
		}

		//para que se valla actualizando en numero de balas y cargadores en el canvas 
        textBalas.text = "" + currentAmno;
        textCargadores.text = "/" + numeroCargadores2;

    }

	//couroutine en la cual se ejecuta la animaicon de recarga se espera sierto numero determinado de tiempo antes de poder volver a disparar 
	// currentamno toma el valor de maxAmno
    IEnumerator Reload ()
	{
		if (isreloading = true) {
			anim.Play ("Reload");
		} else {
		} isreloading = false;
        i = 1;
		n = 1;
		yield return new WaitForSeconds (reloadTime);
		NumeroBalas ();
		if (n == 1) 
		{
			currentAmno = MaxAmno;
			n++;
		}

	} 
	// se ejecuta animacion y sonido de disparo la currentAmno baja 
	// se dispara un raycast al centro de la camara si este tiene inpacto con el enemigo se le ara daño y se instanciara una particula 
	void Shoot()
	{
        sound.Play();
        anim.Play("Fire");
        currentAmno--;
		disparo.Play();
		RaycastHit hit;
		if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward,  out hit, rangoDisparo))
		{
			DestroyEnemy destroyEnemy = hit.transform.GetComponent<DestroyEnemy>();
			if (destroyEnemy != null)
			{
				destroyEnemy.TakeDamage(daño);
			}
			GameObject impacGo = Instantiate(efectoImpacto, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impacGo, 2f);
		}

	}

	// si i es igual a 1 el numero de cargadores bajara y se activara un contador 
    void NumeroBalas()
    {
        if (i == 1)
        {
            numeroCargadores2 -= 1;
            i++;
        }
    }
}
