using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class PosicionarCesta : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instancia este prefab de la cesta en un plano, en la localización del toque.")]
    GameObject cestaPrefab;

    /// <summary>
    /// El prefab a instanciar al tocar.
    /// </summary>
    public GameObject cestaPuesta
    {
        get { return cestaPrefab; }
        set { cestaPrefab = value; }
    }

    /// <summary>
    /// El objeto instanciado como resultado en una intersección exitosa de un raycast con un plano.
    /// </summary>
    public GameObject cestaGenerada { get; private set; }

    [SerializeField]
    [Tooltip("Instancia este prefab de la pelota en frente de la cámara AR.")]
    GameObject pelotaPrefab;

    /// <summary>
    /// El prefab a instanciar al tocar.
    /// </summary>
    public GameObject pelotaPuesta
    {
        get { return pelotaPrefab; }
        set { pelotaPrefab = value; }
    }

    /// <summary>
    /// El objeto instanciado como resultado en una intersección exitosa de un raycast con un plano.
    /// </summary>
    public GameObject pelotaGenerada { get; private set; }

    /// <summary>
    /// Evento invocado cuando un objeto es posicionado en un plano. 
    /// </summary>
    public static event Action onPlacedObject;

    //Booleano que permite comprobar si la cesta ya está puesta.

    private bool laCestaEstaPuesta = false;

    //Manager de los Raycast, en realidad aumentada.
    ARRaycastManager m_RaycastManager;

    //Lista estática de golpes del Raycast.

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    [SerializeField] TextMeshProUGUI textoDeInicio;
    [SerializeField] TextMeshProUGUI textoRecomendacion;

    //Método Awake, al despertar. Se obtiene el componente ARRaycastManager.
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Start() {
        Debug.Log("Cantidad de jugadores: " + PlayerPrefs.GetInt("CantidadJugadores"));
        Debug.Log("Modo de juego:" + PlayerPrefs.GetInt("ModoDeJuego"));
        Debug.Log("Jugador actual: " + PlayerPrefs.GetInt("JugadorActual"));
    }

    void Update()
    {
        //Si la cesta ya está posicionada, se retorna.
        if(laCestaEstaPuesta)
            return;
    

        //Si hay un toque...
        if (Input.touchCount > 0)
        {

            //Se obtiene el toque.
            Touch touch = Input.GetTouch(0);

            //Si corresponde al inicio de un toque...
            if (touch.phase == TouchPhase.Began)
            {

                //Si alcanza a reconocer un plano con el raycast...
                if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {

                    //Se obtiene el pose del golpe.
                    Pose hitPose = s_Hits[0].pose;

                    ControladorPartidaScript controladorPartidaScript = GameObject.FindGameObjectWithTag("ControladorPartida").GetComponent<ControladorPartidaScript>();
                    controladorPartidaScript.aparecerPuntaje();

                    AudioPartidaScript audioPartidaScript = GameObject.FindGameObjectWithTag("ControladorMusicaYSonido").GetComponent<AudioPartidaScript>();
                    audioPartidaScript.reproducirMusica();

                    int ModoDeJuego = PlayerPrefs.GetInt("ModoDeJuego",0);

                    if(ModoDeJuego == 0){
                        controladorPartidaScript.aparecerTiempo();
                    }else if(ModoDeJuego == 1){
                        controladorPartidaScript.aparecerVidas();
                    }

                    //Se instancia la cesta, en la posición del golpe, y se rota a 0 con respecto a Vector3.up
                    cestaGenerada = Instantiate(cestaPrefab, hitPose.position, Quaternion.AngleAxis(0,Vector3.up));

                    Vector3 posicion = cestaGenerada.transform.position;
                    Vector3 camara = Camera.main.transform.position;
                    Vector3 direccion = camara - posicion;
                    
                    Vector3 rotacionObjetivoEuler = Quaternion.LookRotation(direccion).eulerAngles;
                    Vector3 eulerEscalado = Vector3.Scale(rotacionObjetivoEuler,cestaGenerada.transform.up.normalized);
                    
                    Quaternion rotacionObjetivo = Quaternion.Euler(eulerEscalado);
                    cestaGenerada.transform.rotation = cestaGenerada.transform.rotation * rotacionObjetivo;
                    cestaGenerada.transform.parent = transform.parent;
                    
                    //El padre del transform de la cesta, es el padre del transform del XR Session.
                    cestaGenerada.transform.parent = transform.parent;
                    
                    laCestaEstaPuesta = true;
                    textoDeInicio.text = "";
                    textoRecomendacion.text = "";
                    
                    //Se instancia la pelota.
                    pelotaGenerada = Instantiate(pelotaPrefab);

                    //Primero se obtiene el transform del Camara Offset, encontrando el gameObject Camara Offset.
                    Transform cameraOffset = m_RaycastManager.transform.Find("Camera Offset").gameObject.transform;

                    //Transform de la cámara principal, a partir del objeto hijo.
                    Transform mainCamera = cameraOffset.GetChild(0);
                    pelotaGenerada.transform.parent = mainCamera.transform;
                    
                    if (onPlacedObject != null)
                    {
                        onPlacedObject();
                    }
                }
            }
        }
    }
}