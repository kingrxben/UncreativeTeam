using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptTransicionAJugador2 : MonoBehaviour
{

    int tiempoTransicion = 5;
    float tiempoTransicionFloat = 5.0f;
    int modoDeJuego;

    public TextMeshProUGUI textoVidas;
    public TextMeshProUGUI textotiempo;
    public GameObject imagenCorazonRoto;
    public GameObject imagenReloj;

    // Start is called before the first frame update
    void Start()
    {
        modoDeJuego = PlayerPrefs.GetInt("ModoDeJuego",0);
        if(modoDeJuego == 0){
            imagenReloj.SetActive(true);
        }else{
            imagenCorazonRoto.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(modoDeJuego == 0){
            textotiempo.text = "¡Se acabo el tiempo para el jugador 1!";
        }else if(modoDeJuego == 1){
            textoVidas.text = "¡Se acabaron las vidas para el jugador 1!";
        }

        if(tiempoTransicion > 0){
            tiempoTransicionFloat -= Time.deltaTime;
            tiempoTransicion = Mathf.CeilToInt(tiempoTransicionFloat);
        }else{
            SceneManager.LoadScene("EscenaAR");
        }
    }
}
