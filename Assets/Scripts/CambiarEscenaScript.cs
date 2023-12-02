using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{

    //Por determinado, 1.
    int cantidadJugadores;

    //0: modo de juego por tiempo. 1: modo de juego por vidas.
    int modoDeJuego;

    int material;



    // Start is called before the first frame update
    void Start()
    {
        cantidadJugadores = 1;
        modoDeJuego = 0;
        material = PlayerPrefs.GetInt("MaterialSkin",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(){
        PlayerPrefs.SetInt("MaterialSkin",material);
        PlayerPrefs.SetInt("CantidadJugadores",cantidadJugadores);
        PlayerPrefs.SetInt("ModoDeJuego",modoDeJuego);
        PlayerPrefs.SetInt("JugadorActual",1);
        SceneManager.LoadScene("EscenaAR");
    }

    public void definirJugadores(int jugadores){
        cantidadJugadores = jugadores;
    }

    public void definirModo(int modo){
        modoDeJuego = modo;
    }

    public void definirMaterial(int skin){
        material = skin;
    }
}
