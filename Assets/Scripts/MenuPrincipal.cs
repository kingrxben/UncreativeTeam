using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public void Salir()
    {
        PlayerPrefs.SetInt("SeleccionActualSkins",1);
        Debug.Log("Saliendo");
        Application.Quit();
    }
}
