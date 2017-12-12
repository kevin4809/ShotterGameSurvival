using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour 
{

    public float vida = 50f; // vida del enemigo
	//animaciones
	private Animator anim; // variable para las animaciones
	//controlador navmesh
	public NavMeshAgent enemigo; // navmesh del enemigo
	public AnimacionesZombie animZombie; //variable apra acceder a otro scrip
	//score
	public Score newScore; // // script Score
	public int valorScore; // el socore que va a dar el enemigo despues de ser assesinado :D
	//collider
	public Collider zombieColiider; 

	public EnemyManager spawtime; // spaw de enemigos

	public int contador = 0;

	void Start()
	{
		spawtime = GameObject.Find("EnemyManager").GetComponent <EnemyManager> (); // accedemos al scrip de EnemyManager para cambiar el tiempo de spaw
		anim = GetComponent<Animator> (); //cojemos el componente de animator para acer todo lo de animaciones
		animZombie = GetComponent<AnimacionesZombie> ();//accedemos al scrip AnimacionesZombi para activar algunas animaciones del enemygo
		newScore = GameObject.Find("ScoreManager").GetComponent<Score> ();//buscamos el gameobject scrip y luego cojemos su componente 
		zombieColiider = GetComponent<Collider> (); // la variable zombiecollider acede al collider del enemigo
	}
    
    public void TakeDamage ( float amount)
    {
		anim.Play ("damage");    //ejecuta animacion de daño 
        vida -= amount;          // esto es lo q se encarga de controlar la vida del enemigo
            if (vida <= 0f)      //aqui comprobamos si el enemigo tiene menos del 0% de la vida
        {
            die();//se ejecutara died 
			zombieColiider.enabled = false;//cuando el zombie muera se desactivara su collider 
			newScore.AddScore (valorScore);//se sumara determinado numero de puntos al score 
        }
			
    }
		
    void die()
	{
		contador += 1;
		enemigo.speed = 0; //cuando el enemigo muere su velocidad se reduce a 0
		anim.Play ("isDead"); // ejecuta la animacion de muerte
        Destroy(gameObject,2.3f);// se destruye el gameobject despues de determinado numero de segundos
    }

		

}
