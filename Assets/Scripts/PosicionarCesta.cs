using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

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

    //Método Awake, al despertar. Se obtiene el componente ARRaycastManager.
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
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

                    //Se instancia la cesta, en la posición del golpe, y se rota a 180 con respecto a Vector3.up
                    cestaGenerada = Instantiate(cestaPrefab, hitPose.position, Quaternion.AngleAxis(180,Vector3.up));
                    
                    //El padre del transform de la cesta, es el padre del transform del XR Session.
                    cestaGenerada.transform.parent = transform.parent;
                    
                    laCestaEstaPuesta = true;
                    
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