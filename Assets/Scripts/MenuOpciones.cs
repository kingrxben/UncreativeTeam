using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void cambiarVolumenGeneral(float volumen)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volumen) * 20);
    }

    public void cambiarVolumenMusica(float volumen){
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volumen) * 20);
    }

    public void cambiarVolumenSonido(float volumen){
        audioMixer.SetFloat("SoundVolume", Mathf.Log10(volumen) * 20);
    }
}
