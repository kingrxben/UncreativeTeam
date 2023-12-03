using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptControladorSkins : MonoBehaviour
{
    int jugadorActualSkins;
    public TextMeshProUGUI textoSkins;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        jugadorActualSkins = PlayerPrefs.GetInt("SeleccionActualSkins",1);

        if(jugadorActualSkins == 1){
            textoSkins.text = "Elige la skin para el jugador 1";
        }else if(jugadorActualSkins == 2){
            textoSkins.text = "Elige la skin para el jugador 2";
        }
    }
    
    public void guardarJugadorActualSkin(){
        if(jugadorActualSkins == 1){
            jugadorActualSkins = 2;
            PlayerPrefs.SetInt("SeleccionActualSkins",jugadorActualSkins);
        }else if(jugadorActualSkins == 2){
            jugadorActualSkins = 1;
            PlayerPrefs.SetInt("SeleccionActualSkins",jugadorActualSkins);
        }
    }
}
