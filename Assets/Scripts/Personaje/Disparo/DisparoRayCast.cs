using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisparoRayCast : MonoBehaviour
{
    public float daño = 10f; //Daño de la balas del arma
    public float rangoDisparo = 100f; // la distancia a la cual puede llegar la bal
    public ParticleSystem disparo; // sale una particula despues del disparo
    public GameObject efectoImpacto; // particula de cuando la bala imapcta con algo

    public float velocidadDeDisparo = 15f; //velocidad del disparp
    private float nextimetofire = 0f;//tiempo de disparo
    public Camera fpscam;//Camera
	//Relaod
	public int MaxAmno = 10;//Numero de balas que lleba el cargado 
	public int currentAmno;//municion actual del arma 
	public float reloadTime = 5f;//tiempo de se demora el personaje en recargar
	private bool isreloading = false;//esto sirbe ṕara comprobar si el arma esta recargando o no (para que el personaje no dispare mientras recarga)

	Animator anim;//animaciones

	public float numeroCargadores;  // numero de cargadores disponibles 

	AudioSource audioDisparo; //audio disparo 
	// contadore
    float i;
	float n;

	public Text textBalas = null; // text balas
	public Text textCargadores = null;  // text cargadores 


	void Start()
	{
		audioDisparo = GetComponent<AudioSource> ();// sound coje los componentes del AudioSource

		// si al iniciar el juego la municion es == -1 entonses se recargara el arma 
		if(currentAmno == -1)    
			currentAmno = MaxAmno;
		
		anim = GetComponent<Animator> ();//aqui se obtiene el aniamtor
		//contadores
        i = 1;
		n = 1;

		textBalas = GameObject.Find("NumeroBalas").GetComponent<Text>();// se busca el gameobject NumeroBalas y textBalas coje los componetes de Text
		textCargadores = GameObject.Find("NumeroCargadores").GetComponent<Text>(); // se busca el gameobject NumeroCargadores y textCargadores coje los componetes de Text

		//para que aparescan el numero de balas y cargadores al iniciar el juego en el canvas 
        textBalas.text = "" + currentAmno;
        textCargadores.text = "/" + numeroCargadores;
    }
	void Update ()
    {
		// si municon acutal es menor o igual a 0 y numero cargadores mallor o igual a 1 se ejucuta una couroutine 
		if (isreloading)
			return;
		if (currentAmno <= 0 && numeroCargadores >= 1)
            {
                StartCoroutine(Reload());
                return;
            }

		//si se preciona el boton del mause y el valor actual de la municion es mayor a 0 entonces se ejecuta Shoot()
		if (Input.GetButton("Fire1") && Time.time >= nextimetofire && currentAmno > 0)
        {
            nextimetofire = Time.time + 1f / velocidadDeDisparo;
            Shoot();
		
        }

		//para que se valla actualizando en numero de balas y cargadores en el canvas 
        textBalas.text = "" + currentAmno;
        textCargadores.text = "/" + numeroCargadores;

    }
		
	//couroutine en la cual se ejecuta la animaicon de recarga se espera sierto numero determinado de tiempo antes de poder volver a disparar 
	// currentamno toma el valor de maxAmno
	IEnumerator Reload ()
	{
		if (isreloading = true) {
			anim.Play ("Reload");
		} else
		{
		}isreloading = false;

        i = 1;
		n = 1;

        yield return new WaitForSeconds (reloadTime);
        NumeroBalas();
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
        anim.Play("Fire");
        audioDisparo.Play();
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
            numeroCargadores -= 1;
            i++;
        }
    }
}
