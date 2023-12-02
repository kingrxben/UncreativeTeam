using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioPartidaScript : MonoBehaviour
{
    [Header ("------------Audio Source-----------")]
    [SerializeField] AudioSource musicaSource;
    [SerializeField] AudioSource SFXSource;

    [Header ("------------ Sonidos -----------")]

    [SerializeField] AudioClip lanzamientoPelota;
    [SerializeField] AudioClip colisionPelota;
    [SerializeField] AudioClip encestarPelota;
    [SerializeField] AudioClip fallo_perderVida;

    [Header ("------------Arreglo de canciones-----------")]
    [SerializeField]AudioClip[] arregloCanciones;

    int cancionDelArreglo;

    // Start is called before the first frame update
    void Start()
    {
        cancionDelArreglo = Random.Range(0,arregloCanciones.Length);
        musicaSource.clip = arregloCanciones[cancionDelArreglo];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducirColision(){
        SFXSource.PlayOneShot(colisionPelota);
    }

    public void reproducirLanzamiento(){
        SFXSource.PlayOneShot(lanzamientoPelota);
    }

    public void reproducirPunto(){
        SFXSource.PlayOneShot(encestarPelota);
    }

    public void reproducirMusica(){
        musicaSource.Play();
    }

    public void reproducirPerderVida(){
        SFXSource.PlayOneShot(fallo_perderVida);
    }


}
