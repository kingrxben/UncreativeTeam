using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptResultados : MonoBehaviour
{

    [SerializeField] AudioSource sfx_source;
    [SerializeField] AudioSource music_source;

    // Start is called before the first frame update
    void Start()
    {
        sfx_source.Play();
        music_source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void volverAlMenu(){
        Debug.Log("Apreté el botón");
        SceneManager.LoadScene("Menu Principal");
    }


}
