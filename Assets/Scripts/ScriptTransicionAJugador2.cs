using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptTransicionAJugador2 : MonoBehaviour
{

    int tiempoTransicion = 5;
    float tiempoTransicionFloat = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoTransicion > 0){
            tiempoTransicionFloat -= Time.deltaTime;
            tiempoTransicion = Mathf.CeilToInt(tiempoTransicionFloat);
        }else{
            SceneManager.LoadScene("EscenaAR");
        }
    }
}
