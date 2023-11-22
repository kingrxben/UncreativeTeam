using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorPartidaScript : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;
    int puntaje = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aparecerPuntaje(){
        textoPuntaje.text = "Puntaje: " + puntaje;
    }

    public void sumarPuntaje(int value){
        puntaje += value;
        textoPuntaje.text = "Puntaje: " + puntaje;
    }
}
