using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScriptResultados : MonoBehaviour
{

    [SerializeField] AudioSource sfx_source;
    [SerializeField] AudioSource music_source;

    int puntaje_1;
    int puntaje_2;

    int cantidadDeJugadores;

    public TextMeshProUGUI textoJugador1Solo;
    public TextMeshProUGUI textoJugador1Con2Jugadores;
    public TextMeshProUGUI textoJugador2;

    public TextMeshProUGUI textoGanador1;
    public TextMeshProUGUI textoGanador2;
    public TextMeshProUGUI textoEmpate;
    public GameObject coronaGanadora1;
    public GameObject coronaGanadora2;

    // Start is called before the first frame update
    void Start()
    {
        puntaje_1 = PlayerPrefs.GetInt("Puntaje1",0);
        puntaje_2 = PlayerPrefs.GetInt("Puntaje2",0);
        cantidadDeJugadores = PlayerPrefs.GetInt("CantidadJugadores",1);
        sfx_source.Play();
        music_source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(cantidadDeJugadores == 1){
            textoJugador1Solo.text = "Jugador 1: " + puntaje_1;
        }else if(cantidadDeJugadores == 2){
            if(puntaje_1 > puntaje_2){
                textoJugador1Con2Jugadores.text = "Jugador 1: " + puntaje_1;
                textoJugador2.text = "Jugador 2: " + puntaje_2;
                textoGanador1.text = "¡Ganador!";
                coronaGanadora1.SetActive(true);

            }else if(puntaje_2 > puntaje_1){
                textoJugador1Con2Jugadores.text = "Jugador 1: " + puntaje_1;
                textoJugador2.text = "Jugador 2: " + puntaje_2;
                textoGanador2.text = "¡Ganador!";
                coronaGanadora2.SetActive(true);
            }else if(puntaje_1 == puntaje_2){
                textoJugador1Con2Jugadores.text = "Jugador 1: " + puntaje_1;
                textoJugador2.text = "Jugador 2: " + puntaje_2;
                textoEmpate.text = "¡Empate!";
            }
        }
    }

    public void volverAlMenu(){
        Debug.Log("Apreté el botón");
        SceneManager.LoadScene("Menu Principal");
    }


}
