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

    int material_jugador1;
    int material_jugador2;

    int cantidadTotalTiempo;
    int cantidadTotalVidas;

    // Start is called before the first frame update
    void Start()
    {
        cantidadJugadores = 1;
        modoDeJuego = 0;
        material_jugador1 = PlayerPrefs.GetInt("MaterialSkin1",0);
        material_jugador2 = PlayerPrefs.GetInt("MaterialSkin2",0);
        cantidadTotalTiempo = PlayerPrefs.GetInt("CantidadTotalTiempo",65);
        cantidadTotalVidas = PlayerPrefs.GetInt("CantidadTotalVidas",5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(){
        PlayerPrefs.SetInt("MaterialSkin1",material_jugador1);
        PlayerPrefs.SetInt("MaterialSkin2",material_jugador2);
        PlayerPrefs.SetInt("CantidadJugadores",cantidadJugadores);
        PlayerPrefs.SetInt("ModoDeJuego",modoDeJuego);
        PlayerPrefs.SetInt("JugadorActual",1);
        PlayerPrefs.SetInt("CantidadTotalVidas",cantidadTotalVidas);
        PlayerPrefs.SetInt("CantidadTotalTiempo",cantidadTotalTiempo);
        SceneManager.LoadScene("EscenaAR");
    }

    public void definirJugadores(int jugadores){
        cantidadJugadores = jugadores;
    }

    public void definirModo(int modo){
        modoDeJuego = modo;
    }

    public void definirMaterial(int skin){
        if(PlayerPrefs.GetInt("SeleccionActualSkins") != 2){
            material_jugador1 = skin;
        }else{
            material_jugador2 = skin;
        }
        Debug.Log("Selección actual de skin: " + PlayerPrefs.GetInt("SeleccionActualSkins") + " con la skin " + skin);
    }

    public void definirTiempo(int tiempo){
        cantidadTotalTiempo = tiempo;
    }

    public void definirVidas(int vidas){
        cantidadTotalVidas = vidas;
    }


}
