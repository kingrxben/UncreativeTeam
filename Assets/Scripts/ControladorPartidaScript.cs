using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorPartidaScript : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoTiempo;

    int tiempo = 80;
    float tiempo_float = 80.0f;

    bool partida_inicio = false;

    int puntaje = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (partida_inicio)
        {
            tiempo_float -= Time.deltaTime;
            tiempo = Mathf.CeilToInt(tiempo_float);
            conteoAtras();
            aparecerPuntaje();
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
        textoTiempo.text = tiempo.ToString();
        partida_inicio = true;
    }

    public void conteoAtras()
    {
        textoTiempo.text = tiempo.ToString();
    }

}
