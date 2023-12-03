using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] Slider sliderMusica;
    [SerializeField] Slider sliderSonido;
    [SerializeField] Slider sliderGeneral;

    private void Start() {
        cargarVolumen();
    }

    public void cambiarVolumenGeneral()
    {
        float volumen = sliderGeneral.value;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volumen) * 20);
        PlayerPrefs.SetFloat("VolumenGeneral",volumen);
    }

    public void cambiarVolumenMusica(){
        float volumen = sliderMusica.value;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volumen) * 20);
        PlayerPrefs.SetFloat("VolumenMusica",volumen);
    }

    public void cambiarVolumenSonido(){
        float volumen = sliderSonido.value;
        audioMixer.SetFloat("SoundVolume", Mathf.Log10(volumen) * 20);
        PlayerPrefs.SetFloat("VolumenSonido",volumen);
    }

    public void cargarVolumen(){
        sliderMusica.value = PlayerPrefs.GetFloat("VolumenMusica",0.75f);
        sliderSonido.value = PlayerPrefs.GetFloat("VolumenSonido",0.75f);
        sliderGeneral.value = PlayerPrefs.GetFloat("VolumenGeneral",0.75f);

        cambiarVolumenGeneral();
        cambiarVolumenMusica();
        cambiarVolumenSonido();
    }



}
