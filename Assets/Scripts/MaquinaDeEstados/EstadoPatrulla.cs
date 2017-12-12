using UnityEngine;
using System.Collections;

public class EstadoPatrulla : MonoBehaviour {

    public Transform[] WayPoints;
    public Color ColorEstado = Color.green;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private int siguienteWayPoint;

	public Animator anim; //animaciones

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>(); // ingresa al script de maquina de estado el cual se encarga de de activar y desactivar los scripts de persecucion petrulla alerta
        controladorNavMesh = GetComponent<ControladorNavMesh>(); // ingresa al navmesh
        controladorVision = GetComponent<ControladorVision>(); // ingresa a nuestro scripts de controlador vision
		anim = GetComponent<Animator> (); //coje los componentes del aniamtor
    }
	
	// Update is called once per frame
	void Update () {
        //Aqui el ennemigo va a comprobar si puede ver al enemigo
        RaycastHit hit;
        if(controladorVision.PuedeVerAlJugador(out hit))
        {
            controladorNavMesh.perseguirObjectivo = hit.transform; 
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion); // aqui se activa el estado persecucion
            return;
        }
		// aqui se comprueba si el jugador a llegado a su destino 
        if (controladorNavMesh.HemosLlegado())
        {
			anim.Play ("Caminar");
            siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
            ActualizarWayPointDestino();
			anim.Play ("Caminar");
        }
	}

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
        ActualizarWayPointDestino();
    }

    void ActualizarWayPointDestino()
    {
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(WayPoints[siguienteWayPoint].position); // cuando el enemigo haiga llegado a el punto de destino seguira al siguiente 
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled) // cuando el jugador entre en el collider del enemigo se colocar en estado alerta en el cual el personaje jirara alrededor 
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
        }
    }
}
