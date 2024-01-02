using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScriptImagenesResultados : MonoBehaviour
{
    public GameObject imagenJugador1Solo;
    public GameObject imagenJugador1Con2;
    public GameObject imagenJugador2;
    public Sprite[] images;

    int cantidadDeJugadores;
    int skinJugador1;
    int skinJugador2;    


    // Start is called before the first frame update
    void Start()
    {
        skinJugador1 = PlayerPrefs.GetInt("MaterialSkin1",0);
        skinJugador2 = PlayerPrefs.GetInt("MaterialSkin2",0);
        cantidadDeJugadores = PlayerPrefs.GetInt("CantidadJugadores",1);
        if(cantidadDeJugadores == 1){

            if(skinJugador1 != 0){
                Image imagenJugador1 = imagenJugador1Solo.GetComponent<Image>();
                imagenJugador1.sprite = images[skinJugador1];

                if(skinJugador1 == 8){
                    imagenJugador1.color = new Color(255,32,255);
                }else if(skinJugador1 == 9){
                    imagenJugador1.color = new Color(255,15,0,255);
                }else if(skinJugador1 == 10){
                    imagenJugador1.color = new Color(255,111,0,255);
                }else if(skinJugador1 == 15){
                    imagenJugador1.color = new Color(92,255,0,255);
                }else if(skinJugador1 == 16){
                    imagenJugador1.color = new Color(255,104,185,255);
                }

            }else{
                Image imagenJugador1 = imagenJugador1Solo.GetComponent<Image>();
                Color color = new Color(255,88,0);
                imagenJugador1.color = color;
            }
            imagenJugador1Solo.SetActive(true);

        }else{

            if(skinJugador1 != 0){
                Image imagen1 = imagenJugador1Con2.GetComponent<Image>();
                imagen1.sprite = images[skinJugador1];

                if(skinJugador1 == 8){
                    imagen1.color = new Color(255,32,255);
                }else if(skinJugador1 == 9){
                    imagen1.color = new Color(255,15,0,255);
                }else if(skinJugador1 == 10){
                    imagen1.color = new Color(255,111,0,255);
                }else if(skinJugador1 == 15){
                    imagen1.color = new Color(92,255,0,255);
                }else if(skinJugador1 == 16){
                    imagen1.color = new Color(255,104,185,255);
                }

            }else{
                Image imagenJugador1 = imagenJugador1Con2.GetComponent<Image>();
                Color color = new Color(255,88,0);
                imagenJugador1.color = color;
            }


            if(skinJugador2 != 0){
                Image imagen2 = imagenJugador2.GetComponent<Image>();
                imagen2.sprite = images[skinJugador2];

                if(skinJugador2 == 8){
                    imagen2.color = new Color(255,32,255);
                }else if(skinJugador2 == 9){
                    imagen2.color = new Color(255,15,0,255);
                }else if(skinJugador2 == 10){
                    imagen2.color = new Color(255,111,0,255);
                }else if(skinJugador2 == 15){
                    imagen2.color = new Color(92,255,0,255);
                }else if(skinJugador2 == 16){
                    imagen2.color = new Color(255,104,185,255);
                }
                
            }else{
                Image imagen2 = imagenJugador2.GetComponent<Image>();
                Color color = new Color(255,88,0);
                imagen2.color = color;
            }

            imagenJugador1Con2.SetActive(true);
            imagenJugador2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
