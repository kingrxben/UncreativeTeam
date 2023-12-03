using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Unity.VisualScripting.FullSerializer;

public class ControladorPartidaScript : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoVidas;

    int tiempoInt = 60;
    float tiempo_float = 60.0f;
    int cantidadVidas = 5;
    int modoDeJuego = 0;
    int jugadorActual;
    int cantidadDeJugadores;
    bool partida_inicio = false;
    int puntaje = 0;

    // Start is called before the first frame update
    void Start()
    {
        modoDeJuego = PlayerPrefs.GetInt("ModoDeJuego",0);
        jugadorActual = PlayerPrefs.GetInt("JugadorActual",1);
        cantidadDeJugadores = PlayerPrefs.GetInt("CantidadJugadores",1);
    }

    // Update is called once per frame
    void Update()
    {
        if (partida_inicio){
            if(modoDeJuego == 0){
                if(tiempoInt <= 10){
                    pocoTiempo();
                }

                if(tiempoInt == 0){
                    guardarDatos();
                }
                tiempo_float -= Time.deltaTime;
                tiempoInt = Mathf.CeilToInt(tiempo_float);
                conteoAtras();
            }else if(modoDeJuego == 1){
                if(cantidadVidas <= 2){
                    pocasVidas();
                }

                if(cantidadVidas == 0){
                    guardarDatos();
                }
                mostrarVidas();
            }
        }
    }

    public void guardarDatos(){
        if(cantidadDeJugadores == 1){
            PlayerPrefs.SetInt("Puntaje1",puntaje);
            SceneManager.LoadScene("EscenaResultados");
        
        }else if(cantidadDeJugadores == 2){
            if(jugadorActual == 1){
                PlayerPrefs.SetInt("Puntaje1",puntaje);
                PlayerPrefs.SetInt("JugadorActual",2);
                SceneManager.LoadScene("EscenaDeTransicion");
            }else if(jugadorActual == 2){
                PlayerPrefs.SetInt("Puntaje2",puntaje);
                SceneManager.LoadScene("EscenaResultados");
            }
        }
    }

    public void aparecerPuntaje(){
        textoPuntaje.text = "Puntaje: " + puntaje;
    }

    public void sumarPuntaje(int value){
        puntaje += value;
        textoPuntaje.text = "Puntaje: " + puntaje;
    }

    public void aparecerTiempo()
    {
        textoTiempo.text = tiempoInt.ToString();
        partida_inicio = true;
    }

    public void conteoAtras()
    {
        textoTiempo.text = tiempoInt.ToString();
    }

    public void aparecerVidas(){
        textoVidas.text = cantidadVidas.ToString();
        partida_inicio = true;
    }

    public void restarVidas(int vidaMenos){
        cantidadVidas -= vidaMenos;
        textoVidas.text = cantidadVidas.ToString();
    }

    public void mostrarVidas(){
        textoVidas.text = cantidadVidas.ToString();
    }

    public void pocoTiempo(){
        textoTiempo.color = Color.red;
    }

    public void pocasVidas(){
        textoVidas.color = Color.red;
    }
}
