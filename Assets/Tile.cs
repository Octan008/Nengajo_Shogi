using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int state = 0;
    int x;
    int y;

    public int GetState(){
        return state;
    }
    public void Setpos(int _x, int _y){
        x = _x; y = _y;
    }




    public void change_color(){//緑       
        if(StateManager.GetState_check() == 0){
            GetComponent<Renderer>().material.color =  new Color(0.0f,0.8f,0f,0.5f);
        }        
    }
    public void change_color2(Color c){//黄色?
        if(StateManager.GetState_check() == 0){
            Debug.Log("change2");
            GetComponent<Renderer>().material.color =  c;
            state = 1;
            // StateManager.NextState();  
        }      
    }
    public void SetTarget(){
        if(StateManager.GetState_check() == 1 && state == 1){
            GetComponent<Renderer>().material.color =  new Color(0.0f,0.8f,0f,0.5f);
            state = 0;
            int target = StateManager.SelectedKoma;
            if(target > -1){
                Debug.Log(this.transform.parent.GetChild(0).name);
                if(StateManager.map[x,y] == 0){
                    this.transform.parent.GetChild(0).GetChild(target).GetComponent<Koma>().move(x, y);
                    StateManager.NextTeban();
                }
                else{
                    int tile = y + x * 4;
                    this.transform.parent.GetChild(0).GetChild(StateManager.id_map[x,y]).GetComponent<Koma>().move_away();
                    StateManager.NextTeban();
                    this.transform.parent.GetChild(0).GetChild(target).GetComponent<Koma>().move(x, y);
                }
                
                
            }
            
        }     
    }
    public void Reset(){
        state = 0;
        GetComponent<Renderer>().material.color =  new Color(0f,0f,1f,0.0f);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
