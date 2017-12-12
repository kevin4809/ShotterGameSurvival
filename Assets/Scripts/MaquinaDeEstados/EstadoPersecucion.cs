using UnityEngine;
using System.Collections;

public class EstadoPersecucion : MonoBehaviour {

    public Color ColorEstado = Color.red;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

	public Animator anim;

	void Awake () 
	{
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
		anim = GetComponent <Animator> ();
	}

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
    }
	
	void Update () {
        RaycastHit hit;
        if(!controladorVision.PuedeVerAlJugador(out hit, true))
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
		
            return;
        }
		anim.Play ("Correr");
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();    
	}
}
