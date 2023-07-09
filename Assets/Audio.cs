using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSonido : MonoBehaviour
{
    public AudioSource audioSource;
    public bool estadoAudio;
    public bool pause_Final;

    private void Start() {
        audioSource=GetComponent<AudioSource>();
        estadoAudio=true;
    }

    

    public void EstadoAudio(){
        if(estadoAudio){
             audioSource.Pause();
             estadoAudio=false;
        }else{
            audioSource.Play();
            estadoAudio=true;
        }
    }

    public void Pause_Final(){
        if(pause_Final){
            Debug.Log("BUTTON -> Resume");        
            Time.timeScale = 1f;
            pause_Final = false;
        }else{
            Debug.Log("BUTTON -> Pause");       
            Time.timeScale = 0f;
            pause_Final = true;
        }
    }    
}
