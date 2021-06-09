using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject reset_button;
    public GameObject start_button;
    public GameObject GameEndDisplay;
    public GameObject TebanMarker;
    public void reset(){
        StateManager.Reset();
    }
    public void Senko(){
        TebanMarker.transform.GetChild(0).gameObject.SetActive(true);  
        TebanMarker.transform.GetChild(1).gameObject.SetActive(false);  
    }
    public void Koko(){
        TebanMarker.transform.GetChild(0).gameObject.SetActive(false);  
        TebanMarker.transform.GetChild(1).gameObject.SetActive(true);  
    }
    public void reset_button_set(bool b){
        reset_button.SetActive(b);
    }
    public void StartGame(){
        start_button.SetActive(false);        
        StateManager.play = true;
        TebanMarker.SetActive(true);  
        Senko();    
    }
    public void RestartGame(){
        // GameEndDisplay.SetActive(false);        
        StateManager.ResetAll();
        // TebanMarker.SetActive(true); 
        // StateManager.play = true;
    }
    public void EndGame(){
        GameEndDisplay.SetActive(true);  
        TebanMarker.SetActive(false); 
        if(StateManager.GetState_teban()) GameEndDisplay.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        else  GameEndDisplay.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
    }
    
}
