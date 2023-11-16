using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(Rigidbody))]
public class ControlPelota : MonoBehaviour
{

    //La fuerza del tiro.
    public float fuerza_tiro = 100f;

    //La dirección del tiro en X.
    public float direccion_tiro_X = 0.17f;

    //La dirección del tiro en Y.
    public float direccion_tiro_Y = 0.60f;

    //El offset respecto a la cámara.
    public Vector3 offsetPelotaCamara = new Vector3 (0f, -1.4f, 3f);

    //El vector3 de la posición inicial.
    private Vector3 posicionInicial;

    //El vector3 de la dirección.
    private Vector3 direccion;

    //El tiempo de inicio del disparo.
    private float tiempoInicio;

    //El tiempo de término del disparo.
    private float tiempoTermino;

    //La duración del disparo.
    private float duracion;

    //Si ya se eligió una dirección.
    private bool direccionElegida = false;

    //Si ya se inició el tiro.
    private bool tiroIniciado = false;

    //El objeto AR Cámara (este objeto se busca en ejecución).

    [SerializeField]
    GameObject AR_Camera;

    //Componente XROrigin (se busca en ejecución).

    [SerializeField]
    
    XROrigin xrOrigin;

    //El Rigidbody de la pelota.
    Rigidbody rigidbody;

    public void Start(){

        //Se obtiene el componente Rigidbody.
        rigidbody = gameObject.GetComponent<Rigidbody>();

        //Se obtiene el componente del XROrigin, al buscar el gameObject XROrigin.
        xrOrigin = GameObject.Find("XR Origin").GetComponent<XROrigin>();

        //El transform del Camera Offset, objeto hijo del gameObject XROrigin.
        Transform cameraOffset = xrOrigin.transform.GetChild(0);

        //Se obtiene el AR Cámara, a partir de buscarlo con el transform del cameraOffset.
        AR_Camera = cameraOffset.Find("Main Camera").gameObject;

        //El padre del transform, es el transform del ARCamera.
        transform.parent = AR_Camera.transform;

        //Se reinicia la posición de la pelota.
        ReiniciarPelota();
    }

    public void Update(){
        
        //Al presionar, se obtiene la posición inicial y el tiempo de inicio.
        if(Input.GetMouseButtonDown(0)){
            posicionInicial = Input.mousePosition;
            tiempoInicio = Time.time;
            tiroIniciado = true;
            direccionElegida = false;
        }

        //Al soltar, se obtiene el tiempo de término, la duración y dirección del lanzamiento.
        else if(Input.GetMouseButtonUp(0)){
            tiempoTermino = Time.time;
            duracion = tiempoTermino - tiempoInicio;
            direccion = Input.mousePosition - posicionInicial;
            direccionElegida = true;
        }

        //Cuando ya se eligió la dirección, la pelota tiene masa y usa gravedad.
        //Se añade una fuerza, con respecto a la posición de la cámara, la fuerza de tiro, la duración,
        //la dirección de disparo, y la fuerza de disparo en X e Y.

        if(direccionElegida){
            rigidbody.mass = 1;
            rigidbody.useGravity = true;

            rigidbody.AddForce(AR_Camera.transform.forward * fuerza_tiro / duracion +
            AR_Camera.transform.up * direccion.y * direccion_tiro_Y + 
            AR_Camera.transform.right * direccion.x * direccion_tiro_X);

            //El tiempo de inicio y la dirección se reinician a 0, se reinicia la posición y dirección a un vector3 0,
            //y no se puede volver a lanzar hasta que se reinicie el contador de más abajo.
            tiempoInicio = 0.0f;
            duracion = 0.0f;

            posicionInicial = new Vector3(0,0,0);
            direccion = new Vector3(0,0,0);

            tiroIniciado = false;
            direccionElegida = false;
        }

        //Si ya pasaron entre 3 y 4 segundos desde que se terminó de lanzar, se reinicia la pelota.
        if(Time.time - tiempoTermino >= 3 && Time.time - tiempoTermino <= 4){
            ReiniciarPelota();
        }
    }

    public void ReiniciarPelota(){

        //Se reestablecen las propiedades del componente Rigidbody de la pelota, y el tiempo de término es 0.
        rigidbody.mass = 0;
        rigidbody.useGravity = false;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        tiempoTermino = 0.0f;

        //La posición de la pelota, pasa a ser con respecto a la cámara, pero con su offset incluido.
        Vector3 posicionPelota = AR_Camera.transform.position + AR_Camera.transform.forward * offsetPelotaCamara.z + AR_Camera.transform.up * offsetPelotaCamara.y;
        transform.position = posicionPelota;
    }
}
